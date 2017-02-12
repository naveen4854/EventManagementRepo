using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.DataModels
{
    public class OccupancyDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int NoOfPeople { get; set; }

        public int Amount { get; set; }

        public bool isSelected { get; set; }
    }
}
