using EmailService.Core.Models;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace EmailService.Core.Repositories
{
    public interface IEmailCentreRepo
    {
        void SendEmail(MailMessage mail);
    }
}
