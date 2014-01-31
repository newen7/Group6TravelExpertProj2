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
    public Customers NewCustomer; //creates an object of the customer class to be used throughout program

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void CancelBtn_Click(object sender, EventArgs e) //on cancel button click
    {
        //Return to revious page without updating
        Response.Redirect("~/Default.aspx");
    }
    protected void SaveBtn_Click(object sender, EventArgs e) //on save button click
    {
        if (IsValid)//checks isValid to confirm that the validators in the aspx did not return a false
        {
            NewCustomer = new Customers();//sets the object from global scope to a new blank constructor (clearing the object for repurposing)
            NewCustomer.CustomerID = null;
            //fill information from feilds on aspx into the newly cleared object
            NewCustomer.CustFirstName = FirstNameTxt.Text;
            NewCustomer.CustLastName = LastNameTxt.Text;
            NewCustomer.CustAddress = AddressTxt.Text;
            NewCustomer.CustProv = ProvinceTxt.Text;
            NewCustomer.CustCity = CityTxt.Text;
            NewCustomer.CustPostal = PostolCodeTxt.Text;
            NewCustomer.CustCountry = CountryTxt.Text;
            NewCustomer.CustHomePhone = HomePhoneTxt.Text;
            NewCustomer.CustBusPhone = BussinessPhoneTxt.Text;
            NewCustomer.CustEmail = EmailTxt.Text;
            NewCustomer.AgentId = null; //this one must be stored as int so i do a convert.to on it
            try
            {
                if (CustomersDB.Register(UsernameTxt.Text,Password1Txt.Text,NewCustomer)) //pass object to static CustomerDB class method UpdateCustomer this returns true on success false on failure (also throws exception so i do not bother with false return)
                {
                    HttpContext.Current.Response.Write("<SCRIPT LANGUAGE=\"JavaScript\">alert(\"Registration Complete, Welcome to Travel Experts \n \")</SCRIPT>");//inject a javascript alert which will tell user of the saves success
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
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
       switch(CountryTxt.SelectedItem.ToString())
       {
           case "Canada":
                RegularExpressionValidator4.ValidationExpression = "^[ABCEGHJKLMNPRSTVXY]{1}\\d{1}[A-Z]{1} *\\d{1}[A-Z]{1}\\d{1}$"; //reg expression for canada
               break;
           case "United States":
                RegularExpressionValidator4.ValidationExpression = "^\\d{5}(-\\d{4})?$";//regexpression for states
               break;
           default:
               RegularExpressionValidator4.ValidationExpression = "(^\\d{5}(-\\d{4})?$)|(^[ABCEGHJKLMNPRSTVXY]{1}\\d{1}[A-Z]{1} *\\d{1}[A-Z]{1}\\d{1}$)"; //just incase it does both us and canada
               break;
        }
    }
    }