using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TravelExperts
{
    public partial class frmPackage : Form
    {
        List<Package> allPackage;
        int currentPackageId;

        //Package packageFromDB
        List<Package> ListOfPackages = new List<Package>();
        public frmPackage()
        {
            InitializeComponent();
        }

        private void btnEditProduct_Click(object sender, EventArgs e)
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
                //EditProductsDB.UpdateProducts(pkgId, ProductInPackageForm.ProductList); //Updates list in database
                //right now this just updates the list
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
            ////faked products untill New populates it herself.
            //lstProduct.Items.Add(new Product(1, "Air", "SKYWAYS INTERNATIONAL", 5492));
            //lstProduct.Items.Add(new Product(1, "Air", "TRADE WINDS ASSOCIATES", 6505));
            //lstProduct.Items.Add(new Product(4, "Cruise", "SOUTH WIND TOURS LTD.", 2827));

            //load data from GetListOfPackage()
            try
            {

                // get package data from DB
                ListOfPackages = PackageDB.GetListOfPackage();
                DisplayListOfPackage();
            }
            catch (DBConcurrencyException)  // number of rows affected equals zero
            {
                MessageBox.Show("Concurrency error occurred. Some changes did not happen",
                    "Concurrency error");
            }
            catch (SqlException ex)  // SQL Server returns a warning or error
            {
                MessageBox.Show("Database error # " + ex.Number + ": " + ex.Message, ex.GetType().ToString());
            }
            catch (Exception ex)    // any other error
            {
                MessageBox.Show("Other unanticipated error # " + ex.Message, ex.GetType().ToString());
            }
            // check if the return is null -- show popup .. no data in database
        }

        private void DisplayListOfPackage()
        {
            allPackage = PackageDB.GetListOfPackage();

            // clear the listbox before add the list of packages in
            lstAllPackage.Items.Clear();

            if (allPackage != null)
            {
                foreach (Package eachPackage in allPackage)
                    lstAllPackage.Items.Add(eachPackage.PackageId + " --- " + eachPackage.PkgName);
            }
            else
                MessageBox.Show("Sorry, NO Package found in database.\nPlease check with your DBA.");
        }

        private void lstAllPackage_SelectedIndexChanged(object sender, EventArgs e)
        {
            //currentPackageId = lstAllPackage.SelectedItem.ToString();
        }
    }
}
