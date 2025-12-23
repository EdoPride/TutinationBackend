using System.Text.RegularExpressions;
using MailKit.Net.Smtp;
using MimeKit;
using System.Net;
using MailKit.Security;

namespace Tunitation
{
    public class EmailService
    {
        private const string SenderEmail = "cerenachris@gmail.com";
        private const string SenderPassword = "xhup csmu qckb etnv"; // Gmail App Password
        private const string SmtpServer = "smtp.gmail.com";
        private const int SmtpPort = 587;


public async Task SendEmailAsync(string recipientEmail, string subject, string body)
{
    var message = new MimeMessage();
    message.From.Add(new MailboxAddress("Tunination", SenderEmail));
    message.To.Add(new MailboxAddress("", recipientEmail));
    message.Subject = subject;

    var bodyBuilder = new BodyBuilder
    {
        HtmlBody = body
    };

    message.Body = bodyBuilder.ToMessageBody();

    using (var client = new SmtpClient())
    {
        await client.ConnectAsync(SmtpServer, SmtpPort, SecureSocketOptions.StartTls);
        await client.AuthenticateAsync(SenderEmail, SenderPassword);
        await client.SendAsync(message);
        await client.DisconnectAsync(true);
    }
}

//send email with attachement to admin
public async Task SendEmailAsynctoAdmin(string recipientEmail, string subject, string body, byte[] attachment)
{
    var message = new MimeMessage();
    message.From.Add(new MailboxAddress("Tunination", SenderEmail));
    message.To.Add(new MailboxAddress("", recipientEmail));
    message.Subject = subject;

    var bodyBuilder = new BodyBuilder
    {
                HtmlBody = body
            };

            // Add attachment
            bodyBuilder.Attachments.Add("receipt.pdf", attachment);

            message.Body = bodyBuilder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(SmtpServer, SmtpPort, SecureSocketOptions.StartTls);
                await client.AuthenticateAsync(SenderEmail, SenderPassword);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
        }
        //send email with attachement to user
        public async Task SendEmailAsynctoUser(string recipientEmail, string subject, string body)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Tunination", SenderEmail));
            message.To.Add(new MailboxAddress("", recipientEmail));
            message.Subject = subject;

            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = body
            };

            message.Body = bodyBuilder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(SmtpServer, SmtpPort, SecureSocketOptions.StartTls);
                await client.AuthenticateAsync(SenderEmail, SenderPassword);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
        }
    }
}
  