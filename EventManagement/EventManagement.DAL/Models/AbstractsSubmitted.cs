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
    
    public partial class AbstractsSubmitted
    {
        public int Id { get; set; }
        public string SubmittedBy { get; set; }
        public string EmailId { get; set; }
        public string Telephone { get; set; }
        public string Organisation { get; set; }
        public int FK_CategoryId { get; set; }
        public int FK_TrackID { get; set; }
        public string DocName { get; set; }
        public int FK_TitleId { get; set; }
        public int FK_ContryId { get; set; }
        public int FK_ConferenceId { get; set; }
    
        public virtual Category Category { get; set; }
        public virtual Title Title { get; set; }
        public virtual Track Track { get; set; }
        public virtual Conference Conference { get; set; }
        public virtual Country Country { get; set; }
    }
}
