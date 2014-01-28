using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProductInfo : System.Web.UI.Page
{
    int id;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["CustID"] == null)
        {
            id = 0;
            Session.Add("CustID", id);
        }
        else
        {
            id = Convert.ToInt32(Session["CustID"]);
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Session.Add("CustID", null);
    }
}