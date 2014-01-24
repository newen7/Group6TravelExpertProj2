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
            //opens editproducts and sends back list
            DialogResult result;
            frmProductInPackage ProductInPackageForm = new frmProductInPackage();
            result = ProductInPackageForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                lstProduct.Items.Clear();
                foreach (Product p in ProductInPackageForm.ProductList)
                {
                    lstProduct.Items.Add(p);
                }
            }
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
