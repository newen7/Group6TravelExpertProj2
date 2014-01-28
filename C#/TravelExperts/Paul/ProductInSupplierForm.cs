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
    public partial class frmProductInSupplier : Form
    {
        public Supplier SupplierToEdit;
        public frmProductInSupplier()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            List<Product> NewProductList = new List<Product>();
            foreach (Product p in lstSuppliersProducts.Items)
            {
                NewProductList.Add(p); //add all prodcuts to list
            }
            //EditProductsDB.UpdateProducts(PkgId, NewProductList);
            try
            {
                EditProductsDB.UpdateProductsofSupplier(SupplierToEdit.SuplierId, NewProductList);
                MessageBox.Show("Successful!");
            }
            catch
            {
                MessageBox.Show("Cannot delete Products that are in packages!");
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmProductInPackage_Load(object sender, EventArgs e)
        {
            //load all products
            lstAllProducts.Items.Clear();
            foreach (Product p in EditProductsDB.GetProductsOfSupplier(SupplierToEdit.SuplierId)) //adds all productList from first form into product list in this one
            {
                lstSuppliersProducts.Items.Add(p);
            }
            foreach (Product p in EditProductsDB.GetAllProducts())
            {
                lstAllProducts.Items.Add(p);
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //if selected on left is not null check for duplicate and if not pass into other list
            if (lstAllProducts.SelectedItem != null)
            {
                int productId = ((Product)(lstAllProducts.SelectedItem)).ProductId;
                string prodName = ((Product)(lstAllProducts.SelectedItem)).ProdName;
                Product ProductToAdd = new Product(productId, prodName, SupplierToEdit.SupName, SupplierToEdit.SuplierId);
                if (lstSuppliersProducts.Items.Contains(ProductToAdd))
                {
                    MessageBox.Show("I am afraid product: "+ProductToAdd.ToString()+" has already been added.");
                }
                else
                {
                    lstSuppliersProducts.Items.Add(ProductToAdd);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //if selected on right is not null remove it
            if (lstSuppliersProducts.SelectedItem != null)
            {
                lstSuppliersProducts.Items.Remove(lstSuppliersProducts.SelectedItem);
            }
        }
    }
}
