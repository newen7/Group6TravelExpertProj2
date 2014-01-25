using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Customer
/// </summary>
public class Customer
{
    public int CustomerId;
    public string CustFirstName;
    public string CustLastName;
    public string CustAddress;
    public string CustCity;
    public string CustProv;
    public string CustPostal;
    public string CustCountry;
    public string CustHomePhone;
    public string CustBusPhone;
    public string CustEmail;
    public int AgentId;
	public Customer()
	{
        //blank constructor
	}
    public Customer(int newCustomerId, //full constructor
        string newCustFirstName, 
        string newCustLastName, 
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
        CustomerId = newCustomerId;
        CustFirstName = newCustFirstName;
        CustLastName = newCustLastName;
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
}