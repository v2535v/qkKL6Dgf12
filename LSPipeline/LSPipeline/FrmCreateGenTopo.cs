using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GeoScene.Globe;
using GeoScene.Data;
using GeoScene.Engine;
namespace WorldGIS
{
    public partial class FrmCreateGenTopo : Form
    {
        private GSOGlobeControl globeControl1;
        public FrmCreateGenTopo(GSOGlobeControl _globeControl1)
        {
            globeControl1 = _globeControl1;
            InitializeComponent();
        }

        private void FrmGenTopo_Load(object sender, EventArgs e)
        {
            comboBoxDBLayerList.Items.Clear();
            comboBoxDataSourceList.Items.Clear();

            foreach (DatabaseConnectParams connectParams in Utility.connectParamsOfDatabase)
            {
                if (connectParams != null && (connectParams.databaseType == EnumDataSourceType.SqlServer || connectParams.databaseType == EnumDataSourceType.Oracle))
                {
                    comboBoxDataSourceList.Items.Add(connectParams.dataSourceFullName);
                }
            }
            
            if (comboBoxDataSourceList.Items.Count > 0)
            {
                comboBoxDataSourceList.SelectedIndex = 0;                
            }

            textBoxTolerance.Text = "0.1";
            textBoxValveTolerance.Text = "0.1";
            checkBoxIgnoreZ.Checked = true;
            checkBoxValveIgnoreZ.Checked = true;

            checkBoxUnionValve.Checked = false;
            panelValve.Enabled = false;
            textBoxNearestDistLimit.Enabled = false;
        }

        private void cbbDataSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDataSourceList.SelectedItem != null)
            {
                comboBoxDBLayerList.Items.Clear();
                comboBoxDBValveList.Items.Clear();
                GSODataSource ds = Utility.getDataSourceByFullName(globeControl1, comboBoxDataSourceList.SelectedItem.ToString().Trim());
                if (ds != null)
                {
                    for (int i = 0; i < ds.DatasetCount; i++)
                    {
                        GSODataset dataset = ds.GetDatasetAt(i);
                        if (dataset != null && dataset.Name.Contains("Network") == false)
                        {
                            comboBoxDBLayerList.Items.Add(dataset.Name);
                            comboBoxDBValveList.Items.Add(dataset.Name);
                        }
                    }
                    if (comboBoxDBLayerList.Items.Count > 0)
                    {
                        comboBoxDBLayerList.SelectedIndex = 0;
                    }
                }
            }
        }

        private void cbbLayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDBLayerList.SelectedItem != null && comboBoxDataSourceList.SelectedItem != null)
            {
                GSODataSource ds = Utility.getDataSourceByFullName(globeControl1, comboBoxDataSourceList.SelectedItem.ToString().Trim());                
                if (ds != null)
                {
                    GSODataset dataset = ds.GetDatasetByName(comboBoxDBLayerList.SelectedItem.ToString().Trim());
                    if (dataset != null)
                    {
                        textBoxTopoName.Text = dataset.Name + "Network";
                    }
                }
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (comboBoxDataSourceList.SelectedItem == null)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("请选择一个目标数据源！", "提示");
                return;
            }
            GSODataSource ds = Utility.getDataSourceByFullName(globeControl1, comboBoxDataSourceList.SelectedItem.ToString().Trim());
            if (ds == null)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("选择的目标数据源为空！", "提示");
                return;
            }
            if (comboBoxDBLayerList.SelectedItem == null)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("请选择要创建拓扑的图层！","提示");
                return;
            }
            string topoName = textBoxTopoName.Text.Trim();
            if (topoName == "")
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("拓扑图层名称不能为空！");
                return;
            }
            GSODataset dataset = ds.GetDatasetByName(comboBoxDBLayerList.SelectedItem.ToString().Trim());
            if (dataset == null)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("选择的图层为空！", "提示");
                return;
            }
            GSOFeatureDataset featureDataset = dataset as GSOFeatureDataset;
            if (featureDataset == null)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("选择的图层不是矢量图层！", "提示");
                return; 
            }
            if (checkBoxUnionValve.Checked == true)
            {
                if (comboBoxDBValveList.SelectedItem == null)
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("请选择一个阀门图层！", "提示");
                    return;
                }
            }
            try
            {
                GSODataset topoDataset = ds.GetDatasetByName(topoName);
                if (topoDataset != null)
                {
                    DialogResult result = MessageBox.Show("拓扑数据已经存在，是否重建？", "警告", MessageBoxButtons.OKCancel);
                    if (result == DialogResult.OK)
                    {
                        ds.DeleteDatasetByName(topoName);
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                        return;
                    }
                }
                double dTolerance = 0;
                if (Double.TryParse(textBoxTolerance.Text.Trim(), out dTolerance) == false)
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("误差容限值不符合要求！","提示");
                    return;
                }
                GSONetworkDataset newNetworkDataset = GSODataEngineUtility.GeneratePipelineNetwork(ds, featureDataset, topoName, true, dTolerance, "", "", checkBoxIgnoreZ.Checked, false);
                if (newNetworkDataset == null)
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("拓扑数据创建失败！");
                    return;
                }
                if (checkBoxUnionValve.Checked)
                {
                    //添加阀门信息
                    GSONetworkDataset networkDataset = ds.GetDatasetByName(topoName) as GSONetworkDataset;
                    if (networkDataset == null)
                    {
                        this.Cursor = Cursors.Default;
                        MessageBox.Show("要添加阀门信息的拓扑数据不存在！");
                        return;
                    }
                    GSODataset valveDataset = ds.GetDatasetByName(comboBoxDBValveList.SelectedItem.ToString().Trim());
                    GSOFeatureDataset valveFeatureDataset = valveDataset as GSOFeatureDataset;
                    if (valveFeatureDataset == null)
                    {
                        this.Cursor = Cursors.Default;
                        MessageBox.Show("选择的阀门图层不是矢量图层！","提示");
                        return;
                    }
                    if (checkBoxClearValves.Checked == true)//清除掉以前关联的阀门信息
                    {
                        networkDataset.ClearValves();
                    }

                    double dVavleTolerance = 0;
                    if (Double.TryParse(textBoxValveTolerance.Text, out dVavleTolerance) == false)
                    {
                        this.Cursor = Cursors.Default;
                        MessageBox.Show("阀门图层的误差容限值不符合要求！", "提示");
                        return;
                    }

                    double dNearstDisLimit = 0;
                    if (Double.TryParse(textBoxNearestDistLimit.Text, out dNearstDisLimit) == false)
                    {
                        this.Cursor = Cursors.Default;
                        MessageBox.Show("最近点距离的容限值不符合要求！", "提示");
                        return;
                    }

                    Int32 nMatchNum = networkDataset.GenerateValves(valveFeatureDataset, dVavleTolerance, checkBoxValveIgnoreZ.Checked, checkBoxMatchNearest.Checked, dNearstDisLimit);
                    
                    MessageBox.Show("拓扑数据创建成功,阀门匹配完成！共匹配了 " + nMatchNum + " 个阀门！", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("拓扑数据创建成功！", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.Cursor = Cursors.Default;
                this.Close();
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);
                Log.PublishTxt(ex);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkUnionFamen_CheckedChanged(object sender, EventArgs e)
        {
            panelValve.Enabled = checkBoxUnionValve.Checked;            
        }

        private void checkBoxMatchNearest_CheckedChanged(object sender, EventArgs e)
        {
            textBoxNearestDistLimit.Enabled = checkBoxMatchNearest.Checked;
        }
    }
}
