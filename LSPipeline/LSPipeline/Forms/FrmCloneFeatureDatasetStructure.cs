using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using GeoScene.Globe;
using GeoScene.Engine;
using GeoScene.Data;

namespace WorldGIS.Forms
{
    public partial class FrmCloneFeatureDatasetStructure : Form
    {
        GSOGlobeControl globeControl1;
        public FrmCloneFeatureDatasetStructure(GSOGlobeControl _globeControl1)
        {
            globeControl1 = _globeControl1;            
            InitializeComponent();
        }

        private void FrmCloneFeatureDatasetStructure_Load(object sender, EventArgs e)
        {
            foreach (DatabaseConnectParams connectParams in Utility.connectParamsOfDatabase)
            {
                if (connectParams != null && (connectParams.databaseType == EnumDataSourceType.SqlServer || connectParams.databaseType == EnumDataSourceType.Oracle))
                {
                    comboBoxDataSourceList.Items.Add(connectParams.dataSourceFullName);
                    comboBoxTargetDataSource.Items.Add(connectParams.dataSourceFullName);
                }
            }
        }

        private void btnCreateModel_Click(object sender, EventArgs e)
        {
            if (comboBoxDataSourceList.SelectedItem == null)
            {
                MessageBox.Show("请选择要复制的数据的源！");
                return; 
            }
            if (commBoxModelLayerList.SelectedItem == null)
            {
                MessageBox.Show("请选择数据集模板！");
                return;
            }
            if (comboBoxTargetDataSource.SelectedItem == null)
            {
                MessageBox.Show("请选择目标数据源！");
                return;
            }
            string layerName = textBoxNewLayerName.Text.Trim();
            if (layerName == "")
            {
                MessageBox.Show("请输入数据集名称！");
                return;
            }
            int num = -1;
            bool bl = int.TryParse(layerName.Substring(0,1),out num);
            if (!bl)
            {
                GSODataSource dsTarget = Utility.getDataSourceByFullName(globeControl1, comboBoxTargetDataSource.SelectedItem.ToString().Trim()); 
                if (dsTarget != null)
                {
                    GSODataset datasetInTargetDs = dsTarget.GetDatasetByName(layerName);
                    if (datasetInTargetDs != null)
                    {
                        MessageBox.Show("目标数据源中该数据集名称已存在！", "提示");
                        return;
                    }
                    else
                    {
                        GSODataSource ds = Utility.getDataSourceByFullName(globeControl1, comboBoxDataSourceList.SelectedItem.ToString().Trim());
                        if (ds != null)
                        {
                            GSODataset datasetInDs = ds.GetDatasetByName(commBoxModelLayerList.SelectedItem.ToString());
                            GSOFeatureDataset featureDatasetInDs = datasetInDs as GSOFeatureDataset;
                            if (featureDatasetInDs == null)
                            {
                                MessageBox.Show("选中的模板图层不符合要求！", "提示");
                                return;
                            }
                            featureDatasetInDs.Open();
                            
                            GSOFeatureDataset featureDatasetTargetDs = dsTarget.CreateFeatureDataset(layerName);
                            if (featureDatasetTargetDs == null)
                            {
                                MessageBox.Show("输入的新数据集名称不符合要求！", "提示");
                                return;
                            }
                            featureDatasetTargetDs.Open();
                            for (int i = 0; i < featureDatasetInDs.FieldCount; i++)
                            {
                                GSOFieldAttr fieldFromSource = featureDatasetInDs.GetField(i);
                                GSOFieldAttr fieldInTargetDataSource = new GSOFieldAttr();
                                fieldInTargetDataSource.Name = fieldFromSource.Name;
                                fieldInTargetDataSource.Type = fieldFromSource.Type;
                                fieldInTargetDataSource.Width = fieldFromSource.Width;
                                fieldInTargetDataSource.Precision = fieldFromSource.Precision;
                                bool res = featureDatasetTargetDs.AddField(fieldInTargetDataSource);
                            }

                            featureDatasetTargetDs.Save();
                            featureDatasetTargetDs.Close();
                            featureDatasetInDs.Close();
                            MessageBox.Show("复制成功！", "提示");
                            this.Close();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("数据集名称不能以数字开头！", "提示");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBoxDataSourceList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDataSourceList.SelectedItem != null)
            {
                commBoxModelLayerList.Items.Clear();
                GSODataSource ds = Utility.getDataSourceByFullName(globeControl1, comboBoxDataSourceList.SelectedItem.ToString().Trim());
                if (ds != null)
                {
                    for (int i = 0; i < ds.DatasetCount; i++)
                    {
                        GSODataset dataset = ds.GetDatasetAt(i);
                        if (dataset != null && dataset.Caption.Contains("Network") == false)
                        {
                            commBoxModelLayerList.Items.Add(dataset.Caption);
                        }
                    }
                }
            }
        }

        private void commBoxModelLayerList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (commBoxModelLayerList.SelectedItem != null)
            {
                textBoxNewLayerName.Text = commBoxModelLayerList.SelectedItem.ToString().Trim();
            }
        }
    }
}
