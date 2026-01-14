using System.Text.RegularExpressions;
using MailKit.Net.Smtp;
using MimeKit;
using System.Net;
using MailKit.Security;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Tunination;

public class SendgridService
{
    //sendgrid

        private const string SenderEmail = "cerenachris@gmail.com";
        private const string SenderPassword = "xhup csmu qckb etnv"; // Gmail App Password
        private const string SmtpServer = "smtp.gmail.com";
        private const int SmtpPort = 587;
       


         public async Task<bool> SendEmailWithGridAsync(string recipientEmail, string subject, string body)
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
    return true;
         }

         //send email with attachment to admin
         public async Task<bool> SendEmailWithGridToAdmin(string recipientEmail, string subject, string body, byte[] attachment)
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
           return true;
    }

         //send  email of ticket to user
         public async Task<bool> SendEmailWithGridToUser(string recipientEmail, string subject, string body, byte[] ticket)
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
              return true;
    }
         //send email with attachment to user
         public async Task<bool> SendEmailWithGridToUserProof(string recipientEmail, string subject, string body, byte[] ticketBytes, string fileName)
         {
             var message = new MimeMessage();
             message.From.Add(new MailboxAddress("TutiNation", SenderEmail));
             message.To.Add(new MailboxAddress("", recipientEmail));
             message.Subject = subject;

             var bodyBuilder = new BodyBuilder
             {
                 HtmlBody = body
             };

    // Attach the image (NOT a PDF)
    bodyBuilder.Attachments.Add(fileName, ticketBytes);

    message.Body = bodyBuilder.ToMessageBody();

    using var client = new SmtpClient();
    await client.ConnectAsync(SmtpServer, SmtpPort, SecureSocketOptions.StartTls);
    await client.AuthenticateAsync(SenderEmail, SenderPassword);
    await client.SendAsync(message);
    await client.DisconnectAsync(true);
    return true;
        }
}