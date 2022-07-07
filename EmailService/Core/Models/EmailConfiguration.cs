using Microsoft.AspNetCore.Http;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmailService.Core.Models
{
    public class MailConfig
    {
        public string MailName { get; set; }
        public string From { get; set; }
        public string SmtpServer { get; set; }
        public int Port { get; set; }
        public Boolean IsTLS { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class MessageContent
    {
        public List<MailboxAddress> Recipients { get; set; }
        public List<string> Cc { get; set; }
        public List<string> Bcc { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public IFormFileCollection Attachments { get; set; }
    }
}
