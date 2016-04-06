using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;

namespace WebCheckerUI
{
    class email
    {
        public void send(string to, string content, string[] att)
        {
            MailMessage message = new MailMessage("miles_hart@hotmail.com", to, "blah", content);
            message.IsBodyHtml = true;
            foreach (string at in att)
                message.Attachments.Add(new Attachment(at));
            using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587))
            {
                client.Timeout = 600000;
                client.Credentials = new NetworkCredential("mileshart@gmail.com", "yvmqdkjvsqmnaoun");
                client.EnableSsl = true;
                client.Send(message);
            }
        }
    }
}
