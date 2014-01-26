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
    public partial class AddSupplierForm : Form
    {
        string windowIs;
        public AddSupplierForm()
        {
            InitializeComponent();
        }

        private int addSupplierId;
        public int AddSupplierId
        {
            get
            {
                return addSupplierId;
            }
            set
            {
                addSupplierId = value;
            }
        }

        private void AddSupplierForm_Load(object sender, EventArgs e)
        {
            // We are adding a new supplier
            if (AddSupplierId == -2)
            {
                // change the title bar
                this.Text = "Add Supplier";
                windowIs = "add";
                nameTxt.ReadOnly = false;

                // hide the ID controls
                supplierIdLbl.Visible = false;
                supplierIdTxt.Visible = false;

                // enable the name text box
                nameTxt.Enabled = true;

            }

            // we are modifying an existing supplier
            else
            {
                // change the title bar
                this.Text = "Modify Supplier";
                windowIs = "modify";
                addModSupplierGbx.Text = "Modify Supplier";
                nameTxt.ReadOnly = false;
                supplierIdTxt.ReadOnly = true;
                supplierIdTxt.Text = AddSupplierId.ToString();
            }

        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            // We are adding a new supplier
            string name = nameTxt.Text;
            if (windowIs == "add")
            {
                int addResult;
                if (name != "")
                {
                    addResult = TravelExperts.Jon.SuppliersDB.AddSupplier(name);
                    if (addResult > 0)
                    {
                        // Add succeeded
                        this.Close();

                    }

                    else
                    {
                        // Add failed
                        MessageBox.Show("Not added.  DB Error");
                        supplierIdTxt.Focus();
                    }
                }

                else
                {
                    // no name error
                    MessageBox.Show("Please enter a name");
                }
            }

            // we are modifying an existing supplier
            else if (windowIs == "modify")
            {
                
                bool updateResult = false;
                Jon.Supplier updateSupplier = new Jon.Supplier(addSupplierId, name);
                if (name != "")
                {
                    updateResult = TravelExperts.Jon.SuppliersDB.UpdateSupplier(updateSupplier);
                    if (updateResult)
                    {
                        // Update succeeded
                        this.Close();
                    }

                    else
                    {
                        // Update failed
                        MessageBox.Show("Could not update this Supplier.  There was a DB Error");
                    }
                }

                else
                {
                    // no name error
                    MessageBox.Show("Please enter a name");
                    nameTxt.Focus();
                }
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
