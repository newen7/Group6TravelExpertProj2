// ------------------------------------------------------------------
// Pitsini Suwandechochai
// Description: Package form for searching and showing package information
// function to use: Search, Add, Modify and Delete package
//
// P.S.: function "Edit Products" event button was developed by Paul Teixiera
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
        int index = 0;  // keeps selected index for both combo box and list box
        int chosenPkgId = 1;    // keeps packageID that has been chosen, default by 1
        Package aPackage;   // package for showing data in text boxes

        // need to use variable refer to "ModifyPackageForm"
        frmModifyPackage ModifyPackageForm = new frmModifyPackage(); 

        // Contain packageID and name for showing in the packagelist
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
                    //clear and reload functions 
                    aPackage = PackageDB.GetPackageByID(chosenPkgId);
                    DisplayPackageAndProduct();
                }
            }
            else MessageBox.Show("Package not selected");
        }

        // ------------------------------------------------------------------
        // Pitsini Suwandechochai
        // Description: Event - when user click "Add" button
        // ------------------------------------------------------------------
        private void btnAddPkg_Click(object sender, EventArgs e)
        {
            DialogResult result;    // needs returning result from "AddPackageForm" (DialogResult.OK)
            frmAddPackage AddPackageForm = new frmAddPackage(); // create form object
            result = AddPackageForm.ShowDialog();   // show "AddPackageForm" form as a dialob and get DialogResult back

            if (result == DialogResult.OK)  // Checks if user has a successful added package
            { 
                try
                {
                    // calls method "GetListOfPackage()" from PackageDB and keep the result in "ListOfPackages"
                    ListOfPackages = PackageDB.GetListOfPackage();

                    chosenPkgId = AddPackageForm.newJustAddId;  // keeps packageID that user just added in this variable
                    aPackage = PackageDB.GetPackageByID(chosenPkgId);   // get package data from database by using packageID
                    DisplayListOfPackage(); // display list of the package in the combo box and list box
                    DisplayPackageAndProduct(); // display package data in the textboxes and product in the products listbox

                    // get first package as a default
                    lstAllPackage.SelectedIndex = lstAllPackage.Items.Count - 1;    // set the last package as a selectedIndex
                    index = lstAllPackage.SelectedIndex;    // keeps the index in variable

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

        // ------------------------------------------------------------------
        // Pitsini Suwandechochai
        // Description: Event - when user click "Cancel" button
        // ------------------------------------------------------------------
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();   // close this form
        }

        // ------------------------------------------------------------------
        // Pitsini Suwandechochai
        // Description: Event - When the form is loaded
        // ------------------------------------------------------------------
        private void frmPackage_Load(object sender, EventArgs e)
        {            
            try
            {
                // calls method "GetListOfPackage()" from PackageDB and keep the result in "ListOfPackages"
                ListOfPackages = PackageDB.GetListOfPackage();

                DisplayListOfPackage(); // display list of package in combo box and listbox       
                txtPkgId.Focus();       // set focus on PackageId textbox

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

        // ------------------------------------------------------------------
        // Pitsini Suwandechochai
        // Description: function -- for displaying package list from database
        // ------------------------------------------------------------------
        private void DisplayListOfPackage()
        {
            // clear the listbox & combo box
            lstAllPackage.Items.Clear();
            cboPkgName.Items.Clear();

            // make sure the list is not "null"
            if (ListOfPackages != null)

                // put each package into listbox and combo box
                foreach (Package eachPackage in ListOfPackages)
                {
                    lstAllPackage.Items.Add(eachPackage.PackageId + " --- " + eachPackage.PkgName);
                    cboPkgName.Items.Add(eachPackage.PkgName);
                }

            // if list doesn't have data
            else
                MessageBox.Show("Sorry, NO Package found in database.\nPlease check with your DBA.");
        }

        // ------------------------------------------------------------------
        // Pitsini Suwandechochai
        // Description: event -- everytime user choose a package on the listbox
        // ------------------------------------------------------------------
        private void lstAllPackage_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // make sure it has package list
                if (lstAllPackage.Items.Count > 0)
                {
                    // split the packageID out of the list that user have been chosen, keep it in "chosenPkgId" variable
                    string[] separators = new string[] { " --- " };
                    chosenPkgId = Convert.ToInt32(lstAllPackage.SelectedItem.ToString().Split(separators, StringSplitOptions.None)[0]);

                    // get package data from database and display it
                    aPackage = PackageDB.GetPackageByID(chosenPkgId);
                    DisplayPackageAndProduct();
                    
                    // keep the index of listbox into variable
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

        // ------------------------------------------------------------------
        // Pitsini Suwandechochai
        // Description: event -- everytime user choose a package on the combo box
        // ------------------------------------------------------------------
        private void cboPkgName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // get a package info from database and display it
                aPackage = PackageDB.GetPackageByName(cboPkgName.SelectedItem.ToString());
                DisplayPackageAndProduct();

                // keeps index and PackageID into variables
                index = cboPkgName.SelectedIndex;
                chosenPkgId = aPackage.PackageId;

                // make a hilight on the listbox
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

        // ------------------------------------------------------------------
        // Pitsini Suwandechochai
        // Description: function -- to display package and product under those package
        // ------------------------------------------------------------------
        private void DisplayPackageAndProduct()
        {            
            // shows package info in the textboxes
            chosenPkgId = aPackage.PackageId;   
            txtPkgId.Text = aPackage.PackageId.ToString();  
            cboPkgName.SelectedItem = aPackage.PkgName.ToString();  
            txtStartDate.Text = aPackage.PkgStartDate.ToShortDateString();  
            txtEndDate.Text = aPackage.PkgEndDate.ToShortDateString();  
            rtxtDesc.Text = aPackage.PkgDesc;   
            txtBasePrice.Text = aPackage.PkgBasePrice.ToString("c");
            txtAgencyCommission.Text = aPackage.PkgAgencyCommission.ToString("c");

            // get list of product from database
            ListOfProducts = PackageDB.GetListOfProduct(aPackage.PackageId);
            lstProduct.Items.Clear();

            // shows products in the product listbox
            if (ListOfProducts != null)
                foreach (Product eachProduct in ListOfProducts)
                    lstProduct.Items.Add(eachProduct);
            
        }

        // ------------------------------------------------------------------
        // Pitsini Suwandechochai
        // Description: event -- when user click "Search" button
        // ------------------------------------------------------------------
        private void btnSearch_Click(object sender, EventArgs e)
        {
            // checks if input is valid
            if (IsValidData())
            {
                try
                {
                    // gets package by ID textbox
                    aPackage = PackageDB.GetPackageByID(Convert.ToInt32(txtPkgId.Text));

                    // make sure has package in database
                    if (aPackage != null)
                        DisplayPackageAndProduct();                    

                    // don't have Package that user try to search in DB 
                    else   
                    {
                        MessageBox.Show("Package ID: " + txtPkgId.Text + " is not found in Database.");

                        // gets ready for user to type the new data
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
                ResetData();    // reset to the previous selected package
        }

        // ------------------------------------------------------------------
        // Pitsini Suwandechochai
        // Description: function -- check valid input
        // ------------------------------------------------------------------
        private bool IsValidData()
        {
            return
                // validate packageID number
                Validator.IsNotNull(txtPkgId, "Package ID: ") &&    // return true if data is not empty
                Validator.IsInt32(txtPkgId, "Package ID: ");        // return true if data is integer
        }

        // event -- when user click "Modify" button
        private void btnModPkg_Click(object sender, EventArgs e)
        {
            // check if user have selected a package that wants to modify
            if (chosenPkgId != 0)
            {
                // send packageId to modify form
                ModifyPackageForm.selectedPkgId = chosenPkgId;
                                 

                // show Modify form
                DialogResult result;
                result = ModifyPackageForm.ShowDialog();

                // if successful update data
                if (result == DialogResult.OK)
                {                    
                    chosenPkgId = ModifyPackageForm.selectedPkgId; // keep present packageID

                    ModifyPackageForm.selectedPkgId = 0; // reset variable

                    // get the list of packages data from DB and display
                    ListOfPackages = PackageDB.GetListOfPackage();
                    DisplayListOfPackage();
                    txtPkgId.Focus();

                    // get package info and display
                    lstAllPackage.SelectedIndex = index;
                    aPackage = PackageDB.GetPackageByID(chosenPkgId);
                    DisplayPackageAndProduct();
                }
            }

            // show message that user have to choose package first
            else
                MessageBox.Show("Please select package before modify.");
        }

        // ------------------------------------------------------------------
        // Pitsini Suwandechochai
        // Description: reset all data
        // ------------------------------------------------------------------     
        private void ResetData()
        {
            lstAllPackage.SelectedIndex = index;
            aPackage = PackageDB.GetPackageByID(chosenPkgId);
            DisplayPackageAndProduct();
        }
    }
}
