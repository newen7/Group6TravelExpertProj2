using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelExperts
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmPackage_Click(object sender, EventArgs e)
        {
            DialogResult result;
            frmPackage PackageForm = new frmPackage();
            result = PackageForm.ShowDialog();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            DialogResult result;
            TravelExperts.Jon.SuppliersForm SuppliersForm = new Jon.SuppliersForm();
            result = SuppliersForm.ShowDialog();
        }
    }
}
