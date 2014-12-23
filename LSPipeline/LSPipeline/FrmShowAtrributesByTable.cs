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

using System.Reflection;
using System.Collections;


namespace WorldGIS
{
    public partial class FrmShowAtrributesByTable : Form
    {
        GSOGlobeControl m_globeControl = null;
        GSOFeature m_feature = null;

        DataTable dt = null;
        ArrayList list = new ArrayList();
        public FrmShowAtrributesByTable(GSOGlobeControl globeControl,GSOFeature feature)
        {
            InitializeComponent();
            m_globeControl = globeControl;
            m_feature = feature;
        }

        private void FrmAtrributeMapping_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
          
            if (m_feature != null)
            { 
                try
                {
                    //ArrayList list = new ArrayList();
                    dt = new DataTable(m_feature.Name);
                    DataColumn dcName = new DataColumn("Name", typeof(string));
                    DataColumn dcValue = new DataColumn("Value", typeof(string));
                    dt.Columns.Add(dcName);
                    dt.Columns.Add(dcValue);                 
                    dt.Columns["Name"].ReadOnly = true;                    

                    for (int j = 0; j < m_feature.GetFieldCount(); j++)
                    {
                        DataRow dr = dt.NewRow();
                        GSOFieldDefn field = (GSOFieldDefn)m_feature.GetFieldDefn(j);
                        if (field != null)
                        {
                            dr["Name"] = field.Name;
                            object obj = m_feature.GetValue(j);
                            if (obj != null)
                            {
                                dr["Value"] = obj.ToString();
                                DateTime date = DateTime.Now.Date;
                                bool isDatetime = DateTime.TryParse(obj.ToString(), out date);
                                if (isDatetime)
                                {
                                    dr["Value"] = date.ToShortDateString();
                                    list.Add(j);
                                }
                            }
                        }
                        dt.Rows.Add(dr);
                    }
                    
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns[0].HeaderText = "属性名";
                    dataGridView1.Columns[1].HeaderText = "属性值";
                    //for (int i = 0; i < list.Count; i++)
                    //{
                    //    int index = int.Parse(list[i].ToString());
                    //    dataGridView1[1,index].ReadOnly = true;
                    //}       
                }
                catch (System.Exception exp)
                {
                    Log.PublishTxt(exp);
                }
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (m_feature != null)
            {
                //for (int i = 0; i < list.Count; i++)
                //{
                //    int index = int.Parse(list[i].ToString());
                //    dataGridView1[1, index].ReadOnly = false;
                //}       
                for (int j = 0; j < m_feature.GetFieldCount(); j++)
                {
                    GSOFieldDefn field = (GSOFieldDefn)m_feature.GetFieldDefn(j);
                    if (field != null)
                    {                       
                        //m_feature.SetFieldValue(j, dt.Rows[j][1].ToString());
                        m_feature.SetValue(dt.Rows[j][0].ToString().Trim(), dt.Rows[j][1].ToString().Trim());
                    }                    
                }
               
            }
            this.Close();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        { 
            if (e.RowIndex > -1)
            {
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
                }

                if (!bl)
                {
                    MessageBox.Show("您输入的格式不正确！", "提示");
                    dt.Rows[e.RowIndex][e.ColumnIndex] = m_feature.GetValue(e.RowIndex);
                    return;
                }
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            object obj = dt.Rows[e.RowIndex][e.ColumnIndex];
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
                    }
                }
            }
        }

        

        private void buttonNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
