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
    protected void GridViewProduct_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Footer)
        {
                decimal totalCost = ProductDB.GetBasePriceSummary(Convert.ToInt32(Session["CustID"]));
                if (totalCost != 0)
                {
                    e.Row.Cells[6].Text = "Your total cost = ";
                    e.Row.Cells[7].Text = totalCost.ToString("c");
                }
        }
    }
}