//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EventManagement.DAL.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class AccommodationPricing
    {
        public int Id { get; set; }
        public int FK_ConferenceId { get; set; }
        public int FK_AccomodationTypeId { get; set; }
        public int FK_OccupancyId { get; set; }
        public int Amout { get; set; }
    
        public virtual Conference Conference { get; set; }
        public virtual MST_AccomodationType MST_AccomodationType { get; set; }
        public virtual MST_Occupancy MST_Occupancy { get; set; }
    }
}
