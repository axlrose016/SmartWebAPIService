using EmailService.Core.Models;
using EmailService.Core.Repositories;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace EmailService.Persistence.Repositories
{
    public class EmailCentreRepo : IEmailCentreRepo
    {
        private readonly MailConfig _mailConfig;
        public EmailCentreRepo(MailConfig mailConfig)
        {
            _mailConfig = mailConfig;
        }

        public void SendEmail(MailMessage mail)
        {
            var emailMessage = CreateEmailMessage(mail);
            SendEmail(emailMessage);
        }

        private MailMessage CreateEmailMessage(MailMessage message)
        {
            var msg = new MailMessage();
            msg.From = new MailAddress(_mailConfig.From);
            foreach(MailAddress email in message.To) {
                msg.To.Add(email);
            }
            msg.Subject = message.Subject;
            msg.Body = message.Body;
            return msg;
        }

        private void SendMail(MailMessage msg)
        {
            using(var client = new SmtpClient())
            {
                try
                {
                    client.Host = _mailConfig.SmtpServer;
                    client.Port = _mailConfig.Port;
                    client.EnableSsl = true;
                    client.Credentials = new System.Net.NetworkCredential(_mailConfig.UserName, _mailConfig.Password);
                    client.Send(msg);
                }
                catch
                {
                    client.Dispose();
                }
            }
        }
    }
}
