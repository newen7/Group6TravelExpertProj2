using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.ComponentModel;

// ------------------------------------------------------------------
// Pitsini Suwandechochai
// Description: get all products of a customer (select from CustomerId) from DB
// ------------------------------------------------------------------

[DataObject(true)]
public static class ProductDB
{   
    [DataObjectMethod(DataObjectMethodType.Select)]
    public static List<Product> GetProductByID(int CustomerId)
    {
        // collects list of product in DB
        List<Product> productList = new List<Product>();

        // @CustomerId is the variable that we pass the value from session
        string selectStatement = "SELECT b.BookingId, bd.Destination, bd.Description, " +
                    "b.BookingNo, bd.ItineraryNo, bd.TripStart, bd.TripEnd, bd.BasePrice, " +
                    "p.ProductId, p.ProdName " +
              "FROM Bookings b, BookingDetails bd , Customers c, " +
                    "Products_Suppliers ps, Products p " +
              "WHERE c.CustomerId = b.CustomerId and  b.BookingId = bd.BookingId and " +
                    "ps.ProductSupplierId = bd.ProductSupplierId and " +
                    "p.ProductId = ps.ProductId and  c.CustomerId = @CustomerId ";
        
        // executes commmand        
        using (SqlConnection connection = TravelExpertsDB.GetConnection())
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
                    eachProduct.ItineraryNo = Convert.ToDecimal(readerObj["ItineraryNo"]);
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
        return productList; // sent product list to objectDataSource that requested
        
    }
}

