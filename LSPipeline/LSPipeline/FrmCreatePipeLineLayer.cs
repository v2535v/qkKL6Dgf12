using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Collections;

namespace WorldGIS
{
    public partial class FrmCreatePipeLineLayer : Form
    {
        DataTable dt;
        //Dictionary<string,string) dic = 
        public FrmCreatePipeLineLayer()
        {
            InitializeComponent();
        
            dt = new DataTable();
            DataColumn dcName = new DataColumn("attriName", typeof(string));
            DataColumn dcType = new DataColumn("attriType", typeof(string));
            dt.Columns.Add(dcName);
            dt.Columns.Add(dcType);
        }

        private void buttonAddAttri_Click(object sender, EventArgs e)
        {
            //if (textBoxAttriName != "" && comboBoxAttriType.SelectedIndex >= 0)
            //{
            //    DataRow row = dt.NewRow();
            //    row["attriName"] = textBoxAttriName.Text;
            //    row["attriType"] = comboBoxAttriType.Text;
            //    dt.Rows.Add(row);
            //    listBoxDisplayAttri.DataSource = dt;
            //}
        }

        private void FrmAddPipeLine_Load(object sender, EventArgs e)
        {
            comboBoxAttriType.SelectedIndex = 2;
        }

        private void buttonDeleteAttri_Click(object sender, EventArgs e)
        {
            int index = listBoxDisplayAttri.SelectedIndex;
            dt.Rows.RemoveAt(index);
            listBoxDisplayAttri.DataSource = dt;
        }

        private void buttonCreatePipe_Click(object sender, EventArgs e)
        {

        }
    }
}
