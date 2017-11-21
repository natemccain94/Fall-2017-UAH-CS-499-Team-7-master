using System;
using System.Net;
namespace test2
{
    public static class EmailAnAgent
    {
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

            string emailBody = string.Concat(
                "Hello ", agent_fName, " ", agent_lName, ", \n",
                "Attached are the required closing forms for your property located at:\n",
                property_street, "\n",
                property_city, ", ", property_state, " ", property_zip.ToString(), "\n\n",
                "Thank you for using our service!\n");


        }
    }
}
