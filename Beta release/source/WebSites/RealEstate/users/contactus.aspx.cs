using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class users_contactus : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("Data Source=DESKTOP-KFI49LK;Initial Catalog=Housing;Integrated Security=True");
    SqlCommand cmd = new SqlCommand();
    SqlDataReader reader;
    Listing new_listing = new Listing();
    int agent_id, agency_id, listing_id;
    string agent_fname, agent_lname, agent_email, agent_phone;
    string listing_street, listing_city, listing_state, listing_ZIP;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            get_listing_info();
            set_frontend_form();
        }
    }
    protected void get_listing_info()
    {
        listing_id = Convert.ToInt32(Request.QueryString["id"].ToString());
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
            listing_state = reader["listing_state"].ToString();
            listing_street = reader["listing_street"].ToString();
            listing_city = reader["listing_city"].ToString();
            listing_ZIP = reader["listing_zip"].ToString();
            agent_id = Convert.ToInt32(reader["agent_id"]);
            agency_id = Convert.ToInt32(reader["agency_id"]);
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

    protected void request_listing_Click(object sender, EventArgs e)
    {
        string customer_fname, customer_lname, customer_phone, customer_email;
        customer_fname = form_customer_fname.Text;
        customer_lname = form_customer_lname.Text;
        customer_phone = form_customer_phone.Text;
        customer_email = form_customer_email.Text;
        get_listing_info();
        EmailAnAgent.CustomerRequestForShowing(agent_email, agent_fname, agent_lname, customer_fname, customer_lname, customer_phone, customer_email, listing_street,listing_city, listing_state, listing_ZIP);
        Response.Redirect("display_houses.aspx?");

    }
    protected void set_frontend_form()
    {

        front_agentfname.Text = agent_fname;
        front_agentlname.Text = agent_lname;
        front_agentphone.Text = agent_phone;
        front_agentemail.Text = agent_email;
        front_listing_street.Text = listing_street;
        front_listing_city.Text = listing_city;
        front_listing_state.Text = listing_state;
        front_listing_zip.Text = listing_ZIP;

    }
}  