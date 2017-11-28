using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class agents_agent_detailedListing : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-KFI49LK;Initial Catalog=Housing;Integrated Security=True");                  //connects to dayabase
        int id;                                                                                                                                 //will hold the id variable created in the display_house.aspx code
        HttpCookie _listingInfo = Request.Cookies["_listingInfo"];
        HttpCookie _userInfo = Request.Cookies["_userInfo"];

        

        if (_userInfo == null)
        {
            Response.Redirect("login.aspx");
        }

        else
        {
            if (_listingInfo["ID"] == null)                                                                                              //id is the name of the variable holding the listing id
            {

                Response.Redirect("../users/display_houses.aspx");                                                                                       //if id is null then user is redirected to main page when page is loaded
            }
            id = Convert.ToInt32(_listingInfo["ID"].ToString());                                                                     //Changes the listing id into a string so we can use it in our command
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * FROM listing INNER JOIN agency ON listing.agency_id = agency.agency_id INNER JOIN agent ON listing.agent_id = agent.agent_id WHERE listing.listing_id= '" + id + "'";       //
            cmd.ExecuteNonQuery();

            // FROM agency INNER JOIN listing ON listing.agency_id = agency.agency_id INNER JOIN agent ON listing.agent_id = agent.agent_id WHERE listing.listing_sqFT > '"+TextBox1.Text+"'";

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            d1.DataSource = dt;     //d1 is defined in the source portion of this website page
            d1.DataBind();
            con.Close();

        }

        }
    
}