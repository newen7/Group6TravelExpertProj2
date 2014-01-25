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
        public static Package GetPackageByID(int PackageId)
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
                    package.PkgAgencyCommission = (decimal)pkgReader["PkgAgencyCommission"];

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

        // ------------------------------------------------------------------
        // Pitsini Suwandechochai
        // Description: use packageID to get one package info from DB
        // Method to used: GetPackage(ID) 
        // ------------------------------------------------------------------
        public static Package GetPackageByName(string PackageName)
        {
            SqlConnection connectDB = TravelExpertsDB.GetConnection();

            // @PackageID is the variable that we pass the value from textbox
            string selectStatement = "SELECT * " +
                                     "FROM Packages " +
                                     "WHERE PkgName = @PackageName ";
            SqlCommand selectCommand = new SqlCommand(selectStatement, connectDB);

            // provide value for the parameter
            selectCommand.Parameters.AddWithValue("@PackageName", PackageName);

            // executes commmand
            try
            {
                connectDB.Open();
                SqlDataReader pkgReader = selectCommand.ExecuteReader(CommandBehavior.SingleRow);
                Package package = new Package();

                if (pkgReader.Read()) // if geting a row successful
                {
                     // create package object

                    // retrive data from data reader to the object
                    package.PackageId = (int)pkgReader["PackageId"];
                    package.PkgName = pkgReader["PkgName"].ToString();
                    package.PkgStartDate = (DateTime)pkgReader["PkgStartDate"];
                    package.PkgEndDate = (DateTime)pkgReader["PkgEndDate"];
                    package.PkgDesc = pkgReader["PkgDesc"].ToString();
                    package.PkgBasePrice = (decimal)pkgReader["PkgBasePrice"];
                    package.PkgAgencyCommission = (decimal)pkgReader["PkgAgencyCommission"];
                    List<Product> ProductList = GetListOfProduct(package.PackageId);

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

        // ------------------------------------------------------------------
        // Pitsini Suwandechochai
        // Description: use packageID to get one package info from DB
        // Method to used: GetPackage(ID) 
        // ------------------------------------------------------------------
        public static List<Product> GetListOfProduct(int PackageId)
        {
            SqlConnection connectDB = TravelExpertsDB.GetConnection();

            // @PackageID is the variable that we pass the value from textbox
            string selectStatement = "SELECT ps.ProductId, pd.ProdName, sup.SupName, ps.SupplierId " +
                                     "FROM Packages_Products_Suppliers pps, Products_Suppliers ps, " +
                                          "Products pd, Suppliers sup " +
                                     "WHERE	pps.ProductSupplierId = ps.ProductSupplierId and " +
		                                  "ps.ProductId = pd.ProductId and ps.SupplierId = sup.SupplierId " +
                                          "and pps.PackageId = @PackageId ";

            SqlCommand selectCommand = new SqlCommand(selectStatement, connectDB);

            // provide value for the parameter
            selectCommand.Parameters.AddWithValue("@PackageId", PackageId);

            // makes new list to collect list of package names
            List<Product> ProductList = new List<Product>();

            // executes commmand
            try
            {
                connectDB.Open();

                //create pkgreaderObj from SqlDataReader Class and execute sql
                SqlDataReader prodReaderObj = selectCommand.ExecuteReader();

                if (prodReaderObj.HasRows) // if geting a row successful
                {
                    while (prodReaderObj.Read()) //while pkgReaderObj has lines to read, go through each one 
                    {
                        //add to package list all of the products found
                        ProductList.Add(new Product((int)prodReaderObj[0], (string)prodReaderObj[1], (string)prodReaderObj[2], (int)prodReaderObj[3]));                        
                    }
                    return ProductList; //return the list that have been created
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
    }
}
