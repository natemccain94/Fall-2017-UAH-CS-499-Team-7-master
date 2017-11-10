using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.UI.WebControls;
using System.Drawing;
using Resources;

public partial class agents_update_listing : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("Data Source=DESKTOP-KFI49LK;Initial Catalog=Housing;Integrated Security=True");
    SqlCommand cmd = new SqlCommand();
    SqlDataReader reader;
    int id;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["listing_id"] == null)
        {
            Response.Redirect("agentMain.aspx");
        }
        else
        {
            id = Convert.ToInt32(Request.QueryString["listing_id"].ToString());
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * FROM listing WHERE listing_id=" + id;
            cmd.Connection = con;

            con.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Boolean occupied_flag = false;
                listing_price.Text = reader["listing_price"].ToString();
                listing_state.Text = reader["listing_state"].ToString();
                listing_street.Text = reader["listing_street"].ToString();
                listing_shortDescription.Text = reader["listing_shortDescription"].ToString();
                listing_city.Text = reader["listing_city"].ToString();
                listing_sqFT.Text = reader["listing_sqFT"].ToString();
                listing_description.Text = reader["listing_description"].ToString();
                listing_zip.Text = reader["listing_zip"].ToString();
                listing_roomDescription.Text = reader["listing_roomDescription"].ToString();
                listing_nameSubDivision.Text = reader["listing_nameSubDivision"].ToString();
                listing_alarminfo.Text = reader["listing_alarmInfo"].ToString();
                Boolean.TryParse(reader["listing_occupied"].ToString(), out occupied_flag);
                if (occupied_flag == true)
                {
                    listing_occupied.Checked = true;
                }
                Image1.ImageUrl = "data:image/jpg;base64," + ByteArrayToImage((byte[])reader[1]);
                Image2.ImageUrl = "data:image/jpg;base64," + ByteArrayToImage((byte[])reader[2]);
                Image3.ImageUrl = "data:image/jpg;base64," + ByteArrayToImage((byte[])reader[3]);
                Image4.ImageUrl = "data:image/jpg;base64," + ByteArrayToImage((byte[])reader[4]);
                Image5.ImageUrl = "data:image/jpg;base64," + ByteArrayToImage((byte[])reader[5]);
                Image6.ImageUrl = "data:image/jpg;base64," + ByteArrayToImage((byte[])reader[6]);
            }
            reader.Close();
            con.Close();
        }
        //listing_id_text.Text = id.ToString();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        HttpCookie _userInfo = Request.Cookies["_userInfo"];
        _userInfo.Expires = DateTime.Now.AddDays(-1d);
        Response.Cookies.Add(_userInfo);
        Response.Redirect("login.aspx");
    }
    //convert bytearray to image
    public String ByteArrayToImage(byte[] byteArrayIn)
    {
        string base64String = Convert.ToBase64String(byteArrayIn, 0, byteArrayIn.Length);
        return base64String;
    }

    protected void Cancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("agentMain.aspx");
    }

    protected void Delete_Click(object sender, EventArgs e)
    {
        id = Convert.ToInt32(Request.QueryString["listing_id"].ToString());
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "DELETE FROM listing WHERE listing_id=" + id;
        cmd.Connection = con;
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
        Response.Redirect("agentMain.aspx");
    }
}
//template class for listing
