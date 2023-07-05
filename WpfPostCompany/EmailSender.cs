using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace WpfPostCompany
{
    public class EmailSender
    {
        public static void SendEmail(string subject, string body, string to)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("postcompany2023@gmail.com");
            mailMessage.To.Add(to);
            mailMessage.Subject = subject;
            mailMessage.Body = body;

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

            smtpClient.Credentials = new NetworkCredential()
            {
                UserName = "demopostcompany2023@gmail.com",
                Password = "klarioinhovunaxa"
            };

            smtpClient.EnableSsl = true;

            try
            {
                smtpClient.Send(mailMessage);
                Console.WriteLine("Email was sent successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
