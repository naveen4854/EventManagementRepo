using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace EventManagement.BLL.Helpers
{
    public class UploadHelper
    {
        public string UploadFile(HttpPostedFileBase file, string uploadDir)
        {
            var fileName = Guid.NewGuid() + "_" + file.FileName;

            if (file.ContentLength > 0)
            {
                var filePath = Path.Combine(System.Web.HttpContext.Current.Server.MapPath(uploadDir), fileName);
                file.SaveAs(filePath);
            }
            return fileName;
        }

        public List<string> UploadFile(List<HttpPostedFileBase> files, string uploadDir)
        {
            var fileNames = new List<string>();
            foreach (var file in files)
            {
                fileNames.Add( UploadFile(file, uploadDir));
            }
            return fileNames;
        }
    }

}
