using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;


public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie _userInfo = Request.Cookies["_userInfo"];


        if (_userInfo != null)
        {
            Response.Redirect("agentMain.aspx");
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string conString = "Data Source=DESKTOP-KFI49LK;Initial Catalog=Housing;Integrated Security=True";

        using (SqlConnection con = new SqlConnection(conString))
        {
            con.Open();
            string checkUser = "Select count(*) from agent where agent_Uname= '" + TextBoxUN.Text + "'";
            SqlCommand com = new SqlCommand(checkUser, con);
            int temp = Convert.ToInt32(com.ExecuteScalar().ToString());

            if (temp == 1)
            {
                string checkPass = "Select agent_password from agent where agent_Uname= '" + TextBoxUN.Text + "'";
                SqlCommand passCom = new SqlCommand(checkPass, con);
                string password = passCom.ExecuteScalar().ToString();

                if (password == TextBoxPW.Text)
                {
                    string getAgentID = "Select agent_id from agent where agent_Uname ='" + TextBoxUN.Text + "'";
                    SqlCommand getID = new SqlCommand(getAgentID, con);
                    string agent_id = getID.ExecuteScalar().ToString();

                    string getAgencyID = "Select agency_id from agent where agent_Uname ='" + TextBoxUN.Text + "'";
                    SqlCommand getAID = new SqlCommand(getAgencyID, con);
                    string agency_id = getAID.ExecuteScalar().ToString();

                    HttpCookie _userInfo = new HttpCookie("_userInfo");
                    _userInfo["AgencyID"] = agency_id;
                    _userInfo["AgentID"] = agent_id;
                    Response.Cookies.Add(_userInfo);
                    


                    Response.Write("Correct Password");
                    Response.Redirect("agentMain.aspx");   //used to redirect to new page
                }
                else
                {
                    Response.Write("Incorrect Username or password");
                }
            }
            else
            {
                Response.Write("Username is not correct");
            }

        }









    }
}