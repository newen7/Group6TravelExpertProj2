// ------------------------------------------------------------------
// Pitsini Suwandechochai
// Description: Main form to link all of forms together
// ------------------------------------------------------------------
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

        // Event - when user click "Packages" button
        private void frmPackage_Click(object sender, EventArgs e)
        {
            DialogResult result;
            frmPackage PackageForm = new frmPackage();
            result = PackageForm.ShowDialog();
        }

        //Event - when user click "Quit" button
        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Event - when user click "Suppliers" button
        private void btnSupplier_Click(object sender, EventArgs e)
        {
            DialogResult result;
            TravelExperts.Jon.SuppliersForm SuppliersForm = new Jon.SuppliersForm();
            result = SuppliersForm.ShowDialog();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            DialogResult result;
            TravelExperts_Porkodi.ProductFrom frmProduct = new TravelExperts_Porkodi.ProductFrom();
            result = frmProduct.ShowDialog();
        }
    }
}
