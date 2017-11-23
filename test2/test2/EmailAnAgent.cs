using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace test2
{
    /// <summary>
    /// 
    /// </summary>
    public static class EmailAnAgent
    {
        /// <summary>
        /// Customers the request for showing.
        /// </summary>
        /// <param name="agent_email">The agent email.</param>
        /// <param name="agent_fName">Name of the agent f.</param>
        /// <param name="agent_lName">Name of the agent l.</param>
        /// <param name="customer_fName">Name of the customer f.</param>
        /// <param name="customer_lName">Name of the customer l.</param>
        /// <param name="customer_number">The customer number.</param>
        /// <param name="customer_email">The customer email.</param>
        /// <param name="property_street">The property street.</param>
        /// <param name="property_city">The property city.</param>
        /// <param name="property_state">State of the property.</param>
        /// <param name="property_zip">The property zip.</param>
        public static void CustomerRequestForShowing(string agent_email, string agent_fName, string agent_lName,
                                                    string customer_fName, string customer_lName,
                                                    string customer_number, string customer_email,
                                                    string property_street, string property_city,
                                                     string property_state, int property_zip)
        {
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("realestateutilityuahteamseven@gmail.com", "r01lT!de"),
                EnableSsl = true
            };

            string emailBody = string.Concat(
                "Hello ", agent_fName, " ", agent_lName, ",\n",
                "A prospective home buyer would like to look at your property located at \n",
                property_street, " , ", property_city, ", ", property_state, " ", property_zip, "\n\n",
                "Here is the potential buyer's information: \n",
                "Customer First Name: ", customer_fName, "\n",
                "Customer Last Name: ", customer_lName, "\n",
                "Customer Email Address: ", customer_email, "\n",
                "Customer Phone Number: ", customer_number, "\n\n",
                "Thank you for using our service!");

            client.Send("realestateutilityuahteamseven@gmail.com", agent_email, "Requested Showing", emailBody);


        }

        /// <summary>
        /// Emails the closing forms to agent.
        /// </summary>
        /// <param name="agent_email">The agent email.</param>
        /// <param name="agent_fName">Name of the agent f.</param>
        /// <param name="agent_lName">Name of the agent l.</param>
        /// <param name="property_street">The property street.</param>
        /// <param name="property_city">The property city.</param>
        /// <param name="property_state">State of the property.</param>
        /// <param name="property_zip">The property zip.</param>
        /// <param name="ClosingSettlementToSend">The closing settlement to send.</param>
        /// <param name="PurchaseAgreementToSend">The purchase agreement to send.</param>
        /// <param name="RepairsRequestToSend">The repairs request to send.</param>
        public static void EmailClosingFormsToAgent(string agent_email, string agent_fName,
                                                    string agent_lName, string property_street, 
                                                    string property_city, string property_state,
                                                    int property_zip, string ClosingSettlementToSend,
                                                    string PurchaseAgreementToSend, string RepairsRequestToSend)
        {
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("realestateutilityuahteamseven@gmail.com", "r01lT!de"),
                EnableSsl = true
            };

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("realestateutilityuahteamseven@gmail.com");
            mail.To.Add(agent_email);
            mail.Subject = "Closing Forms";


            string emailBody = string.Concat(
                "Hello ", agent_fName, " ", agent_lName, ", \n",
                "Attached are the required closing forms for your property located at:\n",
                property_street, "\n",
                property_city, ", ", property_state, " ", property_zip.ToString(), "\n\n",
                "Thank you for using our service!\n");

            mail.Body = emailBody;

            string ClosingSettlementPath = @"C:\Users\Nate McCain\Desktop\closingsettlement.txt";
            string PurchaseAgreementPath = @"C:\Users\Nate McCain\Desktop\purchaseagreement.txt";
            string RepairsRequestPath = @"C:\Users\Nate McCain\Desktop\repairsrequest.txt";

            MakeAttachment(ClosingSettlementPath,ClosingSettlementToSend);
            MakeAttachment(PurchaseAgreementPath, PurchaseAgreementToSend);
            MakeAttachment(RepairsRequestPath, RepairsRequestToSend);

            System.Net.Mail.Attachment ClosingSettlementForm, PurchaseAgreementForm, RepairsRequestForm;
            ClosingSettlementForm = new System.Net.Mail.Attachment(ClosingSettlementPath);
            PurchaseAgreementForm = new System.Net.Mail.Attachment(PurchaseAgreementPath);
            RepairsRequestForm = new System.Net.Mail.Attachment(RepairsRequestPath);

            mail.Attachments.Add(ClosingSettlementForm);
            mail.Attachments.Add(PurchaseAgreementForm);
            mail.Attachments.Add(RepairsRequestForm);

            client.Send(mail);

            DeleteFilesMadeForAttachment(ClosingSettlementPath, PurchaseAgreementPath, RepairsRequestPath);
        }

        /// <summary>
        /// Makes the attachment.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <param name="thingToWrite">The thing to write.</param>
        private static void MakeAttachment(string filename, string thingToWrite)
        {
            using (StreamWriter writer = File.CreateText(filename))
            {
                writer.WriteLine(thingToWrite);
            }
        }

        /// <summary>
        /// Deletes the files made for attachment.
        /// </summary>
        /// <param name="first">The first.</param>
        /// <param name="second">The second.</param>
        /// <param name="third">The third.</param>
        private static void DeleteFilesMadeForAttachment(string first, string second, string third)
        {
            if (File.Exists(first))
                File.Delete(first);
            if (File.Exists(second))
                File.Delete(second);
            if (File.Exists(third))
                File.Delete(third);
        }
    }
}
