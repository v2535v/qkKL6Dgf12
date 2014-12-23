using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WorldGIS
{
    public partial class FrmMessageShow : Form
    {
        string errorMessage = "";
        public FrmMessageShow(string _errorMessage)
        {
            errorMessage = _errorMessage;
            InitializeComponent();
        }

        private void FrmErrorMessageShow_Load(object sender, EventArgs e)
        {
            textBoxErrorMessage.Text = errorMessage;
        }
    }
}
