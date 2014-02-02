/*
 * Paul Teixeira
 * Registration page, this allows a new customer to register with the travel experts by entering all required information
 * validation for postol code depends on country switch statement below
 * information is passed to Register(string,string,customer) function in DB which checks username doesnt exist and registers the new customer
 * 
 * Cancel returns to previous page without registering
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
                if (CustomersDB.Register(UsernameTxt.Text, Password1Txt.Text, NewCustomer)) //pass object to static CustomerDB class method register this returns true on success false on failure if the username is already taken, other failures(SQL,OVERLOAD,ETC) are caught by try/catch
                {
                    Label14.Visible = false;
                    HttpContext.Current.Response.Write("<SCRIPT LANGUAGE=\"JavaScript\">alert(\"Registration Complete, Welcome to Travel Experts \n \")</SCRIPT>");//inject a javascript alert which will tell user of the saves success
                    Response.Redirect("~/Default.aspx");//then return user to previous page
                }
                else
                {
                    //username already exists
                    Label14.Visible = true;
                    UsernameTxt.Focus();
                }
            }
            catch (Exception ex)
            {
                //problem?
                throw ex; //just throw that exception to the debugger for now
            }
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e) //if user selects new country, update regex to match postol code for that country
    {
       switch(CountryTxt.SelectedItem.ToString())
       {
           case "Canada":
                RegularExpressionValidator4.ValidationExpression = "^[A-Za-z]{1}\\d{1}[A-Za-z]{1} *\\d{1}[A-Za-z]{1}\\d{1}$"; //reg expression for canada
               break;
           case "United States":
                RegularExpressionValidator4.ValidationExpression = "^\\d{5}(-\\d{4})?$";//regexpression for states
               break;
           default:
               RegularExpressionValidator4.ValidationExpression = "(^\\d{5}(-\\d{4})?$)|(^[A-Za-z]{1}\\d{1}[A-Za-z]{1} *\\d{1}[A-Za-z]{1}\\d{1}$)"; //just incase it does both us and canada
               break;
        }
    }
    }