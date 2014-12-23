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
    public partial class FrmSetLineStyle : Form
    {
        public GSOGlobeControl m_GlobeControl = null;
        public GSOLayer mlayer = null;
        public GSOFeature mfeature = null;
        public GSOStyle m_OldStyle = null;
        public GSOStyle m_Style = null;

        public FrmSetLineStyle(GSOStyle style, GSOGlobeControl globeControl)
        {
            InitializeComponent();
            m_GlobeControl = globeControl;
            // 如果m_OldStyle不存在，先备份一个
            if (style != null)
            {
                m_OldStyle = style.Clone();
            }
            m_Style = style;
        }
        public FrmSetLineStyle(GSOStyle style,GSOFeature feature,GSOLayer layer, GSOGlobeControl globeControl)
        {
            InitializeComponent();
            m_GlobeControl = globeControl;
            mlayer = layer;
            mfeature = feature;

            // 如果m_OldStyle不存在，先备份一个
            if (style != null)
            {
                m_OldStyle = style.Clone();
            }
            m_Style = style;
        }
        GSOSimpleLineStyle3D simpleLineStyle3D = null;
        private void SetControlsByStyle(GSOStyle style)
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
            if (m_Style != null)
            {
                mfeature.Geometry.Style = m_OldStyle;
                m_GlobeControl.Refresh();
            }
            this.Close();
        }

        private void FrmLineStyleSetting_Load(object sender, EventArgs e)
        {
              SetControlsByStyle(m_Style);
        }
        private void lineColorChanged()
        {
            if (simpleLineStyle3D != null)
            {
                try
                {
                    m_GlobeControl.Globe.AddToEditHistroy(mlayer, mfeature, EnumEditType.Modify);

                    simpleLineStyle3D.LineColor = Color.FromArgb(Convert.ToByte(numericUpDownLineOpaque.Value), pictureBoxLineColor.BackColor);
                    if (mfeature != null)
                    {
                        mfeature.Geometry.Style = simpleLineStyle3D;
                    }
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
                    m_GlobeControl.Globe.AddToEditHistroy(mlayer, mfeature, EnumEditType.Modify);

                    simpleLineStyle3D.LineWidth = Convert.ToDouble(textBoxLineWidth.Text);
                    mfeature.Geometry.Style = simpleLineStyle3D;

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
                m_GlobeControl.Globe.AddToEditHistroy(mlayer, mfeature, EnumEditType.Modify);

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
                mfeature.Geometry.Style = simpleLineStyle3D;

                if (m_GlobeControl != null)
                {
                    m_GlobeControl.Refresh();
                }
            }
        }      
    }
}
