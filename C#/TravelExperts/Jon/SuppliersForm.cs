using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// getting the name spaces right was a pain in the butt for me but I eventually got the hang of it
namespace TravelExperts.Jon

// ------------------------------------------------------------------
// Jon's Supplier Form
// Student name: Jonathan Love
// Student ID: 000655580
// Description of code: A form that displays supplier info and allows 
// the user to view associated products.  users can also Add, Modify
// and Delete Suppliers via the AddSupplierForm
// ------------------------------------------------------------------
{
    public partial class SuppliersForm : Form
    {

        // variables
        private int currentSelection;
        // a Supplier object to contain the currently selected supplier
        private static Supplier currentSupplier = new Supplier(-1, " ");

        // instantiate a new AddSupplierForm window object
        AddSupplierForm AddSupplierForm = new AddSupplierForm();

        // properties
        public static Supplier CurrentSupplier
        {
            get { return currentSupplier; }
            set { currentSupplier = value; }
        }

        // list to contain the supplier objects from the DB
        List<Supplier> suppliers;
        

        public SuppliersForm()
        {
            InitializeComponent();
        }





        // When the form first loads
        private void SuppliersForm_Load(object sender, EventArgs e)
        {
            // get the info from the DB and display it in the visible fields in the form
            DisplaySuppliers();

            // set the current supplier (first in the list on load)
            currentSupplier = suppliers.First<Supplier>();

            // the current selection stores the List index value of whatever Supplier Object is currently selected
            // on load it will be 0, the index of the first supplier
            currentSelection = suppliers.IndexOf(currentSupplier);

            // hide the modify and delete buttons until there is something selected to modify or delete
            modifyBtn.Enabled = false;
            deleteBtn.Enabled = false;            
        }

        private void DisplaySuppliers()
        {
            // this was tricky for me.  Because supplier IDs are not sequential in the DB I had to find a way to 
            // match them to the list box index.  
            // set index to the ID of the current supplier
            int index = currentSupplier.SupplierId;

            // pull data on all Suppliers, put each supplier into an object and add each object to the suppliers List
            suppliers = SuppliersDB.GetSuppliers();

            // loop through thre List to add suppliers to the list box
            foreach (Supplier supplier in suppliers)
            {
                // bind the list box to the List created in the GUI layer when data was pulled from the DB
                // I only found this out recently.  Before this I was manually adding object properties into the list box
                suppliersLbx.DataSource = suppliers;

                // tell the list box what to display from the List and what to use as a value for that displayed info
                suppliersLbx.DisplayMember = "SupName";
                suppliersLbx.ValueMember = "SupplierId";
            }
            
            // the currentindex is the List index of the object that matches the current supplier by supplierID 
            int currentIndex = suppliers.FindIndex(supplier => supplier.SupplierId.Equals(index));

            // now I can match the List Box selection to the List index.. phew!  That took some thinking
            // would have been a lot easier if the primary keys in the supplier table were sequential like other tables
            suppliersLbx.SetSelected(currentIndex, true);

            // clear the current text fields for name and ID
            supplierIdTxt.Clear();
            nameTxt.Clear();
            
            // if there is an item in the list box which is not the first one, display that info in the text fields
            if (suppliersLbx.SelectedIndex > 0)
            {
                supplierIdTxt.Text = currentSupplier.SupplierId.ToString();
                nameTxt.Text = currentSupplier.SupName;
            }
            

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int searchId = -1;

            // check to see if the user input is actually a valid integer
            bool result = Int32.TryParse(supplierIdTxt.Text, out searchId);

            // if it is a valid and positive integer
            if (result == true && searchId >= 0)
            {
                currentSupplier = SuppliersDB.GetSupplier(searchId);
                if (currentSupplier == null)
                {
                    // Supplier ID is not in the database
                    MessageBox.Show("The Supplier ID you entered is not in the database.", "DB Error");
                    suppliersLbx.SetSelected((currentSelection), true);

                }
                else
                {
                    // if a valid Supplier was returned from the database display it to the user
                    currentSelection = suppliers.FindIndex(supplier => supplier.SupplierId.Equals(searchId)); 
                    supplierIdTxt.Text = currentSupplier.SupplierId.ToString();
                    nameTxt.Text = currentSupplier.SupName;

                    // change the currently selected package in the combo box to the one returned by from the database 
                    suppliersLbx.SetSelected(currentSelection, true);
                }
            }
            else
            {
                // Package ID is not a positive integer
                MessageBox.Show("The Supplier ID must be a positive integer");
                currentSelection = CurrentSupplier.SupplierId;
                supplierIdTxt.Text = currentSelection.ToString();
            }
        }

        // when the list box selected item is changed
        private void suppliersLbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            // reset the currentSelection
            currentSelection = suppliersLbx.SelectedIndex;

            // reset the current supplier based on the currentSelection
            currentSupplier = suppliers[currentSelection];
            supplierIdTxt.Text = currentSupplier.SupplierId.ToString();
            nameTxt.Text = currentSupplier.SupName;

            // enable the modify and delete buttons
            modifyBtn.Enabled = true;
            deleteBtn.Enabled = true;

            //paul
            ProductsLst.Items.Clear();
            foreach (Product p in SuppliersDB.GetSuppliersProducts(Convert.ToInt32(supplierIdTxt.Text)))
            {
                ProductsLst.Items.Add(p);
            }
            // end Paul
        }

        // when the delete button is clicked
        private void deleteBtn_Click(object sender, EventArgs e)
        {
            // confirm witht the user that they really want to delete the selected supplier
            DialogResult result = MessageBox.Show("Delete " + currentSupplier.SupName.ToString() + "?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // if the user's answer is yes
            if (result == DialogResult.Yes)
            {
                try
                {
                    // call SuppliersDB and use the DeleteSupplier() Method
                    // if the DeleteSupplier() Method succeeds 
                    if (SuppliersDB.DeleteSupplier(currentSupplier.SupplierId))
                    {
                        // tell the user the Supplier was deleted successfully
                        MessageBox.Show("Supplier deleted.");
                        // now that the last item in the list has been deleted, reset the current supplier to the first in the list
                        currentSupplier = suppliers.First<Supplier>();

                        // update the Suppliers list box and clear all other fields
                        DisplaySuppliers();
                    }

                    // if the DeleteSupplier() Method did not succeed
                    else
                    {
                        // read the current Supplier from the DB
                        currentSupplier = SuppliersDB.GetSupplier(currentSupplier.SupplierId);

                        // if it is not there
                        if (currentSupplier == null)
                        {
                            // it has already been deleted
                            MessageBox.Show("Another user has already deleted that Supplier.", "DB Error");
                        }
                        else
                        {
                            // it has been modified concurrently
                            MessageBox.Show("Another user has has changed that Supplier and it could not be deleted.", "DB Error");
                        }
                    }
                }
                // catch any other problems not foreseen
                catch (Exception)
                {
                    MessageBox.Show("Couldn't delete this supplier.  It still has products associated with it.");
                }
            }
        }

        // when the add button is clicked
        private void addBtn_Click(object sender, EventArgs e)
        {
            // let the child window know which button was pressed (one child window does add AND modify)
            AddSupplierForm.WindowIs = "add";
            AddSupplierForm.ShowDialog();
            if (currentSupplier.SupplierId > -1)
            {
                // once control is returned to the main window, refresh the list of Suppliers to reflect the change
                DisplaySuppliers();
            }
            
            
        }

        // when the modify button is clicked
        private void modifyBtn_Click(object sender, EventArgs e)
        {
            // let the child window know which button was pressed (one child window does add AND modify)
            AddSupplierForm.WindowIs = "modify";

            // pass current supplier info back into this window via appropriate properties and fields
            AddSupplierForm.CurrentSupplier = currentSupplier;
            AddSupplierForm.ShowDialog();

            // once control is returned to the main window, refresh the list of Suppliers to reflect the change
            DisplaySuppliers();
        }

        // close the window
        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // paul
        private void EditProductsBtn_Click(object sender, EventArgs e)
        {
            DialogResult result;
            frmProductInSupplier ProductInSupplierForm = new frmProductInSupplier();
            if (supplierIdTxt.Text.Length > 0) //is there any other checks for this? can we make pkgID nullable type?
            {
                //ProductInPackageForm.PkgId = chosenPkgId; //chosenPkgId is not working?
                ProductInSupplierForm.SupplierToEdit = new TravelExperts.Supplier(currentSupplier.SupplierId,currentSupplier.SupName); //this needs checking if I am doing validation on pkgform
                result = ProductInSupplierForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                   suppliersLbx_SelectedIndexChanged(this,new EventArgs()); //fires event to make list box reload
                }
            }
            else MessageBox.Show("Package not selected");
        }
        // end paul
    }
}
