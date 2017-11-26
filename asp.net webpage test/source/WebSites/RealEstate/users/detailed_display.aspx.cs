using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class users_detailed_display : System.Web.UI.Page
{

    SqlConnection con = new SqlConnection("Data Source=DESKTOP-KFI49LK;Initial Catalog=Housing;Integrated Security=True");                  //connects to dayabase
    int id;                                                                                                                                 //will hold the id variable created in the display_house.aspx code
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie _userInfo = Request.Cookies["_userInfo"];
        
        if (_userInfo != null)
        {
            HttpCookie _listingInfo = new HttpCookie("_listingInfo");
            _listingInfo["ID"] = Request.QueryString["id"].ToString();
            Response.Cookies.Add(_listingInfo);

            Response.Redirect("../agents/agent_detailedListing.aspx");
        }

        if (Request.QueryString["id"] == null)                                                                                              //id is the name of the variable holding the listing id
        {
            Response.Redirect("display_houses.aspx");                                                                                       //if id is null then user is redirected to main page when page is loaded
        }
        else
        {
            id = Convert.ToInt32(Request.QueryString["id"].ToString());                                                                     //Changes the listing id into a string so we can use it in our command    
            IncrementDailyHitCount(id);
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
    protected void IncrementDailyHitCount(int listing_id)
    {
        using (var command = new SqlCommand())
        {
           SqlConnection  connection = new SqlConnection();
            connection.ConnectionString = "Data Source=DESKTOP-KFI49LK;Initial Catalog=Housing;Integrated Security=True";
            connection.Open();
            try
            {
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "UPDATE listing SET listing_hitCount = listing_hitCount + 1 WHERE listing_id= "+ listing_id;
                command.ExecuteNonQuery();
            }
            catch
            {
                Response.Write("<script>alert('Can't add views count')</script>");
            }
            connection.Close();
        }
    }
    

}
