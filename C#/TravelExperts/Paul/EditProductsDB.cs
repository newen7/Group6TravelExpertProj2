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
        public static List<Product> GetProducts(int PackageId)//Paul Teixeira ID: 653708
        {
            //public static function requires packageId and returns a List of products accociated with that package
            SqlConnection connection = TravelExpertsDB.GetConnection(); //get connection string from main TravelExpertsDB static class
            List<Product> ProductList = new List<Product>();
            //sql statement finds all accociated products
            string sql = "Select ps.ProductId, p.ProdName, s.SupName, ps.ProductSupplierId "
                       + "from Products p, Suppliers s, Products_Suppliers ps,Packages_Products_Suppliers pps "
                       + "where s.SupplierId = ps.SupplierId and "
                       + "pps.ProductSupplierId = ps.ProductSupplierId and "
                       + "ps.ProductId = p.ProductId and "
                       + "pps.PackageId = @pkgId";
            SqlCommand selectCommand = new SqlCommand(sql, connection);
            selectCommand.Parameters.AddWithValue("@pkgId", PackageId);
            try
            {
                connection.Open(); //open connection
                SqlDataReader readerObj = selectCommand.ExecuteReader(); //create readerObj from SqlDataReader Class and execute sql
                while (readerObj.Read()) //while readerObj has lines to read, go through each one 
                {
                    //add to product list all of the products found
                    ProductList.Add(new Product((int)readerObj[0], (string)readerObj[1], (string)readerObj[2], (int)readerObj[3]));
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
        public static List<Product> GetAllProducts()
        {
            SqlConnection connection = TravelExpertsDB.GetConnection(); //get connection string from main TravelExpertsDB static class
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
            SqlConnection connection = TravelExpertsDB.GetConnection(); //get connection string from main TravelExpertsDB static class
            List<Supplier> SupplierList = new List<Supplier>();
            string sql = "Select ps.ProductSupplierId, s.SupName "
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
            SqlConnection connection = TravelExpertsDB.GetConnection(); //get connection string from main TravelExpertsDB static class
            List<Supplier> SupplierList = new List<Supplier>();
            string DeleteSql = "delete from Packages_Products_Suppliers where PackageId = @pkgId";
            string AddSql = "INSERT INTO Packages_Products_Suppliers (PackageId, ProductSupplierId) "
                                    + "VALUES (@pkgId,@productSup)";
            SqlCommand deletecmd = new SqlCommand(DeleteSql, connection);
            deletecmd.Parameters.AddWithValue("@pkgId", pkgId);
            try
            {
                connection.Open(); //open connection
                deletecmd.ExecuteNonQuery(); //delete old list
                foreach (Product p in ListofProducts)
                {
                    SqlCommand addcmd = new SqlCommand(AddSql, connection);
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
            return true;
        }

        public static List<Product> GetProductsOfSupplier(int SupId)
        {
            //public static function requires packageId and returns a List of products accociated with that package
            SqlConnection connection = TravelExpertsDB.GetConnection(); //get connection string from main TravelExpertsDB static class
            List<Product> ProductList = new List<Product>();
            //sql statement finds all accociated products
            string sql = "Select p.ProductId, p.ProdName, s.SupName, ps.ProductSupplierId "
                            +"from Products_Suppliers ps, Suppliers s, Products p " 
                            +"where ps.ProductId = p.ProductId and "
                            +"s.SupplierId = ps.SupplierId and "
                            +"ps.SupplierId =  @SupId";
            SqlCommand selectCommand = new SqlCommand(sql, connection);
            selectCommand.Parameters.AddWithValue("@SupId", SupId);
            try
            {
                connection.Open(); //open connection
                SqlDataReader readerObj = selectCommand.ExecuteReader(); //create readerObj from SqlDataReader Class and execute sql
                while (readerObj.Read()) //while readerObj has lines to read, go through each one 
                {
                    //add to product list all of the products found
                    ProductList.Add(new Product((int)readerObj[0], (string)readerObj[1], (string)readerObj[2], (int)readerObj[3]));
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
        public static bool UpdateProductsofSupplier(int supID, List<Product> ListofProducts)
        {
            SqlConnection connection = TravelExpertsDB.GetConnection(); //get connection string from main TravelExpertsDB static class
            List<Supplier> SupplierList = new List<Supplier>();
            string DeleteSql = "Delete from Products_Suppliers where SupplierId = @supId";
            string AddSql = "Insert into Products_Suppliers (ProductId,SupplierId) VALUES (@prodId,@supId)";
            SqlCommand deletecmd = new SqlCommand(DeleteSql, connection);
            deletecmd.Parameters.AddWithValue("@supId", supID);
            try
            {
                connection.Open(); //open connection
                deletecmd.ExecuteNonQuery(); //delete old list
                foreach (Product p in ListofProducts)
                {
                    SqlCommand addcmd = new SqlCommand(AddSql, connection);
                    addcmd.Parameters.AddWithValue("@supId", supID);
                    addcmd.Parameters.AddWithValue("@prodId", p.ProductId);
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
            return true;
        }
    }
}
