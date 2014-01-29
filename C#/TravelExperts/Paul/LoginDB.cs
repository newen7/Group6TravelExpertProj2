using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace TravelExperts
{
    public static class LoginDB
    {
    public static bool Login(string username, string password)//Paul Teixeira ID: 653708
        {
            SqlConnection connection = TravelExpertsDB.GetConnection(); //get connection string from main TravelExpertsDB static class
            List<Product> ProductList = new List<Product>();
            string sql = "Select AgentId from Login where Username = '"+username+"' and Password = CONVERT(NVARCHAR(32),HashBytes('SHA1', '"+password+"' +Salt),2)";
            SqlCommand logincmd = new SqlCommand(sql, connection);
            try
            {
                connection.Open(); //open connection
                SqlDataReader readerObj = logincmd.ExecuteReader(CommandBehavior.SingleRow); //try login
                if (readerObj.Read()) //if true then we got a winner
                {
                    return true; //correct login
                }
                else
                {
                    return false; //incorrect login
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
        }
    }
}
