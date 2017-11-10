using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;

/// <summary>
/// Summary description for SQL_connection
/// </summary>

public class SQL_connection
{
    public SQL_connection()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public void openConnection()
    {
        connection = new SqlConnection();
        connection.ConnectionString = "Data Source=DESKTOP-TGE6FLJ;Initial Catalog=Housing;Integrated Security=True";
        connection.Open();
    }
    public void closeConnection()
    {
        connection.Close();
    }
    public int GetTotalNumberOfAgencies()
    {
        int result = 0;
        using (SqlCommand command = new SqlCommand())
        {
            try
            {
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT COUNT(*) FROM agency";
                result = Convert.ToInt32(command.ExecuteScalar());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                result = -1;
            }
        }
        return result;
    }
    //get all agents
    public DataTable GetAllAgents()
    {
        DataTable table = new DataTable();
        using (SqlCommand command = new SqlCommand())
        {
            try
            {
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText =
                    String.Concat("SELECT ALL agent_Fname, agent_Lname, agent_number, agent_email, agent_id, ",
                                      "agency_id FROM agent");

                table.Columns.Add("agent_Fname");
                table.Columns.Add("agent_Lname");
                table.Columns.Add("agent_number");
                table.Columns.Add("agent_email");
                table.Columns.Add("agent_id");
                table.Columns.Add("agency_id");


                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(table);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }
        return table;
    }

    //variables 
    private SqlConnection connection;
    private SqlCommand command;
}