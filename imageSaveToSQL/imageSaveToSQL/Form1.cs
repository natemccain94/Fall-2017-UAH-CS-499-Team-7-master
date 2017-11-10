using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace imageSaveToSQL
{
    public partial class Form1 : Form
    {
        static string conString = "Data Source=DESKTOP-KFI49LK;Initial Catalog=Housing;Integrated Security=True";
        SqlConnection con = new SqlConnection(conString);
        SqlCommand command;
        string imgLoc = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "JPG Files (*.jpg|*.jpg|GIF Files (*.gif)|*.gif|All Files (*.*)|.*.*";
                dlg.Title = "Select Listing Picture";
                if(dlg.ShowDialog() == DialogResult.OK)
                {
                    imgLoc = dlg.FileName.ToString();
                    pictureEMP.ImageLocation = imgLoc;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] img = null;
                FileStream fs = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                img = br.ReadBytes((int)fs.Length);
                string sql = "INSERT INTO listing(listing_price, agent_id, agency_id,pic1)VALUES(" + textBoxlPrice.Text + ",'" + textBoxagent_id.Text + "','" + textBoxagency_id.Text + "',@img)";
                if(con.State!=ConnectionState.Open)
                {
                    con.Open();
                }

                command = new SqlCommand(sql, con);
                command.Parameters.Add(new SqlParameter("@img", img));
                int x = command.ExecuteNonQuery();
                con.Close();
                MessageBox.Show(x.ToString() + "Record(s) saved.");
                con.Close();

                textBoxlPrice.Text = "";
                textBoxagency_id.Text = "";
                textBoxagent_id.Text = "";
                pictureEMP.Image = null;

            }
            catch(Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "SELECT listing_price,agent_id,agency_id,pic1 FROM listing WHERE listing_id=" +textBoxLID.Text+ "";
                if(con.State!=ConnectionState.Open)
                {
                    con.Open();
                }
                command = new SqlCommand(sql, con);
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                if(reader.HasRows)
                {
                    textBoxlPrice.Text = reader[0].ToString();
                    textBoxagent_id.Text = reader[1].ToString();
                    textBoxagency_id.Text = reader[2].ToString();
                    byte[] img = (byte[])(reader[3]);
                    if (img ==null)
                    {
                        pictureEMP.Image = null;
                    }
                    else
                    {
                        MemoryStream ms = new MemoryStream(img);
                        pictureEMP.Image = Image.FromStream(ms);

                    }
                }
                else
                {
                    MessageBox.Show("This ID does not exist.");
                    textBoxlPrice.Text = "";
                    textBoxagency_id.Text = "";
                    textBoxagent_id.Text = "";
                    pictureEMP.Image = null;
                }
                con.Close();
            }
            catch(Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
