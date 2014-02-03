//Author:PORKODI
//Created date: Jan-29-2014
//This is for Product Add GUI
//This GUI is going to be use  add product and  search product  
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
    public partial class ProductAddForm : Form
    {
        public ProductAddForm()
        {
            InitializeComponent();
        }
        //cancel the add product 
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // When you done save "successful" go to  "ADD FORM" in Search button "*" use wildcard Then can see "new add Product"
        private void btnSave_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            product.ProdName = txtProdName.Text;
            ProductDB.AddProduct(product);
            MessageBox.Show("Successful!");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

 