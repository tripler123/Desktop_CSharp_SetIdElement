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
        public frmParameterName()
        {
            InitializeComponent();
        }

        private void frmParameterName_Load(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            setIdElement.next = true;
            setIdElement.paramName = txtNameParam.Text;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            setIdElement.next = false;
            Close();
        }
    }
}
