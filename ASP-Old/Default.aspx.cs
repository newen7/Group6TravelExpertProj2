using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    int id; // keeps customerID
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["CustID"] != null)
        {
            id = Convert.ToInt32(Session["CustID"]);
        }
        else
        {
            id = 0;
            Session.Add("CustID", id);
        }
    }

    //==========================================================
    // Pitsini Suwandechochai
    // when user clicks button to view products
    protected void btnProduct_Click(object sender, EventArgs e)
    {
        if (Session["CustID"] != null)
        {
            Session["CustID"] = id.ToString();
            Response.Redirect("~/ProductInfo.aspx");
        }
    }
    
    // shows customer ID on the button everytime user selects customer (ObjectDatasource2 was Selected).    
    protected void ObjectDataSource2_Selected(object sender, ObjectDataSourceStatusEventArgs e)
    {
        id = Convert.ToInt32(ddlCustomer.SelectedValue);
        Session["CustID"] = id.ToString();
        btnProduct.Text = "View products from Customer ID: " + id.ToString();        
    }
    //==============End-Pitsini==================================    
}