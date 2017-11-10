using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    [WebMethod]
    public static string getAllagents(string name)
    {
        SQL_connection tester = new SQL_connection();
        tester.openConnection();
        DataTable a = tester.GetAllAgents();
        return ConvertDataTableToHTML(a);
    }
    public static string getOneagents(string name)
    {
        SQL_connection tester = new SQL_connection();
        tester.openConnection();
        DataTable a = tester.GetAllAgents();
        return ConvertDataTableToHTML(a);
    }
    [WebMethod]
    protected void login(object sender, System.EventArgs e)
    {
        Response.Redirect("login.aspx");
    }
    public static string ConvertDataTableToHTML(DataTable dt)
    {
        string html = "<table>";
        //add header row
        html += "<tr>";
        for (int i = 0; i < dt.Columns.Count; i++)
            html += "<td>" + dt.Columns[i].ColumnName + "</td>";
        html += "</tr>";
        //add rows
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            html += "<tr>";
            for (int j = 0; j < dt.Columns.Count; j++)
                html += "<td>" + dt.Rows[i][j].ToString() + "</td>";
            html += "</tr>";
        }
        html += "</table>";
        return html;
    }
}
