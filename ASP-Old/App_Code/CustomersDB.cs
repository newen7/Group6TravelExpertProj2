//CoustomersDB
// CreatDate: 24-01-2014
//Select created by:(Porkodi)
//Version 1.2
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.ComponentModel;

[DataObject(true)]
public static class CustomersDB
{
    [DataObjectMethod(DataObjectMethodType.Select)]
    public static List<Customers> GetCustomers()
    {
        List<Customers> customersList = new List<Customers>();
        string sel = "SELECT CustomerId, CustFirstName, CustLastName,CustAddress,"
        + "CustCity, CustProv, CustPostal, CustCountry, CustHomePhone, CustBusPhone, CustEmail, AgentId "
            + "FROM Customers ORDER BY CustomerId";

        using (SqlConnection con = new SqlConnection("Data Source=localhost\\sqlserver;Initial Catalog=TravelExperts;Integrated Security=True"))
        {
            using (SqlCommand cmd = new SqlCommand(sel, con))
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                Customers customers;
                while (dr.Read())
                {
                    customers = new Customers();
                    customers.CustomerID = dr["CustomerId"].ToString();
                    customers.CustFirstName = dr["CustFirstName"].ToString();
                    customers.CustLastName = dr["CustLastName"].ToString();
                    customers.CustAddress = dr["CustAddress"].ToString();
                    customers.CustCity = dr["CustCity"].ToString();
                    customers.CustProv = dr["CustProv"].ToString();
                    customers.CustPostal = dr["CustPostal"].ToString();
                    customers.CustCountry = dr["CustCountry"].ToString();
                    customers.CustHomePhone = dr["CustHomePhone"].ToString();
                    customers.CustBusPhone = dr["CustBusPhone"].ToString();
                    customers.CustEmail = dr["CustEmail"].ToString();
                    customers.AgentId = dr["AgentId"].ToString();
                    customersList.Add(customers);
                }
                dr.Close();
            }
        }
        return customersList;
    }

    [DataObjectMethod(DataObjectMethodType.Select)]
    public static Customers GetCustomerID(string CustomerId)
    {
        Customers customers = new Customers();
       
        string sel = "SELECT CustomerId, CustFirstName, CustLastName,CustAddress,"
        + "CustCity, CustProv, CustPostal, CustCountry, CustHomePhone, CustBusPhone, CustEmail, AgentId "
            + "FROM Customers WHERE CustomerId = @CustomerId";
        using (SqlConnection con = new SqlConnection("Data Source=localhost\\sqlserver;Initial Catalog=TravelExperts;Integrated Security=True"))
        {
            using (SqlCommand cmd = new SqlCommand(sel, con))//calling 
            {
                cmd.Parameters.AddWithValue("CustomerId", CustomerId);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    customers.CustomerID = dr["CustomerId"].ToString();
                    customers.CustFirstName = dr["CustFirstName"].ToString();
                    customers.CustLastName = dr["CustLastName"].ToString();
                    customers.CustAddress = dr["CustAddress"].ToString();
                    customers.CustCity = dr["CustCity"].ToString();
                    customers.CustProv = dr["CustProv"].ToString();
                    customers.CustPostal = dr["CustPostal"].ToString();
                    customers.CustCountry = dr["CustCountry"].ToString();
                    customers.CustHomePhone = dr["CustHomePhone"].ToString();
                    customers.CustBusPhone = dr["CustBusPhone"].ToString();
                    customers.CustEmail = dr["CustEmail"].ToString();
                    customers.AgentId = dr["AgentId"].ToString();
                }
                dr.Close();
            }
        }
        return customers;

    }
}
