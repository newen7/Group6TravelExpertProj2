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
    public partial class frmPackage : Form
    {
        public frmPackage()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult result;
            frmProductInPackage ProductInPackageForm = new frmProductInPackage();
            result = ProductInPackageForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result;
            frmAddPackage AddPackageForm = new frmAddPackage();
            result = AddPackageForm.ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
