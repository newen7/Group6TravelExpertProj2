using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

    public static class TravelExpertsDB
    {
        public static SqlConnection GetConnection()
        {
            string connectionString = "Data Source=localhost\\sqlserver;Initial Catalog=TravelExperts;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
    }
