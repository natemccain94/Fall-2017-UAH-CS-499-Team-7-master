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
    Listing new_listing = new Listing();
    int id;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["listing_id"] == null)
        {
            Response.Redirect("agentMain.aspx");
        }
        if(!IsPostBack)
        {
            set_frontend_listing();
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
        con.Open();
        cmd.CommandText = "DELETE FROM schedule WHERE listing_id=" + id;
        cmd.Connection = con;
        cmd.ExecuteNonQuery();
        cmd.CommandText = "DELETE FROM reviews WHERE listing_id=" + id;
        cmd.Connection = con;
        cmd.ExecuteNonQuery();
        cmd.CommandText = "DELETE FROM listing WHERE listing_id=" + id;
        cmd.Connection = con;
        cmd.ExecuteNonQuery();
        con.Close();
        Response.Redirect("agentMain.aspx");
    }

    protected void Update_Click(object sender, EventArgs e)
    {
        Listing temp = new Listing();
        temp.Listing_price = Int64.Parse(listing_price.Text);
        temp.Listing_state = listing_state.Text;
        temp.Listing_street = listing_street.Text;
        temp.Listing_shortDescription = listing_shortDescription.Text;
        temp.Listing_city = listing_city.Text;
        temp.Listing_sqFT = Int64.Parse(listing_sqFT.Text);
        temp.Listing_description = listing_description.Text;
        temp.Listing_zip = Int64.Parse(listing_zip.Text);
        temp.Listing_roomDescription = listing_roomDescription.Text;
        temp.Listing_nameSubDivision = listing_nameSubDivision.Text;
        temp.Listing_alarminfo = listing_alarminfo.Text;
        if (listing_occupied.Checked == true)
        {
            temp.Listing_occupied = true;
        }

    }

    protected void Update_listing(object sender, EventArgs e)
    {
        //check if agent is null
        if (Request.QueryString["listing_id"] == null)
        {
            Response.Redirect("agentMain.aspx");
        }
        //get all update data back to new_listing
        set_backend_listing();
        //push new data of specific listing back to database
        if (Request.QueryString["listing_id"] == null)
        {
            Response.Redirect("agentMain.aspx");
        }
        else
        {
            id = Convert.ToInt32(Request.QueryString["listing_id"].ToString());
            cmd.CommandType = CommandType.Text;

            //initialize the long-ass sql querry
            cmd.CommandText = "UPDATE listing SET pic1 = @pic1, pic2 = @pic2, pic3 = @pic3, pic4 = @pic4, pic5 = @pic5, pic6 = @pic6, " +
                "listing_price = @listing_price, listing_street = @listing_street, listing_state = @listing_state, listing_city = @listing_city, " +
                "listing_zip = @listing_zip, listing_sqFT = @listing_sqFT, listing_description = @listing_description, listing_roomDescription = @listing_roomDescription," +
                "listing_shortDescription = @listing_shortDescription, listing_nameSubDivision = @listing_nameSubdivision, listing_alarmInfo = @listing_alarmInfo, " +
                "listing_occupied = @listing_occupied WHERE listing_id=" + id;
            cmd.Parameters.AddWithValue("@pic1", new_listing.Pic1);
            cmd.Parameters.AddWithValue("@pic2", new_listing.Pic2);
            cmd.Parameters.AddWithValue("@pic3", new_listing.Pic3);
            cmd.Parameters.AddWithValue("@pic4", new_listing.Pic4);
            cmd.Parameters.AddWithValue("@pic5", new_listing.Pic5);
            cmd.Parameters.AddWithValue("@pic6", new_listing.Pic6);
            cmd.Parameters.AddWithValue("@listing_price", new_listing.Listing_price);
            cmd.Parameters.AddWithValue("@listing_street", new_listing.Listing_street);
            cmd.Parameters.AddWithValue("@listing_state", new_listing.Listing_state);
            cmd.Parameters.AddWithValue("@listing_city", new_listing.Listing_city);
            cmd.Parameters.AddWithValue("@listing_zip", new_listing.Listing_zip);
            cmd.Parameters.AddWithValue("@listing_sqFT", new_listing.Listing_sqFT);
            cmd.Parameters.AddWithValue("@listing_description", new_listing.Listing_description);
            cmd.Parameters.AddWithValue("@listing_roomDescription", new_listing.Listing_roomDescription);
            cmd.Parameters.AddWithValue("@listing_shortDescription", new_listing.Listing_shortDescription);
            cmd.Parameters.AddWithValue("@listing_nameSubDivision", new_listing.Listing_nameSubDivision);
            cmd.Parameters.AddWithValue("@listing_alarmInfo", new_listing.Listing_alarminfo);
            cmd.Parameters.AddWithValue("@listing_occupied", new_listing.Listing_occupied);
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        Response.Redirect("agentMain.aspx");

    }
    
    private void set_Frontend_gui(Listing new_listing)
    {
        listing_price.Text = new_listing.Listing_price.ToString();
        listing_state.Text = new_listing.Listing_state;
        listing_street.Text = new_listing.Listing_street;
        listing_shortDescription.Text = new_listing.Listing_shortDescription;
        listing_city.Text = new_listing.Listing_city;
        listing_sqFT.Text = new_listing.Listing_sqFT.ToString();
        listing_description.Text = new_listing.Listing_description;
        listing_zip.Text = new_listing.Listing_zip.ToString();
        listing_roomDescription.Text = new_listing.Listing_roomDescription;
        listing_nameSubDivision.Text = new_listing.Listing_nameSubDivision;
        listing_alarminfo.Text = new_listing.Listing_alarminfo;
        if (new_listing.Listing_occupied == true)
        {
            listing_occupied.Checked = true;
        }
        Image1.ImageUrl = "data:image/jpg;base64," + ByteArrayToImage(new_listing.Pic1);
        Image2.ImageUrl = "data:image/jpg;base64," + ByteArrayToImage(new_listing.Pic2);
        Image3.ImageUrl = "data:image/jpg;base64," + ByteArrayToImage(new_listing.Pic3);
        Image4.ImageUrl = "data:image/jpg;base64," + ByteArrayToImage(new_listing.Pic4);
        Image5.ImageUrl = "data:image/jpg;base64," + ByteArrayToImage(new_listing.Pic5);
        Image6.ImageUrl = "data:image/jpg;base64," + ByteArrayToImage(new_listing.Pic6);

    }
    private void set_backend_listing()
    {
        Int64 Local_sqFt = 0;
        Int64 Zipcode = 0;
        Int64 local_price = 0;
        Int64.TryParse(listing_sqFT.Text, out Local_sqFt);
        Int64.TryParse(listing_zip.Text, out Zipcode);
        Int64.TryParse(listing_price.Text, out local_price);

        new_listing.Listing_price = local_price;
        new_listing.Listing_state = listing_state.Text;
        new_listing.Listing_street = listing_street.Text;
        new_listing.Listing_shortDescription = listing_shortDescription.Text;
        new_listing.Listing_city = listing_city.Text;
        new_listing.Listing_sqFT = Local_sqFt;
        new_listing.Listing_description = listing_description.Text;
        new_listing.Listing_zip = Zipcode;
        new_listing.Listing_roomDescription = listing_roomDescription.Text;
        new_listing.Listing_nameSubDivision = listing_nameSubDivision.Text;
        new_listing.Listing_alarminfo = listing_alarminfo.Text;
        if (listing_occupied.Checked == true)
        {
            new_listing.Listing_occupied = true;
        }
        //get pics
        new_listing.Pic1 = FileUpload1.FileBytes;
        new_listing.Pic2 = FileUpload2.FileBytes;
        new_listing.Pic3 = FileUpload3.FileBytes;
        new_listing.Pic4 = FileUpload4.FileBytes;
        new_listing.Pic5 = FileUpload5.FileBytes;
        new_listing.Pic6 = FileUpload6.FileBytes;
    }
    private void set_frontend_listing()
    {

        id = Convert.ToInt32(Request.QueryString["listing_id"].ToString());
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "Select * FROM listing WHERE listing_id=" + id;
        cmd.Connection = con;

        con.Open();
        reader = cmd.ExecuteReader();
        while (reader.Read())
        {   //initialize new_listing object to with retrieving sql data 
            Boolean occupied_flag = false;
            new_listing.Listing_price = Convert.ToInt64(reader["listing_price"]);
            new_listing.Listing_state = reader["listing_state"].ToString();
            new_listing.Listing_street = reader["listing_street"].ToString();
            new_listing.Listing_shortDescription = reader["listing_shortDescription"].ToString();
            new_listing.Listing_city = reader["listing_city"].ToString();
            new_listing.Listing_sqFT = Convert.ToInt64(reader["listing_sqFT"]);
            new_listing.Listing_description = reader["listing_description"].ToString();
            new_listing.Listing_zip = Convert.ToInt64(reader["listing_zip"]);
            new_listing.Listing_roomDescription = reader["listing_roomDescription"].ToString();
            new_listing.Listing_nameSubDivision = reader["listing_nameSubDivision"].ToString();
            new_listing.Listing_alarminfo = reader["listing_alarmInfo"].ToString();
            Boolean.TryParse(reader["listing_occupied"].ToString(), out occupied_flag);
            new_listing.Listing_occupied = occupied_flag;
            new_listing.Pic1 = (byte[])reader[1];
            new_listing.Pic2 = (byte[])reader[2];
            new_listing.Pic3 = (byte[])reader[3];
            new_listing.Pic4 = (byte[])reader[4];
            new_listing.Pic5 = (byte[])reader[5];
            new_listing.Pic6 = (byte[])reader[6];

        }
        set_Frontend_gui(new_listing);
        reader.Close();
        con.Close();
    }
}
//template class for listing
