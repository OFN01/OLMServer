using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using System.Net.Mail;
using System.Text.Json;

namespace OLMServer.OLMData.Structures
{
    public class Mail
    {
        public int ID { get; set; }

        public string username { get; set; }
        public string domain { get; set; }
        public string extension { get; set; }
        [NotMapped]
        public string address { get => username + "@" + domain + "." + extension; }

        public Mail(string username, string domain, string extension)
        {
            this.username = username;
            this.domain = domain;
            this.extension = extension;
        }

        public static implicit operator Mail(string address)
        {
            string username = address.Split("@")[0];
            string[] fullDomain = address.Split("@")[1].Split(".");
            string extension = "";
            for (int i = 1; i < fullDomain.Length; i++)
            {
                extension += fullDomain[i] + ".";
            }
            extension = extension.Remove(extension.Length - 1, 1);
            return new Mail(username, fullDomain[0], extension);
        }
        
        public Mail(string JsonData)
        {
            string username = JsonData.Split("@")[0];
            string[] fullDomain = JsonData.Split("@")[1].Split(".");
            string extension = "";
            for (int i = 1; i < fullDomain.Length; i++)
            {
                extension += fullDomain[i] + ".";
            }
            extension = extension.Remove(extension.Length - 1, 1);
            this.username = username;
            this.domain = fullDomain[0];
            this.extension = extension;
        }

        public string SerializeData() => address;

        public void SendMail(string subject, string htmlString)
        {
            //try
            //{
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress(ProgramData.ProgramMail);
                message.To.Add(new MailAddress(address));
                message.Subject = subject;
                message.IsBodyHtml = true; //to make message body as html
                message.Body = htmlString;
                smtp.Port = 587;
                smtp.Host = "smtp.yaanimail.com"; //for gmail host
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(ProgramData.ProgramMail, ProgramData.ProgramMailPass);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            //}
            //catch (Exception) { }
        }
    }
}