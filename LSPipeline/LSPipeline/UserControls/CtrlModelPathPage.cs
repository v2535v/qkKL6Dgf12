using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using GeoScene.Globe;
using GeoScene.Data;
namespace WorldGIS
{
    public partial class CtrlModelPathPage : UserControl
    {
        public GSOGlobeControl m_GlobeControl = null;
        public GSOFeature m_Feature= null;
        // 空间信息的窗体要要更新
        public CtrlEntitySpaceInfo m_SpaceCtrl=null;

        public CtrlModelPathPage(GSOFeature feature, GSOGlobeControl globeControl)
        {
            InitializeComponent();
            m_GlobeControl = globeControl;
            m_Feature = feature;
        }

        private void buttonModelPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "支持格式(*.gcm;*.3ds;*.obj;*.3d)|*.gcm;*.3ds;*.obj;*.3d|*.gcm|*.gcm|*.3ds|*.3ds|*.obj|*.obj|*.3d|*.3d||";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                textBoxModelPath.Text = dlg.FileName;
                updateModelPath(dlg.FileName);
            }            
        }
        private void textBoxModelPath_TextChanged(object sender, EventArgs e)
        {
            updateModelPath(textBoxModelPath.Text);
        }

        //修改模型路径
        private void updateModelPath(string modelPath)
        {
            if (m_Feature == null)
            {
                return;
            }
            GSOGeoModel geoOldModel = m_Feature.Geometry as GSOGeoModel;
            GSOGeoModel geoModel = new GSOGeoModel();
            geoModel.FilePath = modelPath;

            String strFilePath = modelPath;
            string strFileExt = Path.GetExtension(strFilePath);
            string strFileName = Path.GetFileName(strFilePath);
            int nIndex = strFileName.LastIndexOf('.');
            string strTitle = strFileName.Substring(0, nIndex);

            // 采用立即加载的模式，而非异步加载,这样能很快看到预览效果
            geoModel.IsAsynLoaded = false;
            if (geoOldModel != null)
            {
                geoModel.Align = geoOldModel.Align;
            }
            // gcm含有坐标信息，需要单独处理一下
            if (strFileExt == ".gcm") // 如果是gcm需要提前加载坐标信息
            {
                //geoModel.LoadGCMCoordInfo();
                // 下面这个表示GCM中是否存在投影坐标,即X、Y值是否已经通过投影转换自动生成了
                // 如果没有自动生成则做如下处理
                if (!geoModel.IsCoordInfoValid())
                {
                    if (geoOldModel != null)
                    {
                        // 如果以前模型存在，就把以前模型的坐标赋给它吧
                        geoModel.Position = geoOldModel.Position;
                    }
                    else
                    {
                        // 只赋予X和Y的值，对于GCM来说GCM文件中保存的Z值一般都是有用的，所以z值就不赋予0值了
                        geoModel.PositionX = m_GlobeControl.Globe.CameraState.Longitude;
                        geoModel.PositionY = m_GlobeControl.Globe.CameraState.Latitude;
                    }

                }
                // GCM的Z值一般都会有用，所以设置为RelativeToGround模型
                geoModel.AltitudeMode = EnumAltitudeMode.RelativeToGround;
            }
            else
            {
                if (geoOldModel != null)
                {
                    // 如果以前模型存在，就把以前模型的坐标赋给它吧
                    geoModel.Position = geoOldModel.Position;
                }
                else
                {
                    geoModel.PositionX = m_GlobeControl.Globe.CameraState.Longitude;
                    geoModel.PositionY = m_GlobeControl.Globe.CameraState.Latitude;
                    geoModel.PositionZ = 0; // 这里赋予0值吧
                }
            }

            // 将新模型赋值给他，注意只能通过这种方式，如果改变原来模型的FilePath的方法可能有问题
            m_Feature.Geometry = geoModel;
            if (m_SpaceCtrl != null)
            {
                m_SpaceCtrl.UpdateControls();
            }
            if (m_GlobeControl != null)
            {
                m_GlobeControl.Refresh();

            }
        }

        private void CtrlModelPathPage_Load(object sender, EventArgs e)
        {
            if (m_Feature!=null)
            {
                GSOGeoModel geoModel = m_Feature.Geometry as GSOGeoModel;
                if (geoModel != null)
                {
                    textBoxModelPath.Text = geoModel.FilePath;
                }
            }            
        }

       
    }
}
