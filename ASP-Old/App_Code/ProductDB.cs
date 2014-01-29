//=======================================
// Pitsini Suwandechochai
// Description: ProductDB (2nd layer)
// Methods:  1. GetProductByID(CustomerId) >> get the list of the product query by using CustomerId
//           2. GetBasePriceSummary(int inputCustId) >> get the total cost by using SUM(BasePrice)
//=======================================
using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.ComponentModel;


[DataObject(true)]
public static class ProductDB
{
    // get all products of a customer (select from CustomerId) from DB
    [DataObjectMethod(DataObjectMethodType.Select)]
    public static List<Product> GetProductByID(int CustomerId)
    {
        SqlConnection connection = new SqlConnection();        // connection
        List<Product> productList = new List<Product>();// collects list of product from database

        // statement
        string selectStatement = "SELECT b.BookingId, bd.Destination, bd.Description, " +
                    "b.BookingNo, bd.ItineraryNo, bd.TripStart, bd.TripEnd, bd.BasePrice, " +
                    "p.ProductId, p.ProdName " +
              "FROM Bookings b, BookingDetails bd , Customers c, " +
                    "Products_Suppliers ps, Products p " +
              "WHERE c.CustomerId = b.CustomerId and  b.BookingId = bd.BookingId and " +
                    "ps.ProductSupplierId = bd.ProductSupplierId and " +
                    "p.ProductId = ps.ProductId and  c.CustomerId = @CustomerId ";
        try
        {
            // executes commmand        
            using (connection = TravelExpertsDB.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(selectStatement, connection))
                {
                    // variable to sent to sqlcommand
                    cmd.Parameters.AddWithValue("@CustomerId", CustomerId);

                    connection.Open(); 
                    SqlDataReader readerObj = cmd.ExecuteReader();
                    while (readerObj.Read()) //while readerObj has lines to read 
                    {
                        Product eachProduct = new Product();
                        eachProduct.BookingId = (int)readerObj["BookingId"];
                        eachProduct.Destination = readerObj["Destination"].ToString();
                        eachProduct.Description = readerObj["Description"].ToString();
                        eachProduct.BookingNo = readerObj["BookingNo"].ToString();
                        eachProduct.ItineraryNo = Convert.ToDouble(readerObj["ItineraryNo"]);
                        eachProduct.TripStart = Convert.ToDateTime(readerObj["TripStart"]);
                        eachProduct.TripEnd = Convert.ToDateTime(readerObj["TripEnd"]);
                        eachProduct.BasePrice = Convert.ToDecimal(readerObj["BasePrice"]);
                        eachProduct.ProductId = (int)readerObj["ProductId"];
                        eachProduct.ProductName = readerObj["ProdName"].ToString();

                        // puts all data to the list
                        productList.Add(eachProduct);
                    }
                    readerObj.Close();
                }
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
        return productList; // sent product list to objectDataSource where requested       
 
    }

    // calculate total cost of a customer from DB
    [DataObjectMethod(DataObjectMethodType.Select)]
    public static decimal GetBasePriceSummary(int inputCustId)
    {
        SqlConnection connection = new SqlConnection();    // connection
        decimal summary = new decimal();            // variable to return result

        // SELECT statement using SUM()
        string selectStatement = "SELECT SUM(bd.BasePrice) " +
            "FROM Bookings b, BookingDetails bd , Customers c, " +
            "Products_Suppliers ps, Products p " +
            "WHERE c.CustomerId = b.CustomerId and  b.BookingId = bd.BookingId and " +
            "ps.ProductSupplierId = bd.ProductSupplierId and " +
            "p.ProductId = ps.ProductId and  c.CustomerId = @CustomerId ";

        try
        {
            // connection to TravelExperts Database        
            using (connection = TravelExpertsDB.GetConnection())
            {
                // executes commmand
                using (SqlCommand cmd = new SqlCommand(selectStatement, connection))
                {
                    // parameter from the webpage
                    cmd.Parameters.AddWithValue("CustomerId", inputCustId);

                    connection.Open();
                    SqlDataReader readerObj = cmd.ExecuteReader(CommandBehavior.SingleRow);
                    if (readerObj.Read()) //while readerObj has lines to read, go through each one 
                    {
                        summary = (decimal)readerObj[0];
                    }
                    readerObj.Close();
                }
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
            return summary;
    }
}

