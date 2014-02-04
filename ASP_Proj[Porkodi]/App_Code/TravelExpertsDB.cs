//Author:Porkodi
//CreatedDate:Jan-29-2014
//TravelExperts
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;


public static class TravelExpertsDB
{
	public  static SqlConnection GetConnection()
	{
        string connectionString = "Data Source=localhost\\sqlserver;Initial Catalog=TravelExperts;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);
        return connection;          
	}
}