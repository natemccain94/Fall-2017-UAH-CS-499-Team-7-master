using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class users_display_houses : System.Web.UI.Page
{

    SqlConnection con = new SqlConnection("Data Source=DESKTOP-KFI49LK;Initial Catalog=Housing;Integrated Security=True");
    protected void Page_Load(object sender, EventArgs e)
    {
        con.Open();                                             //connects to database
        SqlCommand cmd = con.CreateCommand();                   //create object of command called cmd
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "SELECT listing.listing_id, agency.agency_id, agent.agent_id, listing.listing_zip, listing.pic1, listing.listing_price, listing.listing_street, listing.listing_state, listing.listing_city, listing.listing_zip, listing.listing_sqFT, agency.agency_name, agent.agent_Fname, agent.agent_Lname FROM agency INNER JOIN listing ON listing.agency_id = agency.agency_id INNER JOIN agent ON listing.agent_id = agent.agent_id";
        cmd.ExecuteNonQuery();                                 //takes the text we created above and executes it
        
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        d1.DataSource = dt;                                   //d1 is defined in the source portion of this website page
        d1.DataBind();
        con.Close();
    }

    protected void Button1_Click(object sender, EventArgs e)        //code for when the search button is clicked
    {
       
        if(search_req.SelectedValue == "1")                 //If search request equals to minimum square feet
        {

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT listing.listing_id, agency.agency_id, agent.agent_id, listing.listing_zip, listing.pic1, listing.listing_price, listing.listing_street, listing.listing_state, listing.listing_city, listing.listing_zip, listing.listing_sqFT, agency.agency_name, agent.agent_Fname, agent.agent_Lname FROM agency INNER JOIN listing ON listing.agency_id = agency.agency_id INNER JOIN agent ON listing.agent_id = agent.agent_id WHERE listing.listing_sqFT > '"+TextBox1.Text+"'";
            cmd.ExecuteNonQuery();
        

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            d1.DataSource = dt;     //d1 is defined in the source portion of this website page
            d1.DataBind();

            con.Close();
            
        }
        else if(search_req.SelectedValue == "2")        //if price min and max are selected
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT listing.listing_id, agency.agency_id, agent.agent_id, listing.listing_zip, listing.pic1, listing.listing_price, listing.listing_street, listing.listing_state, listing.listing_city, listing.listing_zip, listing.listing_sqFT, agency.agency_name, agent.agent_Fname, agent.agent_Lname FROM agency INNER JOIN listing ON listing.agency_id = agency.agency_id INNER JOIN agent ON listing.agent_id = agent.agent_id WHERE listing.listing_price > '" + TextBox1.Text + "' AND listing.listing_price < '"+TextBox2.Text+"'";
            cmd.ExecuteNonQuery();


            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            d1.DataSource = dt;     //d1 is defined in the source portion of this website page
            d1.DataBind();

            con.Close();
        }
        else if(search_req.SelectedValue == "3")    //if zip is selected
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT listing.listing_id, agency.agency_id, agent.agent_id, listing.listing_zip, listing.pic1, listing.listing_price, listing.listing_street, listing.listing_state, listing.listing_city, listing.listing_zip, listing.listing_sqFT, agency.agency_name, agent.agent_Fname, agent.agent_Lname FROM agency INNER JOIN listing ON listing.agency_id = agency.agency_id INNER JOIN agent ON listing.agent_id = agent.agent_id WHERE listing.listing_zip = '" + TextBox1.Text + "'";
            cmd.ExecuteNonQuery();


            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            d1.DataSource = dt;     //d1 is defined in the source portion of this website page
            d1.DataBind();

            con.Close();
            TextBox1.Visible = false;
            
        }

        
    }


    //This piece of code correlates to the search bar. Basically 
    //The code here will make the text box change depending on what search the user wants to perform
    //If user wants to select search by zip then the text box will say "enter minimum zip" and so on and so on
    protected void search_req_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(search_req.SelectedValue == "2")
        {
            TextBox2.Visible = true;
            TextBox1.Text = "Enter Min Price";
            TextBox2.Text = "Enter Max Price";
        }
        else if(search_req.SelectedValue == "1")
        {
            TextBox1.Text = "Enter Min SqFt";
            TextBox2.Visible = false;
           
        }
        else
        {
            TextBox2.Visible = false;
            TextBox1.Text = "Enter ZipCode";
        }

        if(search_req.SelectedValue != "-1")
        {
            TextBox1.Visible = true;
        }
        else
        {
            TextBox1.Visible = false;
        }
    }
}