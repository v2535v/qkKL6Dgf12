using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GeoScene.Data;
using GeoScene.Globe;
using System.Collections;

namespace WorldGIS
{
    public partial class FrmShowValvesNeedClose : Form
    {
        GSOGlobeControl globeControl1;
        GSOFeatures m_CloseValvesAnalyResFeatures;
        ArrayList m_CloseValvesList;

        private static FrmShowValvesNeedClose form=null;

        public static FrmShowValvesNeedClose getForm(GSOGlobeControl globe, GSOFeatures features, ArrayList list)
        {
            if (form == null)
            {
                form = new FrmShowValvesNeedClose(globe, features, list);
            }
            else
            {
                form.m_CloseValvesAnalyResFeatures = features;
                form.m_CloseValvesList = list;    
            }
            return form;
        }


        private FrmShowValvesNeedClose(GSOGlobeControl globe,GSOFeatures features,ArrayList list)
        {                       
                InitializeComponent();
                globeControl1 = globe;
                m_CloseValvesAnalyResFeatures = features;
                m_CloseValvesList = list;    
        }

        private void FrmCloseValves_Load(object sender, EventArgs e)
        {
            //setLstValvesName();
        }
        public void setLstValvesName()
        {
            lstValvesName.Items.Clear();
            int ncount = m_CloseValvesAnalyResFeatures.Length;
            if (ncount > 0)
            {
                for (int i = 0; i < ncount; i++)
                {
                    lstValvesName.Items.Add(m_CloseValvesAnalyResFeatures[i].Name);
                }
            }
        }



        private void lstValvesName_DoubleClick(object sender, EventArgs e)
        {
            int i = this.lstValvesName.SelectedIndex;
            if (i < 0)
            {
                return;
            }
            GSOFeature m_CloseValvesAnalyresFeature = m_CloseValvesAnalyResFeatures[i];
            globeControl1.Globe.FlyToFeature(m_CloseValvesAnalyresFeature, 1, 45, 5);
            GSOLabel newLabel = new GSOLabel();
            newLabel.Text = "关闭此阀门";
            newLabel.Style = new GSOLabelStyle();
            newLabel.Style.Opaque = 0.8;
            newLabel.Style.OutlineColor = Color.Red;
            //newLabel.Style.TractionLineEndPos = new GSOPoint2d(150, 120);
            newLabel.Style.OutlineWidth = 1;
            newLabel.Style.TracktionLineWidth = 1;
            newLabel.Style.BackBeginColor = Color.Orange;
            newLabel.Style.BackEndColor = Color.PaleGreen;

            m_CloseValvesAnalyresFeature.Label = newLabel;

            m_CloseValvesList.Add(m_CloseValvesAnalyresFeature);

            globeControl1.Refresh();
        }

        private void FrmCloseValves_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClearCloseValvesAnalysis();
            form = null;
        }
        private void ClearCloseValvesAnalysis()//清楚阀门分析结果
        {
            if (m_CloseValvesAnalyResFeatures != null)
            {
                for (int i = 0; i < m_CloseValvesList.Count; i++)
                {
                    GSOFeature feature = m_CloseValvesList[i] as GSOFeature;
                    feature.Label.Text = "";
                }
                globeControl1.Refresh();
                m_CloseValvesAnalyResFeatures = null;
                m_CloseValvesList = new ArrayList();
            }
        }

        private void FlyToMenu_Click(object sender, EventArgs e)
        {
            int i = this.lstValvesName.SelectedIndex;
            if (i < 0)
            {
                return;
            }
            GSOFeature m_CloseValvesAnalyresFeature = m_CloseValvesAnalyResFeatures[i];
            globeControl1.Globe.FlyToFeature(m_CloseValvesAnalyresFeature, 1, 45, 5);
            GSOLabel newLabel = new GSOLabel();
            newLabel.Text = "关闭此阀门";
            newLabel.Style = new GSOLabelStyle();
            newLabel.Style.Opaque = 0.8;
            newLabel.Style.OutlineColor = Color.Red;
            //newLabel.Style.TractionLineEndPos = new GSOPoint2d(150, 120);
            newLabel.Style.OutlineWidth = 1;
            newLabel.Style.TracktionLineWidth = 1;
            newLabel.Style.BackBeginColor = Color.Orange;
            newLabel.Style.BackEndColor = Color.PaleGreen;

            m_CloseValvesAnalyresFeature.Label = newLabel;

            m_CloseValvesList.Add(m_CloseValvesAnalyresFeature);

            globeControl1.Refresh();
        }

        private void lstValvesName_MouseDown(object sender, MouseEventArgs e)
        {
            int i = this.lstValvesName.SelectedIndex;
            if (i < 0)
            {
                return;
            }
            if (e.Button == MouseButtons.Right)
            {
                lstValvesName.ContextMenuStrip = contextMenuStrip1;
                foreach (ToolStripItem item in contextMenuStrip1.Items)
                {
                    item.Visible = true;
                }
            }
        }
        string flashflag = "";
        private void LightMenu_Click(object sender, EventArgs e)
        {
            flashflag = "single";
            timer1.Start();
        }
        int count = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            int i = this.lstValvesName.SelectedIndex;
            if (i < 0)
            {
                return;
            }
            GSOFeature m_feature = m_CloseValvesAnalyResFeatures[i];
            if (count < 6)
            {
                count++;
                if (flashflag == "single")
                {
                    if (m_feature != null)
                    {
                        if (count % 2 != 0)
                        {
                            m_feature.HighLight = true;
                            globeControl1.Refresh();
                        }
                        else
                        {
                            m_feature.HighLight = false;
                            globeControl1.Refresh();
                        }
                    }
                }
                else if (flashflag == "all")
                {
                    
                }

            }
            else
            {
                timer1.Stop();
                count = 0;
            }
        }
    }
}
