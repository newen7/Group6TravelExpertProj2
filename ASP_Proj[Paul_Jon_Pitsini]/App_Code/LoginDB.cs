using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

// ------------------------------------------------------------------
// Pitsini Suwandechochai & Paul Teixeira
// Description: Login class --> Secure Salted Password Hashing
// ------------------------------------------------------------------

public static class LoginDB
{
    // Login method -- checks username and password
    public static int Login(string user, string passwd) 
	{
        int customerId;
        SqlConnection connection = TravelExpertsDB.GetConnection();
        string sql = "Select CustomerId from Customers where Username = '" + user + "' and Password = CONVERT(NVARCHAR(32),HashBytes('SHA1', '" + passwd + "' +Salt),2)";

        SqlCommand loginCommand = new SqlCommand(sql, connection);
        
            // executes commmand
            try
            {
                connection.Open();

                //create pkgreaderObj from SqlDataReader Class and execute sql
                SqlDataReader loginReaderObj = loginCommand.ExecuteReader(CommandBehavior.SingleRow);

                if (loginReaderObj.Read()) // if geting a row successful
                {
                    customerId = CustomersDB.GetCustomerByUserName(user);
                    return customerId;
                }
                else // if coun't find data in DB
                {
                    return 0;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();  //close connection
            }
	}
}