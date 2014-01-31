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
        public int newJustAddId; // store new created packgeID

        public frmAddPackage()
        {
            InitializeComponent();
        }
        
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
                    newPackage.PkgAgencyCommission = Convert.ToDecimal(txtAgencyCommission.Text);

                    newJustAddId = PackageDB.InsertPackage(newPackage);

                    if (newJustAddId == 0)
                    {
                        // if cannot update data. It will show an error
                        MessageBox.Show("Somthing went wrong with Database. " +
                            "Please check with your Administrator.", "Database Error");
                        this.DialogResult = DialogResult.Retry;
                    }
                    else
                    {
                        // if updating is successful
                        MessageBox.Show("Insert Successful.", "Alert");
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
            txtAgencyCommission.Text = "";
        }

        // function for validate all input
        public bool IsValidData()
        {
            return
                // validate package name
                Validator.IsNotNull(txtPkgName, "Package name: ") &&

                // validate description
                Validator.IsNotNull(rtxtDesc, "Description: ") &&

                // validate start date and end date
                Validator.IsDateWithinRange(dtpStartDate.Value, dtpEndDate.Value) &&

                // validate base price
                Validator.IsNotNull(txtBasePrice, "Base Price: ") &&
                Validator.IsPosNum(txtBasePrice, "Base Price: ") &&
                Validator.IsDecimal(txtBasePrice) &&
                
                // validate agency commission
                Validator.IsNotNull(txtAgencyCommission, "Agency Commission: ") &&
                Validator.IsPosNum(txtAgencyCommission, "Agency Commission: ") &&
                Validator.IsPriceGreaterThan(txtBasePrice, txtAgencyCommission);
        }        
    }
}
