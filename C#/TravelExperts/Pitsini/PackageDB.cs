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
    {   // ------------------------------------------------------------------
        // Pitsini Suwandechochai
        // Description: use packageID to get one package info from DB
        // Method to used: GetListOfPackage() 
        // ------------------------------------------------------------------
        public static List<Package> GetListOfPackage()
        {
            SqlConnection connectDB = TravelExpertsDB.GetConnection();

            string selectStatement = "SELECT * " +
                                     "FROM Packages ";
            SqlCommand selectCommand = new SqlCommand(selectStatement, connectDB);

            // makes new list to collect list of package names
            List<Package> PackageList = new List<Package>();

            // executes commmand
            try
            {
                connectDB.Open();
                //create pkgreaderObj from SqlDataReader Class and execute sql
                SqlDataReader pkgReaderObj = selectCommand.ExecuteReader();

                if (pkgReaderObj.HasRows) // if geting a row successful
                {
                    while (pkgReaderObj.Read()) //while pkgReaderObj has lines to read, go through each one 
                    {
                        //add to package list all of the products found
                        PackageList.Add(new Package((int)pkgReaderObj[0], (string)pkgReaderObj[1]));
                    }

                    return PackageList; //return the list that have been created
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
                connectDB.Close();  //close connection
            }

        }
        // ------------------------------------------------------------------
        // Pitsini Suwandechochai
        // Description: use packageID to get one package info from DB
        // Method to used: GetPackage(ID) 
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
