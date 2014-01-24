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
            string connectionString = "Data Source=localhost\\sqlserver;Initial Catalog=TravelExperts;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString); 
            List<Product> ProductList = new List<Product>();
            string sql = "Select * FROM Products";
            SqlCommand selectCommand = new SqlCommand(sql, connection);
            try
            {
                connection.Open(); //open connection
                SqlDataReader readerObj = selectCommand.ExecuteReader(); //create readerObj from SqlDataReader Class and execute sql
                while (readerObj.Read()) //while readerObj has lines to read, go through each one 
                {
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
            string connectionString = "Data Source=localhost\\sqlserver;Initial Catalog=TravelExperts;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            List<Supplier> SupplierList = new List<Supplier>();
            string sql = "Select s.SupplierId, s.SupName "
                        + "From Suppliers s, Products p, Products_Suppliers ps "
                        + "where s.SupplierId = ps.SupplierId and "
                        + "p.ProductId = ps.ProductId and "
                        + "p.ProdName = @productName";
            SqlCommand selectCommand = new SqlCommand(sql, connection);
            selectCommand.Parameters.AddWithValue("@productName", prodName);
            try
            {
                connection.Open(); //open connection
                SqlDataReader readerObj = selectCommand.ExecuteReader(); //create readerObj from SqlDataReader Class and execute sql
                while (readerObj.Read()) //while readerObj has lines to read, go through each one 
                {
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
        public static bool UpdateProducts(int pkgId,List<Product> ListofProducts)
        {
            //delete where PackageId = PackageId
            //foreach(Product p in ListOfProdcuts) do insert sql
            string connectionString = "Data Source=localhost\\sqlserver;Initial Catalog=TravelExperts;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            List<Supplier> SupplierList = new List<Supplier>();
            string DeleteSql = "delete from Packages_Products_Suppliers where PackageId = @pkgId";
            string AddSql = "INSERT INTO Packages_Products_Suppliers (PackageId, ProductSupplierId) "
                             +"VALUES (@pkgId,@productSup)";
            SqlCommand deletecmd = new SqlCommand(DeleteSql, connection);
            SqlCommand addcmd = new SqlCommand(AddSql, connection);
            deletecmd.Parameters.AddWithValue("@pkgId", pkgId);
            try
            {
                connection.Open(); //open connection
                deletecmd.ExecuteNonQuery(); //delete old list
                foreach (Product p in ListofProducts)
                {
                    addcmd.Parameters.AddWithValue("@pkgId", pkgId);
                    addcmd.Parameters.AddWithValue("@productSup", p.ProductSupplierId);
                    addcmd.ExecuteNonQuery();//add new product
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
            return true; //finally return the list we created
        }
    }
}
