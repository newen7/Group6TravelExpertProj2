using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace TravelExperts.Jon
{
    class SuppliersDB
    {
        // Gets a List of all Suppliers
        public static List<Supplier> GetSuppliers()
        {
            SqlConnection connection = TravelExpertsDB.GetConnection();

            string selectStatement = "SELECT * FROM Suppliers";
            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
            List<Supplier> suppliers = new List<Supplier>();
            try
            {
                connection.Open();
                SqlDataReader supplierReader = selectCommand.ExecuteReader();

                if (supplierReader.HasRows)
                {
                    while (supplierReader.Read())
                    {
                        Supplier supplier = new Supplier((int)supplierReader["SupplierId"], (string)supplierReader["SupName"]);
                        suppliers.Add(supplier);
                    }
                    return suppliers;
                }
                else
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
            selectCommand.Parameters.AddWithValue("@SupplierId", supplierId);
            List<Supplier> suppliers = new List<Supplier>();
            try
            {
                connection.Open();

                SqlDataReader supplierReader = selectCommand.ExecuteReader(CommandBehavior.SingleRow);

                if (supplierReader.HasRows)
                {
                    supplierReader.Read();
                    supplier = new Supplier((int)supplierReader["SupplierId"], (string)supplierReader["SupName"]);
                    return supplier;
                }
                else
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
                connection.Close();
            }
        }

        // Deletes, then Inserts one supplier by supplierId
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
                updateCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
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

            string findMaxId = "SELECT * " +
                               "FROM Suppliers " +
                               "WHERE SupplierId = (" +
                               "SELECT MAX(SupplierId) " +
                               "FROM Suppliers)";

            SqlCommand findMaxIdCommand = new SqlCommand(findMaxId, connection);

            string addString = "INSERT " +
                               "INTO Suppliers (SupplierId, SupName) " +
                               "VALUES (@SupplierId, @SupName)";
            try
            {
                connection.Open();
                SqlDataReader supplierReader = findMaxIdCommand.ExecuteReader(CommandBehavior.SingleRow);
                
                if (supplierReader.HasRows)
                {
                    supplierReader.Read();
                    
                    maxId = ((int)supplierReader[0]) + 1;
                    connection.Close();
                    
                    SqlCommand addCommand = new SqlCommand(addString, connection);

                    connection.Open();
                    addCommand.Parameters.AddWithValue("@SupplierId", maxId);
                    addCommand.Parameters.AddWithValue("@SupName", supName);
                    result = addCommand.ExecuteNonQuery();
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
            return result;
        }

        // Deletes one supplier by supplierId
        public static bool DeleteSupplier(int supplierId)
        {
            bool resultMessage;
            SqlConnection connection = TravelExpertsDB.GetConnection();

            string selectProductSupplierId = "Select ProductSupplierId " +
                                  "FROM Products_Suppliers " +
                                  "WHERE SupplierId = @SupplierId ";

            SqlCommand selectPSIdCommand = new SqlCommand(selectProductSupplierId, connection);

            string deleteFromPS = "DELETE " +
                                  "FROM Package_Products_Suppliers " +
                                  "WHERE SupplierId = @SupplierId";
 

            string deleteFromSuppliers = "DELETE " +
                                  "FROM Suppliers " +
                                  "WHERE SupplierId = @SupplierId";

            
            SqlCommand product_SupplierCommand = new SqlCommand(deleteFromPS, connection);
            SqlCommand supplierCommand = new SqlCommand(deleteFromSuppliers, connection);

            
            supplierCommand.Parameters.AddWithValue("@SupplierId", supplierId);
            product_SupplierCommand.Parameters.AddWithValue("@SupplierId", supplierId);

            try
            {
                //connection.Open();
                //product_SupplierCommand.ExecuteNonQuery();
                //connection.Close();

                connection.Open();
                supplierCommand.ExecuteNonQuery();

                resultMessage = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
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
