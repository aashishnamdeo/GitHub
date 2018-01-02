using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace MessageBoard.Services
{
    public class MailService : IMailService
    {
        public bool SentMail(string from, string to, string subject, string message)
        {
            try
            {
                var msg = new MailMessage(from, to, subject, message);
                var client = new SmtpClient();

                client.Send(msg);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}