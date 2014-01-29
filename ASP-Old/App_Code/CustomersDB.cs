//CoustomersDB
// CreatDate: 24-01-2014
//Select created by:(Porkodi)
//Version 1.2

/*
 * Update Function by Paul Teixiera
 * The update function is passed an object of Customers type and then builds an sql statment to do an update
 * based on this information.
 * Uses unified connection string from TravelDb and throws exception on failure to any try/catch block that called it.
 */
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
                    customers.CustomerID = (int)dr["CustomerId"];
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
                    customers.AgentId = (int)dr["AgentId"];
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
        using (SqlConnection con = TravelExpertsDB.GetConnection())
        {
            using (SqlCommand cmd = new SqlCommand(sel, con))//calling 
            {
                cmd.Parameters.AddWithValue("CustomerId", CustomerId);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    customers.CustomerID = (int)dr["CustomerId"];
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
                    customers.AgentId = (int)dr["AgentId"];
                }
                dr.Close();
            }
        }
        return customers;
    }

    // ------------------------------------------------------------------
    // Pitsini Suwandechochai
    // Method: GetCustomerFNameById(Id)
    // Description: query 1 customer from DB to display on "Product" page by merging 
    //              first and last name togerther as 1 field (as 'FullName')
    // ------------------------------------------------------------------
    [DataObjectMethod(DataObjectMethodType.Select)]
    public static Customers GetCustomerFNameById(int inputCustId)
    {
        Customers CustomerGot = new Customers();
        string sel = "SELECT CustomerId, CustFirstName + ' ' + CustLastName as FullName, "
                + "CustAddress, CustCity, CustProv, CustPostal, CustCountry, CustHomePhone, "
              + "CustBusPhone, CustEmail, AgentId "
            + "FROM Customers "
            + "WHERE CustomerId = @CustomerId";

        using (SqlConnection con = TravelExpertsDB.GetConnection())
        {
            using (SqlCommand cmd = new SqlCommand(sel, con))
            {
                cmd.Parameters.AddWithValue("CustomerId", inputCustId);

                con.Open();
                SqlDataReader readerObj = cmd.ExecuteReader(CommandBehavior.SingleRow);
                if (readerObj.Read()) //while readerObj has lines to read, go through each one 
                {
                    //add to a customer
                    CustomerGot = new Customers((int)readerObj[0], (string)readerObj[1],
                        (string)readerObj[2], (string)readerObj[3], (string)readerObj[4],
                        (string)readerObj[5], (string)readerObj[6], (string)readerObj[7],
                        (string)readerObj[8], (string)readerObj[9], (int)readerObj[10]);
                }
                readerObj.Close();
            }
        }
        return CustomerGot;
    }
    //Paul Teixeira Update Customer
    public static bool UpdateCustomer(Customers NewCustomerInfo)
    {
        SqlConnection connection = TravelExpertsDB.GetConnection();
        string updateStatement = "UPDATE Customers SET "
                                    + "CustFirstName = @firstName, "
                                    + "CustLastName = @lastName, "
                                    + "CustAddress = @address, "
                                    + "CustCity = @city, "
                                    + "CustProv = @prov, "
                                    + "CustPostal = @postal, "
                                    + "CustCountry = @country, "
                                    + "CustHomePhone = @homeph, "
                                    + "CustBusPhone = @busph, "
                                    + "CustEmail = @email, "
                                    + "AgentId = @agntId "
                                    + "WHERE CustomerId = @CustId";
        SqlCommand updateCommand = new SqlCommand(updateStatement, connection);
        updateCommand.Parameters.AddWithValue("@CustId", NewCustomerInfo.CustomerID);
        updateCommand.Parameters.AddWithValue("@firstName", NewCustomerInfo.CustFirstName);
        updateCommand.Parameters.AddWithValue("@lastName", NewCustomerInfo.CustLastName);
        updateCommand.Parameters.AddWithValue("@address", NewCustomerInfo.CustAddress);
        updateCommand.Parameters.AddWithValue("@city", NewCustomerInfo.CustCity);
        updateCommand.Parameters.AddWithValue("@prov", NewCustomerInfo.CustProv);
        updateCommand.Parameters.AddWithValue("@postal", NewCustomerInfo.CustPostal);
        updateCommand.Parameters.AddWithValue("@country", NewCustomerInfo.CustCountry);
        updateCommand.Parameters.AddWithValue("@homeph", NewCustomerInfo.CustHomePhone);
        updateCommand.Parameters.AddWithValue("@busph", NewCustomerInfo.CustBusPhone);
        updateCommand.Parameters.AddWithValue("@email", NewCustomerInfo.CustEmail);
        updateCommand.Parameters.AddWithValue("@agntId", NewCustomerInfo.AgentId);
        try
        {
            connection.Open();
            updateCommand.ExecuteNonQuery();
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        finally
        {
            connection.Close();
        }
        return true;
    }
}
