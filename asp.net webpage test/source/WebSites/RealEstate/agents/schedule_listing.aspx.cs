using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class agents_schedule_listing : System.Web.UI.Page
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-KFI49LK;Initial Catalog=Housing;Integrated Security=True");                  //connects to dayabase
        HttpCookie _listingInfo = Request.Cookies["_listingInfo"];
        int id;                                                                                                                                 //will hold the id variable created in the display_house.aspx code
        

        id = Convert.ToInt32(_listingInfo["ID"].ToString());
        
        SqlCommand cmd = new SqlCommand("select listing.listing_id, listing.listing_city, listing.listing_state, listing.listing_street, listing.listing_zip, schedule.start, schedule.finish, agent.agent_Fname, agent.agent_Lname, agency.agency_name, schedule.agent_showing_firstName, schedule.agent_showing_lastName, schedule.agency_showing_company FROM listing INNER JOIN agency ON listing.agency_id = agency.agency_id INNER JOIN agent ON listing.agent_id = agent.agent_id INNER JOIN schedule ON listing.listing_id = schedule.listing_id WHERE listing.listing_id= '" + id + "'", con);
        //cmd.CommandType = CommandType.Text;
        //cmd.CommandText = "select listing.listing_id, listing.listing_city, listing.listing_state, listing.listing_street, listing.listing_zip, schedule.start, schedule.finish, agent.agent_Fname, agent.agent_Lname, agency.agency_name FROM listing INNER JOIN agency ON listing.agency_id = agency.agency_id INNER JOIN agent ON listing.agent_id = agent.agent_id INNER JOIN schedule ON listing.listing_id = schedule.listing_id WHERE listing.listing_id= '" + id + "'";       //
        //cmd.ExecuteNonQuery();
        // FROM agency INNER JOIN listing ON listing.agency_id = agency.agency_id INNER JOIN agent ON listing.agent_id = agent.agent_id WHERE listing.listing_sqFT > '"+TextBox1.Text+"'";
        con.Open();

        GridView1.DataSource = cmd.ExecuteReader();   //d1 is defined in the source portion of this website page
        GridView1.DataBind();

        con.Close();

    }

    protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}