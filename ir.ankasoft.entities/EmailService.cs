using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace ir.ankasoft.entities
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your email service here to send an email.
            var credentialUserName = "no-reply@alamdari-trading.com";
            var sentFrom = "no-reply@alamdari-trading.com";
            var pwd = "Alamdari-1395";

            // Configure the client:
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient("mail.alamdari-trading.com");

            client.Port = 25;
            client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;

            // Creatte the credentials:
            System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(credentialUserName, pwd);
            client.EnableSsl = false;
            client.Credentials = credentials;

            // Create the message:
            var mail = new System.Net.Mail.MailMessage(sentFrom, message.Destination);
            mail.Subject = message.Subject;
            mail.Body = message.Body;

            return client.SendMailAsync(mail);

            // Plug in your email service here to send an email.
            //return Task.FromResult(0);
        }
    }
}