// ------------------------------------------------------------------
// Pitsini Suwandechochai
// Description: PackageDB Class
// ------------------------------------------------------------------
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

            // select statement
            string selectStatement = "SELECT * " +
                                     "FROM Packages ";
            SqlCommand selectCommand = new SqlCommand(selectStatement, connectDB);

            // makes new list to collect list of package
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
                        //add to package list all of the products are found
                        PackageList.Add(new Package((int)pkgReaderObj[0], (string)pkgReaderObj[1]));
                    }

                    return PackageList; //return the list that have been created
                }
                else // if coun't find data in DB
                {
                    return null;
                }
            }
            catch (SqlException ex) // SQL Server returns a warning or error
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

            // select statement
            string selectStatement = "SELECT * " +
                                     "FROM Packages " +
                                     "WHERE PackageId = @PackageID ";
            SqlCommand selectCommand = new SqlCommand(selectStatement, connectDB);

            // @PackageID is a variable that we pass the value from textbox
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
            catch (SqlException ex) // SQL Server returns a warning or error
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
        // Description: use PackageName to get one package info from DB
        // Method to used: GetPackageByName(PackageName) 
        // ------------------------------------------------------------------
        public static Package GetPackageByName(string PackageName)
        {
            SqlConnection connectDB = TravelExpertsDB.GetConnection();

            // select statement
            string selectStatement = "SELECT * " +
                                     "FROM Packages " +
                                     "WHERE PkgName = @PackageName ";
            SqlCommand selectCommand = new SqlCommand(selectStatement, connectDB);

            // @PackageName is a variable that we pass the value from textbox
            selectCommand.Parameters.AddWithValue("@PackageName", PackageName);

            // executes commmand
            try
            {
                connectDB.Open();
                SqlDataReader pkgReader = selectCommand.ExecuteReader(CommandBehavior.SingleRow);
                Package package = new Package();

                if (pkgReader.Read()) // if geting a row successful
                {
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
            catch (SqlException ex) // SQL Server returns a warning or error
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
        // Description: use PackageId to get one package info from DB
        // Method to used: GetListOfProduct(PackageId) 
        // ------------------------------------------------------------------
        public static List<Product> GetListOfProduct(int PackageId)
        {
            SqlConnection connectDB = TravelExpertsDB.GetConnection();

            // select statement
            string selectStatement = "SELECT ps.ProductId, pd.ProdName, sup.SupName, ps.SupplierId " +
                                     "FROM Packages_Products_Suppliers pps, Products_Suppliers ps, " +
                                          "Products pd, Suppliers sup " +
                                     "WHERE	pps.ProductSupplierId = ps.ProductSupplierId and " +
		                                  "ps.ProductId = pd.ProductId and ps.SupplierId = sup.SupplierId " +
                                          "and pps.PackageId = @PackageId ";

            SqlCommand selectCommand = new SqlCommand(selectStatement, connectDB);

            // @PackageID is the variable that we pass the value from textbox
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
            catch (SqlException ex) // SQL Server returns a warning or error
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
        // Description: Updating method for package data 
        // It will return "true" if updating is successful. Otherwise will return "false"
        // ------------------------------------------------------------------
        public static bool UpdatePackage(int packageID, Package newPackage)
        {
            
            SqlConnection connection = TravelExpertsDB.GetConnection();

            // update statement
            string updateStatement = "UPDATE Packages SET PkgName = @NewName, " +
                                     "PkgStartDate = @NewPkgStartdate, " +
                                     "PkgEndDate = @NewPkgEndDate, " +
                                     "PkgDesc = @NewPkgDesc, " +
                                     "PkgBasePrice = @NewPkgBasePrice, " +
                                     "PkgAgencyCommission = @NewPkgAgencyCommission " +
                                     "Where PackageId = @PackageId ";

            SqlCommand updateCommand = new SqlCommand(updateStatement, connection);

            // variables that user would like to update
            updateCommand.Parameters.AddWithValue("@NewName", newPackage.PkgName);
            updateCommand.Parameters.AddWithValue("@NewPkgStartdate", newPackage.PkgStartDate);
            updateCommand.Parameters.AddWithValue("@NewPkgEndDate", newPackage.PkgEndDate);
            updateCommand.Parameters.AddWithValue("@NewPkgDesc", newPackage.PkgDesc);
            updateCommand.Parameters.AddWithValue("@NewPkgBasePrice", newPackage.PkgBasePrice);
            updateCommand.Parameters.AddWithValue("@NewPkgAgencyCommission", newPackage.PkgAgencyCommission);
            updateCommand.Parameters.AddWithValue("@PackageId", packageID);

            try
            {
                connection.Open();

                // run command
                int count = updateCommand.ExecuteNonQuery();
                if (count > 0)
                    return true;
                else
                    return false;
            }
            catch (SqlException ex) // SQL Server returns a warning or error
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }   

        // ------------------------------------------------------------------
        // Pitsini
        // Insert method for package data 
        // It will return "true" if inserting is successful. Otherwise will return "false"
        // ------------------------------------------------------------------
        public static int InsertPackage(Package newPackage)
        {
            SqlConnection connection = TravelExpertsDB.GetConnection();

            // insert statement
            string insertStatement = "INSERT INTO Packages(PkgName, PkgStartDate, PkgEndDate, " + 
                                     "PkgDesc, PkgBasePrice, PkgAgencyCommission) " +
                                     "VALUES (@newName, @newSDate,@newEDate, @newDesc, @newBasePrice, @newCommission)";

            SqlCommand insertCommand = new SqlCommand(insertStatement, connection);

            // variables that user would like to insert
            insertCommand.Parameters.AddWithValue("@newName", newPackage.PkgName);
            insertCommand.Parameters.AddWithValue("@newSDate", newPackage.PkgStartDate);
            insertCommand.Parameters.AddWithValue("@newEDate", newPackage.PkgEndDate);
            insertCommand.Parameters.AddWithValue("@newDesc", newPackage.PkgDesc);
            insertCommand.Parameters.AddWithValue("@newBasePrice", newPackage.PkgBasePrice);
            insertCommand.Parameters.AddWithValue("@newCommission", newPackage.PkgAgencyCommission);

            try
            {
                connection.Open();

                // run command
                int count = insertCommand.ExecuteNonQuery();
                if (count > 0)
                {
                    Package pkg = new Package();
                    pkg = GetPackageByName(newPackage.PkgName);
                    return pkg.PackageId;
                }
                else
                    return 0;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }   // End Insert method
    }
}
