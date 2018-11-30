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
    public partial class ExportForm : System.Windows.Forms.Form
    {
        public ExportForm()
        {
            InitializeComponent();
        }
        public ExportForm(int cantTotal)
        {
            InitializeComponent();

            pgbProceso.Minimum = 0;
            pgbProceso.Maximum = cantTotal;
            pgbProceso.Value = 0;
            Show();
            Application.DoEvents();           
        }

        public void Increment(int cantTotal)
        {

            pgbProceso.Value = pgbProceso.Value + 1;
            txtCount.Text = pgbProceso.Value.ToString() + " de " + cantTotal.ToString() + " elementos";
            Application.DoEvents();         
            
        }

        private void ExportForm_Load(object sender, EventArgs e)
        {

        }
    }
}
