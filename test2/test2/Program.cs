using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace test2
{
    /// <summary>
    /// 
    /// </summary>
    public class EmailClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmailClient" /> class.
        /// </summary>
        public EmailClient()
        {
            emailConnectionToDatabase = new SQL_Connection();

            client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("realestateutilityuahteamseven@gmail.com", "r01lT!de"),
                EnableSsl = true
            };
        }

        /// <summary>
        /// Prepares the hit counts prior to emails.
        /// </summary>
        public void PrepareHitCountsPriorToEmails()
        {
            try
            {
                // Connect to the database.
                emailConnectionToDatabase.openConnection();
                // Update all lifetime hit counts.
                emailConnectionToDatabase.UpdateLifetimeHitCount();
                // Prepare the emails!!!
                GatherAgentsToEmail();
            }
            catch (Exception e)
            {
                // Do nothing
            }
        }

        /// <summary>
        /// Gathers the agents to email.
        /// </summary>
        private void GatherAgentsToEmail()
        {
            var AgentTable = new DataTable();
            AgentTable = emailConnectionToDatabase.GetAllAgents();
            TrimEmailList(AgentTable);
        }

        /// <summary>
        /// Trims the email list.
        /// </summary>
        /// <param name="AgentTable">The agent table.</param>
        private void TrimEmailList(DataTable AgentTable)
        {
            DataTable AgentsWithProperties = new DataTable();
            foreach (DataRow row in AgentTable.Rows)
            {
                if (emailConnectionToDatabase.GetTotalNumberOfListingsFromAgent((int) row["agent_id"]) >= 1)
                {
                    AgentsWithProperties.Rows.Add(row);
                }
            }
            PrepareSpamEmails(AgentsWithProperties);
        }

        /// <summary>
        /// Prepares the spam emails.
        /// </summary>
        /// <param name="AgentTable">The agent table.</param>
        private void PrepareSpamEmails(DataTable AgentTable)
        {
            DataTable PropertiesTableForSpecificAgent = new DataTable();
            foreach (DataRow row in AgentTable.Rows)
            {
                PropertiesTableForSpecificAgent = emailConnectionToDatabase.GetAllListingsForEmailToSpecificAgent((int) row["agent_id"]);
                EmailAnAgent(row, PropertiesTableForSpecificAgent);
            }
            ResetDailyHitCounts();
        }

        /// <summary>
        /// Emails an agent.
        /// </summary>
        /// <param name="AgentToEmail">The agent to email.</param>
        /// <param name="Properties">The properties.</param>
        private void EmailAnAgent(DataRow AgentToEmail, DataTable Properties)
        {
            String firstLine = String.Concat("Hello ", (String) AgentToEmail["agent_Fname"],
                " ", (String) AgentToEmail["agent_Lname"], ". Here is a list of how your \n",
                "properties are performing: \n \n");

            String agentEmailAddress = (String) AgentToEmail["agent_email"];

            String propertyListHeader =
                "Address                    Daily Hit Count                    Lifetime Hit Count \n\n";
            
            String row;
            
            List<String> listingStats = new List<String>();

            int daily, lifetime, requiredNumberOfWhitespaces;
            
            foreach (DataRow propertyRow in Properties.Rows)
            {
                daily = (int) propertyRow["listing_hitCount"];
                lifetime = (int) propertyRow["listingLifetimeHitCount"];

                row = String.Concat((String) propertyRow["listing_street"]);
                requiredNumberOfWhitespaces = 34 - row.Length;

                while (requiredNumberOfWhitespaces > 0)
                {
                    row = String.Concat(row, " ");
                    requiredNumberOfWhitespaces--;
                }

                row = String.Concat(row, daily.ToString());
                requiredNumberOfWhitespaces = propertyListHeader.Length - 9;

                while (requiredNumberOfWhitespaces > 0)
                {
                    row = String.Concat(row, " ");
                    requiredNumberOfWhitespaces--;
                }

                row = String.Concat(row, lifetime.ToString(), "\n");

                // Add the first line of the property info to the list.
                listingStats.Add(row);
                // Now begin adding the rest of the address to the listings thing.
                row = String.Concat(propertyRow["listing_city"], ", ", propertyRow["listing_state"], " ",
                    propertyRow["listing_zip"], "\n\n");
                // Add the rest to the list.
                listingStats.Add(row);
            }

            // Put the email body together.
            String emailBody = String.Concat(firstLine, propertyListHeader);
            foreach (String item in listingStats)
            {
                emailBody = String.Concat(emailBody, item);
            }
            emailBody = String.Concat(emailBody, "End of Email. \n");

            client.Send("realestateutilityuahteamseven@gmail.com", agentEmailAddress, "Your Property Statistics", emailBody);
            
        }

        /// <summary>
        /// Resets the daily hit counts.
        /// </summary>
        private void ResetDailyHitCounts()
        {
            // Call to function to reset all daily hit counts.
            emailConnectionToDatabase.ResetDailyHitCount();
            // Close the connection.
            FinishedSendingEmails();
        }

        /// <summary>
        /// Finisheds the sending emails.
        /// </summary>
        private void FinishedSendingEmails()
        {
            emailConnectionToDatabase.closeConnection();
        }


        /// <summary>
        /// The client
        /// </summary>
        private SmtpClient client;
        /// <summary>
        /// The email connection to database
        /// </summary>
        private SQL_Connection emailConnectionToDatabase;
    }
}
