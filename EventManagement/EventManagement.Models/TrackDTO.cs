﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.DataModels
{
    public class TrackDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }

        public int ConferenceId { get; set; }
    }
}
