﻿using System;
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
        public void SendMailWithAttachment(string from, string to, string fileName)
        {
            // Specify the file to be attached and sent.
            string file = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/content/uploads/"), fileName);
            // Create a message and set up the recipients.
            MailMessage message = new MailMessage(
               from,
               to,
               "Quarterly data report.",
               "See the attached spreadsheet.");

            // Create  the file attachment for this e-mail message.
            Attachment data = new Attachment(file, MediaTypeNames.Application.Octet);
            // Add time stamp information for the file.
            ContentDisposition disposition = data.ContentDisposition;
            disposition.CreationDate = System.IO.File.GetCreationTime(file);
            disposition.ModificationDate = System.IO.File.GetLastWriteTime(file);
            disposition.ReadDate = System.IO.File.GetLastAccessTime(file);
            // Add the file attachment to this e-mail message.
            message.Attachments.Add(data);

            //Send the message.
            SmtpClient client = new SmtpClient(server, 587);
            // Add credentials if the SMTP server requires them.
            client.Credentials = new NetworkCredential("sc_admin@scientificcognizance.com", "SC_admin_2017");
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
            // Display the values in the ContentDisposition for the attachment.
            ContentDisposition cd = data.ContentDisposition;
            //Console.WriteLine("Content disposition");
            //Console.WriteLine(cd.ToString());
            //Console.WriteLine("File {0}", cd.FileName);
            //Console.WriteLine("Size {0}", cd.Size);
            //Console.WriteLine("Creation {0}", cd.CreationDate);
            //Console.WriteLine("Modification {0}", cd.ModificationDate);
            //Console.WriteLine("Read {0}", cd.ReadDate);
            //Console.WriteLine("Inline {0}", cd.Inline);
            //Console.WriteLine("Parameters: {0}", cd.Parameters.Count);
            //foreach (DictionaryEntry d in cd.Parameters)
            //{
            //    Console.WriteLine("{0} = {1}", d.Key, d.Value);
            //}
            data.Dispose();
        }
    }
}
