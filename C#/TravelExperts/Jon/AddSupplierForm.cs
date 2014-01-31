using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TravelExperts.Jon
{
    // ------------------------------------------------------------------
    // Jon's Add Supplier Form
    // Student name: Jonathan Love
    // Student ID: 000655580
    // Description of code: A form that allows the user to add a new
    // supplier to the DB or modify an existing supplier in the DB
    // ------------------------------------------------------------------
    public partial class AddSupplierForm : Form
    {
        // variables
        private string windowIs; // shows whether the user clicked on the add or modify button in the parent form
        private static Supplier currentSupplier = new Supplier(-1, " "); // stores the ID of the supplier being added or modified
        public AddSupplierForm() // 
        {
            InitializeComponent();
        }

        // property for the private variable currentSupplier
        public static Supplier CurrentSupplier
        {
            get { return currentSupplier; }
            set { currentSupplier = value; }
        }

        // when the form loads
        private void AddSupplierForm_Load(object sender, EventArgs e)
        {
            CurrentSupplier = SuppliersForm.CurrentSupplier;
            // if the user is trying to add a new supplier
            if (CurrentSupplier.SupplierId == -2)
            {
                // change the title bar to reflect what we are trying to do
                this.Text = "Add Supplier";

                // set the windowIs variable so we know what operation the user is trying to accomplish
                windowIs = "add";
                nameTxt.ReadOnly = false;

                // hide the supplier ID controls
                supplierIdLbl.Visible = false;
                supplierIdTxt.Visible = false;

                nameTxt.Enabled = true;

            }

            // if the user is trying to modify an existing supplier
            else
            {
                // change the title bar to reflect what we are trying to do
                this.Text = "Modify Supplier";

                // set the windowIs variable so we know what operation the user is trying to accomplish
                windowIs = "modify";

                // change the title in the group box (looks sexy, default is add)
                addModSupplierGbx.Text = "Modify Supplier";

                // enable the name text box so that the user can input text into it
                nameTxt.ReadOnly = false;

                // leave the ID field visible but don't allow the user to alter it
                supplierIdTxt.ReadOnly = true;

                // Read the supplier name the user is trying to modify into the name text box
                supplierIdTxt.Text = CurrentSupplier.SupplierId.ToString();
            }

        }

        // when the save button is clicked
        private void saveBtn_Click(object sender, EventArgs e)
        {
            // set this variable to the text the user has (supposedly) entered
            string name = nameTxt.Text;

            // if the user is trying to add a new supplier
            if (windowIs == "add")
            {
                // will hold the result of the DB add attempt (number of rows affected)
                int addResult;

                // if the name field is not empty
                if (name != "")
                {
                    // call the AddSupplier() method in the SuppliersDB class and pass it the entered name
                    addResult = SuppliersDB.AddSupplier(name);

                    // if more than 0 rows were affected (realistically only one will be)
                    if (addResult > 0)
                    {
                        // Add succeeded
                        this.Close();
                        SuppliersForm.CurrentSupplier = AddSupplierForm.CurrentSupplier;

                    }

                    else
                    {
                        // Add failed
                        MessageBox.Show("Not added.  DB Error");
                        supplierIdTxt.Focus();
                    }
                }

                // if the user didn't enter anything into the text field
                else
                {
                    // no name error
                    MessageBox.Show("Please enter a name");
                }
            }

            // if the user is trying to modify an existing supplier
            else if (windowIs == "modify")
            {
                // this variable will be set to true if/when an update to the DB succeeds
                bool updateResult = false;

                // if the name field is not empty
                if (name != "")
                {
                    CurrentSupplier.SupName = nameTxt.Text;

                    // call the UpdateSupplier() method in the SuppliersDB class and pass it the new object
                    // when this is attempted the DB will return true or false depending on success or failure
                    // to update the records.  Store that boolean value in updateResult
                    updateResult = SuppliersDB.UpdateSupplier(CurrentSupplier);

                    // if the DB update succeeded
                    if (updateResult)
                    {
                        // GREAT!  Close the window
                        this.Close();
                        // When the execution of the program continues in the parent window it will go
                        // back to the DB to get a fresh list of suppliers and display the change
                    }

                    else
                    {
                        // Update failed, show an error message to the user
                        MessageBox.Show("Could not update this Supplier.  There was a DB Error");
                    }
                }

                // if the user didn't enter anything into the text field
                else
                {
                    // no name error
                    MessageBox.Show("Please enter a name");
                    nameTxt.Focus();
                }
            }
        }

        // closes the window without any attempt to add to or modify suppliers in the DB 
        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
