﻿using System;
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
    public partial class SuppliersForm : Form
    {
        // variables
        int currentSelection;
        private static Supplier currentSupplier = new Supplier(-1, " ");

        public static Supplier CurrentSupplier
        {
            get { return currentSupplier; }
            set { currentSupplier = value; }
        }

        List<Supplier> suppliers;
        

        public SuppliersForm()
        {
            InitializeComponent();
        }

        private void SuppliersForm_Load(object sender, EventArgs e)
        {
            CurrentSupplier = SuppliersForm.CurrentSupplier;
            currentSelection = CurrentSupplier.SupplierId;
            DisplaySuppliers();
            modifyBtn.Enabled = false;
            deleteBtn.Enabled = false;            
        }

        private void DisplaySuppliers()
        {
            suppliersLbx.Items.Clear();
            suppliers = SuppliersDB.GetSuppliers();
            foreach (Supplier supplier in suppliers)
            {
                suppliersLbx.Items.Add(supplier.SupName);
            }
            if (CurrentSupplier.SupplierId != -1)
            {
                suppliersLbx.SetSelected((currentSelection), true);
            }
            
            supplierIdTxt.Clear();
            nameTxt.Clear();
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
                    supplierIdTxt.Text = currentSupplier.SupplierId.ToString();
                    nameTxt.Text = currentSupplier.SupName;

                    // change the currently selected package in the combo box to the one returned by from the database 
                    suppliersLbx.SelectedItem = (currentSupplier.SupName);
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

        private void suppliersLbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            supplierIdTxt.Clear();
            if (suppliersLbx.SelectedIndex > -1)
            {

                // enable the modify and delete buttons
                currentSelection = CurrentSupplier.SupplierId;
                modifyBtn.Enabled = true;
                deleteBtn.Enabled = true;
            }

            string item = (string)suppliersLbx.SelectedItem;

            item.Replace(("(" + currentSupplier.SupplierId.ToString() + ")"), "");

            
            foreach (Supplier supplier in suppliers)
            {
                if (item == supplier.SupName)
                {
                    currentSupplier = supplier;
                }
            }
            supplierIdTxt.Text = currentSupplier.SupplierId.ToString();
            nameTxt.Text = currentSupplier.SupName;

            //paul
            ProductsLst.Items.Clear();
            foreach (Product p in SuppliersDB.GetSuppliersProducts(Convert.ToInt32(supplierIdTxt.Text)))
            {
                ProductsLst.Items.Add(p);
            }
        }

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

        private void addBtn_Click(object sender, EventArgs e)
        {
            AddSupplierForm AddSupplierForm = new AddSupplierForm();
            AddSupplierForm.WindowIs = "add";
            AddSupplierForm.ShowDialog();
            Supplier x = CurrentSupplier;
            DisplaySuppliers();
        }

        private void modifyBtn_Click(object sender, EventArgs e)
        {

            AddSupplierForm AddSupplierForm = new AddSupplierForm();
            AddSupplierForm.WindowIs = "modify";
            currentSelection = suppliersLbx.SelectedIndex;
            AddSupplierForm.CurrentSupplier = currentSupplier;
            AddSupplierForm.ShowDialog();
            DisplaySuppliers();
            suppliersLbx.SelectedItem = CurrentSupplier;
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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
    }
}
