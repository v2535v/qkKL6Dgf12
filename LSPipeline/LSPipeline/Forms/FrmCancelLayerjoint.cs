using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GeoScene.Globe;
using GeoScene.Data;
using System.IO;
namespace WorldGIS.Forms
{
    public partial class FrmCancelLayerjoint : Form
    {
        private GSOGlobeControl ctl;
        public FrmCancelLayerjoint(GSOGlobeControl _ctl)
        {
            ctl = _ctl;
            InitializeComponent();
        }

        private void FrmPipelineLayerButtjoint_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < ctl.Globe.Layers.Count; i++)
            {
                GSOLayer layer = ctl.Globe.Layers[i];   
                /*
                int idx=layer.Name.LastIndexOf(@"\");
                int idx1=layer.Name.LastIndexOf(".");
                string layerCaption = layer.Caption.Substring(idx+1,idx1-idx-1);
                */
                cmbLayers.Items.Add(layer.Caption);
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            GSOLayer layer = ctl.Globe.Layers[cmbLayers.SelectedIndex];
            if (layer != null)
            {
                if (layer.Type != EnumLayerType.FeatureLayer)
                {
                    MessageBox.Show("当前选中的图层不是矢量图层！", "提示");
                    return;
                }
                ctl.Globe.CancelPipelineDatasetJoint(layer.Dataset,true,true);                
                ctl.Refresh();
            }
            else
            {
                MessageBox.Show("请选择图层");
            }
        }
     
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
