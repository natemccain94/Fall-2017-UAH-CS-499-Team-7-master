using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class agentMain : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("Data Source=DESKTOP-KFI49LK;Initial Catalog=Housing;Integrated Security=True");
    int total_result;
    int counter;
    int page_Num;
    int icurrent_page, total_listing;
    DataTable dt;

    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie _userInfo = Request.Cookies["_userInfo"];

        if (_userInfo == null)
        {
            Response.Redirect("login.aspx");
        }
        else
        {
            //first_load();
        }
        if (!IsPostBack)
        {
            Bind_gridview(Search_option.SelectedItem.Value);
        }
    }
    protected void first_load()
    {
        //parse agent id to int
        //agent_id_flag return false if can't convert agent_id
        bool agent_id_flag = false;
        int agent_id = 0;
        counter = 0;
        HttpCookie _userInfo = Request.Cookies["_userInfo"];

        agent_id_flag = int.TryParse(_userInfo["AgentID"], out agent_id);
        con.Open();                                             //connects to database
        SqlCommand cmd = con.CreateCommand();                   //create object of command called cmd
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "Select * FROM listing WHERE agent_id=" + agent_id;
        //cmd.CommandText = "Select * FROM listing WHERE agent_id=" + agent_id + " ORDER BY agent_id OFFSET 3 ROWS  FETCH NEXT 3 ROWS ONLY";
        cmd.ExecuteNonQuery();                                 //takes the text we created above and executes it
        dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        total_listing = dt.Rows.Count;
        con.Close();
        //gridview
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    protected void Bind_gridview(string option)
    {
        //agent_id_flag return false if can't convert agent_id
        bool agent_id_flag = false;
        int agent_id = 0;
        counter = 0;
        HttpCookie _userInfo = Request.Cookies["_userInfo"];
        agent_id_flag = int.TryParse(_userInfo["AgentID"], out agent_id);
        con.Open();
        SqlCommand cmd = con.CreateCommand();                   //create object of command called cmd
        cmd.CommandType = CommandType.Text;
        if (option == "all")
        {
            cmd.CommandText = "Select * FROM listing WHERE agent_id=" + agent_id;
        }
        else if (option == "street")
        {
            // columnname like '%Moses%' and columnname like'%Robi%'
            cmd.CommandText = "Select * FROM listing WHERE agent_id=" + agent_id + "and listing_street LIKE '%" + txtSearch.Text + "%'";
        }
        else if (option == "zipcode")
        {
            int zipcode = 0;
            bool result = Int32.TryParse(txtSearch.Text, out zipcode);
            if (result)
            {
                cmd.CommandText = "Select * FROM listing WHERE agent_id=" + agent_id + "and listing_zip=" + zipcode;
            }
            else
            {
                cmd.CommandText = "Select * FROM listing WHERE agent_id=" + agent_id;
            }

        }
        else if (option == "price")
        {
            int min = 0;
            int max = 99999999;
            bool min_flag = Int32.TryParse(price_min.Text, out min);
            bool max_flag = Int32.TryParse(price_max.Text, out max);
            if (min_flag && max_flag && max >= min)
            {
                cmd.CommandText = "Select * FROM listing WHERE agent_id=" + agent_id + "and listing_price >=" + min + "and listing_price <=" + max;
            }
            else if (min_flag && max_flag == false)
            {
                cmd.CommandText = "Select * FROM listing WHERE agent_id=" + agent_id + "and listing_price >=" + min;
            }
            else if (max_flag && min_flag == false)
            {
                cmd.CommandText = "Select * FROM listing WHERE agent_id=" + agent_id + "and listing_price <=" + max;
            }
            else
            {
                cmd.CommandText = "Select * FROM listing WHERE agent_id=" + agent_id;
            }
        }
        else
        {
            cmd.CommandText = "Select * FROM listing WHERE agent_id=" + agent_id;
        }
        //fill datatable
        cmd.ExecuteNonQuery();                                 //takes the text we created above and executes it
        dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
        con.Close();


    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        HttpCookie _userInfo = Request.Cookies["_userInfo"];
        _userInfo.Expires = DateTime.Now.AddDays(-1d);
        Response.Cookies.Add(_userInfo);
        Response.Redirect("login.aspx");
    }
    protected void GridView1_PageIndexChanged(object sender, EventArgs e)
    {
        //bindGridView();
        Bind_gridview(Search_option.SelectedItem.Value);
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        Bind_gridview(Search_option.SelectedItem.Value);
    }

    protected void Search_Click(object sender, EventArgs e)
    {
        this.Bind_gridview(Search_option.SelectedItem.Value);
    }

    protected void Search_option_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Search_option.SelectedItem.Value == "price")
        {
            search_text.Visible = false;
            txtSearch.Visible = false;
            search_price.Visible = true;
            price_min.Visible = true;
            price_max.Visible = true;
        }
        else
        {
            search_text.Visible = true;
            txtSearch.Visible = true;
            search_price.Visible = false;
            price_min.Visible = false;
            price_max.Visible = false;
        }
    }
}