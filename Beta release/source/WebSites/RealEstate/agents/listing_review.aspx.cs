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
    //int id;
    string scheduleID = null;
    string showing_agent_email = null;
    string showing_agent_phone = null;
    string lock_box_info = null;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.QueryString["id"] == null)                                                                                              //id is the name of the variable holding the listing id
        {
            Response.Redirect("display_houses.aspx");                                                                                       //if id is null then user is redirected to main page when page is loaded
        }
        /*
        if (IsPostBack)
        {
          autopopulate();
        }
        */

        scheduleID = (Request.QueryString["id"]).ToString();


        int listingID = 0;
        int agentID = 0;

        HttpCookie _listingInfo = Request.Cookies["_listingInfo"];
        HttpCookie _userInfo = Request.Cookies["_userInfo"];
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-KFI49LK;Initial Catalog=Housing;Integrated Security=True");
        SqlCommand cmd1 = new SqlCommand("SELECT agent_email FROM agent  WHERE agent_id = '" + agentID + "' ", con);
        SqlDataReader usernameRdr = null;
        listingID = Convert.ToInt32(_listingInfo["ID"].ToString());
        agentID = Convert.ToInt32(_userInfo["AgentID"].ToString());


        con.Open();

        usernameRdr = cmd1.ExecuteReader();

        while (usernameRdr.Read())
        {
            showing_agent_email = usernameRdr["agent_email"].ToString();
        }

        usernameRdr.Close();
        cmd1 = new SqlCommand("SELECT agent_number FROM agent  WHERE agent_id = '" + agentID + "' ", con);
        usernameRdr = null;
        usernameRdr = cmd1.ExecuteReader();

        while (usernameRdr.Read())
        {
            lock_box_info = usernameRdr["agent_number"].ToString();
        }


        usernameRdr.Close();
        cmd1 = new SqlCommand("SELECT listing_alarmInfo FROM listing  WHERE listing_id = '" + listingID + "' ", con);
        usernameRdr = null;
        usernameRdr = cmd1.ExecuteReader();

        while (usernameRdr.Read())
        {
            showing_agent_phone = usernameRdr["listing_alarmInfo"].ToString();
        }


        con.Close();


        Label5.Text = showing_agent_email;
        Label6.Text = showing_agent_phone;
        Label7.Text = lock_box_info;

    }

    protected void Button1_Click(object sender, EventArgs e)
    {


        int cust_interest = 0;
        int cust_experience = 0;
        int cust_opinionPrice = 0;
        int agent_opinionPrice = 0;
        string fname_Buyer = null;
        string lname_Buyer = null;
        string additional_notes = null;
        int listingID = 0;
        int agentID = 0;


        HttpCookie _listingInfo = Request.Cookies["_listingInfo"];
        HttpCookie _userInfo = Request.Cookies["_userInfo"];
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-KFI49LK;Initial Catalog=Housing;Integrated Security=True");
        scheduleID = Request.QueryString["id"];
        agentID = Convert.ToInt32(_userInfo["AgentID"].ToString());

        cust_interest = Convert.ToInt32(DropDownList1.SelectedValue);
        cust_experience = Convert.ToInt32(DropDownList2.SelectedValue);
        cust_opinionPrice = Convert.ToInt32(DropDownList3.SelectedValue);
        agent_opinionPrice = Convert.ToInt32(DropDownList4.SelectedValue);

        fname_Buyer = TextBox2.Text;
        lname_Buyer = TextBox3.Text;
        additional_notes = TextBox1.Text;

        checkDel();

        con.Open();
        string sql = "INSERT INTO reviews(cutomer_interest, customer_experience, customer_priceOpinion, agent_priceOpinion, fname_ofBuyer, lname_ofBuyer, listing_id, agent_id, additional_notes, schedule_id)VALUES('" + cust_interest + "','" + cust_experience + "','" + cust_opinionPrice + "','" + agent_opinionPrice + "','" + fname_Buyer + "','" + lname_Buyer + "','" + listingID + "','" + agentID + "', '" + additional_notes + "', '" + Convert.ToInt32(scheduleID) + "' )";
        SqlCommand command;
        command = new SqlCommand(sql, con);
        int x = command.ExecuteNonQuery();

        con.Close();

        Response.Redirect("schedule_listing.aspx");

    }


    public void checkDel()
    {
        int del = 0;
        string sql = "SELECT COUNT(*) from reviews WHERE schedule_id= '" + scheduleID + "' ";
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-KFI49LK;Initial Catalog=Housing;Integrated Security=True");
        SqlCommand cmd = new SqlCommand(sql, con);

        con.Open();
        int result = int.Parse(cmd.ExecuteScalar().ToString());

        if (result == 0)
        {
            Response.Write("This is good");
        }
        else
        {
            del = 1;


        }

        if (del == 1)
        {
            string delSql = "DELETE FROM reviews WHERE schedule_id= '" + scheduleID + "'";
            SqlCommand cmd2 = new SqlCommand(delSql, con);
            int x = cmd2.ExecuteNonQuery();
        }

        con.Close();

    }
    //---------------------------------------------
    //---------------------------------------------------------
    public void autopopulate()
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-KFI49LK;Initial Catalog=Housing;Integrated Security=True");
        SqlCommand cmd1 = new SqlCommand("SELECT cutomer_interest FROM reviews  WHERE schedule_id = '" + scheduleID + "' ", con);
        SqlDataReader usernameRdr = null;
        con.Open();


        usernameRdr = cmd1.ExecuteReader();

        while (usernameRdr.Read())
        {
            DropDownList1.SelectedItem.Text = usernameRdr["cutomer_interest"].ToString();

        }


        usernameRdr.Close();


        cmd1 = new SqlCommand("SELECT customer_experience FROM reviews  WHERE schedule_id = '" + scheduleID + "' ", con);
        usernameRdr = null;
        usernameRdr = cmd1.ExecuteReader();
        while (usernameRdr.Read())
        {
            //DropDownList1.SelectedValue = 2.ToString();
            DropDownList2.SelectedItem.Text = usernameRdr["customer_experience"].ToString();

        }

        usernameRdr.Close();

        cmd1 = new SqlCommand("SELECT customer_priceOpinion FROM reviews  WHERE schedule_id = '" + scheduleID + "' ", con);
        usernameRdr = null;
        usernameRdr = cmd1.ExecuteReader();
        while (usernameRdr.Read())
        {
            DropDownList3.SelectedItem.Text = usernameRdr["customer_priceOpinion"].ToString();
            //DropDownList3.SelectedValue = usernameRdr["customer_priceOpinion"].ToString();

        }

        usernameRdr.Close();

        cmd1 = new SqlCommand("SELECT agent_priceOpinion FROM reviews  WHERE schedule_id = '" + scheduleID + "' ", con);
        usernameRdr = null;
        usernameRdr = cmd1.ExecuteReader();
        while (usernameRdr.Read())
        {
            DropDownList4.SelectedItem.Text = usernameRdr["agent_priceOpinion"].ToString();
            //DropDownList4.SelectedValue = usernameRdr["agent_priceOpinion"].ToString();

        }

        usernameRdr.Close();

        cmd1 = new SqlCommand("SELECT fname_ofBuyer FROM reviews  WHERE schedule_id = '" + scheduleID + "' ", con);
        usernameRdr = null;
        usernameRdr = cmd1.ExecuteReader();
        while (usernameRdr.Read())
        {
            TextBox2.Text = usernameRdr["fname_ofBuyer"].ToString();
        }

        usernameRdr.Close();

        cmd1 = new SqlCommand("SELECT lname_ofBuyer FROM reviews  WHERE schedule_id = '" + scheduleID + "' ", con);
        usernameRdr = null;
        usernameRdr = cmd1.ExecuteReader();
        while (usernameRdr.Read())
        {
            string a = usernameRdr["lname_ofBuyer"].ToString();
            TextBox3.Text = usernameRdr["lname_ofBuyer"].ToString();
        }

        usernameRdr.Close();

        cmd1 = new SqlCommand("SELECT additional_notes FROM reviews  WHERE schedule_id = '" + scheduleID + "' ", con);
        usernameRdr = null;
        usernameRdr = cmd1.ExecuteReader();
        while (usernameRdr.Read())
        {
            string a = usernameRdr["additional_notes"].ToString();
            TextBox1.Text = usernameRdr["additional_notes"].ToString();
        }

        usernameRdr.Close();


        con.Close();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        int cust_interest = 0;
        int cust_experience = 0;
        int cust_opinionPrice = 0;
        int agent_opinionPrice = 0;
        string fname_Buyer = null;
        string lname_Buyer = null;
        string additional_notes = null;


        HttpCookie _listingInfo = Request.Cookies["_listingInfo"];
        //HttpCookie _userInfo = Request.Cookies["_userInfo"];
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-KFI49LK;Initial Catalog=Housing;Integrated Security=True");
        scheduleID = Request.QueryString["id"];
        //agentID = Convert.ToInt32(_userInfo["AgentID"].ToString());

        cust_interest = Convert.ToInt32(DropDownList1.SelectedItem.Value);
        cust_experience = Convert.ToInt32(DropDownList2.SelectedItem.Text);
        cust_opinionPrice = Convert.ToInt32(DropDownList3.SelectedValue);
        agent_opinionPrice = Convert.ToInt32(DropDownList4.SelectedValue);

        fname_Buyer = TextBox2.Text;
        lname_Buyer = TextBox3.Text;
        additional_notes = TextBox1.Text;
        //Response.Write(cust_interest);


        string sql = "UPDATE reviews SET cutomer_interest = @cutomer_interest, customer_experience = @customer_experience, customer_priceOpinion = @customer_priceOpinion, agent_priceOpinion = @agent_priceOpinion, fname_ofBuyer = @fname_ofBuyer, lname_ofBuyer = @lname_ofBuyer, additional_notes = @additional_notes WHERE schedule_id=" + scheduleID;

        con.Open();

        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.Parameters.AddWithValue("@cutomer_interest", cust_interest);
        cmd.Parameters.AddWithValue("@customer_experience", cust_experience);
        cmd.Parameters.AddWithValue("@customer_priceOpinion", cust_opinionPrice);
        cmd.Parameters.AddWithValue("@agent_priceOpinion", agent_opinionPrice);
        cmd.Parameters.AddWithValue("@fname_ofBuyer", fname_Buyer);
        cmd.Parameters.AddWithValue("@lname_ofBuyer", lname_Buyer);
        cmd.Parameters.AddWithValue("@additional_notes", additional_notes);


        int i = cmd.ExecuteNonQuery();
        //Response.Redirect("schedule_listing.aspx");

        con.Close();
        //DropDownList1.SelectedValue = 2.ToString();



    }




    protected void Button3_Click(object sender, EventArgs e)
    {
        autopopulate();
    }
}