using System;
using System.Collections;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
namespace EventManagement.BLL.Helpers
{
    public class MailHelper
    {
        private readonly string server = "smtp.gmail.com";
        private readonly int port = 587;
        public void SendMailWithAttachment(string from, string to, string fileName, string mailSubject, string mailBody)
        {
            // Specify the file to be attached and sent.
            string file = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/content/uploads/"), fileName);
            // Create a message and set up the recipients.
            MailMessage message = new MailMessage(
               from,
               to,
               mailSubject,
               mailBody);

            // Create  the file attachment for this e-mail message.
            Attachment data = new Attachment(file, MediaTypeNames.Application.Octet);
            // Add time stamp information for the file.
            ContentDisposition disposition = data.ContentDisposition;
            disposition.CreationDate = System.IO.File.GetCreationTime(file);
            disposition.ModificationDate = System.IO.File.GetLastWriteTime(file);
            disposition.ReadDate = System.IO.File.GetLastAccessTime(file);
            // Add the file attachment to this e-mail message.
            message.Attachments.Add(data);

            SmtpClient client = new SmtpClient(server, 587);
            client.Credentials = new NetworkCredential("sc_admin@scientificcognizance.com", "cognizance@2017");
            client.EnableSsl = true;
            try
            {
                client.Send(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in CreateMessageWithAttachment(): {0}",
                            ex.ToString());
            }
            ContentDisposition cd = data.ContentDisposition;
            data.Dispose();
        }
    }
}
