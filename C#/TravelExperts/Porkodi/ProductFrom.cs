//Author:Porkodi
//Created date: Jan-30-2014
//Created GUI C# in  webform for Product 
//Version: 1.0
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelExperts_Porkodi
{
    public partial class ProductFrom : Form
    {
       // private Product;
        public ProductFrom()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DialogResult result;
            ProductAddForm frmProductAdd = new ProductAddForm();
            result = frmProductAdd.ShowDialog();
        }
        //when  main form start load, all product will display 
        private void ProductFrom_Load(object sender, EventArgs e)
        {
            List<Product> ProductList = ProductDB.GetProducts();
            foreach (Product product in ProductList)
            {
                lstAllProducts.Items.Add(product.ProductId + "-" + product.ProdName);
            }
        }
        //when search button click  display only one product --When wild card "*"in search textbox, the listbox display all product name with Id
  
        private void btnSearch_Click(object sender, EventArgs e)
        {

            if (txtPkgId.Text == null || txtPkgId.Text == "")
            {
                MessageBox.Show("Invalid Product Id");
                return;
            }
            else
            {
                if (txtPkgId.Text == "*")
                {
                    lstAllProducts.Items.Clear();
                    List<Product> ProductList = ProductDB.GetProducts();
                    foreach (Product product in ProductList)
                    {
                        lstAllProducts.Items.Add(product.ProductId + "-" + product.ProdName);
                    }
                }
                else
                {
                    lstAllProducts.Items.Clear();
                    Product product = ProductDB.GetProduct(Convert.ToInt32(txtPkgId.Text));
                    lstAllProducts.Items.Add(product.ProductId + "-" + product.ProdName);
                }
            }
        }

         //before delete the product Confirm to the user 
        private void btnDelete_Click(object sender, EventArgs e)
        
        {

            DialogResult result = MessageBox.Show("Delete" + lstAllProducts.SelectedItem + "?", "Confirm Delete",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                ProductDB.DeleteProduct(Convert.ToInt32(lstAllProducts.SelectedItem.ToString().Split('-')[0]));

                lstAllProducts.Items.Remove(lstAllProducts.SelectedItem);
                MessageBox.Show("Selected Product Deleted");
            }
    
       
        }
    }
}     
         
             


      

 