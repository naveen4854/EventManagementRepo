using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.DataModels
{
    public class User
    {
        [Display(Name ="User Name")]
        public string UserName { get; set; }
        public string Roles { get; set; }
        public string Password { get; set; }
    }
}
