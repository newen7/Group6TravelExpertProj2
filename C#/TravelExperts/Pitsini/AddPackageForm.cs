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
    public partial class frmAddPackage : Form
    {
        public frmAddPackage()
        {
            InitializeComponent();
        }

        //private int addSupplierId;
        //public int AddSupplierId
        //{
        //    get
        //    {
        //        return addSupplierId;
        //    }
        //    set
        //    {
        //        addSupplierId = value;
        //    }
        //}

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            frmModifyPackage modForm = new frmModifyPackage();
            // validate data
            if (IsValidData())
            {
                try
                {
                    // prepare package data into the new package object 
                    Package newPackage = new Package();
                    newPackage.PkgName = txtPkgName.Text;
                    newPackage.PkgStartDate = Convert.ToDateTime(dtpStartDate.Text);
                    newPackage.PkgEndDate = Convert.ToDateTime(dtpEndDate.Text);
                    newPackage.PkgDesc = rtxtDesc.Text;
                    newPackage.PkgBasePrice = Convert.ToDecimal(txtBasePrice.Text);
                    newPackage.PkgAgencyCommission = Convert.ToDecimal(txtAgencyAdmission.Text);


                    if (!PackageDB.InsertPackage(newPackage))
                    {
                        // if cannot update data. It will show an error
                        MessageBox.Show("Somthing went wrong with Database. " +
                            "Please check with your Admin.", "Database Error");
                        this.DialogResult = DialogResult.Retry;
                    }
                    else
                    {
                        // if updating is successful
                        MessageBox.Show("Package has been inserted!!!");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
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
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString());
                }
            }
        }

        private void frmAddPackage_Load(object sender, EventArgs e)
        {
            ClearForm();
        }

        // clears data in this form
        private void ClearForm()
        {
            txtPkgName.Text = "";
            dtpStartDate.Text = "";
            dtpEndDate.Text = "";
            rtxtDesc.Text = "";
            txtBasePrice.Text = "";
            txtAgencyAdmission.Text = "";
        }

        // function for validate all input
        public bool IsValidData()
        {
            return
                // validate package name
                Validator.IsPresent(txtPkgName, "Package name: ") &&
                Validator.IsLetter(txtPkgName, "Package Name: ") &&

                // validate base price
                Validator.IsPosNum(txtBasePrice, "Base Price: ") &&
                Validator.IsDecimal(txtBasePrice) &&

                // validate start daten and end date
                Validator.DateIsWithinRange(dtpStartDate.Value, dtpEndDate.Value) &&

                // validate agency commission
                //Validator.IsGreaterThan(Convert.ToDecimal(txtBasePrice), 
                //          Convert.ToDecimal(txtAgencyAdmission.Text)) &&

                // validate for description
                Validator.IsPresent(rtxtDesc, "Description: ");
        }
        
    }
}
