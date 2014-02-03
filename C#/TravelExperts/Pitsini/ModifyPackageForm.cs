// ------------------------------------------------------------------
// Pitsini Suwandechochai
// Description: Modify Package form for editing package information
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
using System.Globalization;

namespace TravelExperts
{    
    public partial class frmModifyPackage : Form
    {
        public int selectedPkgId = 0;   // this variable gets packageId from previous form
        Package ChosenPackage;          // object from Package class
                
        public frmModifyPackage()
        {
            InitializeComponent();
        }

        //Event - when user click "Cancel" button
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Event - when user click "Save" button
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

                    // if cannot update data. It will show an error
                    if (!PackageDB.UpdatePackage(selectedPkgId, newPackage))
                    {                        
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

        // Event - When the form is loaded
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

        // function -- displays a package user wants to modify from DB
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
        
        // function -- check validate all input
        public bool IsValidData()
        {
            return
                // validate package name
                Validator.IsNotNull(txtPkgName, "Package name: ") &&
                
                // validate start date and end date
                Validator.IsDateWithinRange(dtpStartDate.Value, dtpEndDate.Value) &&

                // validate base price
                Validator.IsNotNull(txtBasePrice, "Base Price: ") &&
                Validator.IsPosNum(txtBasePrice, "Base Price: ") &&
                Validator.IsDecimal(txtBasePrice) &&

                // validate agency commission
                Validator.IsNotNull(txtAgencyCommission, "Base Price: ") &&
                Validator.IsPosNum(txtAgencyCommission, "Base Price: ") &&
                Validator.IsPriceGreaterThan(txtBasePrice, txtAgencyCommission) &&
                        
                // validate description
                Validator.IsNotNull(rtxtDesc, "Description: ");

        }
    }
}
