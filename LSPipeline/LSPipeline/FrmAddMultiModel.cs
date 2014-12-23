using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;

namespace WorldGIS
{
    public partial class FrmAddMultiModel : Form
    {
        public ArrayList m_arryFileSel;
        public FrmAddMultiModel()
        {
            InitializeComponent();
            m_arryFileSel=new ArrayList();
        }

        private void AddMultiModeDlg_Load(object sender, EventArgs e)
        {

        }

        private void checkBoxEntireDir_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxSubDir.Enabled = checkBoxEntireDir.Checked;
            textBoxSrcPath.Text = "";
            m_arryFileSel.Clear();
            
        }

        private void buttonSrcPath_Click(object sender, EventArgs e)
        {
            if (checkBoxEntireDir.Checked)
            {
               FolderBrowserDialog dlg=new FolderBrowserDialog();
               if (dlg.ShowDialog() == DialogResult.OK)
                {
                    m_arryFileSel.Clear();
                    textBoxSrcPath.Text = dlg.SelectedPath;
                    RecurseFindDirFile(dlg.SelectedPath,checkBoxSubDir.Checked);
                }

            }
            else
            {
                m_arryFileSel.Clear();
                OpenFileDialog dlg = new OpenFileDialog();

                String strContent = "";
                dlg.Multiselect = true;
                dlg.Filter = "*.gcm|*.gcm|*.gse|*.gse|*.gsez|*.gsez|*.3ds|*.3ds|*.obj|*.obj|*.3d|*3d||";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    int nCount=dlg.FileNames.GetLength(0);
                    for (int i = 0; i < nCount; i++)
                    {
                        m_arryFileSel.Add(dlg.FileNames[i]);
                        strContent = strContent + dlg.FileNames[i] + ";"; 

                    }
                    textBoxSrcPath.Text = strContent;
                }


            }
        }
        private void RecurseFindDirFile(String strDir,Boolean bRecurseIntoSubDir)
        {
            DirectoryInfo Dir = new DirectoryInfo(strDir);

            try
            {
                if (bRecurseIntoSubDir)
                {
                    foreach (DirectoryInfo d in Dir.GetDirectories())     //查找子目录  
                    {
                        RecurseFindDirFile(d.FullName, bRecurseIntoSubDir);
                    }
                }
              
                foreach (FileInfo f in Dir.GetFiles("*.* ")) //查找文件
                {
                    string strExt = f.Extension.ToLower();
                    if (strExt == ".gcm")
                    {
                        m_arryFileSel.Add(f.FullName);
                    }
                }
            }
            catch (Exception e)
            {
                Log.PublishTxt(e);
                MessageBox.Show(e.Message);
            }


        }

        private void buttonOk_Click(object sender, EventArgs e)
        {

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            m_arryFileSel.Clear();
        }
    }
}
