//Author:Porkodi
//Version:1.0
//CustomerCS
//Created Date:Jan-29-2014
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

	public Customers()
	{
		//
		// TODO: Add constructor logic here
		//
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

    public string  CustEmail
    {
        get
        {
            return  custEmail;
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
}