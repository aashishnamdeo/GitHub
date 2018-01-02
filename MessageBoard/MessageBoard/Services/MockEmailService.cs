using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace MessageBoard.Services
{
    public class MockEmailService : IMailService
    {
        public bool SentMail(string from, string to, string subject, string message)
        {
            Debug.WriteLine($"Mail sent for {subject}");
            return true;
        }
    }
}