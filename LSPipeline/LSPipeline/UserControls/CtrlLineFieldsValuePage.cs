using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using GeoScene.Data;
using GeoScene.Globe;
using GeoScene.Engine;
using System.Collections;

namespace WorldGIS
{
    public partial class CtrlLineFieldsValuePage : UserControl
    {
        GSOGlobeControl mGlobeControl;
        GSOLayer mlayer;
        GSOFeature m_feature;

        public static DataTable dt = null;

        public CtrlLineFieldsValuePage(GSOFeature feature,GSOGlobeControl globeControl)
        {
            InitializeComponent();
            mGlobeControl = globeControl;
            m_feature = feature;
        }
        public CtrlLineFieldsValuePage(GSOFeature feature,GSOLayer layer, GSOGlobeControl globeControl)
        {
            InitializeComponent();
            mGlobeControl = globeControl;
            m_feature = feature;

            mlayer = layer;
        }
      
        private void CtrlLineFieldsValuePage_Load(object sender, EventArgs e)
        {
           
            if (m_feature != null)
            {
                try
                {
                    dt = new DataTable(m_feature.Name);
                    DataColumn dcName = new DataColumn("属性名", typeof(string));
                    DataColumn dcValue = new DataColumn("属性值", typeof(string));
                    dt.Columns.Add(dcName);
                    dt.Columns.Add(dcValue);
                    dt.Columns["属性名"].ReadOnly = true;
                    
                    if (m_feature.GetFieldCount() > 0)
                    {
                        for (int j = 0; j < m_feature.GetFieldCount(); j++)
                        {
                            DataRow dr = dt.NewRow();
                            GSOFieldDefn field = (GSOFieldDefn)m_feature.GetFieldDefn(j);
                            if (field != null)
                            {
                                dr["属性名"] = field.Name;
                                object obj = m_feature.GetValue(j);
                                if (obj != null)
                                {
                                    dr["属性值"] = obj.ToString();                                  
                                   
                                    if (obj.GetType() == typeof(DateTime))
                                    {
                                        DateTime date = DateTime.Parse(obj.ToString());
                                        dr["属性值"] = date.ToShortDateString();
                                        
                                    }
                                }
                            }
                            dt.Rows.Add(dr);
                        }
                    }

                    dataGridView1.DataSource = dt;
                    dataGridView1.ReadOnly = !mlayer.Editable;
                    dataGridView1.Columns[0].Width = 100;
                    dataGridView1.Columns[1].Width = 200;
                   
                }
                catch (System.Exception exp)
                {
                    Log.PublishTxt(exp);
                }
            }
        }

       

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            mGlobeControl.Globe.AddToEditHistroy(mlayer, m_feature, EnumEditType.Modify);

            bool bl = true;
            object obj = dt.Rows[e.RowIndex][e.ColumnIndex];
            GSOFieldDefn field = (GSOFieldDefn)m_feature.GetFieldDefn(e.RowIndex);
            switch (field.Type)
            {
                case EnumFieldType.Float:
                    float value = 0;
                    bl = float.TryParse(obj.ToString(), out value);
                    break;
                case EnumFieldType.Double:
                    double value1 = 0;
                    bl = double.TryParse(obj.ToString(), out value1);
                    break;
                case EnumFieldType.INT16:
                    Int16 value2 = 0;
                    bl = Int16.TryParse(obj.ToString(), out value2);
                    break;
                case EnumFieldType.INT32:
                    Int32 value3 = 0;
                    bl = Int32.TryParse(obj.ToString(), out value3);
                    break;
                case EnumFieldType.INT64:
                    Int64 value4 = 0;
                    bl = Int64.TryParse(obj.ToString(), out value4);
                    break;
                case EnumFieldType.Date:
                    DateTime dtime = DateTime.Now;
                    bl = DateTime.TryParse(obj.ToString(), out dtime);
                    break;
                case EnumFieldType.DateTime:
                    DateTime dtime1 = DateTime.Now;
                    bl = DateTime.TryParse(obj.ToString(), out dtime1);
                    break;
            }

            if (!bl)
            {
                MessageBox.Show("您输入的格式不正确！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dt.Rows[e.RowIndex][e.ColumnIndex] = m_feature.GetValue(e.RowIndex);
                if (m_feature.GetValue(e.RowIndex).GetType() == typeof(DateTime))
                {
                    dt.Rows[e.RowIndex][e.ColumnIndex] = ((DateTime)m_feature.GetValue(e.RowIndex)).ToShortDateString();
                }
                return;
            }
            else
            {
                m_feature.SetValue(e.RowIndex, dt.Rows[e.RowIndex][e.ColumnIndex]);
            }

        
          
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (mlayer != null && mlayer.Editable == true)
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0)
                {
                    return;
                }
                object obj = dt.Rows[e.RowIndex][e.ColumnIndex];
                if (obj.ToString().Length < 8)
                {
                    return;
                }
                DateTime date = DateTime.Now;
                bool bl = DateTime.TryParse(obj.ToString(), out date);
                if (bl)
                {
                    FrmSetDateTime dateTime = new FrmSetDateTime(obj.ToString());
                   
                    if (dateTime.ShowDialog() == DialogResult.OK)
                    {
                        if (dateTime.m_date != null)
                        {
                            dt.Rows[e.RowIndex][e.ColumnIndex] = dateTime.m_date;
                            
                            m_feature.SetValue(e.RowIndex, dateTime.d);
                        }
                    }
                }
            }
        }
    }
}
