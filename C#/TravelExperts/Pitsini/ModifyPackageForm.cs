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
using System.Globalization;

namespace TravelExperts
{    
    public partial class frmModifyPackage : Form
    {
        public int selectedPkgId = 0;   // get packageId from previous form
        Package ChosenPackage;  // object from Package class

          // bring packageID from Main form
        public frmModifyPackage()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // save package data to DB
        private void btnSave_Click(object sender, EventArgs e)
        {
            // validate data
            if (IsValidData())
            {
                try
                {
                    // prepare package data into the new package object 
                    Package newPackage = new Package(selectedPkgId, txtPkgName.Text, dtpStartDate.Value,
                                                dtpEndDate.Value, rtxtDesc.Text,
                                                decimal.Parse(txtBasePrice.Text, 
                                                NumberStyles.Currency, CultureInfo.CurrentCulture.NumberFormat),
                                                decimal.Parse(txtAgencyCommission.Text,
                                                NumberStyles.Currency, CultureInfo.CurrentCulture.NumberFormat));

                    if (!PackageDB.UpdatePackage(selectedPkgId, newPackage))
                    {
                        // if cannot update data. It will show an error
                        MessageBox.Show("Another user has updated or " +
                            "deleted that customer.", "Database Error");
                        this.DialogResult = DialogResult.Retry;
                    }
                    else
                    {
                        // if updating is successful
                        MessageBox.Show("Package has been updated!!!");
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

        private void frmModifyPackage_Load(object sender, EventArgs e)
        {
            if (selectedPkgId != 0)
            {
                try
                {
                    // get package data from DB
                    ChosenPackage = PackageDB.GetPackageByID(selectedPkgId);
                    DisplayPackage();   // shows package data in textboxes
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

        // displays data from DB
        private void DisplayPackage()
        {
            txtPkgId.Text = selectedPkgId.ToString();
            txtPkgName.Text = ChosenPackage.PkgName;
            dtpStartDate.Text = ChosenPackage.PkgStartDate.ToShortDateString();
            dtpEndDate.Text = ChosenPackage.PkgEndDate.ToShortDateString();
            rtxtDesc.Text = ChosenPackage.PkgDesc.ToString();
            txtBasePrice.Text = ChosenPackage.PkgBasePrice.ToString("c");
            txtAgencyCommission.Text = ChosenPackage.PkgAgencyCommission.ToString("c");
        }

        // function for validate all input
        private bool IsValidData()
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
                Validator.IsPosNum(txtAgencyCommission, "Agency Commission: ") &&
                Validator.IsDecimal(txtAgencyCommission);

            // validate for description. We don't need to be done because it is not necessary.
        }
    }
}
