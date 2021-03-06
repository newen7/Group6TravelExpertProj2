﻿/* Paul Teixeira
 * Modififes the products within a package
 */

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
    public partial class frmProductInPackage : Form
    {
        public int PkgId;
        public frmProductInPackage()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            List<Product> NewProductList = new List<Product>();
            foreach (Product p in lstProductSupplier.Items)
            {
                NewProductList.Add(p); //add all prodcuts to list
            }
            try
            {
                EditProductsDB.UpdateProducts(PkgId, NewProductList);
                MessageBox.Show("Successful!");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Cannot remove Products tied to packages/bookings /n /n" + ex);
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
            cboProduct.Items.Clear();
            lstSupport.Items.Clear();
            foreach (Product p in EditProductsDB.GetProducts(PkgId)) //adds all productList from first form into product list in this one
            {
                lstProductSupplier.Items.Add(p);
            }
            foreach (Product p in EditProductsDB.GetAllProducts()) //populates combo box with all products
            {
                cboProduct.Items.Add(p);
            }
            cboProduct.SelectedIndex = 0;//sets it to select the first item
            foreach (Supplier s in EditProductsDB.GetSuppliersOfProduct((string)cboProduct.SelectedItem)) //gets all suppliers of first product
            {
                lstSupport.Items.Add(s);
            }
        }

        private void cboProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            //load all suppliers of that prodcut
            lstSupport.Items.Clear();
            foreach (Supplier s in EditProductsDB.GetSuppliersOfProduct(((Product)cboProduct.SelectedItem).ProdName))
            {
                lstSupport.Items.Add(s);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //if selected on left is not null check for duplicate and if not pass into other list
            if (cboProduct.SelectedItem != null && lstSupport.SelectedItem != null)
            {
                int prodId = ((Product)(cboProduct.SelectedItem)).ProductId;
                int suppId = ((Supplier)(lstSupport.SelectedItem)).SuplierId;
                string prodName = ((Product)(cboProduct.SelectedItem)).ProdName;
                string suppName = ((Supplier)(lstSupport.SelectedItem)).SupName;
                Product ProductToAdd = new Product(prodId,prodName,suppName,suppId);
                if (lstProductSupplier.Items.Contains(ProductToAdd))
                {
                    MessageBox.Show("I am afraid product: "+ProductToAdd.ToString()+" has already been added.");
                }
                else
                {
                    lstProductSupplier.Items.Add(ProductToAdd);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //if selected on right is not null remove it
            if (lstProductSupplier.SelectedItem != null)
            {
                lstProductSupplier.Items.Remove(lstProductSupplier.SelectedItem);
            }
        }
    }
}
