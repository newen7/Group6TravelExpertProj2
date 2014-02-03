//Author:Porkodi
//Created Date:Jan-30-214
//Version: 1.0
//TravelExperts- ProductsDB.cs 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace TravelExperts_Porkodi
{
    public static class ProductDB
    {
        //Get data from product, it will start empty list    
        public static List<Product> GetProducts()
        {
            List<Product> ProductList = new List<Product>();
            SqlConnection connection = TravelExpertsDB.GetConnection();//getting connection from Data
            string selectStatement = "SELECT ProductId, ProdName "
                                    + "FROM Products ";
            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
             try
            {
                connection.Open();
                SqlDataReader readerObj = selectCommand.ExecuteReader(); //create readerObj from SqlDataReader Class and execute sql
                while (readerObj.Read()) //while readerObj has line to read & go through each one 
                {
                    //add to product list all of the products found
                    Product product = new Product();
                    product.ProductId = (int)readerObj["ProductId"];
                    product.ProdName = readerObj["ProdName"].ToString();
                    ProductList.Add(product);
                }
                return ProductList;//go back to the Productlist
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


        //when getting Id ,list will display 
        public static Product GetProduct(int productId)
        {
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string selectStatement = "SELECT ProductId, ProdName "
                                    + "FROM Products "
                                    + "WHERE ProductId = @ProductId";
            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@ProductId", productId);

            try
            {
                connection.Open();
                SqlDataReader custReader = selectCommand.ExecuteReader(CommandBehavior.SingleRow);
                if (custReader.Read())
                {
                    Product product = new Product();
                    product.ProductId = (int)custReader["ProductId"];
                    product.ProdName = custReader["ProdName"].ToString();
                    return product;
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
        //add Product function is going to be start
        public static int AddProduct(Product product)
        {
            SqlConnection connection = TravelExpertsDB.GetConnection();//data is going to product data to TravcelExpert
            string insertStatement =
                "INSERT Products " +
                "(ProdName) " +
                "VALUES (@ProdName)";
            SqlCommand insertCommand = new SqlCommand(insertStatement, connection);
            insertCommand.Parameters.AddWithValue("@ProdName", product.ProdName);

            try
            {
                connection.Open();
                insertCommand.ExecuteNonQuery();
                string selectStatement = "SELECT IDENT_CURRENT('Products') FROM Products";
                SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
                int productId = Convert.ToInt32(selectCommand.ExecuteScalar());
                return productId;
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
        //delete Product  function is going to be start
        public static bool DeleteProduct(int productID)
        {
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string deleteStatement =
                "DELETE FROM Products " +
                "WHERE ProductId = @ProductId ";

            SqlCommand deleteCommand = new SqlCommand(deleteStatement, connection);
            deleteCommand.Parameters.AddWithValue("@ProductId", productID);

            try
            {
                connection.Open();
                deleteCommand.ExecuteNonQuery();
                return  true;
                
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

        //internal static void lstAllProducts(Product product)
        //{
        //    throw new NotImplementedException();
        //}

        //internal static object GetPackage(Product currentProdName)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
