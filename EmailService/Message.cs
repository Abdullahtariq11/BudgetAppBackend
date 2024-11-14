using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MimeKit;

namespace EmailService
{
    public class Message
    {
        public List<MailboxAddress> To { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public Message(IEnumerable<string>to,string subject,string content)
        {
            To = new List<MailboxAddress>();
            To.AddRange(to.Select(email=>new MailboxAddress("",email)));
            Subject = subject;
            Content = content;
        }
    }
}
