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
            foreach(Product p in lstProduct.Items) //takes prodcuts in list and puts it in my from
            {
                ProductInPackageForm.ProductList.Add(p);
            }  
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

        private void frmPackage_Load(object sender, EventArgs e)
        {
            //faked products untill New populates it herself.
            lstProduct.Items.Add(new Product(1, "Air", "SKYWAYS INTERNATIONAL", 5492));
            lstProduct.Items.Add(new Product(1, "Air", "TRADE WINDS ASSOCIATES", 6505));
            lstProduct.Items.Add(new Product(4, "Cruise", "SOUTH WIND TOURS LTD.", 2827));
        }
    }
}
