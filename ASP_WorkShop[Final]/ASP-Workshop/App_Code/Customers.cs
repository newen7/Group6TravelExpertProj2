//Author:Porkodi
//Created Date:24-Jan-2014
//ASP.net-CPRG-214

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class Customers
{
    private int customerId;
    private string custFirstName;
    private string custLastName;
    private string custAddress;
    private string custCity;
    private string custProv;
    private string custPostal;
    private string custCountry;
    private string custHomePhone;
    private string custBusPhone;
    private string custEmail;
    private int agentId;

    // =========================
    // Pitsini Suwandechochai
    // create parameter - Full name of customers    [P.S. Just try to be fancy]
    private string fullName;
    // =========================
    

    public Customers()
    {
        // TODO: Add constructor logic here
    }

    public int CustomerID
    {
        get
        {
            return customerId;
        }
        set
        {
            customerId = value;
        }
    }

    public string CustFirstName
    {
        get
        {
            return custFirstName;
        }
        set
        {
            custFirstName = value;
        }
    }
    public string CustLastName
    {
        get
        {
            return custLastName;
        }
        set
        {
            custLastName = value;
        }
    }

    public string CustAddress
    {
        get
        {
            return custAddress;
        }
        set
        {
            custAddress = value;
        }
    }
    public string CustCity
    {
        get
        {
            return custCity;
        }
        set
        {
            custCity = value;
        }
    }

    public string CustProv
    {
        get
        {
            return custProv;
        }
        set
        {
            custProv = value;
        }
    }

    public string CustPostal
    {
        get
        {
            return custPostal;
        }
        set
        {
            custPostal = value;
        }
    }
    public string CustCountry
    {
        get
        {
            return custCountry;
        }
        set
        {
            custCountry = value;
        }
    }
    public string CustHomePhone
    {
        get
        {
            return custHomePhone;
        }
        set
        {
            custHomePhone = value;
        }
    }

    public string CustBusPhone
    {
        get
        {
            return custBusPhone;
        }
        set
        {
            custBusPhone = value;
        }
    }

    public string CustEmail
    {
        get
        {
            return custEmail;
        }
        set
        {
            custEmail = value;
        }
    }
    public int AgentId
    {
        get
        {
            return agentId;
        }
        set
        {
            agentId = value;
        }
    }

    // =============================================
    // Pitsini - added FullName parameter
    //         - added a constructor
    // =============================================
    public string FullName
    {
        get { return fullName; }
        set { fullName = value; }
    }

    // constructor
    public Customers(int newCustomerId, // full constructor (with "Full name")
        string newFullName,
        string newCustAddress,
        string newCustCity,
        string newCustProv,
        string newCustPostal,
        string newCustCountry,
        string newCustHomePhone,
        string newCustBusPhone,
        string newCustEmail,
        int newAgentId)
    {
        CustomerID = newCustomerId;
        FullName = newFullName;
        CustAddress = newCustAddress;
        CustCity = newCustCity;
        CustProv = newCustProv;
        CustPostal = newCustPostal;
        CustCountry = newCustCountry;
        CustHomePhone = newCustHomePhone;
        CustBusPhone = newCustBusPhone;
        CustEmail = newCustEmail;
        AgentId = newAgentId;
    }
    // =============End - Pitsini===============
}