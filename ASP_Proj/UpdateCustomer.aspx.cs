/*
 * Paul Teixeira
 * This file is the behaviour of my updateCustomer functionality
 * On load, (and not on postbacks) it fills these textboxes with information retreived by customerId from the database
 * On save, it validates firstname and last name (as per assignment) 
 * loads the information from the textboxes into a Customers object and passes this object to
 * CustomerDB.UpdateCustomer(CustomerObject)
 * 
 * Cancel returns to previous page without updating and save will return to previous page after saving
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UpdateCustomer : System.Web.UI.Page
{
    public int CustId;
    public Customers CustomerToEdit; //creates an object of the customer class to be used throughout program

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["CustID"] != null) //gets the sessionId New was storing to find current customerID that was selected by user
        {
            CustId = Convert.ToInt32(Session["CustID"]); //stores it in my own integer (global and public)
            if(!IsPostBack) SetFeilds(); //only on first load (not postbacks) do i set the feilds to the information from database
        }
        else
        {
            Response.Redirect("~/Default.aspx"); //if no sessionId we cannot do update anyways, so return user to previous page
        }
    }
    protected void SetFeilds()
    {
        //page loads get all the information
        CustomerToEdit = CustomersDB.GetCustomerID(CustId.ToString()); //use GetCustomerId() to load the global CustomerToEdit object with information from database

        CustIdTxt.Text = CustomerToEdit.CustomerID.ToString(); //fill every feild on page with this information stored in the object
        FirstNameTxt.Text = CustomerToEdit.CustFirstName;
        LastNameTxt.Text = CustomerToEdit.CustLastName;
        AddressTxt.Text = CustomerToEdit.CustAddress;
        CityTxt.Text = CustomerToEdit.CustCity;
        ProvinceTxt.Text = CustomerToEdit.CustProv;
        PostolCodeTxt.Text = CustomerToEdit.CustPostal;
        CountryTxt.Text = CustomerToEdit.CustCountry;
        HomePhoneTxt.Text = CustomerToEdit.CustHomePhone;
        BussinessPhoneTxt.Text = CustomerToEdit.CustBusPhone;
        EmailTxt.Text = CustomerToEdit.CustEmail;
        AgentIdTxt.Text = CustomerToEdit.AgentId.ToString();
    }
    protected void CancelBtn_Click(object sender, EventArgs e) //on cancel button click
    {
        //Return to revious page without updating
        Response.Redirect("~/Default.aspx");
    }
    protected void SaveBtn_Click(object sender, EventArgs e) //on save button click
    {
        if (IsValid)//checks isValid to confirm that the validators(agentId range,firstname & lastname required) in the aspx did not return a false
        {
            CustomerToEdit = new Customers();//sets the object from global scope to a new blank constructor (clearing the object for repurposing)
            CustomerToEdit.CustomerID = CustId; //get id from global integer (just incase somone was to change this to try to overwrite others information)
            //fill information from feilds on aspx into the newly cleared object
            CustomerToEdit.CustFirstName = FirstNameTxt.Text;
            CustomerToEdit.CustLastName = LastNameTxt.Text;
            CustomerToEdit.CustAddress = AddressTxt.Text;
            CustomerToEdit.CustProv = ProvinceTxt.Text;
            CustomerToEdit.CustCity = CityTxt.Text;
            CustomerToEdit.CustPostal = PostolCodeTxt.Text;
            CustomerToEdit.CustCountry = CountryTxt.Text;
            CustomerToEdit.CustHomePhone = HomePhoneTxt.Text;
            CustomerToEdit.CustBusPhone = BussinessPhoneTxt.Text;
            CustomerToEdit.CustEmail = EmailTxt.Text;
            if (CustomerToEdit.AgentId.ToString().Length > 0)
            {
                CustomerToEdit.AgentId = Convert.ToInt32(AgentIdTxt.Text);
            }
            else
            {
                CustomerToEdit.AgentId = null;
            }
            try
            {
                if (CustomersDB.UpdateCustomer(CustomerToEdit)) //pass object to static CustomerDB class method UpdateCustomer this returns true on success false on failure (also throws exception so i do not bother with false return)
                {
                    HttpContext.Current.Response.Write("<SCRIPT LANGUAGE=\"JavaScript\">alert(\"Updated Successfully !\")</SCRIPT>");//inject a javascript alert which will tell user of the saves success
                    Response.Redirect("~/Default.aspx");//then return user to previous page
                }
            }
            catch (Exception ex)
            {
                //problem?
                throw ex; //just throw that exception to the debugger for now
            }
        }
        else
        {
          //if not valid, possibly do something else? javascript "Update could not be made?" Exception would catch above this and Exceptions are generally more verbose
        }
    }
}