using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity.UI.Services;
using MimeKit;

namespace vidly.Utility
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var emailMsg = new MimeMessage();
            emailMsg.From.Add(MailboxAddress.Parse("jaroiaung@gmail.com"));
            emailMsg.To.Add(MailboxAddress.Parse(email));
            emailMsg.Subject = subject;
            emailMsg.Body = new TextPart(MimeKit.Text.TextFormat.Html) {
                Text = htmlMessage
            };

            using (var emailClient = new SmtpClient())
            {
                emailClient.Connect("smtp.gmail.com",587,MailKit.Security.SecureSocketOptions.StartTls);
                emailClient.Authenticate("jaj933676@gmail.com","jajamaru@26");
                emailClient.Send(emailMsg);
                emailClient.Disconnect(true);
            }   
            return Task.CompletedTask;
        }
    }
}