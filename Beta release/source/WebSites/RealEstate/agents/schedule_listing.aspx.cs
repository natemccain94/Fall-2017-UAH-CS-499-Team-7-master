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

        SqlCommand cmd = new SqlCommand("select schedule.schedule_id, listing.listing_id, listing.listing_city, listing.listing_state, listing.listing_street, listing.listing_zip, schedule.start, schedule.finish, agent.agent_Fname, agent.agent_Lname, agency.agency_name, schedule.agent_showing_firstName, schedule.agent_showing_lastName, schedule.agency_showing_company FROM listing INNER JOIN agency ON listing.agency_id = agency.agency_id INNER JOIN agent ON listing.agent_id = agent.agent_id INNER JOIN schedule ON listing.listing_id = schedule.listing_id WHERE listing.listing_id= '" + id + "'", con);
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

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        getValue();

    }

    public void getValue()
    {
        string i = DropDownList1.SelectedValue;
        switch (i.ToLower())
        {
            case "01":
                addItems(31);
                break;
            case "02":
                addItems(28);
                break;
            case "03":
                addItems(31);
                break;
            case "04":
                addItems(30);
                break;
            case "05":
                addItems(31);
                break;
            case "06":
                addItems(30);
                break;
            case "07":
                addItems(31);
                break;
            case "08":
                addItems(31);
                break;
            case "09":
                addItems(30);
                break;
            case "10":
                addItems(31);
                break;
            case "11":
                addItems(30);
                break;
            case "12":
                addItems(31);
                break;
        }
    }
    public void addItems(int c)
    {
        DropDownList2.Items.Clear();

        for (int i = 1; i < c + 1; i++)
        {
            DropDownList2.Items.Insert(i - 1, new ListItem(i.ToString(), i.ToString()));
        }


    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-KFI49LK;Initial Catalog=Housing;Integrated Security=True");
        List<string> result = new List<string>();
        int listingID;
        int currentAgentID;
        int currentAgencyID;

        string zero = "00";
        string start = null;
        string finish = null;
        int agent_id = 0;
        int listing_id;     //got it its called listingID
        int agency_id = 0;
        string agent_showing_firstName = null;
        string agent_showing_lastName = null;
        string agency_showing_company = null;
        HttpCookie _listingInfo = Request.Cookies["_listingInfo"];
        HttpCookie _userInfo = Request.Cookies["_userInfo"];
        if (_userInfo == null)
        {
            Response.Write("dam");
        }


        listingID = Convert.ToInt32(_listingInfo["ID"].ToString());
        currentAgentID = Convert.ToInt32(_userInfo["AgentID"].ToString());
        currentAgencyID = Convert.ToInt32(_userInfo["AgencyID"].ToString());
        //Response.Write(_userInfo["AgentID"]);
        // Response.Write(_userInfo["AgencyID"]);
        con.Open();
        SqlCommand cmd1 = new SqlCommand("SELECT agent.agent_id FROM listing INNER JOIN agent ON listing.agent_id = agent.agent_id WHERE listing.listing_id = '" + listingID + "' ", con);
        SqlDataReader usernameRdr = null;
        usernameRdr = cmd1.ExecuteReader();

        while (usernameRdr.Read())
        {
            // Response.Write("This happens");
            agent_id = Convert.ToInt32(usernameRdr["agent_id"]);
        }

        start = DropDownList3.SelectedValue + "-" + DropDownList1.SelectedValue + "-" + DropDownList2.SelectedValue + " " + DropDownList4.SelectedValue + ":" + DropDownList5.SelectedValue + ":" + zero;
        finish = DropDownList3.SelectedValue + "-" + DropDownList1.SelectedValue + "-" + DropDownList2.SelectedValue + " " + DropDownList7.SelectedValue + ":" + DropDownList8.SelectedValue + ":" + zero;

        cmd1 = new SqlCommand("SELECT agency.agency_id FROM listing INNER JOIN agency ON listing.agency_id = agency.agency_id WHERE listing.listing_id = '" + listingID + "' ", con);
        usernameRdr.Close();

        usernameRdr = null;
        usernameRdr = cmd1.ExecuteReader();
        while (usernameRdr.Read())
        {

            agency_id = Convert.ToInt32(usernameRdr["agency_id"]);
        }

        //Response.Write(currentAgencyID);
        cmd1 = new SqlCommand("SELECT agency_name FROM agency WHERE agency_id = '" + currentAgencyID + "' ", con);
        usernameRdr.Close();

        usernameRdr = null;
        usernameRdr = cmd1.ExecuteReader();
        while (usernameRdr.Read())
        {

            agency_showing_company = usernameRdr["agency_name"].ToString();
        }

        cmd1 = new SqlCommand("SELECT agent_Fname FROM agent WHERE agent_id= '" + currentAgentID + "' ", con);
        usernameRdr.Close();

        usernameRdr = null;
        usernameRdr = cmd1.ExecuteReader();
        while (usernameRdr.Read())
        {
            agent_showing_firstName = usernameRdr["agent_Fname"].ToString();
        }

        cmd1 = new SqlCommand("SELECT agent_Lname FROM agent WHERE agent_id= '" + currentAgentID + "' ", con);
        usernameRdr.Close();

        usernameRdr = null;
        usernameRdr = cmd1.ExecuteReader();
        while (usernameRdr.Read())
        {
            agent_showing_lastName = usernameRdr["agent_Lname"].ToString();
        }

        usernameRdr.Close();

        //Response.Write(start);
        // Response.Write(finish);

        //checkDate(start, finish, currentAgentID);

        string sql = "INSERT INTO schedule(start, finish, agent_id, listing_id, agency_id, agent_showing_firstName, agent_showing_lastName, agency_showing_company, agent_showing_id)VALUES('" + start + "','" + finish + "','" + agent_id + "','" + listingID + "','" + agency_id + "','" + agent_showing_firstName + "','" + agent_showing_lastName + "','" + agency_showing_company + "' ,'" + currentAgentID + "'  )";
        SqlCommand command;
        command = new SqlCommand(sql, con);
        int x = command.ExecuteNonQuery();




        con.Close();
        Response.Redirect("schedule_listing.aspx");
    }

    public void checkDate(string start, string finish, int currentAgentID)
    {
        DateTime todayDate = DateTime.Parse(start);

        if (true)
        {
            Response.Write(todayDate);
        }

    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}