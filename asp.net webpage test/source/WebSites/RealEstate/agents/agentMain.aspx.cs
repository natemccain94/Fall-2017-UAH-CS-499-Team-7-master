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
            Bind_gridview();
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
    protected void Bind_gridview()
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
        cmd.CommandText = "Select * FROM listing WHERE agent_id=" + agent_id;
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

    /*
    protected void Next_Click(object sender, EventArgs e)
    {

        if (total_result >= 1)
        {
            //+1 to pageNum 
            page_Num = int.Parse(pageNum.Text);
            page_Num = page_Num++;

            HttpCookie _userInfo = Request.Cookies["_userInfo"];
            //parse agent id to int
            //agent_id_flag return false if can't convert agent_id
            bool agent_id_flag = false;
            int agent_id = 0;
            agent_id_flag = int.TryParse(_userInfo["AgentID"], out agent_id);
            int k = counter * 2;
            counter = counter++;
            con.Open();                                             //connects to database
            SqlCommand cmd = con.CreateCommand();                   //create object of command called cmd
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * FROM listing WHERE agent_id=" + agent_id + " ORDER BY agent_id OFFSET "+ k +" ROWS  FETCH NEXT 1 ROWS ONLY";
            cmd.ExecuteNonQuery();                                 //takes the text we created above and executes it

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            total_result = dt.Rows.Count;
            d2.DataSource = dt;     //d1 is defined in the source portion of this website page
            d2.DataBind();
            con.Close();
        }
    }
    */
    protected void GridView1_PageIndexChanged(object sender, EventArgs e)
    {
        //bindGridView();
        Bind_gridview();
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        Bind_gridview();
    }

    protected void Search_Click(object sender, EventArgs e)
    {
        this.Bind_gridview();
    }
}