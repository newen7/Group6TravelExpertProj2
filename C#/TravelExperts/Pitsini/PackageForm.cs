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
        int chosenPkgId;
        Package aPackage;   // package for showing data in text boxes

        // Contain packageID and name) for showing in the packagelist
        List<Package> ListOfPackages = new List<Package>();
        List<Product> ListOfProducts = new List<Product>();

        public frmPackage()
        {
            InitializeComponent();
        }

        // Paul Teixiera
        private void btnEditProduct_Click(object sender, EventArgs e)
        {
            //opens editproducts and sends back list
            DialogResult result;
            frmProductInPackage ProductInPackageForm = new frmProductInPackage();
            foreach (Product p in ListOfProducts)   //takes prodcuts in list and puts it in my from            
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

        private void btnAddPkg_Click(object sender, EventArgs e)
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
            //allPackage = PackageDB.GetListOfPackage();

            // clear the listbox & combobox
            lstAllPackage.Items.Clear();
            cboPkgName.Items.Clear();

            if (ListOfPackages != null)
                foreach (Package eachPackage in ListOfPackages)
                {
                    lstAllPackage.Items.Add(eachPackage.PackageId + " --- " + eachPackage.PkgName);
                    cboPkgName.Items.Add(eachPackage.PkgName);
                }
            else
                MessageBox.Show("Sorry, NO Package found in database.\nPlease check with your DBA.");
        }

        private void lstAllPackage_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lstAllPackage.Items.Count > 0)
                {
                    string[] separators = new string[] { " --- " };
                    chosenPkgId = Convert.ToInt32(lstAllPackage.SelectedItem.ToString().Split(separators, StringSplitOptions.None)[0]);

                    aPackage = PackageDB.GetPackageByID(chosenPkgId);
                    DisplayPackageAndProduct();
                }
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
            
        }

        private void cboPkgName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                aPackage = PackageDB.GetPackageByName(cboPkgName.SelectedItem.ToString());
                DisplayPackageAndProduct();  
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
        }

        private void DisplayPackageAndProduct()
        {
            txtPkgId.Text = aPackage.PackageId.ToString();
            cboPkgName.SelectedItem = aPackage.PkgName.ToString();
            txtStartDate.Text = aPackage.PkgStartDate.ToShortDateString();
            txtEndDate.Text = aPackage.PkgEndDate.ToShortDateString();
            rtxtDesc.Text = aPackage.PkgDesc;
            txtBasePrice.Text = aPackage.PkgBasePrice.ToString("c");
            txtAgencyAdmission.Text = aPackage.PkgAgencyCommission.ToString("c");

            ListOfProducts = PackageDB.GetListOfProduct(aPackage.PackageId);
            lstProduct.Items.Clear();
            if (ListOfProducts != null)
                foreach (Product eachProduct in ListOfProducts)
                    lstProduct.Items.Add(eachProduct);
        }
    }
}
