using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class agents_agent_forms : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("Data Source=DESKTOP-KFI49LK;Initial Catalog=Housing;Integrated Security=True");
    SqlCommand cmd = new SqlCommand();
    SqlDataReader reader;
    Listing new_listing = new Listing();
    string agent_fname, agent_lname, agent_email, agent_phone;

    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie _userInfo = Request.Cookies["_userInfo"];

        if (_userInfo == null)
        {
            Response.Redirect("login.aspx");
        }
        else
        {
            //write your code here on first load...
            first_load();
        }
        if (!IsPostBack)
        {
            set_frontend_form();
        }
    }

    protected void logoutButton_Click(object sender, EventArgs e)
    {
        HttpCookie _userInfo = Request.Cookies["_userInfo"];
        _userInfo.Expires = DateTime.Now.AddDays(-1d);
        Response.Cookies.Add(_userInfo);
        Response.Redirect("login.aspx");
    }
    protected void first_load()
    {
        //get agent and listing ID
        int agent_id = 0;
        int listing_id = 0;
        HttpCookie _userInfo = Request.Cookies["_userInfo"];
        int.TryParse(_userInfo["AgentID"], out agent_id);
        listing_id = Convert.ToInt32(Request.QueryString["listing_id"].ToString());
        //********************************************
        //*******************************************


        SqlCommand cmd = con.CreateCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select * FROM listing WHERE listing_id=" + listing_id;
        con.Open();
        reader = cmd.ExecuteReader();
        //for listing
        while (reader.Read())
        {   //initialize new_listing object to with retrieving sql data 
            Boolean occupied_flag = false;
            new_listing.Listing_price = Convert.ToInt32(reader["listing_price"]);
            new_listing.Listing_state = reader["listing_state"].ToString();
            new_listing.Listing_street = reader["listing_street"].ToString();
            new_listing.Listing_shortDescription = reader["listing_shortDescription"].ToString();
            new_listing.Listing_city = reader["listing_city"].ToString();
            new_listing.Listing_sqFT = Convert.ToInt32(reader["listing_sqFT"]);
            new_listing.Listing_description = reader["listing_description"].ToString();
            new_listing.Listing_zip = reader["listing_zip"].ToString();
            new_listing.Listing_roomDescription = reader["listing_roomDescription"].ToString();
            new_listing.Listing_nameSubDivision = reader["listing_nameSubDivision"].ToString();
            new_listing.Listing_alarminfo = reader["listing_alarmInfo"].ToString();
            Boolean.TryParse(reader["listing_occupied"].ToString(), out occupied_flag);
            new_listing.Listing_occupied = occupied_flag;
        }
        reader.Close();
        con.Close();


        cmd.CommandText = "select * FROM agent WHERE agent_id=" + agent_id;
        con.Open();
        reader = cmd.ExecuteReader();
        //for agent
        while (reader.Read())
        {   //initialize new_listing object to with retrieving sql data 
            //= Convert.ToInt64(reader["listing_price"]);
            agent_fname = reader["agent_Fname"].ToString();
            agent_lname = reader["agent_Lname"].ToString();
            agent_email = reader["agent_email"].ToString();
            agent_phone = reader["agent_number"].ToString();
        }
        reader.Close();
        con.Close();

        //ClosingForms.SendClosingForms();
    }

    protected void Cancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("agentMain.aspx");
    }

    protected void close_listing_Click(object sender, EventArgs e)
    {
        ClosingForms.SendClosingForms(new_listing.Listing_street, new_listing.Listing_city, new_listing.Listing_state, new_listing.Listing_zip.ToString(), new_listing.Listing_description, 90000, agent_fname, agent_lname, agent_email);
        Response.Redirect("agentMain.aspx?");
    }
    protected void set_frontend_form()
    {
        front_agentfname.Text = agent_fname;
        front_agentlname.Text = agent_lname;
        front_agentphone.Text = agent_phone;
        front_agentemail.Text = agent_email;
        front_listing_street.Text = new_listing.Listing_street;
        front_listing_city.Text = new_listing.Listing_city;
        front_listing_state.Text = new_listing.Listing_state;
        front_listing_zip.Text = new_listing.Listing_zip.ToString();

    }
}