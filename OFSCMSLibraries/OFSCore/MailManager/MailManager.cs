using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.Collections;
using System.Text.RegularExpressions;
using System.Net.Mime;

namespace OFSCore.MailManager
{
    public class MailManager
    {
        public static string SMTPAddress
        {
            get;
            set;
        }
        /// <summary>
        /// Transmit an email message to a recipient without
        /// any attachments
        /// </summary>
        /// <param name="sendTo">Recipient Email Address</param>
        /// <param name="sendFrom">Sender Email Address</param>
        /// <param name="sendSubject">Subject Line Describing Message</param>
        /// <param name="sendMessage">The Email Message Body</param>
        /// <returns>Status Message as String</returns>
        public static string SendMessage(string sendTo, string sendFrom,
            string sendSubject, string sendMessage)
        {
            try
            {
                // validate the email address
                bool bTest = ValidateEmailAddress(sendTo);

                // if the email address is bad, return message
                if (bTest == false)
                    return "Invalid recipient email address: " + sendTo;

                // create the email message
                MailMessage message = new MailMessage(
                   sendFrom,
                   sendTo,
                   sendSubject,
                   sendMessage);

                // create smtp client at mail server location
                SmtpClient client = new SmtpClient(SMTPAddress, 25);

                // add credentials
                //client.UseDefaultCredentials = true;

                NetworkCredential Credential = new NetworkCredential();
                //Credential.Domain = OFSCore.Util.Parameters.MailSMTP;
                Credential.UserName = OFSCore.Util.Parameters.SmtpUserName;
                Credential.Password = OFSCore.Util.Parameters.SmtpPassword;
                client.UseDefaultCredentials = false;
                client.Credentials = Credential;
                //client.EnableSsl = true;

                // send message
                client.Send(message);

                return "Il tuo messaggio è stato inviato. Ti risponderemo quanto prima";
            }
            catch (Exception ex)
            {
                string msg = "Errore nell'invio del messaggio: " + ex.Message.ToString();
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                    msg += "<br/>" + ex.Message.ToString();
                }
                return msg;
            }
        }


        /// <summary>
        /// Transmit an email message with
        /// attachments
        /// </summary>
        /// <param name="sendTo">Recipient Email Address</param>
        /// <param name="sendFrom">Sender Email Address</param>
        /// <param name="sendSubject">Subject Line Describing Message</param>
        /// <param name="sendMessage">The Email Message Body</param>
        /// <param name="attachments">A string array pointing to the location of each attachment</param>
        /// <returns>Status Message as String</returns>
        public static string SendMessageWithAttachment(string sendTo, string
        sendFrom, string sendSubject, string sendMessage, ArrayList
        attachments)
        {
            try
            {
                // validate email address
                bool bTest = ValidateEmailAddress(sendTo);

                if (bTest == false)
                    return "Invalid recipient email address: " + sendTo;

                // Create the basic message
                MailMessage message = new MailMessage(
                   sendFrom,
                   sendTo,
                   sendSubject,
                   sendMessage);

                // The attachments array should point to a file location     
                // where
                // the attachment resides - add the attachments to the
                // message
                foreach (string attach in attachments)
                {
                    Attachment attached = new Attachment(attach,
                    MediaTypeNames.Application.Octet);
                    message.Attachments.Add(attached);
                }

                // create smtp client at mail server location
                SmtpClient client = new
                SmtpClient(SMTPAddress);

                // Add credentials
                client.UseDefaultCredentials = true;

                // send message
                client.Send(message);

                return "Message sent to " + sendTo + " at " +
                DateTime.Now.ToString() + ".";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        /// <summary>
        /// Confirm that an email address is valid
        /// in format
        /// </summary>
        /// <param name="emailAddress">Full email address to validate</param>
        /// <returns>True if email address is valid</returns>
        public static bool ValidateEmailAddress(string emailAddress)
        {
            try
            {
                string TextToValidate = emailAddress;
                Regex expression = new Regex(@"\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}");

                // test email address with expression
                if (expression.IsMatch(TextToValidate))
                {
                    // is valid email address
                    return true;
                }
                else
                {
                    // is not valid email address
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}