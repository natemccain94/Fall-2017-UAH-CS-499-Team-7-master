using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class agentMain : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("Data Source=DESKTOP-KFI49LK;Initial Catalog=Housing;Integrated Security=True");
    protected void Page_Load(object sender, EventArgs e)
    {
        
        HttpCookie _userInfo = Request.Cookies["_userInfo"];

        if (_userInfo == null)
        {
            Response.Redirect("login.aspx");
        }
        else
        {
            //parse agent id to int
            //agent_id_flag return false if can't convert agent_id
            bool agent_id_flag = false;
            int agent_id = 0;
            agent_id_flag = int.TryParse(_userInfo["AgentID"], out agent_id);

            con.Open();                                             //connects to database
            SqlCommand cmd = con.CreateCommand();                   //create object of command called cmd
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT listing.listing_id, agency.agency_id, agent.agent_id, listing.listing_zip, listing.pic1, listing.listing_price, listing.listing_street, listing.listing_state, listing.listing_city, listing.listing_zip, listing.listing_sqFT, agency.agency_name, agent.agent_Fname, agent.agent_Lname FROM agency INNER JOIN listing ON listing.agency_id = agency.agency_id INNER JOIN agent ON listing.agent_id = agent.agent_id WHERE listing.agent_id="+agent_id;
            cmd.ExecuteNonQuery();                                 //takes the text we created above and executes it

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            d2.DataSource = dt;     //d1 is defined in the source portion of this website page
            d2.DataBind();
            con.Close();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        HttpCookie _userInfo = Request.Cookies["_userInfo"];
        _userInfo.Expires = DateTime.Now.AddDays(-1d);
        Response.Cookies.Add(_userInfo);
        Response.Redirect("login.aspx");
    }

    protected void GetAgentID_Click(object sender, EventArgs e)
    {
        HttpCookie _userInfo = Request.Cookies["_userInfo"];
        updaterino.Text = _userInfo["AgentID"];
    }
}