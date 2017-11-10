using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using Resources;

public partial class agents_insert_listing : System.Web.UI.Page
{
    //template class for listing
    Listing temp;
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie _userInfo = Request.Cookies["_userInfo"];

        if (_userInfo == null)
        {
            Response.Redirect("login.aspx");
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        HttpCookie _userInfo = Request.Cookies["_userInfo"];
        _userInfo.Expires = DateTime.Now.AddDays(-1d);
        Response.Cookies.Add(_userInfo);
        Response.Redirect("login.aspx");
    }
    /*
    protected void b1_Click(object sender, EventArgs e)
    {
        SqlCommand command;
        string conString = "Data Source=DESKTOP-KFI49LK;Initial Catalog=Housing;Integrated Security=True";
        string agent_id = null;
        string agency_id = null;

        //byte[] encodePic1 = pic1.FileBytes;
       // byte[] encodePic2 = pic2.FileBytes;
        //byte[] encodePic3 = pic3.FileBytes;
        //byte[] encodePic4 = pic4.FileBytes;
        //byte[] encodePic5 = pic5.FileBytes;
        //byte[] encodePic6 = pic6.FileBytes;


        HttpCookie reqCookies = Request.Cookies["_userInfo"];
        if(reqCookies != null)
        {
            agent_id = reqCookies["AgentID"].ToString();
            agency_id = reqCookies["AgencyID"].ToString();
        }
        

        using (SqlConnection con = new SqlConnection(conString))
        {

            int agentID;
            int agencyID;
            agentID = Convert.ToInt32(agent_id);
            agencyID = Convert.ToInt32(agency_id);

            Boolean listOcc = Convert.ToBoolean(0);

            if(listing_occupied.Text == "true" )
            {
                listOcc = Convert.ToBoolean(1);
            }

            
            
            con.Open();
            string sql = "INSERT INTO listing(pic1,pic2,pic3,pic4,pic5,pic6,listing_price,listing_street,listing_state,listing_city,listing_zip,listing_sqFT,listing_description,listing_roomDescription,listing_shortDescription,listing_nameSubDivision,listing_alarmInfo,agent_id,agency_id,listing_occupied)VALUES(@img1, @img2, @img3, @img4, @img5, @img6,'" + listing_price.Text + "','" + listing_street.Text + "','" + listing_state.Text + "','" + listing_city.Text + "','" + listing_zip.Text + "','" + listing_sqFT.Text + "','" + listing_description.Text + "','" + listing_roomDescription.Text + "','" + listing_shortDescription.Text + "','" + listing_nameSubDivision.Text + "','" + listing_alarmInfo.Text + "','" + agent_id + "','" + agency_id + "','"+listOcc+"')";

            command = new SqlCommand(sql, con);
            command.Parameters.Add(new SqlParameter("@img1", encodePic1));
            command.Parameters.Add(new SqlParameter("@img2", encodePic2));
            command.Parameters.Add(new SqlParameter("@img3", encodePic3));
            command.Parameters.Add(new SqlParameter("@img4", encodePic4));
            command.Parameters.Add(new SqlParameter("@img5", encodePic5));
            command.Parameters.Add(new SqlParameter("@img6", encodePic6));

            int x = command.ExecuteNonQuery();
            con.Close();
        }
    }
    */
    protected void Add_Click(object sender, EventArgs e)
    {
        SqlCommand command;
        string conString = "Data Source=DESKTOP-KFI49LK;Initial Catalog=Housing;Integrated Security=True";
        string agent_id = null;
        string agency_id = null;
        temp = init_listing();
        //get pics
        byte[] encodePic1 = FileUpload1.FileBytes;
        byte[] encodePic2 = FileUpload2.FileBytes;
        byte[] encodePic3 = FileUpload3.FileBytes;
        byte[] encodePic4 = FileUpload4.FileBytes;
        byte[] encodePic5 = FileUpload5.FileBytes;
        byte[] encodePic6 = FileUpload6.FileBytes;
        //get agent_id and agency_id
        HttpCookie reqCookies = Request.Cookies["_userInfo"];
        if (reqCookies != null)
        {
            agent_id = reqCookies["AgentID"].ToString();
            agency_id = reqCookies["AgencyID"].ToString();
        }

        using (SqlConnection con = new SqlConnection(conString))
        {

            int agentID;
            int agencyID;
            agentID = Convert.ToInt32(agent_id);
            agencyID = Convert.ToInt32(agency_id);

            Boolean listOcc = Convert.ToBoolean(0);

            if (listing_occupied.Text == "true")
            {
                listOcc = Convert.ToBoolean(1);
            }



            con.Open();
            string sql = "INSERT INTO listing(pic1,pic2,pic3,pic4,pic5,pic6,listing_price,listing_street,listing_state,listing_city,listing_zip,listing_sqFT,listing_description,listing_roomDescription,listing_shortDescription,listing_nameSubDivision,listing_alarmInfo,agent_id,agency_id,listing_occupied)VALUES(@img1, @img2, @img3, @img4, @img5, @img6,'" + temp.Listing_price + "','" + temp.Listing_street + "','" + temp.Listing_state + "','" + temp.Listing_city + "','" + temp.Listing_zip + "','" + temp.Listing_sqFT + "','" + temp.Listing_description + "','" + temp.Listing_roomDescription + "','" + temp.Listing_shortDescription + "','" + temp.Listing_nameSubDivision + "','" + temp.Listing_alarminfo + "','" + agent_id + "','" + agency_id + "','" + temp.Listing_occupied + "')";

            command = new SqlCommand(sql, con);
            command.Parameters.Add(new SqlParameter("@img1", encodePic1));
            command.Parameters.Add(new SqlParameter("@img2", encodePic2));
            command.Parameters.Add(new SqlParameter("@img3", encodePic3));
            command.Parameters.Add(new SqlParameter("@img4", encodePic4));
            command.Parameters.Add(new SqlParameter("@img5", encodePic5));
            command.Parameters.Add(new SqlParameter("@img6", encodePic6));

            int x = command.ExecuteNonQuery();
            con.Close();
        }
    }
    protected void Cancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("agentMain.aspx");
    }

    private Listing init_listing()
    {
        Listing temp = new Listing();
        Int64 Local_sqFt = 0;
        Int64 Zipcode = 0;
        Int64 local_price = 0;
        Int64.TryParse(sqFT.Text, out Local_sqFt);
        Int64.TryParse(zip.Text, out Zipcode);
        Int64.TryParse(listing_price.Text, out local_price);
        temp.Listing_sqFT = Local_sqFt;
        temp.Listing_price = local_price;
        temp.Listing_zip = Zipcode;
        temp.Listing_state = listing_state.Text;
        temp.Listing_city = listing_city.Text;
        temp.Listing_description = listing_description.Text;
        temp.Listing_roomDescription = listing_roomDescription.Text;
        temp.Listing_nameSubDivision = listing_nameSubDivision.Text;
        temp.Listing_alarminfo = listing_alarmInfo.Text;
        temp.Listing_street = listing_street.Text;
        temp.Listing_shortDescription = listing_shortDescription.Text;
        if (listing_occupied.Checked)
        {
            temp.Listing_occupied = true;
        }
        else
        {
            temp.Listing_occupied = false;
        }
        return temp;
    }
}