using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class agents_Practice : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("Data Source=DESKTOP-KFI49LK;Initial Catalog=Housing;Integrated Security=True");
    int id;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] == null)
        {
            Response.Redirect("display_houses.aspx");
        }
        else
        {
            id = Convert.ToInt32(Request.QueryString["id"].ToString());
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * FROM listing INNER JOIN agency ON listing.agency_id = agency.agency_id INNER JOIN agent ON listing.agent_id = agent.agent_id WHERE listing.listing_id= '" + id + "'";       //
            cmd.ExecuteNonQuery();
            // FROM agency INNER JOIN listing ON listing.agency_id = agency.agency_id INNER JOIN agent ON listing.agent_id = agent.agent_id WHERE listing.listing_sqFT > '"+TextBox1.Text+"'";

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            d2.DataSource = dt;     //d2 is defined in the source portion of this website page
            d2.DataBind();

            con.Close();
        }
    }
}