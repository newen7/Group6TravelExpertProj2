using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

// ------------------------------------------------------------------
// Jon's SupplierDB class
// Student name: Jonathan Love
// Student ID: 000655580
// Description of code: A Database class for Suppliers.
// Get all, get one, add one, update one and delete one supplier
// methods are in here.
// ------------------------------------------------------------------
namespace TravelExperts.Jon
{
    class SuppliersDB
    {
        // Gets a List of all Suppliers
        public static List<Supplier> GetSuppliers()
        {
            // Get the connection string stored centrally in the TravelExpertsDB class
            SqlConnection connection = TravelExpertsDB.GetConnection();

            // set the select statement, the * means all suppliers
            string selectStatement = "SELECT * FROM Suppliers";

            // build the actually SQL command using the connection string and select statement
            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);

            // instantiate a new List of Suppliers to put all that DB info into
            List<Supplier> suppliers = new List<Supplier>();

            // try to access the database.. an exception will be caught if any failure occurrs
            try
            {
                connection.Open(); // um.. open the database..

                // prepare to execute the SQL command, this two step execution took me a while to understand
                // This actually reads the data from the database and stores it.  But a separate command 
                // actually retrieves the data from the SqlDataReader.  I wasn't putting in the 
                // supplierReader.Read() code which actually moves through the rows of data stored when 
                // accessed from the DB.  This took me about an hour to figure out... sigh
                SqlDataReader supplierReader = selectCommand.ExecuteReader();

                // if there were actually any rows retrieved from the DB
                if (supplierReader.HasRows)
                {
                    // loop through those rows in the SqlDataReader and store them in the List
                    while (supplierReader.Read())
                    {
                        // instantiate a new object of type Supplier and use the default constructor with parameters from the DB
                        Supplier supplier = new Supplier((int)supplierReader["SupplierId"], (string)supplierReader["SupName"]);
                        
                        // add that object to the List created earlier
                        suppliers.Add(supplier);
                    }
                    return suppliers;
                }
                // if there were no rows in the SqlDataReader
                else
                {
                    return null; // as far as I know this is different from a database exception so it isn't redundant
                }
            }
                // catch any exceptions that may have occured when the DB was accessed
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                // after everything has been attempted, close the connection
                connection.Close();
            }
        }

        // Gets one supplier by supplierId
        public static Supplier GetSupplier(int supplierId)
        {
            // a supplier object to store the returning row of data
            Supplier supplier;

            // the connection string from TravelExpertsDB
            SqlConnection connection = TravelExpertsDB.GetConnection();

            // SELECT everything from the Supliers Table by a unique supplierId
            string selectStatement = "SELECT * " + 
                                     "FROM Suppliers " +
                                     "WHERE SupplierID = @supplierId";

            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);

            // when the select statement is built using the selectCommand, substitute the 
            // @supplierId placeholder with the value stored in the supplierId variable
            // passed into this method when it was called from the GUI using the Supplier
            // entity class
            selectCommand.Parameters.AddWithValue("@SupplierId", supplierId);
            try
            {
                connection.Open();

                SqlDataReader supplierReader = selectCommand.ExecuteReader(CommandBehavior.SingleRow);

                if (supplierReader.HasRows)
                {
                    // since we are only trying to retrieve one row from the Suppliers table in the DB there is no 
                    // need to loop through the supplierReader when we execute the supplierReader.Read() method
                    supplierReader.Read();

                    // instantiate a new object of type Supplier and use the default constructor with parameters from the DB
                    supplier = new Supplier((int)supplierReader["SupplierId"], (string)supplierReader["SupName"]);

                    // send the resulting info, stored in this new object, back to the GUI which requested it
                    return supplier;
                }
                else
                {
                    // if there were no rows read from the DB return null
                    return null;
                }
            }
            // catch any DB exceptions that may have occured
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                // close the connection
                connection.Close();
            }
        }

        // updates one supplier by supplierId
        public static bool UpdateSupplier(Supplier supplier)
        {
            SqlConnection connection = TravelExpertsDB.GetConnection();

            string updateSuppliers = "UPDATE Suppliers SET SupName=@SupName WHERE SupplierId=@SupplierId";

            SqlCommand updateCommand = new SqlCommand(updateSuppliers, connection);

            updateCommand.Parameters.AddWithValue("@SupplierId", supplier.SupplierId);
            updateCommand.Parameters.AddWithValue("@SupName", supplier.SupName);

            try
            {
                connection.Open();
                // since no data is acutally being requested from the DB, only given, we use a non query SQL command
                updateCommand.ExecuteNonQuery();
            }

            // if the update failed, catch the exception
            catch (Exception ex)
            {
                //send it to the GUI to be processed and displayed to the user
                throw ex;
            }
            finally
            {
                // close the connection
                connection.Close();
            }
            return true;
        }

        // Inserts one supplier by supplierId
        public static int AddSupplier(string supName)
        {
            
            int maxId = 13597;
            Supplier supplier = new Supplier(maxId, supName);
            int result = 0;

            SqlConnection connection = TravelExpertsDB.GetConnection();

            // select SQL string which finds the last row in the table and stores its ID
            string findMaxId = "SELECT * " +
                               "FROM Suppliers " +
                               "WHERE SupplierId = (" +
                               "SELECT MAX(SupplierId) " +
                               "FROM Suppliers)";

            // finding and storing the last row in the table is necessary because:
            // 1. the supplier IDs in the table are non-sequential and
            // 2. the primary keys (in this case the suplier IDs) are not set to
            // auto increment which presents a problem when adding new rows to the table
            SqlCommand findMaxIdCommand = new SqlCommand(findMaxId, connection);


            // insert SQL string for adding a new supplier
            string addString = "INSERT " +
                               "INTO Suppliers (SupplierId, SupName) " +
                               "VALUES (@SupplierId, @SupName)";
            try
            {
                connection.Open();
                SqlDataReader supplierReader = findMaxIdCommand.ExecuteReader(CommandBehavior.SingleRow);
                
                // if you get a row back it will be the last row in the table
                if (supplierReader.HasRows)
                {
                    // read that row
                    supplierReader.Read();
                    
                    // and set the maxId variable to that row's supplier ID
                    //  + 1 so we can add the next record after that last one
                    maxId = ((int)supplierReader[0]) + 1;

                    // close the connection
                    connection.Close();
                    
                    // then actually start to add the new row
                    SqlCommand addCommand = new SqlCommand(addString, connection);

                    // unless you finish one SQL command before you start another you get errors
                    // so it's important to close and reopen the connection for multiple SQL commands
                    // this also took me over an hour to figure out... sigh... :)
                    connection.Open();

                    // add the ID
                    addCommand.Parameters.AddWithValue("@SupplierId", maxId);

                    // add the name
                    addCommand.Parameters.AddWithValue("@SupName", supName);

                    // return the result which in this case will be the number of rows affected
                    result = addCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                // close the second connection
                connection.Close();
            }
            return result;
        }

        // Deletes one supplier by supplierId
        public static bool DeleteSupplier(int supplierId)
        {
            // variables
            bool resultMessage;

            // set the connection screen
            SqlConnection connection = TravelExpertsDB.GetConnection();

            // set the select statement for the Products_Suppliers table (child of Suppliers table)
            string selectProductSupplierId = "SELECT ProductSupplierId " +
                                  "FROM Products_Suppliers " +
                                  "WHERE SupplierId = @SupplierId ";

            // set the select command for the Products_Suppliers table
            SqlCommand selectPSIdCommand = new SqlCommand(selectProductSupplierId, connection);

            // set the delete statement for the Products_Suppliers table (child of Suppliers table)
            string deleteFromPS = "DELETE " +
                                  "FROM Products_Suppliers " +
                                  "WHERE SupplierId = @SupplierId";

            // set the delete statement for the Suppliers table (parent to Products_Suppliers table)
            string deleteFromSuppliers = "DELETE " +
                                  "FROM Suppliers " +
                                  "WHERE SupplierId = @SupplierId";

            // delete commands for the two tables (child before parent)
            SqlCommand product_SupplierCommand = new SqlCommand(deleteFromPS, connection);
            SqlCommand supplierCommand = new SqlCommand(deleteFromSuppliers, connection);

            // use values passed into the method from the GUI
            supplierCommand.Parameters.AddWithValue("@SupplierId", supplierId);
            product_SupplierCommand.Parameters.AddWithValue("@SupplierId", supplierId);

            try
            {
                //connection.Open();
                //product_SupplierCommand.ExecuteNonQuery();
                //connection.Close();

                // the child command was commented out as Paul and I decided that the responsibility 
                // for deleting Suppliers accross multiple, dependent tables should not rest in the 
                // Supplier part of the User Interface.  Rather, that responisbility should be part
                // of the Customer/Bookings User Interface or at least from the Products side of things.

                // so only Supplier table deletion is done here and if that fails due to dependancies
                // on records in other tables an exception will be thrown and show to the user in the GUI
                connection.Open();
                supplierCommand.ExecuteNonQuery();

                // if the delete succeeded then the supplier deleted did not have any products associated with it
                resultMessage = true;
            }

            // catch any exceptions from the DB
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                // close the connection
                connection.Close();
            }
            return resultMessage;
        }

        //Paul Teixeira
        public static List<Product> GetSuppliersProducts(int SupplierId) //perameters SupplierId and returns a list of products that supplier offers (used for drop downs in add/modify)
        {
            List<Product> ProductList = new List<Product>(); //list of products will be stored here
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string sql = "Select p.ProductId, p.ProdName, s.SupName, ps.ProductSupplierId "
                         + "From Products p, Products_Suppliers ps, Suppliers s "
                         + "where p.ProductId = ps.ProductId and "
                         + "s.SupplierId = ps.SupplierId and "
                         + "ps.SupplierId = @supId"; //sql finds all products of supplierId
            SqlCommand selectCommand = new SqlCommand(sql, connection);
            selectCommand.Parameters.AddWithValue("@supId", SupplierId);
            try
            {    //get products of package
                connection.Open();
                SqlDataReader readerObj = selectCommand.ExecuteReader();
                while (readerObj.Read())//scroll through all rows
                {// add product into list
                    ProductList.Add(new Product((int)readerObj[0], (string)readerObj[1], (string)readerObj[2], (int)readerObj[3]));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return ProductList;//return List of products
        }
    }
}
