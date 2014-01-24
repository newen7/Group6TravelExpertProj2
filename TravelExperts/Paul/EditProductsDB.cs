using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace TravelExperts
{
    public static class EditProductsDB
    {
        public static List<Product> GetAllProducts()
        {
            SqlConnection connection = TravelExpertsDB.GetConnection();
            List<Product> ProductList = new List<Product>();
            //sql statement finds all accociated products
            string sql = "Select * FROM Products";
            SqlCommand selectCommand = new SqlCommand(sql, connection);
            try
            {
                connection.Open(); //open connection
                SqlDataReader readerObj = selectCommand.ExecuteReader(); //create readerObj from SqlDataReader Class and execute sql
                while (readerObj.Read()) //while readerObj has lines to read, go through each one 
                {
                    //add to product list all of the products found
                    ProductList.Add(new Product((int)readerObj[0], (string)readerObj[1]));
                }
            }
            catch (Exception ex) //catch exceptions
            {
                throw ex;
            }
            finally
            {
                connection.Close(); //close connection
            }
            return ProductList; //finally return the list we created
        }
        public static List<Supplier> GetSuppliersOfProduct(string prodName)
        {
            //public static function requires packageId and returns a List of products accociated with that package
            string connectionString = "Data Source=localhost\\sqlserver;Initial Catalog=TravelExperts;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            List<Supplier> SupplierList = new List<Supplier>();
            //sql statement finds all accociated products
            string sql = "Select s.SupplierId, s.SupName "
                        + "From Suppliers s, Products p, Products_Suppliers ps "
                        + "where s.SupplierId = ps.SupplierId and "
                        + "p.ProductId = ps.ProductId and "
                        + "p.ProdName = 'Air'";
            SqlCommand selectCommand = new SqlCommand(sql, connection);
            try
            {
                connection.Open(); //open connection
                SqlDataReader readerObj = selectCommand.ExecuteReader(); //create readerObj from SqlDataReader Class and execute sql
                while (readerObj.Read()) //while readerObj has lines to read, go through each one 
                {
                    //add to product list all of the products found
                    SupplierList.Add(new Supplier((int)readerObj[0], (string)readerObj[1]));
                }
            }
            catch (Exception ex) //catch exceptions
            {
                throw ex;
            }
            finally
            {
                connection.Close(); //close connection
            }
            return SupplierList; //finally return the list we created
        }
    }
}
