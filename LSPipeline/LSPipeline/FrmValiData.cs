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
using System.Collections;
using System.Xml;
using System.IO;

namespace WorldGIS
{
    public partial class FrmValiData : Form
    {
        private GSOGlobeControl ctl;
        private GSOLayer layerShp = null;

        private Hashtable en_cns = new Hashtable();
        private Hashtable fields_types = new Hashtable();

        private Hashtable gj_cns = new Hashtable();
        private Hashtable gj_types = new Hashtable();

        private Hashtable yb_cns = new Hashtable();
        private Hashtable yb_types = new Hashtable();

        private Hashtable fm_cns = new Hashtable();
        private Hashtable fm_types = new Hashtable();
        public FrmValiData(GSOGlobeControl _ctl)
        {
            InitializeComponent();
            ctl = _ctl;
        }

        private void FrmValiData_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < ctl.Globe.Layers.Count; i++)
            {
                GSOLayer layer = ctl.Globe.Layers[i];
                if (layer != null && System.IO.Path.GetExtension(layer.Name).ToLower() == ".shp")
                {
                    cmbLayerName.Items.Add(layer.Caption);
                }
            }
            cmbLayerName.SelectedIndex = -1;

            cmbLayerType.Items.Add("管线");
            cmbLayerType.Items.Add("工井");
            cmbLayerType.Items.Add("雨篦");
            cmbLayerType.Items.Add("阀门");

            string filename = Application.StartupPath + "\\FormText.xml";
            if (File.Exists(filename))
            {
                XmlTextReader XmlReader = new XmlTextReader(filename);
                try
                {
                    while (XmlReader.Read())
                    {
                        if (XmlReader.Name == "Field")
                        {
                            string str1 = XmlReader["label"];
                            string str3 = XmlReader["type"];
                            string str2 = XmlReader.ReadElementString();
                            en_cns.Add(str1, str2);
                            fields_types.Add(str1, str3);
                        }
                        else if (XmlReader.Name == "GongJing")
                        {
                            string str1 = XmlReader["label"];
                            string str3 = XmlReader["type"];
                            string str2 = XmlReader.ReadElementString();
                            gj_cns.Add(str1, str2);
                            gj_types.Add(str1, str3);
                        }
                        else if (XmlReader.Name == "YuBi")
                        {
                            string str1 = XmlReader["label"];
                            string str3 = XmlReader["type"];
                            string str2 = XmlReader.ReadElementString();
                            yb_cns.Add(str1, str2);
                            yb_types.Add(str1, str3);
                        }
                        else if (XmlReader.Name == "Valve")
                        {
                            string str1 = XmlReader["label"];
                            string str3 = XmlReader["type"];
                            string str2 = XmlReader.ReadElementString();
                            fm_cns.Add(str1, str2);
                            fm_types.Add(str1, str3);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnVali_Click(object sender, EventArgs e)
        {            
            if (cmbLayerName.SelectedItem == null)
            {
                MessageBox.Show("请选择一个shape图层！", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cmbLayerType.SelectedItem == null)
            {
                MessageBox.Show("请选择shape图层的类型！", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
           
            GSOLayer layerShp = ctl.Globe.Layers.GetLayerByCaption(cmbLayerName.SelectedItem.ToString().Trim());
            if (layerShp != null)
            {

                if (cmbLayerType.SelectedItem.ToString() == "管线")
                {
                    valiPipedata(layerShp);
                }
                if (cmbLayerType.SelectedItem.ToString() == "工井")
                {
                    valiGongJingdata(layerShp);
                }
                if (cmbLayerType.SelectedItem.ToString() == "雨篦")
                {
                    valiYBdata(layerShp);
                }
                if (cmbLayerType.SelectedItem.ToString() == "阀门")
                {
                    valiValvedata(layerShp);
                }
                if (txtMessage.Text == "")
                {
                    txtMessage.Text = "数据正确";
                }
            }
        }

        #region 验证
        private void valiValvedata(GSOLayer layer)
        {
            txtMessage.Text = "";
            if (layer != null)
            {
                GSOFeatureDataset featDataSet = layer.Dataset as GSOFeatureDataset;
                List<string> lstField = new List<string>();
                List<string> listFieldType_Text = new List<string>();
                for (int i = 0; i < featDataSet.FieldCount; i++)
                {
                    string fieldName = featDataSet.GetField(i).Name;
                    lstField.Add(fieldName);
                    if (fm_types.ContainsKey(fieldName))
                    {
                        string fieldType = fm_types[fieldName].ToString().ToUpper();
                        switch (featDataSet.GetField(i).Type)
                        {
                            case EnumFieldType.Text:
                                if (fieldType != "string".ToUpper())
                                {
                                    txtMessage.Text += "" + fieldName + "数据类型不正确\r\n";
                                }
                                listFieldType_Text.Add(fieldName);
                                break;
                            case EnumFieldType.INT32:
                                if (fieldType != "int".ToUpper() && fieldType != "double".ToUpper())
                                {
                                    txtMessage.Text += "" + fieldName + "数据类型不正确\r\n";
                                }
                                break;
                            case EnumFieldType.INT16:
                                if (fieldType != "int".ToUpper() && fieldType != "double".ToUpper())
                                {
                                    txtMessage.Text += "" + fieldName + "数据类型不正确\r\n";
                                }
                                break;
                            case EnumFieldType.Double:
                                if (fieldType != "double".ToUpper())
                                {
                                    txtMessage.Text += "" + fieldName + "数据类型不正确\r\n";
                                }
                                break;
                            case EnumFieldType.Date:
                                if (fieldType != "date".ToUpper())
                                {
                                    txtMessage.Text += "" + fieldName + "数据类型不正确\r\n";
                                }
                                break;
                        }
                    }
                    else
                    {
                        txtMessage.Text += "警告：配置文件中不包含\"" + fieldName + "\"字段\r\n";
                    }
                }
                if (!lstField.Contains("编号"))
                {
                    txtMessage.Text += "编号字段不存在！\r\n";
                }
                if (!lstField.Contains("模型路径"))
                {
                    txtMessage.Text += "模型路径字段不存在！\r\n";
                }
                if (!lstField.Contains("Z坐标"))
                {
                    txtMessage.Text += "Z坐标字段不存在！\r\n";
                }
                else
                {
                    GSOFieldAttr fieldZ = featDataSet.GetField("Z坐标");
                    if (fieldZ.Type != EnumFieldType.Double && fieldZ.Type != EnumFieldType.Float && fieldZ.Type != EnumFieldType.INT16 && fieldZ.Type != EnumFieldType.INT32)
                    {
                        txtMessage.Text += "\"Z坐标\"字段必须为数值类型 \r\n";
                    }
                }

                for (int i = 0; i < layer.GetAllFeatures().Length; i++)
                {
                    GSOFeature f = layer.GetAt(i);
                    for (int j = 0; j < listFieldType_Text.Count; j++)
                    {
                        string fieldName = listFieldType_Text[j];
                        if (fm_types.ContainsKey(fieldName))
                        {
                            if (f.GetValue(fieldName).ToString().Trim().Length > 8000)
                            {
                                txtMessage.Text += "ID为" + f.ID + "的要素的字段" + fieldName + "的长度大于8000 ！\r\n";
                            }
                        }
                    }
                }
            }
        }
        private void valiYBdata(GSOLayer layer)
        {
            txtMessage.Text = "";
            if (layer != null)
            {
                GSOFeatureDataset featDataSet = layer.Dataset as GSOFeatureDataset;
                List<string> lstField = new List<string>();
                List<string> listFieldType_Text = new List<string>();
                for (int i = 0; i < featDataSet.FieldCount; i++)
                {
                    string fieldName = featDataSet.GetField(i).Name;
                    lstField.Add(fieldName);
                    if (yb_types.ContainsKey(fieldName))
                    {
                        string fieldType = yb_types[fieldName].ToString().ToUpper();
                        switch (featDataSet.GetField(i).Type)
                        {
                            case EnumFieldType.Text:
                                if (fieldType != "string".ToUpper())
                                {
                                    txtMessage.Text += "" + fieldName + "数据类型不正确\r\n";
                                }
                                listFieldType_Text.Add(fieldName);
                                break;
                            case EnumFieldType.INT32:
                                if (fieldType != "int".ToUpper() && fieldType != "double".ToUpper())
                                {
                                    txtMessage.Text += "" + fieldName + "数据类型不正确\r\n";
                                }
                                break;
                            case EnumFieldType.INT16:
                                if (fieldType != "int".ToUpper() && fieldType != "double".ToUpper())
                                {
                                    txtMessage.Text += "" + fieldName + "数据类型不正确\r\n";
                                }
                                break;
                            case EnumFieldType.Double:
                                if (fieldType != "double".ToUpper())
                                {
                                    txtMessage.Text += "" + fieldName + "数据类型不正确\r\n";
                                }
                                break;
                            case EnumFieldType.Date:
                                if (fieldType != "date".ToUpper())
                                {
                                    txtMessage.Text += "" + fieldName + "数据类型不正确\r\n";
                                }
                                break;
                        }
                    }
                    else
                    {
                        txtMessage.Text += "警告：配置文件中不包含\"" + fieldName + "\"字段\r\n";
                    }
                }
                if (!lstField.Contains("编号"))
                {
                    txtMessage.Text += "编号字段不存在！\r\n";
                }
                if (!lstField.Contains("管线点编码"))
                {
                    txtMessage.Text += "管线点编码字段不存在！\r\n";
                }
                if (!lstField.Contains("井深"))
                {
                    txtMessage.Text += "井深字段不存在！\r\n";
                }
                else
                {
                    GSOFieldAttr fieldZ = featDataSet.GetField("井深");
                    if (fieldZ.Type != EnumFieldType.Double && fieldZ.Type != EnumFieldType.Float && fieldZ.Type != EnumFieldType.INT16 && fieldZ.Type != EnumFieldType.INT32)
                    {
                        txtMessage.Text += "\"井深\"字段必须为数值类型 \r\n";
                    }
                }
                if (!lstField.Contains("旋转角度"))
                {
                    txtMessage.Text += "旋转角度字段不存在！\r\n";
                }
                else
                {
                    GSOFieldAttr fieldZ = featDataSet.GetField("旋转角度");
                    if (fieldZ.Type != EnumFieldType.Double && fieldZ.Type != EnumFieldType.Float && fieldZ.Type != EnumFieldType.INT16 && fieldZ.Type != EnumFieldType.INT32)
                    {
                        txtMessage.Text += "\"旋转角度\"字段必须为数值类型 \r\n";
                    }
                }
                for (int i = 0; i < layer.GetAllFeatures().Length; i++)
                {
                    GSOFeature f = layer.GetAt(i);
                    for (int j = 0; j < listFieldType_Text.Count; j++)
                    {
                        string fieldName = listFieldType_Text[j];
                        if (yb_types.ContainsKey(fieldName))
                        {
                            if (f.GetValue(fieldName).ToString().Trim().Length > 8000)
                            {
                                txtMessage.Text += "名称为" + f.Name + "的要素的字段" + fieldName + "的长度大于8000 ！\r\n";
                            }
                        }
                    }
                }
            }
        }
        private void valiGongJingdata(GSOLayer layer)
        {
            txtMessage.Text = "";
            if (layer != null)
            {
                GSOFeatureDataset featDataSet = layer.Dataset as GSOFeatureDataset;
                List<string> lstField = new List<string>();
                List<string> listFieldType_Text = new List<string>();
                for (int i = 0; i < featDataSet.FieldCount; i++)
                {
                    string fieldName = featDataSet.GetField(i).Name;
                    lstField.Add(fieldName);
                    if (gj_types.ContainsKey(fieldName))
                    {
                        string fieldType = gj_types[fieldName].ToString().ToUpper();
                        switch (featDataSet.GetField(i).Type)
                        {
                            case EnumFieldType.Text:
                                if (fieldType != "string".ToUpper())
                                {
                                    txtMessage.Text += "" + fieldName + "数据类型不正确\r\n";
                                }
                                listFieldType_Text.Add(fieldName);
                                break;
                            case EnumFieldType.INT32:
                                if (fieldType != "int".ToUpper() && fieldType != "double".ToUpper())
                                {
                                    txtMessage.Text += "" + fieldName + "数据类型不正确\r\n";
                                }
                                break;
                            case EnumFieldType.INT16:
                                if (fieldType != "int".ToUpper() && fieldType != "double".ToUpper())
                                {
                                    txtMessage.Text += "" + fieldName + "数据类型不正确\r\n";
                                }
                                break;
                            case EnumFieldType.Double:
                                if (fieldType != "double".ToUpper())
                                {
                                    txtMessage.Text += "" + fieldName + "数据类型不正确\r\n";
                                }
                                break;
                            case EnumFieldType.Date:
                                if (fieldType != "date".ToUpper())
                                {
                                    txtMessage.Text += "" + fieldName + "数据类型不正确\r\n";
                                }
                                break;
                        }
                    }
                    else
                    {
                        txtMessage.Text += "警告：配置文件中不包含\"" + fieldName + "\"字段\r\n";
                    }
                    //if (fieldName == "井深")
                    //{
                    //    if (featDataSet.GetField(i).Type != EnumFieldType.Double)
                    //    {
                    //        txtMessage.Text += "井深字段数据类型不正确！\r\n";
                    //    }
                    //}
                    //if (fieldName == "管线点编码")
                    //{
                    //    if (featDataSet.GetField(i).Type != EnumFieldType.Double)
                    //    {
                    //        txtMessage.Text += "管线点编码字段数据类型不正确！\r\n";
                    //    }
                    //}
                }
                if (!lstField.Contains("编号"))
                {
                    txtMessage.Text += "编号字段不存在！\r\n";
                }
                if (!lstField.Contains("管线点编码"))
                {
                    txtMessage.Text += "管线点编码字段不存在！\r\n";
                }
                if (!lstField.Contains("井深"))
                {
                    txtMessage.Text += "井深字段不存在！\r\n";
                }
                else
                {
                    GSOFieldAttr fieldZ = featDataSet.GetField("井深");
                    if (fieldZ.Type != EnumFieldType.Double && fieldZ.Type != EnumFieldType.Float && fieldZ.Type != EnumFieldType.INT16 && fieldZ.Type != EnumFieldType.INT32)
                    {
                        txtMessage.Text += "\"井深\"字段必须为数值类型 \r\n";
                    }
                }
                for (int i = 0; i < layer.GetAllFeatures().Length; i++)
                {
                    GSOFeature f = layer.GetAt(i);
                    for (int j = 0; j < listFieldType_Text.Count; j++)
                    {
                        string fieldName = listFieldType_Text[j];
                        if (gj_types.ContainsKey(fieldName))
                        {
                            if (f.GetValue(fieldName).ToString().Trim().Length > 8000)
                            {
                                txtMessage.Text += "名称为" + f.Name + "的要素的字段" + fieldName + "的长度大于8000 ！\r\n";
                            }
                        }
                    }
                }
            }
        }
        private void valiPipedata(GSOLayer layer)
        {
            txtMessage.Text = "";
            if (layer != null)
            {
                GSOFeatureDataset featDataSet = layer.Dataset as GSOFeatureDataset;
                List<string> lstField = new List<string>();
                List<string> listFieldType_Text = new List<string>();
                for (int i = 0; i < featDataSet.FieldCount; i++)
                {
                    string fieldName = featDataSet.GetField(i).Name;
                    lstField.Add(fieldName);
                    if (fields_types.ContainsKey(fieldName))
                    {
                        string fieldType = fields_types[fieldName].ToString().ToUpper();
                        switch (featDataSet.GetField(i).Type)
                        {
                            case EnumFieldType.Text:
                                if (fieldType != "string".ToUpper())
                                {
                                    txtMessage.Text += "" + fieldName + "数据类型不正确\r\n";
                                }
                                listFieldType_Text.Add(fieldName);
                                break;
                            case EnumFieldType.INT32:
                                if (fieldType != "int".ToUpper() && fieldType != "double".ToUpper())
                                {
                                    txtMessage.Text += "" + fieldName + "数据类型不正确\r\n";
                                }
                                break;
                            case EnumFieldType.INT16:
                                if (fieldType != "int".ToUpper() && fieldType != "double".ToUpper())
                                {
                                    txtMessage.Text += "" + fieldName + "数据类型不正确\r\n";
                                }
                                break;
                            case EnumFieldType.Double:
                                if (fieldType != "double".ToUpper())
                                {
                                    txtMessage.Text += "" + fieldName + "数据类型不正确\r\n";
                                }
                                break;
                            case EnumFieldType.Date:
                                if (fieldType != "date".ToUpper())
                                {
                                    txtMessage.Text += "" + fieldName + "数据类型不正确\r\n";
                                }
                                break;
                        }
                    }
                    else
                    {
                        txtMessage.Text += "警告：配置文件中不包含\"" + fieldName + "\"字段\r\n";
                    }
                }
                if (!lstField.Contains("Deep1"))
                {
                    txtMessage.Text += "Deep1字段不存在！\r\n";
                }
                else
                {
                    GSOFieldAttr fieldDeep1 = featDataSet.GetField("Deep1");
                    if (fieldDeep1.Type != EnumFieldType.Double && fieldDeep1.Type != EnumFieldType.Float && fieldDeep1.Type != EnumFieldType.INT16 && fieldDeep1.Type != EnumFieldType.INT32)
                    {
                        txtMessage.Text += "Deep1字段必须为数值类型\r\n";
                    }
                }
                if (!lstField.Contains("Deep2"))
                {
                    txtMessage.Text += "Deep2字段不存在！\r\n";
                }
                else
                {
                    GSOFieldAttr fieldDeep1 = featDataSet.GetField("Deep2");
                    if (fieldDeep1.Type != EnumFieldType.Double && fieldDeep1.Type != EnumFieldType.Float && fieldDeep1.Type != EnumFieldType.INT16 && fieldDeep1.Type != EnumFieldType.INT32)
                    {
                        txtMessage.Text += "Deep2字段必须为数值类型\r\n";
                    }
                }
                if (!lstField.Contains("Diameter"))
                {
                    txtMessage.Text += "Diameter字段不存在！\r\n";
                }
                else
                {
                    GSOFieldAttr fieldDeep1 = featDataSet.GetField("Diameter");
                    if (fieldDeep1.Type != EnumFieldType.Double && fieldDeep1.Type != EnumFieldType.Float && fieldDeep1.Type != EnumFieldType.INT16 && fieldDeep1.Type != EnumFieldType.INT32)
                    {
                        txtMessage.Text += "Diameter字段必须为数值类型\r\n";
                    }
                }
                if (!lstField.Contains("Handle"))
                {
                    txtMessage.Text += "Handle字段不存在！\r\n";
                }
                List<string> lstHandle = new List<string>();
                for (int i = 0; i < layer.GetAllFeatures().Length; i++)
                {
                    GSOFeature f = layer.GetAt(i);
                    for (int j = 0; j < listFieldType_Text.Count; j++)
                    {
                        string fieldName = listFieldType_Text[j];
                        if (fields_types.ContainsKey(fieldName))
                        {
                            if (f.GetValue(fieldName).ToString().Trim().Length > 8000)
                            {
                                txtMessage.Text += "ID为" + f.ID + "的要素的字段" + fieldName + "的长度大于8000 ！\r\n";
                            }
                        }
                    }
                    if (f.GetFieldAsFloat("Diameter") <= 0)
                    {
                        txtMessage.Text += "ID为" + f.ID + "\"Diameter\"字段中的值必须大于0 \r\n";
                    }
                    if (!lstHandle.Contains(f.GetFieldAsString("Handle")))
                    {
                        lstHandle.Add(f.GetFieldAsString("Handle"));
                    }
                    else
                    {
                        txtMessage.Text += "ID为" + f.ID + "的\"Handle\"字段中的值重复\r\n";
                    }
                }
            }
        }

        #endregion

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonXExportErrorMessage_Click(object sender, EventArgs e)
        {
            if (txtMessage.Text == "")
            {
                MessageBox.Show("错误信息为空！", "提示");
                return;
            }
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "*.txt|*.txt";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string errorFilePath = dlg.FileName;
                string strErrorMessage = txtMessage.Text.Trim();
                StreamWriter writer = new StreamWriter(errorFilePath, false);
                writer.Write(strErrorMessage);
                writer.Close();
                MessageBox.Show("导出成功!", "提示");
            }
        }

        private void FrmValiData_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (layerShp != null)
            {
                ctl.Globe.Layers.Remove(layerShp);
            }
        }
    }
}
