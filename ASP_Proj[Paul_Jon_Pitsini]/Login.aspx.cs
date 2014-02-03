using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        //try
        //{

        int CustomerId = LoginDB.Login(txtUserName.Text, txtPasswd.Text);
            if (CustomerId != 0) //logged in was returned true
            {
                //List<Customers> ListOfCustomer = new List<Customers>();
                
                Session.Add("CustID", CustomerId);
           // customerDetail = .

            // goes to the result form
            Response.Redirect("~/ProductInfo.aspx");

            }
            else
            {
                lblError.Text = "The username or password that you entered is incorrect.";
                txtUserName.Focus();
            }
        //}
        //catch (DBConcurrencyException)  // number of rows affected equals zero
        //{
        //    lblError.Text = "Concurrency error occurred. Some changes did not happen";
        //}
        //catch (SqlException ex)  // SQL Server returns a warning or error
        //{
        //    lblError.Text = "Database error # " + ex.Number + ": " + ex.Message;
        //}
        //catch (Exception ex)    // any other error
        //{
        //    lblError.Text = "Other unanticipated error # " + ex.Message;
        //}  


    }
}