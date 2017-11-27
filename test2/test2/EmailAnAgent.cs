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
                                                     string property_state, string property_zip)
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

            client.Dispose();

        }


        /// <summary>
        /// Contacts the listing agent about showing their listing.
        /// </summary>
        /// <param name="listing_agent_email">The listing agent email.</param>
        /// <param name="listing_agent_Fname">The listing agent fname.</param>
        /// <param name="listing_agent_Lname">The listing agent lname.</param>
        /// <param name="showing_agent_email">The showing agent email.</param>
        /// <param name="showing_agent_number">The showing agent number.</param>
        /// <param name="showing_agent_Fname">The showing agent fname.</param>
        /// <param name="showing_agent_Lname">The showing agent lname.</param>
        /// <param name="customer_Fname">The customer fname.</param>
        /// <param name="customer_Lname">The customer lname.</param>
        /// <param name="customer_email">The customer email.</param>
        /// <param name="customer_number">The customer number.</param>
        /// <param name="property_street">The property street.</param>
        /// <param name="property_city">The property city.</param>
        /// <param name="property_state">State of the property.</param>
        /// <param name="property_zip">The property zip.</param>
        /// <param name="showing_start_date">The showing start date.</param>
        /// <param name="showing_end_date">The showing end date.</param>
        /// <param name="showing_start_time">The showing start time.</param>
        /// <param name="showing_end_time">The showing end time.</param>
        public static void ContactListingAgentAboutShowingTheirListing(string listing_agent_email,
            string listing_agent_Fname, string listing_agent_Lname,
            string showing_agent_email, string showing_agent_number, string showing_agent_Fname,
            string showing_agent_Lname, string customer_Fname,
            string customer_Lname, string customer_email, string customer_number, string property_street,
            string property_city, string property_state,
            string property_zip, string showing_start_date, string showing_end_date, string showing_start_time,
            string showing_end_time)
        {
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("realestateutilityuahteamseven@gmail.com", "r01lT!de"),
                EnableSsl = true
            };

            string emailBody;

            // if the listing agent is also the showing agent.
            if (string.Compare(listing_agent_email, showing_agent_email, true) == 0 &&
                string.Compare(listing_agent_Fname, showing_agent_Fname, true) == 0 &&
                string.Compare(listing_agent_Lname, showing_agent_Lname, true) == 0)
            {
                emailBody = GenerateEmailBodyForListingAgentShowingTheirProperty(listing_agent_Fname,
                    listing_agent_Lname);
            }
            // if the listing agent is not the showing agent.
            else
            {
                emailBody = GenerateEmailBodyForListingAgentNotShowingTheirProperty(listing_agent_Fname,
                    listing_agent_Lname,
                    showing_agent_email, showing_agent_number, showing_agent_Fname, showing_agent_Lname);
            }

            #region Email Body Replacements
            emailBody = emailBody.Replace("<Street>",property_street);
            emailBody = emailBody.Replace("<City>",property_city);
            emailBody = emailBody.Replace("<State>",property_state);
            emailBody = emailBody.Replace("<Zip>",property_zip);
            emailBody = emailBody.Replace("<Customer_First>",customer_Fname);
            emailBody = emailBody.Replace("<Customer_Last>",customer_Lname);
            emailBody = emailBody.Replace("<Customer_Phone>",customer_number);
            emailBody = emailBody.Replace("<Customer_Email>",customer_email);
            emailBody = emailBody.Replace("<Start_Date>",showing_start_date);
            emailBody = emailBody.Replace("<Start_Time>",showing_start_time);
            emailBody = emailBody.Replace("<End_Date>",showing_end_date);
            emailBody = emailBody.Replace("<End_Time>",showing_end_time);
            #endregion

            client.Send("realestateutilityuahteamseven@gmail.com", listing_agent_email, "Showing Notification", emailBody);

            client.Dispose();
        }

        /// <summary>
        /// Generates the email body for listing agent showing their property.
        /// </summary>
        /// <param name="Fname">The fname.</param>
        /// <param name="Lname">The lname.</param>
        /// <returns></returns>
        public static string GenerateEmailBodyForListingAgentShowingTheirProperty(string Fname, string Lname)
        {
            string message = string.Concat(
                "Hello <Listing_First> <Listing_Last>!\n",
                "This is a reminder that you will be showing your listing located at: \n\n",
                "<Street>\n",
                "<City>, <State> <Zip> \n\n",
                "The showing is scheduled for the following: \n",
                "<Start_Date> at <Start_Time> to <End_Date> at <End_Time> \n\n",
                "Here is the information on the potential buyer you will be showing the property to:\n",
                "<Customer_First> <Customer_Last> \n",
                "Customer's Phone Number: <Customer_Phone> \n",
                "Customer's Email Address: <Customer_Email>\n\n",
                "Thank you for using our service!\n");

            message = message.Replace("<Listing_First>", Fname);
            message = message.Replace("<Listing_Last>", Lname);

            return message;
        }

        /// <summary>
        /// Generates the email body for listing agent not showing their property.
        /// </summary>
        /// <param name="listing_agent_Fname">The listing agent fname.</param>
        /// <param name="listing_agent_Lname">The listing agent lname.</param>
        /// <param name="showing_agent_email">The showing agent email.</param>
        /// <param name="showing_agent_number">The showing agent number.</param>
        /// <param name="showing_agent_Fname">The showing agent fname.</param>
        /// <param name="showing_agent_Lname">The showing agent lname.</param>
        /// <returns></returns>
        public static string GenerateEmailBodyForListingAgentNotShowingTheirProperty(string listing_agent_Fname, string listing_agent_Lname,
            string showing_agent_email, string showing_agent_number, string showing_agent_Fname, string showing_agent_Lname)
        {
            string message = string.Concat(
                "Hello <Listing_First> <Listing_Last>!\n",
                "This is a notification that another agent will be showing your listing located at: \n\n",
                "<Street> \n",
                "<City>, <State> <Zip> \n\n",
                "The agent that will be showing your property is: \n",
                showing_agent_Fname, " ", showing_agent_Lname, "\n",
                "Showing Agent's Phone Number: ", showing_agent_number, " \n",
                "Showing Agent's Email Address: ", showing_agent_email, " \n\n",
                "The showing is scheduled for the following: \n",
                "<Start_Date> at <Start_Time> to <End_Date> at <End_Time> \n\n",
                "Here is the information on the potential buyer you will be showing the property to:\n",
                "<Customer_First> <Customer_Last> \n",
                "Customer's Phone Number: <Customer_Phone> \n",
                "Customer's Email Address: <Customer_Email>\n\n",
                "Thank you for using our service!\n");

            message = message.Replace("<Listing_First>", listing_agent_Fname);
            message = message.Replace("<Listing_Last>", listing_agent_Lname);

            return message;
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
                                                    string property_zip, string ClosingSettlementToSend,
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
                property_city, ", ", property_state, " ", property_zip, "\n\n",
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
            
            mail.Dispose();
            client.Dispose();

            DeleteFilesMadeForAttachment(ClosingSettlementPath, PurchaseAgreementPath, RepairsRequestPath);
        }

        /// <summary>
        /// Makes the attachment.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <param name="thingToWrite">The thing to write.</param>
        private static void MakeAttachment(string filename, string thingToWrite)
        {
            using (var writer = new StreamWriter(filename, false))
            {
                writer.WriteLine(thingToWrite);
                writer.Close();
            }
            //using (StreamWriter writer = File.CreateText(filename))
            //{
            //    writer.WriteLine(thingToWrite);
            //}
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
