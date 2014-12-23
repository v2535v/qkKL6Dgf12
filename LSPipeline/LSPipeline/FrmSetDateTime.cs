using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace WorldGIS
{
    public partial class FrmSetDateTime : Form
    {

        public string m_date = "";
        public DateTime d = DateTime.Now;
        public FrmSetDateTime(string date)
        {
            InitializeComponent();

            m_date = date;
        }

        private void FrmDateTime_Load(object sender, EventArgs e)
        {
            textbox1.Text = m_date.ToString();

            RegistryKey rk;
            rk = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows NT\\CurrentVersion");
            string version = "当前操作系统版本：" + rk.GetValue("ProductName").ToString();
            if (!version.Contains("Windows XP"))
            {
                this.Width = 251;
                this.Height = 321;
                textbox1.Width = 151;
                groupBox1.Size = new Size(238, 14);
                groupBox1.Location = new Point(3, 242);
                buttonOk.Location = new Point(81,262);
                buttonNo.Location = new Point(163,262);
            }
        }

        //确定
        private void button1_Click(object sender, EventArgs e)
        {
            if (textbox1.Text != "")
            {
                m_date = textbox1.Text.Trim();                
                bool bl = DateTime.TryParse(m_date,out d);
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        //关闭
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();        
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            textbox1.Text = monthCalendar1.SelectionEnd.ToShortDateString();
        }
    }
}
 