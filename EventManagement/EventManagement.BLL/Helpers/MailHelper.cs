using EventManagement.DataModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Reflection;

namespace EventManagement.BLL.Helpers
{
    public class MailHelper
    {
        Assembly _assembly;
        Stream _imageStream;
        StreamReader _textStreamReader;
        private readonly string server = "smtp.gmail.com";
        private readonly int port = 587;
        public void SendMailWithAttachment(string from, string to, string fileName, string mailSubject, string bodyHtml, IEnumerable<MailData> mailData)
        {
            // Specify the file to be attached and sent.
            string file = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/content/uploads/"), fileName);
            string mailBody = PopulateBody(bodyHtml, mailData);

            // Create a message and set up the recipients.
            MailMessage message = new MailMessage(
               from,
               to,
               mailSubject,
               mailBody);
            message.IsBodyHtml = true;
            // Create  the file attachment for this e-mail message.
            Attachment data = new Attachment(file, MediaTypeNames.Application.Octet);
            // Add time stamp information for the file.
            ContentDisposition disposition = data.ContentDisposition;
            disposition.CreationDate = System.IO.File.GetCreationTime(file);
            disposition.ModificationDate = System.IO.File.GetLastWriteTime(file);
            disposition.ReadDate = System.IO.File.GetLastAccessTime(file);
            // Add the file attachment to this e-mail message.
            message.Attachments.Add(data);

            SmtpClient client = new SmtpClient(server, port);
            client.Credentials = new NetworkCredential(from, "cognizance@2017");
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

        private string PopulateBody(string bodyHtml, IEnumerable<MailData> mailData)
        {
            string body = string.Empty;
            try
            {
                _assembly = Assembly.GetExecutingAssembly();
                var resources = _assembly.GetManifestResourceNames();
                var res = Array.Find(resources, q => q.Contains(bodyHtml));
                _imageStream = _assembly.GetManifestResourceStream(res);
                using (StreamReader reader = new StreamReader(_imageStream))
                {
                    body = reader.ReadToEnd();
                }
                foreach (var data in mailData)
                {
                    body = body.Replace(data.Placeholder, data.Data);
                }
            }
            catch
            {
            }
            return body;
        }
    }
}
