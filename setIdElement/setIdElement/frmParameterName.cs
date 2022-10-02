using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace setIdElement
{
    public partial class frmParameterName : Form
    {
        private bool okPressed { get; set; }
        private string paramName { get; set; }

        public string ParamName
        {
            get { return paramName; }
        }

        public bool OkPressed
        {
            get { return okPressed; }
        }


        public frmParameterName()
        {
            InitializeComponent();
        }


        private void btnOk_Click(object sender, EventArgs e)
        {
            okPressed = true;
            paramName = txtNameParam.Text;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            okPressed = false;
            Close();
        }
    }
}
