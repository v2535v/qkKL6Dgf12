using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using GeoScene.Globe;
using GeoScene.Engine;
using GeoScene.Data;
using System.Collections;

namespace WorldGIS
{
    public partial class FrmUnionFeatureDataset : Form
    {
        private GSOGlobeControl globeControl1;

        public FrmUnionFeatureDataset(GSOGlobeControl _globeControl1)
        {
            InitializeComponent();
            globeControl1 = _globeControl1;
        }

        private void Frm_UnionFeatureDataSet_Load(object sender, EventArgs e)//连接数据库要素集
        {
            foreach(DatabaseConnectParams connectParams in Utility.connectParamsOfDatabase)
            {
                if (connectParams != null && (connectParams.databaseType == EnumDataSourceType.SqlServer || connectParams.databaseType == EnumDataSourceType.Oracle))
                {
                    comboBoxTargetDataSource.Items.Add(connectParams.dataSourceFullName);
                    comboBoxDataSourceList1.Items.Add(connectParams.dataSourceFullName);
                    comboBoxDataSourceList2.Items.Add(connectParams.dataSourceFullName);
                }
            }
        }

        private void btn_Union_Click(object sender, EventArgs e)
        {
            if (comboBoxTargetDataSource.SelectedItem == null)
            {
                MessageBox.Show("请选择目标数据源！", "提示");
                return;
            }
            string newLayerName = textBoxUnionLayerName.Text.Trim();
            if (newLayerName == "")
            {
                MessageBox.Show("请输入目标数据集名称！", "提示");
                return;
            }
            if (comboBoxDataSourceList1.SelectedItem == null)
            {
                MessageBox.Show("请选择要合并的数据源1！", "提示");
                return;
            }
            if (comboBoxUnionLayerList1.SelectedItem == null)
            {
                MessageBox.Show("请选择要合并的要素集1！", "提示");
                return;
            }
            if (comboBoxDataSourceList2.SelectedItem == null)
            {
                MessageBox.Show("请选择要合并的数据源2！", "提示");
                return;
            }
            if (comboBoxUnionLayerList2.SelectedItem == null)
            {
                MessageBox.Show("请选择要合并的要素集2！", "提示");
                return;
            }
            GSODataSource dsTarget = Utility.getDataSourceByFullName(globeControl1, comboBoxTargetDataSource.SelectedItem.ToString().Trim());
            if (dsTarget != null)
            {
                GSODataset dataset = dsTarget.GetDatasetByName(newLayerName);
                if (dataset != null)
                {
                    MessageBox.Show("目标数据集名称已存在目标数据源中！", "提示");
                    return;
                }
                GSOFeatureDataset featureDatasetInTargetDs = dsTarget.CreateFeatureDataset(newLayerName);
                if (featureDatasetInTargetDs == null)
                {
                    MessageBox.Show("目标数据集名称不符合要求！", "提示");
                    return;
                }
                GSODataSource dsUnion1 = Utility.getDataSourceByFullName(globeControl1, comboBoxDataSourceList1.SelectedItem.ToString().Trim());
                GSODataSource dsUnion2 = Utility.getDataSourceByFullName(globeControl1, comboBoxDataSourceList2.SelectedItem.ToString().Trim());
                 if (dsUnion1 != null && dsUnion2 != null)
                 {
                     GSOFeatureDataset datasetInUnionDs1 = dsUnion1.GetDatasetByName(comboBoxUnionLayerList1.SelectedItem.ToString().Trim()) as GSOFeatureDataset;
                     GSOFeatureDataset datasetInUnionDs2 = dsUnion1.GetDatasetByName(comboBoxUnionLayerList2.SelectedItem.ToString().Trim()) as GSOFeatureDataset;
                     if (datasetInUnionDs1 != null && datasetInUnionDs2 != null)
                     {
                         //判断要合并的数据集结构是否相同
                         datasetInUnionDs1.Open();
                         datasetInUnionDs2.Open();
                         if (datasetInUnionDs1.FieldCount != datasetInUnionDs2.FieldCount)
                         {
                             MessageBox.Show("要合并的数据集结构不相同，无法合并！", "错误");
                             return;
                         }
                         for (int i = 0; i < datasetInUnionDs1.FieldCount; i++)
                         {
                             if (datasetInUnionDs1.GetField(i).Equals(datasetInUnionDs2.GetField(i)) == false)
                             {
                                 MessageBox.Show("要合并的数据集结构不相同，无法合并！", "错误");
                                 return;
                             }
                         }
                         featureDatasetInTargetDs.Open();
                         for (int i = 0; i < datasetInUnionDs1.FieldCount; i++)
                         {
                             GSOFieldAttr fieldInUnionDs = datasetInUnionDs1.GetField(i);
                             featureDatasetInTargetDs.AddField(fieldInUnionDs);
                         }
                         //向新的数据集写入数据
                         for (int i = 0; i < datasetInUnionDs1.GetAllFeatures().Length; i++)//循环添加第一个要素集的所有feature到新数据集中
                         {
                             GSOFeature featureInUnionDs1 = datasetInUnionDs1.GetFeatureAt(i);
                             GSOFeature featureInTargetDs = featureInUnionDs1.Clone();
                             featureDatasetInTargetDs.AddFeature(featureInTargetDs);
                         }
                         for (int i = 0; i < datasetInUnionDs2.GetAllFeatures().Length; i++)//循环添加第一个要素集的所有feature到新数据集中
                         {
                             GSOFeature featureInUnionDs2 = datasetInUnionDs2.GetFeatureAt(i);
                             GSOFeature featureInTargetDs = featureInUnionDs2.Clone();
                             featureDatasetInTargetDs.AddFeature(featureInTargetDs);
                         }
                         featureDatasetInTargetDs.Save();
                         featureDatasetInTargetDs.Close();
                         datasetInUnionDs1.Close();
                         datasetInUnionDs2.Close();
                         MessageBox.Show("数据集合并成功！", "提示");
                         this.Close();
                     }
                 }
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBoxDataSourceList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDataSourceList1.SelectedItem != null)
            {
                comboBoxUnionLayerList1.Items.Clear();
                string dataSourceFullName = comboBoxDataSourceList1.SelectedItem.ToString().Trim();
                GSODataSource ds = Utility.getDataSourceByFullName(globeControl1, dataSourceFullName);
                if (ds != null)
                {
                    for (int i = 0; i < ds.DatasetCount; i++)
                    {
                        GSODataset dataset = ds.GetDatasetAt(i);
                        if (dataset != null && dataset.Caption.Contains("Network") == false)
                        {
                            comboBoxUnionLayerList1.Items.Add(dataset.Name);
                        }
                    }
                }
            }
        }

        private void comboBoxDataSourceList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDataSourceList2.SelectedItem != null)
            {
                comboBoxUnionLayerList2.Items.Clear();
                string dataSourceFullName = comboBoxDataSourceList2.SelectedItem.ToString().Trim();
                GSODataSource ds = Utility.getDataSourceByFullName(globeControl1, dataSourceFullName);
                if (ds != null)
                {
                    for (int i = 0; i < ds.DatasetCount; i++)
                    {
                        GSODataset dataset = ds.GetDatasetAt(i);
                        if (dataset != null && dataset.Caption.Contains("Network") == false)
                        {
                            comboBoxUnionLayerList2.Items.Add(dataset.Name);
                        }
                    }
                }
            }
        }
    }
}