using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class agents_listing_review : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("Data Source=DESKTOP-KFI49LK;Initial Catalog=Housing;Integrated Security=True");                  //connects to dayabase
    int id;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] == null)                                                                                              //id is the name of the variable holding the listing id
        {
            Response.Redirect("display_houses.aspx");                                                                                       //if id is null then user is redirected to main page when page is loaded
        }
    }
}