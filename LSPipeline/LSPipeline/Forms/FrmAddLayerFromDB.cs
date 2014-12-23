using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GeoScene.Engine;
using GeoScene.Globe;
using GeoScene.Data;
namespace WorldGIS.Forms
{
    public partial class FrmAddLayerFromDB : Form
    {
        private GSOGlobeControl globeControl1;
        public FrmAddLayerFromDB(GSOGlobeControl _globeControl)
        {
            globeControl1 = _globeControl;
            InitializeComponent();
        }
        
        private void FrmAddLayerFromDB_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = true;
            foreach (DatabaseConnectParams connectParams in Utility.connectParamsOfDatabase)
            {
                if (connectParams != null && (connectParams.databaseType == EnumDataSourceType.SqlServer || connectParams.databaseType == EnumDataSourceType.Oracle))
                {
                    comboBoxDataSourceList.Items.Add(connectParams.dataSourceFullName);
                }
            }
            if(comboBoxDataSourceList.Items.Count > 0)
            {
                comboBoxDataSourceList.SelectedIndex = 0;
            }
        }

        private void comboBoxDataSourceList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDataSourceList.SelectedItem != null)
            {
                refreshListBox(comboBoxDataSourceList.SelectedItem.ToString().Trim());
            }
        }
        private void refreshListBox(string dataSourceFullName)
        {
            listBox1.Items.Clear();
            GSODataSource ds = Utility.getDataSourceByFullName(globeControl1, comboBoxDataSourceList.SelectedItem.ToString().Trim());
            if (ds != null)
            {
                for (int i = 0; i < ds.DatasetCount; i++)
                {
                    GSODataset dataset = ds.GetDatasetAt(i);
                    if (checkBox1.Checked)
                    {
                        if (dataset.Name.ToLower().Contains("network"))
                        {
                            continue;
                        }
                    }
                    listBox1.Items.Add(dataset.Name);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)//确定
        {
            if (listBox1.SelectedItems.Count > 0)
            {
                GSODataSource ds = Utility.getDataSourceByFullName(globeControl1, comboBoxDataSourceList.SelectedItem.ToString().Trim());
                if (ds != null)
                {
                    DateTime timeStart = DateTime.Now;
                    for (int i = 0; i < listBox1.SelectedItems.Count; i++)
                    {
                        GSODataset dataset = ds.GetDatasetByName(listBox1.SelectedItems[i].ToString().Trim());
                        if (dataset != null)
                        {
                            dataset.Caption = dataset.Name;
                            GSOLayer layer = globeControl1.Globe.Layers.Add(dataset);
                            layer.MaxVisibleAltitude = 7000;                           
                        }
                    }
                    TimeSpan timeConnect = DateTime.Now - timeStart;
                    double secondsConnect = timeConnect.TotalSeconds;
                    MessageBox.Show("打开" + listBox1.SelectedItems.Count.ToString() + "个图层， 用时" + secondsConnect.ToString() + "秒", "提示");
                    this.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)//删除
        {
            if (listBox1.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("确定要删除所有选中的图层吗 ?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    GSODataSource ds = Utility.getDataSourceByFullName(globeControl1, comboBoxDataSourceList.SelectedItem.ToString().Trim());
                    if (ds != null)
                    {
                        for (int i = listBox1.SelectedItems.Count - 1; i >= 0; i--)
                        {
                            ds.DeleteDatasetByName(listBox1.SelectedItems[i].ToString());
                            listBox1.Items.Remove(listBox1.SelectedItems[i]);
                        }
                    }
                }
            }
        }

        private void buttonNo_Click(object sender, EventArgs e)//取消
        {
            this.Close();
        }

        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index > -1)
            {
                e.DrawBackground();
                e.DrawFocusRectangle();
                StringFormat strFormat = new StringFormat();
                strFormat.LineAlignment = StringAlignment.Center;
                e.Graphics.DrawString(listBox1.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds, strFormat);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (comboBoxDataSourceList.SelectedItem != null)
            {
                refreshListBox(comboBoxDataSourceList.SelectedItem.ToString().Trim());
            }
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBox1.SelectedItems.Count != 0)
            {
                button1_Click(sender, e);
            }
        }
    }
}