using API.Services.Interfaces;
using API.Services.ServiceEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace API.Services.Classes
{
    class EmailService : IEmailService
    {
        public string SendEmail(EmailTypeEnum emailType, string emailAddress)
        {
            switch (emailType)
            {
                case EmailTypeEnum.AccountCreationConfirmationEmail:
                    return this.AccountConfirmationEmail(emailAddress);
                default: return null;
            }
        }

        private string AccountConfirmationEmail(string emailAddress)
        {
            SmtpClient client = new SmtpClient();
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            // setup Smtp authentication
            System.Net.NetworkCredential credentials =
                new System.Net.NetworkCredential("licentanoreply@gmail.com", "Licenta.,16");
            client.UseDefaultCredentials = false;
            client.Credentials = credentials;
            //can be obtained from your model
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("licentanoreply@gmail.com");
            msg.To.Add(new MailAddress(emailAddress));

            msg.Subject = "Your account was succesfully created.";
            msg.IsBodyHtml = true;
            msg.Body = string.Format("<html><head></head><body><b>Account Creation Confirmation</b></body>");
            try
            {
                //client.Send(msg);
                return "OK";
            }
            catch (Exception ex)
            {

                return "error:" + ex.ToString();
            }
        }
    }
}
