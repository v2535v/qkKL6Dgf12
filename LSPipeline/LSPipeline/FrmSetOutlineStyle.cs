using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GeoScene.Globe;
using GeoScene.Data;
namespace WorldGIS
{
    public partial class FrmSetOutlineStyle : Form
    {
        public GSOGlobeControl m_GlobeControl = null;
        public GSOLayer mlayer = null;
        GSOFeature mfeature = null;
        public GSOGeoPolygon3D mpolygon = null;
        public GSOLineStyle3D m_OldStyle = null;
        GSOSimpleLineStyle3D simpleLineStyle3D = null;

        public FrmSetOutlineStyle(GSOLineStyle3D style, GSOGeoPolygon3D polygon, GSOFeature feature, GSOGlobeControl globeControl)
        {
            InitializeComponent();
            m_GlobeControl = globeControl;
            mfeature = feature;
            mpolygon = polygon;

            // 如果m_OldStyle不存在，先备份一个
            if (style != null)
            {
                m_OldStyle = (GSOLineStyle3D)style.Clone();
            }
            simpleLineStyle3D = (GSOSimpleLineStyle3D)style;
        }

        private void SetControlsByStyle()
        {
            if (simpleLineStyle3D != null)
            {
                // 这句要写到前面，不然下面Checked的时候要检查
                pictureBoxLineColor.BackColor = Color.FromArgb(255, simpleLineStyle3D.LineColor);
                numericUpDownLineOpaque.Value = simpleLineStyle3D.LineColor.A;
                textBoxLineWidth.Text = simpleLineStyle3D.LineWidth.ToString();

                switch (simpleLineStyle3D.LineType)
                {
                    case EnumLineType.Solid:
                        comboBoxLineType.SelectedIndex = 0;
                        break;
                    case EnumLineType.Dash:
                        comboBoxLineType.SelectedIndex = 1;
                        break;
                    case EnumLineType.Dot:
                        comboBoxLineType.SelectedIndex = 2;
                        break;
                    case EnumLineType.DashDot:
                        comboBoxLineType.SelectedIndex = 3;
                        break;
                    case EnumLineType.DashDotDot:
                        comboBoxLineType.SelectedIndex = 4;
                        break;
                }
            }
            else
            {
                simpleLineStyle3D = new GSOSimpleLineStyle3D();
            }
        }
        private void buttonOk_Click(object sender, EventArgs e)
        { 
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            // 如果取消的话，将备份的拷贝回来
            if (m_OldStyle != null)
            {
                ((GSOSimplePolygonStyle3D)mpolygon.Style).OutlineStyle = m_OldStyle;
                if (m_GlobeControl != null)
                {
                    m_GlobeControl.Refresh();
                }
            }
            this.Close();
        }

        private void FrmLineStyleSetting_Load(object sender, EventArgs e)
        {
            SetControlsByStyle();
        }
        private void lineColorChanged()
        {
            if (simpleLineStyle3D != null)
            {
                try
                {
                    m_GlobeControl.Globe.AddToEditHistroy(null, mfeature, EnumEditType.Modify);

                    simpleLineStyle3D.LineColor = Color.FromArgb(Convert.ToByte(numericUpDownLineOpaque.Value), pictureBoxLineColor.BackColor);
                    ((GSOSimplePolygonStyle3D)mpolygon.Style).OutlineStyle = simpleLineStyle3D;

                    if (m_GlobeControl != null)
                    {
                        m_GlobeControl.Refresh();
                    }
                }
                catch (System.Exception exp)
                {
                    MessageBox.Show("输入的值格式不符合要求","提示");
                    Log.PublishTxt(exp);
                }
            }   
        }
        private void pictureBoxLineColor_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.FullOpen = true;
            dlg.Color = pictureBoxLineColor.BackColor;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                pictureBoxLineColor.BackColor = Color.FromArgb(255, dlg.Color);
                lineColorChanged();
            }
        }

        private void numericUpDownLineOpaque_ValueChanged(object sender, EventArgs e)
        {           
            lineColorChanged();
        }

        private void textBoxLineWidth_TextChanged(object sender, EventArgs e)
        {        
            if (simpleLineStyle3D != null)
            {
                try
                {
                    m_GlobeControl.Globe.AddToEditHistroy(null,mfeature, EnumEditType.Modify);
                    if (textBoxLineWidth.Text == "")
                    {
                        simpleLineStyle3D.LineWidth = 1;
                    }
                    else
                    {
                        simpleLineStyle3D.LineWidth = Convert.ToDouble(textBoxLineWidth.Text);
                    }
                    ((GSOSimplePolygonStyle3D)mpolygon.Style).OutlineStyle = simpleLineStyle3D;

                    if (m_GlobeControl != null)
                    {
                        m_GlobeControl.Refresh();
                    }
                }
                catch (System.Exception exp)
                {
                    MessageBox.Show("输入的值格式不符合要求", "提示");
                    Log.PublishTxt(exp);
                }
            }    
        }

        private void comboBoxLineType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (simpleLineStyle3D != null)
            {
                m_GlobeControl.Globe.AddToEditHistroy(null, mfeature, EnumEditType.Modify);

                switch (comboBoxLineType.SelectedIndex)
                {
                    case 0:
                        simpleLineStyle3D.LineType = EnumLineType.Solid;
                        break;
                    case 1:
                        simpleLineStyle3D.LineType = EnumLineType.Dash;
                        break;
                    case 2:
                        simpleLineStyle3D.LineType = EnumLineType.Dot;
                        break;
                    case 3:
                        simpleLineStyle3D.LineType = EnumLineType.DashDot;
                        break;
                    case 4:
                        simpleLineStyle3D.LineType = EnumLineType.DashDotDot;
                        break;
                }
                ((GSOSimplePolygonStyle3D)mpolygon.Style).OutlineStyle = simpleLineStyle3D;

                if (m_GlobeControl != null)
                {
                    m_GlobeControl.Refresh();
                }
            }
        }      
    }
}
