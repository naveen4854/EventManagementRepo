using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.DataModels
{
    public class RegistrationClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public DateTime? FromDt { get; set; }
        public DateTime? ToDt { get; set; }
        public int Amount { get; set; }
    }
}
