//=======================================
 //Pitsini Suwandechochai
 //Description: 1. This page is continued from Default.aspx [Customer Display-Porkodi's part]
 //                When this page loades, it gets the session state is called ["CustID"] which 
 //                stores Customer ID from the previous page and sent it to 2 ObjectDataSources.
 //                - First ObjectDatasource: to show customer information on "DetailsView" to
 //                  let user knkow it's the right customer that he/she is looking for.
 //                - Secound ObjectDataSource: to show infomation on "GridView" about booking details 
 //                  and products that displayed customer has booked. Also have Total cost owing 
 //                  for all products for those customer.
 //Note#1: I set the currency format for "Base Price" and the ShortDate format for 
 //        the "StartDate" and "EndDate" [in the GridView]
 //Note#2: For my experience for learning ASP, I tried to merge fist and last name from databse
 //        to the "FullName" and display in "DetailsView" by using sql command in 
 //        CustomersDB >> "GetCustomerFNameById(Id)" method
//---------------------------------------
// Summary Pitsini's work
// 1. GetCustomerFNameById(CustId) Method >> in CustomersDB
// 2. create Product Class
// 3. create ProductDB
//    - GetProductByID(int CustomerId)
//    - GetBasePriceSummary(int inputCustId)
// 4. ProductInfo.aspx >> display customer detail and all products for a chosen customer.
//                     >> has button to go back to the previous page to choose another customer.
//=======================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProductInfo : System.Web.UI.Page
{
    int id;     // store Customer ID and pass it to Session State

    // when loading the page
    protected void Page_Load(object sender, EventArgs e)
    {
        // checks if have data in Session
        if (Session["CustID"] == null)
        {
            id = 0;
            Session.Add("CustID", id);
        }
        else
        {
            id = Convert.ToInt32(Session["CustID"]);

            string name = CustomersDB.GetCustomerID(id.ToString()).CustFirstName;
            lblWelcome.Text = "Welcome, " + name;
        }
    }

    // on click event -- "Choose another customer" button
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Session.Add("CustID", null);    // reset Session State as customer wants to signout
    }

    // event -- after a row has been databound [in GridView]
    protected void GridViewProduct_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // checks if that row is footer
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            // call method from ProductDB for the total cost
            decimal totalCost = ProductDB.GetBasePriceSummary(Convert.ToInt32(Session["CustID"]));
            if (totalCost != 0) // if customer has bought a product
            {
                e.Row.Cells[6].Text = "Your total cost = ";
                e.Row.Cells[7].Text = totalCost.ToString("c");
            }
        }   // end - if statement
        
    }
    
}