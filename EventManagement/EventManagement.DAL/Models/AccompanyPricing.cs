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
    
    public partial class AccompanyPricing
    {
        public int Id { get; set; }
        public int FK_conferenceId { get; set; }
        public int FK_AccompanyId { get; set; }
        public int Amount { get; set; }
    
        public virtual Conference Conference { get; set; }
        public virtual MST_Accompany MST_Accompany { get; set; }
    }
}
