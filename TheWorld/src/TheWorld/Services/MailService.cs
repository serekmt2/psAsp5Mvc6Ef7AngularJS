using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace TheWorld.Services
{
    public interface IMailService
    {
        bool SendMessage(MailDto mail);
    }

    public class DebugMailService : IMailService
    {
        public bool SendMessage(MailDto mail)
        {
            Debug.WriteLine($"Sending mail to:{mail.To}, Subject: {mail.Subject}");
            return true;
        }
    }

    public class MailDto
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Body { get; set; }
        public string Subject { get; set; }
    }
}
