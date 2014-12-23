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
using System.Data.SqlClient;

namespace WorldGIS
{
    public partial class FrmCopyFeatureDataset : Form
    {

        private GSOGlobeControl globeControl1;
        public FrmCopyFeatureDataset(GSOGlobeControl _ctl)
        {
            InitializeComponent();
            globeControl1 = _ctl;
        }

        private void Frm_CopyFeatureDataSet_Load(object sender, EventArgs e)
        {
            foreach (DatabaseConnectParams connectParams in Utility.connectParamsOfDatabase)
            {
                if (connectParams != null && (connectParams.databaseType == EnumDataSourceType.SqlServer || connectParams.databaseType == EnumDataSourceType.Oracle))
                {
                    comboBoxDataSourceList.Items.Add(connectParams.dataSourceFullName);
                    comboBoxTargetDataSource.Items.Add(connectParams.dataSourceFullName);
                }
            }

            checkBoxCopyMult.Checked = true;
            groupBoxCopyOne.Enabled = false;
            progressBar1.Visible = false;
        }
      
        private void buttonApply_Click(object sender, EventArgs e)//应用
        {
            this.Cursor = Cursors.WaitCursor;
            Set();
            this.Cursor = Cursors.Default;
        }
        private void Set()
        {
            if (listBoxCopyLayerList.SelectedItems.Count <= 0)
            {
                MessageBox.Show("请选择要复制的数据集！", "提示");
                return;
            }
            if (comboBoxTargetDataSource.SelectedItem == null)
            {
                MessageBox.Show("请选择目标数据源！", "提示");
                return;
            }
            if (checkBoxCopyOne.Checked == true && textboxNewLayerName.Text.Trim() == "")
            {
                MessageBox.Show("请给要复制的数据集命名！", "提示");
                return; 
            }
            if (checkBoxCopyOne.Checked == true)
            {
                GSODataSource dsTarget = Utility.getDataSourceByFullName(globeControl1, comboBoxTargetDataSource.SelectedItem.ToString().Trim());
                if (dsTarget != null)
                {
                    GSODataset newDataset = dsTarget.GetDatasetByName(textboxNewLayerName.Text.Trim());
                    if (newDataset != null)
                    {
                        MessageBox.Show("输入的新的数据集的名称已存在目标数据源中！", "提示");
                        return;
                    }
                    GSOFeatureDataset newFeatureDataset = dsTarget.CreateFeatureDataset(textboxNewLayerName.Text.Trim());
                    if (newFeatureDataset == null)
                    {
                        MessageBox.Show("输入的新数据集的名称不符合要求！", "提示");
                        return;
                    }
                    GSODataSource ds = Utility.getDataSourceByFullName(globeControl1, comboBoxDataSourceList.SelectedItem.ToString().Trim());
                    if (ds != null)
                    {
                        GSODataset dataset = ds.GetDatasetByName(listBoxCopyLayerList.SelectedItem.ToString().Trim());
                        GSOFeatureDataset featureDataset = dataset as GSOFeatureDataset;
                        if (featureDataset != null)
                        {
                            try
                            {
                                featureDataset.Open();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message,"提示");
                                if (featureDataset.IsOpened == true)
                                {
                                    featureDataset.Close();
                                }
                                return;
                            }
                            //向新数据集写入字段
                            for (int i = 0; i < featureDataset.FieldCount; i++)
                            {
                                GSOFieldAttr fieldFromDs = featureDataset.GetField(i);
                                newFeatureDataset.AddField(fieldFromDs);
                            }

                            //向新的要素集写入数据                
                            for (int i = 0; i < featureDataset.GetAllFeatures().Length; i++)
                            {
                                GSOFeature featureInDs = featureDataset.GetFeatureAt(i);
                                GSOFeature featureInTargetDs = featureInDs.Clone();
                                featureInDs.Dispose();
                                newFeatureDataset.AddFeature(featureInTargetDs);
                            }
                            newFeatureDataset.Save();
                            featureDataset.Close();
                            MessageBox.Show("复制成功！","提示");
                        }
                    }
                }
            }
            else if (checkBoxCopyMult.Checked == true)
            {
                GSODataSource dsTarget = Utility.getDataSourceByFullName(globeControl1, comboBoxTargetDataSource.SelectedItem.ToString().Trim()); 
                if (dsTarget != null)
                {
                    string datasetNames = "";
                    for (int i = 0; i < listBoxCopyLayerList.SelectedItems.Count; i++)
                    {
                        GSODataset datasetInTargetDs = dsTarget.GetDatasetByName(listBoxCopyLayerList.SelectedItems[i].ToString().Trim());
                        if (datasetInTargetDs != null)
                        {
                            datasetNames += "\"" + listBoxCopyLayerList.SelectedItems[i].ToString().Trim() + "\" ";
                        }
                    }
                    if (datasetNames != "")
                    {
                        MessageBox.Show("数据集名称" + datasetNames + "在目标数据源中已存在", "提示");
                        return;
                    }
                    GSODataSource ds = Utility.getDataSourceByFullName(globeControl1, comboBoxDataSourceList.SelectedItem.ToString().Trim());
                     if (ds != null)
                     {
                         progressBar1.Visible = true;
                         progressBar1.Maximum = listBoxCopyLayerList.SelectedItems.Count - 1;
                         progressBar1.Minimum = 0;
                         for (int j = 0; j < listBoxCopyLayerList.SelectedItems.Count; j++)
                         {
                             //获取要复制的要素集
                             GSODataset datasetInDs = ds.GetDatasetByName(listBoxCopyLayerList.SelectedItems[j].ToString().Trim());
                             GSOFeatureDataset featureDatasetInDs = datasetInDs as GSOFeatureDataset;
                             if (featureDatasetInDs == null)
                             {
                                 continue;
                             }
                             featureDatasetInDs.Open();

                             //创建新的数据库要素集
                             GSOFeatureDataset featureDatasetInTargetDs = dsTarget.CreateFeatureDataset(listBoxCopyLayerList.SelectedItems[j].ToString().Trim());

                             if (featureDatasetInTargetDs == null)
                             {
                                 continue;
                             }
                             featureDatasetInTargetDs.Open();
                             for (int i = 0; i < featureDatasetInDs.FieldCount; i++)
                             {
                                 GSOFieldAttr fieldInDs = featureDatasetInDs.GetField(i);
                                 featureDatasetInTargetDs.AddField(fieldInDs);
                             }

                             //(2)向新的要素集写入数据                
                             for (int i = 0; i < featureDatasetInDs.GetAllFeatures().Length; i++)
                             {
                                 GSOFeature featureInDs = featureDatasetInDs.GetFeatureAt(i);
                                 GSOFeature featureInTargetDs = featureInDs.Clone();
                                 featureInDs.Dispose();
                                 featureDatasetInTargetDs.AddFeature(featureInTargetDs);
                             }
                             featureDatasetInTargetDs.Save();
                             featureDatasetInTargetDs.Close();
                             featureDatasetInDs.Close();

                             progressBar1.Value = j;
                         }
                         progressBar1.Visible = false;
                         MessageBox.Show("数据复制成功！", "提示");
                     }
                }
            }
        }
       
        private void btn_Cancel_Click(object sender, EventArgs e)//取消
        { 
            this.Close();
        }

        private void comboBoxDataSourceList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDataSourceList.SelectedItem != null)
            {
                listBoxCopyLayerList.Items.Clear();
                GSODataSource ds = Utility.getDataSourceByFullName(globeControl1, comboBoxDataSourceList.SelectedItem.ToString().Trim());
                if (ds != null)
                {
                    listBoxCopyLayerList.Items.Clear();
                    for (int i = 0; i < ds.DatasetCount; i++)
                    {
                        GSODataset dataset = ds.GetDatasetAt(i);
                        if (dataset != null && dataset.Caption.Contains("Network") == false)
                        {
                            listBoxCopyLayerList.Items.Add(dataset.Name);
                        }
                    }
                }
            }
        }

        private void checkBoxCopyMult_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCopyMult.Checked == true)
            {
                checkBoxCopyOne.Checked = false;
                groupBoxCopyOne.Enabled = false;                
                listBoxCopyLayerList.SelectionMode = SelectionMode.MultiExtended;
            }
        }

        private void checkBoxCopyOne_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCopyOne.Checked == true)
            {
                checkBoxCopyMult.Checked = false;
                groupBoxCopyOne.Enabled = true;               
                listBoxCopyLayerList.SelectionMode = SelectionMode.One;
                listBoxCopyLayerList.ClearSelected();
            }
        }

        private void listBoxCopyLayerList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkBoxCopyOne.Checked == true && listBoxCopyLayerList.SelectedItem != null)
            {
                textboxNewLayerName.Text = listBoxCopyLayerList.SelectedItem.ToString().Trim();
            }
        }
    }
}