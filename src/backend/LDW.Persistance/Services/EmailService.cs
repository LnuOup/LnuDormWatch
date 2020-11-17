using LDW.Application.Interfaces.Services;
using LDW.Domain.Common;
using LDW.Domain.Entities;
using LDW.Domain.Entities.Options;
using LDW.Domain.Resources;
using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace LDW.Persistence.Services
{
    public class EmailService : ServiceBase, IEmailService
    {
        public async Task<OperationResult> SendVerificationEmail(string userName, string url, SmtpOptions config)
        {
            var body = new StringBuilder();
            body.AppendLine($"{Translations.Hello} {userName}");
            body.AppendLine("<br/>");
            body.AppendLine(Translations.VerifyEmail);
            body.AppendLine("<br/>");
            body.AppendLine($"<a href=\"{url}\">{Translations.ClickHere}</a>");
            body.AppendLine("<br/>");
            body.AppendLine($"{Translations.BestRegards}, {config.DisplayName}");

            return Result(() => SendEmail(
                    userName,
                    config.Email,
                    config.DisplayName,
                    config.Password,
                    Translations.VerifyEmailSubject,
                    body.ToString()));
        }


        public static void SendEmail( string receiver, string sender, string senderName,
                                      string senderPassword, string subject, string htmlBody)
        {
            var mail = new MailMessage();
            mail.To.Add(receiver);
            mail.From = new MailAddress(sender, senderName, Encoding.UTF8);
            mail.Subject = subject;
            mail.SubjectEncoding = Encoding.UTF8;
            mail.Body = htmlBody;
            mail.BodyEncoding = Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;

            var client = new SmtpClient
            {
                Credentials = new NetworkCredential(sender, senderPassword),
                Port = 587,
                Host = "smtp.gmail.com",
                EnableSsl = true
            };

            client.Send(mail);
        }
    }
}
