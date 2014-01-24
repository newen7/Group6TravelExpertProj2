using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace TravelExperts
{
    public static class PackageDB
    {
        // ------------------------------------------------------------------
        // Pitsini Suwandechochai
        // Student ID: 000625877
        // Method to used: GetPackage(ID) 
        // Description: use packageID to select a package info from DB
        // ------------------------------------------------------------------
        public static Package GetPackage(int PackageId)
        {
            SqlConnection connectDB = TravelExpertsDB.GetConnection();

            // @PackageID is the variable that we pass the value from textbox
            string selectStatement = "SELECT * " +
                                     "FROM Packages " + 
                                     "WHERE PackageId = @PackageID ";
            SqlCommand selectCommand = new SqlCommand(selectStatement, connectDB);

            // provide value for the parameter
            selectCommand.Parameters.AddWithValue("@PackageID", PackageId);

            // executes commmand
            try
            {
                connectDB.Open();
                SqlDataReader pkgReader = selectCommand.ExecuteReader(CommandBehavior.SingleRow);

                if (pkgReader.Read()) // if geting a row successful
                {
                    Package package = new Package(); // create package object

                    // retrive data from data reader to the object
                    package.PackageId = (int)pkgReader["PackageId"];
                    package.PkgName = pkgReader["PkgName"].ToString();
                    package.PkgStartDate = (DateTime)pkgReader["PkgStartDate"];
                    package.PkgEndDate = (DateTime)pkgReader["PkgEndDate"];
                    package.PkgDesc = pkgReader["PkgDesc"].ToString();
                    package.PkgBasePrice = (decimal)pkgReader["PkgBasePrice"];
                    package.PkgAgencyCommission = (decimal)pkgReader["PkgAgencyCommision"];

                    return package;
                }
                else // if coun't find data in DB
                {
                    return null;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connectDB.Close();
            }
            
        }

        //public static List<Package> GetPackageNProductList(int PackageId)
        //{
        //    List<Package> ProductList = new List<Package>();
        //    SqlConnection connection = TravelExpertsDB.GetConnection();


        //}
    }
}
