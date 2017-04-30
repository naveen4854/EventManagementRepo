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
    
    public partial class Registrations_Log
    {
        public int Id { get; set; }
        public string SubmittedBy { get; set; }
        public string EmailId { get; set; }
        public string Telephone { get; set; }
        public string Organisation { get; set; }
        public int FK_CountryId { get; set; }
        public string Address { get; set; }
        public int FK_ConferenceId { get; set; }
        public int FK_RegTypeId { get; set; }
        public int FK_RegClassId { get; set; }
        public int FK_StatusId { get; set; }
        public double TotalPrice { get; set; }
        public string Description { get; set; }
    
        public virtual Conference Conference { get; set; }
        public virtual Country Country { get; set; }
        public virtual MST_RegistrationClass MST_RegistrationClass { get; set; }
        public virtual MST_RegistrationType MST_RegistrationType { get; set; }
    }
}