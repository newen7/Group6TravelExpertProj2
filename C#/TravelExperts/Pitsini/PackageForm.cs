// ------------------------------------------------------------------
// Pitsini Suwandechochai
// Description: Package form for searching and showing package information
// function to use: Search, Add, Modify and Delete package
//
// P.S.: function "Edit Products" event button was develop by Paul Teixiera
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
using System.Data.SqlClient;

namespace TravelExperts
{
    public partial class frmPackage : Form
    {
        int index = 0;
        int chosenPkgId = 1;    // keep id that chosen by selecting the package listbox
        Package aPackage;   // package for showing data in text boxes

        // need to use variable from modify form
        frmModifyPackage ModifyPackageForm = new frmModifyPackage(); 

        // Contain packageID and name) for showing in the packagelist
        List<Package> ListOfPackages = new List<Package>();
        List<Product> ListOfProducts = new List<Product>();

        public frmPackage()
        {
            InitializeComponent();
        }

        // ------------------------------------------------------------------
        // Paul Teixiera
        // ------------------------------------------------------------------
        private void btnEditProduct_Click(object sender, EventArgs e)
        {
            //opens editproducts and sends back list
            DialogResult result;
            frmProductInPackage ProductInPackageForm = new frmProductInPackage();
            if (txtPkgId.Text.Length>0) //is there any other checks for this? can we make pkgID nullable type?
            {
                ProductInPackageForm.PkgId = Convert.ToInt32(txtPkgId.Text); //this needs checking if I am doing validation on pkgform
                result = ProductInPackageForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                  //New's clear and reload functions 
                    aPackage = PackageDB.GetPackageByID(chosenPkgId);
                    DisplayPackageAndProduct();
                }
            }
            else MessageBox.Show("Package not selected");
        }

        // Pitsini
        private void btnAddPkg_Click(object sender, EventArgs e)
        {
            DialogResult result;
            //int resultPkgID;
            frmAddPackage AddPackageForm = new frmAddPackage();
            result = AddPackageForm.ShowDialog();

            // if user just came back from ModifyPkg Form
            if (result == DialogResult.OK)
            { 
                try
                {
                    // get the list of packages data from DB
                    ListOfPackages = PackageDB.GetListOfPackage();

                    chosenPkgId = AddPackageForm.newJustAddId;
                    aPackage = PackageDB.GetPackageByID(chosenPkgId);
                    DisplayListOfPackage();
                    DisplayPackageAndProduct();

                    // get first package as a default
                    lstAllPackage.SelectedIndex = lstAllPackage.Items.Count - 1;
                    index = lstAllPackage.SelectedIndex;
                    lstAllPackage.SelectedIndex = index;

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
        
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPackage_Load(object sender, EventArgs e)
        {            
            try
            {         
                // get the list of packages data from DB
                ListOfPackages = PackageDB.GetListOfPackage();
                DisplayListOfPackage();                
                txtPkgId.Focus();

                // get first package as a default
                lstAllPackage.SelectedIndex = index;
                aPackage = PackageDB.GetPackageByID(chosenPkgId);
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

        private void DisplayListOfPackage()
        {
            // clear the listbox & combo box
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
                    
                    // store index of listbox
                    index = lstAllPackage.SelectedIndex;
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

                // collect index of combo box and PackageID
                index = cboPkgName.SelectedIndex;
                chosenPkgId = aPackage.PackageId;
                lstAllPackage.SelectedIndex = index;    // hilights on listbox in the same packager
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
            chosenPkgId = aPackage.PackageId;
            txtPkgId.Text = aPackage.PackageId.ToString();
            cboPkgName.SelectedItem = aPackage.PkgName.ToString();
            txtStartDate.Text = aPackage.PkgStartDate.ToShortDateString();
            txtEndDate.Text = aPackage.PkgEndDate.ToShortDateString();
            rtxtDesc.Text = aPackage.PkgDesc;
            txtBasePrice.Text = aPackage.PkgBasePrice.ToString("c");
            txtAgencyCommission.Text = aPackage.PkgAgencyCommission.ToString("c");

            ListOfProducts = PackageDB.GetListOfProduct(aPackage.PackageId);
            lstProduct.Items.Clear();
            if (ListOfProducts != null)
                foreach (Product eachProduct in ListOfProducts)
                    lstProduct.Items.Add(eachProduct);
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                try
                {
                    aPackage = PackageDB.GetPackageByID(Convert.ToInt32(txtPkgId.Text));
                    if (aPackage != null)
                    {
                        DisplayPackageAndProduct();
                    }
                    else   // don't have PackageID that user try to search
                    {
                        MessageBox.Show("Package ID: " + txtPkgId.Text + " is not found in Database.");

                        txtPkgId.Focus();
                        txtPkgId.SelectAll();
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
       
                ResetData();            
        }
        
        private bool IsValidData()
        {
            return
                // validate packageID
                Validator.IsNotNull(txtPkgId, "Package ID: ") &&
                Validator.IsInt32(txtPkgId, "Package ID: ");
        }

        private void btnModPkg_Click(object sender, EventArgs e)
        {
            if (chosenPkgId != 0)
            {
                // send packageId to modify form
                ModifyPackageForm.selectedPkgId = chosenPkgId;
                                 

                // show Modify form
                DialogResult result;
                result = ModifyPackageForm.ShowDialog();

                // if user just came back from ModifyPkg Form
                if (result == DialogResult.OK)
                {                    
                    chosenPkgId = ModifyPackageForm.selectedPkgId;        

                    ModifyPackageForm.selectedPkgId = 0; // reset variable

                    // get the list of packages data from DB
                    ListOfPackages = PackageDB.GetListOfPackage();
                    DisplayListOfPackage();
                    txtPkgId.Focus();

                    // get first package as a default
                    lstAllPackage.SelectedIndex = index;
                    aPackage = PackageDB.GetPackageByID(chosenPkgId);
                    DisplayPackageAndProduct();
                }
            }
            else  // ask user to choose package before click modify button
                MessageBox.Show("Please select package before modify.");
        }

        // clear all data
        private void ResetData()
        {
            lstAllPackage.SelectedIndex = index;
            aPackage = PackageDB.GetPackageByID(chosenPkgId);
            DisplayPackageAndProduct();
        }
    }
}
