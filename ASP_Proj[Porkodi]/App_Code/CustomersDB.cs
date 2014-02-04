//Author:Porkodi
//Version1.0
//CustomersDB-ASP.NET
//Created Date:Jan-29-2014
using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.ComponentModel;

[DataObject(true)]
public static class CustomersDB
{
    [DataObjectMethod(DataObjectMethodType.Select)]
    public static List<Customers> GetCustomers()//get customer from datatable
    {
        //select customer from  customers table
        SqlConnection Connection = new SqlConnection();
        List<Customers> customersList = new List<Customers>();
        string sel = "SELECT CustomerId, CustFirstName, CustLastName, CustAddress,"
        + "CustCity, CustProv, CustPostal, CustCountry, CustHomePhone, CustBusPhone, CustEmail, AgentId "
            + "FROM Customers ORDER BY CustomerId";

        using (Connection = TravelExpertsDB.GetConnection())//connecting from travel data table
        {
            using (SqlCommand cmd = new SqlCommand(sel, Connection))
            {
                Connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                Customers customers;
                while (dr.Read())
                {
                    customers = new Customers();
                    customers.CustomerID = (int)dr["CustomerId"];
                    customers.CustFirstName = dr["CustFirstName"].ToString();
                    customers.CustLastName = dr["CustLastName"].ToString();
                    customers.CustAddress = dr["CustAddress"].ToString();
                    customers.CustCity = dr["CustCity"].ToString();
                    customers.CustProv = dr["CustProv"].ToString();
                    customers.CustPostal = dr["CustPostal"].ToString();//Postcode should be validation
                    customers.CustCountry = dr["CustCountry"].ToString();
                    customers.CustHomePhone = dr["CustHomePhone"].ToString();//Phone number should be validate 
                    customers.CustBusPhone = dr["CustBusPhone"].ToString();//phone number should be validate
                    customers.CustEmail = dr["CustEmail"].ToString();
                    if (dr["AgentId"] != null && dr["AgentId"].ToString().Length > 0)
                    {
                        customers.AgentId = (int)dr["AgentId"];
                        
                    }
                    customersList.Add(customers);
                }
                dr.Close();
            }
        }
        return customersList;//return to customers list
    }
    [DataObjectMethod(DataObjectMethodType.Select)]
    public static Customers GetCustomer(int CustomerId)//upDateADD customer from datatable
    {
        Customers customers = new Customers();
        //select customer from  customers table
        SqlConnection Connection = new SqlConnection();

        string sel = "SELECT CustomerId, CustFirstName, CustLastName, CustAddress,"
        + "CustCity, CustProv, CustPostal, CustCountry, CustHomePhone, CustBusPhone, CustEmail, AgentId "
            + "FROM Customers WHERE CustomerId =@CustomerId";

        using (Connection = TravelExpertsDB.GetConnection())//connecting from travel data table
        {
            using (SqlCommand cmd = new SqlCommand(sel, Connection))
            {
                Connection.Open();
                cmd.Parameters.AddWithValue("@CustomerId", CustomerId);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    customers = new Customers();
                    customers.CustomerID = (int)dr["CustomerId"];
                    customers.CustFirstName = dr["CustFirstName"].ToString();
                    customers.CustLastName = dr["CustLastName"].ToString();
                    customers.CustAddress = dr["CustAddress"].ToString();
                    customers.CustCity = dr["CustCity"].ToString();
                    customers.CustProv = dr["CustProv"].ToString();
                    customers.CustPostal = dr["CustPostal"].ToString();//Postcode should be validation
                    customers.CustCountry = dr["CustCountry"].ToString();
                    customers.CustHomePhone = dr["CustHomePhone"].ToString();//Phone number should be validate 
                    customers.CustBusPhone = dr["CustBusPhone"].ToString();//phone number should be validate
                    customers.CustEmail = dr["CustEmail"].ToString();
                    if (dr["AgentId"] != null && dr["AgentId"].ToString().Length > 0)
                    {
                        customers.AgentId = (int)dr["AgentId"];

                    }

                }
                dr.Close();
            }
        }
        return customers;//return to customers list
    }


    [DataObjectMethod(DataObjectMethodType.Update)]
    //travelexperts customers list update
    public static int UpdateCustomers(Customers customers)
    {
        SqlConnection Connection = new SqlConnection();
        int updateCount = 0;
        string up = "UPDATE Customers "
            + "SET CustFirstName  = @CustFirstName, "
            + "CustLastName = @CustLastName, "
            + "CustAddress = @CustAddress, "
            + "CustCity =@CustCity, "
            + "CustProv =@CustProv, "
            + "CustPostal =@CustPostal, "
            + " CustCountry =@CustCountry, "
            + " CustHomePhone =@CustHomePhone, "
            + " CustBusPhone =@CustBusPhone, "
            + " CustEmail =@CustEmail, "
            + " AgentId =@AgentId "

            + "WHERE CustomerID =@CustomerID";


        using (Connection = TravelExpertsDB.GetConnection())
        {
            using (SqlCommand cmd = new SqlCommand(up, Connection))//cmd= displays Windows XP version and copyright information.
            {
                cmd.Parameters.AddWithValue("CustomerID", customers.CustomerID);
                cmd.Parameters.AddWithValue("CustFirstName", customers.CustFirstName);
                cmd.Parameters.AddWithValue("CustLastName", customers.CustLastName);
                cmd.Parameters.AddWithValue("CustAddress", customers.CustAddress);
                cmd.Parameters.AddWithValue("CustCity", customers.CustCity);
                cmd.Parameters.AddWithValue("CustProv", customers.CustProv);
                cmd.Parameters.AddWithValue("CustPostal", customers.CustPostal);
                cmd.Parameters.AddWithValue("CustCountry", customers.CustCountry);
                cmd.Parameters.AddWithValue("CustHomePhone", customers.CustHomePhone);
                cmd.Parameters.AddWithValue("CustBusPhone", customers.CustBusPhone);
                cmd.Parameters.AddWithValue("CustEmail", customers.CustEmail);
                if (customers.AgentId > 0)
                {
                    cmd.Parameters.AddWithValue("AgentId", customers.AgentId);
                }
                else
                {
                    cmd.Parameters.AddWithValue("AgentId", DBNull.Value);
                }


                Connection.Open();
                updateCount = cmd.ExecuteNonQuery();
                Connection.Close();
            }
        }
        return updateCount;
    }
}



	