using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.BLL.Helpers
{
    public static class Utilities
    {
        public static string ProcessDefaultImage(string fileName, string filepath)
        {

            if (File.Exists(System.Web.HttpContext.Current.Server.MapPath(filepath + fileName)))
            {
                return filepath + fileName;
            }

            return "~/Content/images/default.png";
        }

    }
}
