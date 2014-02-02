/*
 * Update Function by Paul Teixiera
 * The update function is passed an object of Customers type and then builds an sql statment to do an update
 * based on this information.
 * Uses unified connection string from TravelDb and throws exception on failure to any try/catch block that called it.
 * 
 * Register Function by Paul Teixeira
 * It accepts a username,password(cleartext) and customer object to register a new user with the website
 * I considered hashing the password client side and passing a hashed string to the server, but this would reveal not only the
 * hashing algorithim used in the database, but the salt as well. I decieded to hash it only server side, and preserve security 
 * by using SSL (which would encrypt ALL data TO the server includeing the cleartext password)
 */
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.ComponentModel;

// Porkodi
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
                    customers.CustomerID = System.Convert.ToInt32(dr["CustomerId"]);
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
                    if (dr["AgentId"].ToString().Length > 0)
                    {
                        customers.AgentId = System.Convert.ToInt32(dr["AgentId"]);
                    }
                    else
                    {
                        customers.AgentId = null;
                    }
                    customersList.Add(customers);
                }
                dr.Close();
            }
        }
        return customersList;
    }

    // Porkodi
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
                    if (dr["AgentId"].ToString().Length > 0)
                    {
                        customers.AgentId = System.Convert.ToInt32(dr["AgentId"]);
                    }
                    else
                    {
                        customers.AgentId = null;
                    }
                }
                dr.Close();
            }
        }
        return customers;
    }

    // ------------------------------------------------------------------
    // Pitsini Suwandechochai
    // Method: GetCustomerFNameById(Id)
    // Description: query 1 customer from DB to display on "ProductInfo.aspx" by merging 
    //              first and last name together as 1 field (as 'FullName')
    // ------------------------------------------------------------------
    [DataObjectMethod(DataObjectMethodType.Select)]
    public static Customers GetCustomerFNameById(int inputCustId)
    {
        SqlConnection connection = new SqlConnection();
        Customers CustomerGot = new Customers();
        string sel = "SELECT CustomerId, CustFirstName + ' ' + CustLastName as FullName, "
                + "CustAddress, CustCity, CustProv, CustPostal, CustCountry, CustHomePhone, "
              + "CustBusPhone, CustEmail "
            + "FROM Customers "
            + "WHERE CustomerId = @CustomerId";
        try
        {
            using (connection = TravelExpertsDB.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(sel, connection))
                {
                    cmd.Parameters.AddWithValue("CustomerId", inputCustId);

                    connection.Open();
                    SqlDataReader readerObj = cmd.ExecuteReader(CommandBehavior.SingleRow);
                    if (readerObj.Read()) //while readerObj has lines to read, go through each one 
                    {
                        //add to a customer
                        CustomerGot = new Customers((int)readerObj[0], (string)readerObj[1],
                            (string)readerObj[2], (string)readerObj[3], (string)readerObj[4],
                            (string)readerObj[5], (string)readerObj[6], (string)readerObj[7],
                            (string)readerObj[8], (string)readerObj[9]);
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
                                    + "CustEmail = @email";
                                    if (NewCustomerInfo.AgentId != null) updateStatement += ", AgentId = @agntId ";
                                    updateStatement += " WHERE CustomerId = @CustId";
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
        if (NewCustomerInfo.AgentId != null)
        {
            updateCommand.Parameters.AddWithValue("@agntId", NewCustomerInfo.AgentId);
        }
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

    // ------------------------------------------------------------------
    // Pitsini Suwandechochai
    // Method: GetCustomerFNameById(Id)
    // Description: query 1 customer from DB to display on "ProductInfo.aspx" by merging 
    //              first and last name together as 1 field (as 'FullName')
    // ------------------------------------------------------------------
    [DataObjectMethod(DataObjectMethodType.Select)]
    public static int GetCustomerByUserName(string userName)
    {
        int gotCustId = 0;
        SqlConnection connection = new SqlConnection();
        
        string sel = "SELECT CustomerId "
            + "FROM Customers "
            + "WHERE Username = @userName";
        try
        {
            using (connection = TravelExpertsDB.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(sel, connection))
                {
                    cmd.Parameters.AddWithValue("userName", userName);

                    connection.Open();
                    SqlDataReader readerObj = cmd.ExecuteReader(CommandBehavior.SingleRow);
                    if (readerObj.Read()) //while readerObj has lines to read, go through each one 
                    {
                        //add to a customer
                        gotCustId = (int)readerObj["CustomerId"];
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
        return gotCustId;
    }

    // Pauls GetSalt function returns the salt of the Username this could allow me to do client side hashing (see comment above)
    // it also functions as my "Check user exists" funciton, for if a salt is returned the user DOES exist
        public static string GetSalt(string username)
     {
         SqlConnection connection = TravelExpertsDB.GetConnection();
                    string checkstring = "Select Salt from Customers WHERE Username = '"+username+"';";
        SqlCommand CheckCmd = new SqlCommand(checkstring, connection);
         try
         {
             connection.Open();
            SqlDataReader readerObj = CheckCmd.ExecuteReader(CommandBehavior.SingleRow);
            if (readerObj.Read()) //if it reads a user then checkuser returns true
            {
                return readerObj[0].ToString();
            }
            else return "";
         }
        catch
         {
            throw;
         }
         finally
         {
             connection.Close();
         }
    }
    //Paul Teixeira
    //and ofcourse my registration function, it does an check if exists then insert into customers table
    //returning true if registered, and false if username is already used, throw exception for any other errors
    public static bool Register(string username, string password, Customers NewCustomer)
    {
        string theSalt = GetSalt(username);
        if (theSalt.Length==0)
        {
            //this function creates a random salt for the salting of hashes stored in the database
            string haystack = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789"; //a string of charecters i will choose from
            string newSalt="";//blank string
            System.Random rand = new System.Random();//i use this to reandomly select from the haystack above
            for (int i = 0; i < 6; i++) //do it 5 times
            {
                newSalt += haystack[rand.Next(haystack.Length)];//get random charecter from the beggining and the end of the haystack and add to the salt
            }
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string registerString = "INSERT INTO Customers (Username,Password,Salt,CustFirstName,CustLastName,CustAddress,CustCity,CustProv,CustPostal,CustCountry,CustHomePhone,CustBusPhone,CustEmail) VALUES('"
            + username + "', "
            + "CONVERT(NVARCHAR(32),HashBytes('SHA1', '" + password + "' +'"+newSalt+"'),2), '" //sql statment to hash the password with the salt
            + newSalt + "', '"
            + NewCustomer.CustFirstName + "', '"
            + NewCustomer.CustLastName + "', '"
            + NewCustomer.CustAddress + "', '"
            + NewCustomer.CustCity + "', '"
            + NewCustomer.CustProv + "', '"
            + NewCustomer.CustPostal + "', '"
            + NewCustomer.CustCountry + "', '"
            + NewCustomer.CustHomePhone + "', '"
            + NewCustomer.CustBusPhone + "', '"
            + NewCustomer.CustEmail + "');";
            SqlCommand RegisterCmd = new SqlCommand(registerString, connection);
            try
            {
                connection.Open();
                RegisterCmd.ExecuteNonQuery();
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
        else
        {//salt exsists which means user does too
            return false;
        }
     }
 

}
