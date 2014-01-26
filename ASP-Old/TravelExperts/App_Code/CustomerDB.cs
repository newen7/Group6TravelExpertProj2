using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

public static class CustomerDb
{
    public static Customer GetCustomerInfo(int custId)
    {
        //public static function requires packageId and returns a List of products accociated with that package
        SqlConnection connection = TravelExpertsDB.GetConnection(); //get connection string from main TravelExpertsDB static class
        Customer CustomerGot = new Customer();
        //sql statement finds all accociated products
        string sql = "Select * "
                    +"from Customers "
                    +"where CustomerId = @custId";
        SqlCommand selectCommand = new SqlCommand(sql, connection);
        selectCommand.Parameters.AddWithValue("@custId", custId);
        try
        {
            connection.Open(); //open connection
            SqlDataReader readerObj = selectCommand.ExecuteReader(); //create readerObj from SqlDataReader Class and execute sql
            while (readerObj.Read()) //while readerObj has lines to read, go through each one 
            {
                //add to product list all of the products found
                CustomerGot = new Customer((int)readerObj[0], (string)readerObj[1], (string)readerObj[2], (string)readerObj[3], (string)readerObj[4], (string)readerObj[5], (string)readerObj[6], (string)readerObj[7], (string)readerObj[8], (string)readerObj[9], (string)readerObj[10], (int)readerObj[11]);
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
        return CustomerGot;
    }
}