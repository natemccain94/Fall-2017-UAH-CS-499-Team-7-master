using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class agents_delete_listing : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie _userInfo = Request.Cookies["_userInfo"];


        if (_userInfo == null)
        {
            Response.Redirect("login.aspx");
        }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        HttpCookie _userInfo = Request.Cookies["_userInfo"];
        _userInfo.Expires = DateTime.Now.AddDays(-1d);
        Response.Cookies.Add(_userInfo);
        Response.Redirect("login.aspx");
    }
}