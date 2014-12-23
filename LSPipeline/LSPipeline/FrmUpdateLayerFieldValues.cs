using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using GeoScene.Data;
using GeoScene.Engine;
using GeoScene.Globe;
using System.Data.SqlClient;
using System.IO;
using System.Xml;

namespace WorldGIS
{
    public partial class FrmUpdateLayerFieldValues : Form
    {
        private GSOGlobeControl ctl;
        int changeCount = 1;
        public FrmUpdateLayerFieldValues(GSOGlobeControl ctl)
        {
            InitializeComponent();
            this.ctl = ctl;

            for (int j = 0; j < ctl.Globe.Layers.Count; j++) 
            {
                comboBoxLayerSource.Items.Add(ctl.Globe.Layers[j].Caption);
                comboBoxLayerTarget.Items.Add(ctl.Globe.Layers[j].Caption);
            }
            comboBoxChangeSource1.Name = "comboBoxChangeSource1";
            comboBoxChangeTarget1.Name = "comboBoxChangeTarget1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBoxLayer1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GSOLayer l = ctl.Globe.Layers[comboBoxLayerSource.SelectedIndex];
            GSOFeatureDataset flayer = l.Dataset as GSOFeatureDataset;
            comboBoxFieldSource.Items.Clear();
            comboBoxChangeSource1.Items.Clear();
            for (int j = 0; j < flayer.FieldCount; j++)
            {
                comboBoxFieldSource.Items.Add(flayer.GetField(j).Name);
                comboBoxChangeSource1.Items.Add(flayer.GetField(j).Name);               
            }
        }

        private void comboBoxLayer2_SelectedIndexChanged(object sender, EventArgs e)
        {
            GSOLayer l = ctl.Globe.Layers[comboBoxLayerTarget.SelectedIndex];
            GSOFeatureDataset flayer = l.Dataset as GSOFeatureDataset;
            comboBoxFiledTarget.Items.Clear();
            comboBoxChangeTarget1.Items.Clear();
            for (int j = 0; j < flayer.FieldCount; j++)
            {
                comboBoxFiledTarget.Items.Add(flayer.GetField(j).Name);
                comboBoxChangeTarget1.Items.Add(flayer.GetField(j).Name);                
            }
        }

        private bool isSameType(GSOFeatureDataset sourceDataset, string fieldSourceName,GSOFeatureDataset targetDataset, string fieldTargetName)
        {
            if (sourceDataset == null || targetDataset == null)
            {
                return false;
            }
            GSOFieldAttr sourceField = sourceDataset.GetField(fieldSourceName);
            GSOFieldAttr targetField = targetDataset.GetField(fieldTargetName);
            if (sourceField == null || targetField == null)
            {
                return false;
            }
            if (sourceField.Type == targetField.Type)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GSOLayer l1 = ctl.Globe.Layers[comboBoxLayerSource.SelectedIndex];
            GSOFeatureDataset flayer1 = l1.Dataset as GSOFeatureDataset;
            GSOLayer l2 = ctl.Globe.Layers[comboBoxLayerTarget.SelectedIndex];
            GSOFeatureDataset flayer2 = l2.Dataset as GSOFeatureDataset;

            string sourceIDFieldName = comboBoxFieldSource.SelectedItem.ToString().Trim();
            string targetIDFieldName = comboBoxFiledTarget.SelectedItem.ToString().Trim();
            if (sourceIDFieldName == null || targetIDFieldName == null)
            {
                MessageBox.Show("请选择唯一标识字段！","提示");
                return;
            }
            if(isSameType(flayer1,sourceIDFieldName,flayer2,targetIDFieldName) == false)
            {
                MessageBox.Show("请选择类型相同的唯一标识字段！", "提示");
                return;
            }
            //for (int i = 1; i <= changeCount; i++)
            { 
                string sourceChangeFieldName = comboBoxChangeSource1.SelectedItem == null ? "" : comboBoxChangeSource1.SelectedItem.ToString().Trim();
                string targetChangeFieldName = comboBoxChangeTarget1.SelectedItem == null ? "" : comboBoxChangeTarget1.SelectedItem.ToString().Trim();
                if (sourceChangeFieldName == "" || targetChangeFieldName == "")
                {
                    MessageBox.Show("请选择要修改的字段！", "提示");
                    return;
                }
                if (isSameType(flayer1, sourceChangeFieldName, flayer2, targetChangeFieldName) == false)
                {
                    MessageBox.Show("请选择类型相同的要修改的字段！", "提示");
                    return;
                }
                for (int j = 0; j < flayer1.GetAllFeatures().Length; j++)
                {
                    if (flayer1.GetFeatureAt(j) == null)
                    {
                        continue;
                    }
                    object fieldValue = flayer1.GetFeatureAt(j).GetValue(sourceIDFieldName);
                    GSOFeatures targetLayerFeatures = flayer2.GetFeatureByFieldValue(targetIDFieldName, fieldValue.ToString().Trim(),true);
                    if (targetLayerFeatures != null)
                    {
                        for (int m = 0; m < targetLayerFeatures.Length; m++)
                        {
                            GSOFeature targetLayerFeature = targetLayerFeatures[m];
                            if (targetLayerFeature != null)
                            {
                                fieldValue = flayer1.GetFeatureAt(j).GetValue(sourceChangeFieldName);
                                if (flayer1.GetField(sourceChangeFieldName) != null)
                                {
                                    switch (flayer1.GetField(sourceChangeFieldName).Type)
                                    { 
                                        case EnumFieldType.Double:
                                            double dFieldValue = 0.0;
                                            if (double.TryParse(fieldValue.ToString(), out dFieldValue) == true)
                                            {
                                                targetLayerFeature.SetFieldValue(targetChangeFieldName, dFieldValue);
                                            }
                                            break;
                                        case EnumFieldType.INT32:
                                            int intFieldValue = 0;
                                            if (int.TryParse(fieldValue.ToString(), out intFieldValue) == true)
                                            {
                                                targetLayerFeature.SetFieldValue(targetChangeFieldName, intFieldValue);
                                            }
                                            break;
                                        case EnumFieldType.DateTime:
                                            DateTime datatimeFieldValue = DateTime.Now ;
                                            if (DateTime.TryParse(fieldValue.ToString(), out datatimeFieldValue) == true)
                                            {
                                                targetLayerFeature.SetFieldValue(targetChangeFieldName, datatimeFieldValue);
                                            }
                                            break;
                                        case EnumFieldType.Text:                                            
                                            targetLayerFeature.SetFieldValue(targetChangeFieldName, fieldValue.ToString());
                                            break;
                                    }                                    
                                }
                            }
                        }
                    }
                }
            }
            MessageBox.Show("修改成功！","提示");           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Height += 50;
            ComboBox combo1 = new ComboBox();
            ComboBox combo2 = new ComboBox();
            combo1.Size = comboBoxChangeSource1.Size;
            combo2.Size = comboBoxChangeSource1.Size;
            combo1.Location = new Point(24,this.Height-118);
            combo2.Location=new Point(170,this.Height-118);
            combo1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            combo2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            Point p = button1.Location;
            p.Y = this.Height - 73;
            button1.Location = p;
            p = button2.Location;
            p.Y = this.Height - 73;
            button2.Location = p;
            p = button3.Location;
            p.Y = this.Height - 73;
            button3.Location = p;
            changeCount++;
            this.Controls.Add(combo1);
            this.Controls.Add(combo2);
            for (int j = 0; j < comboBoxChangeSource1.Items.Count; j++) 
            {
                combo1.Items.Add(comboBoxChangeSource1.Items[j]);
            }

            for (int j = 0; j < comboBoxChangeTarget1.Items.Count; j++) 
            {
                combo2.Items.Add(comboBoxChangeTarget1.Items[j]);
            }
            combo1.Name = "comboBoxChangeSource" + changeCount;
            combo2.Name = "comboBoxChangeTarget" + changeCount;
        }
    }
}
