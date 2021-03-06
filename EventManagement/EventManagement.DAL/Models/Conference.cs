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
    
    public partial class Conference
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Conference()
        {
            this.ConferenceImages = new HashSet<ConferenceImage>();
            this.Programs = new HashSet<Program>();
            this.Tracks = new HashSet<Track>();
            this.AbstractsSubmitteds = new HashSet<AbstractsSubmitted>();
            this.Pricings = new HashSet<Pricing>();
            this.AccommodationPricings = new HashSet<AccommodationPricing>();
            this.AccompanyPricings = new HashSet<AccompanyPricing>();
            this.ConferenceTeams = new HashSet<ConferenceTeam>();
            this.Conference_RegClass_Mapping = new HashSet<Conference_RegClass_Mapping>();
            this.Registrations_Log = new HashSet<Registrations_Log>();
            this.Conference_MediaPartners = new HashSet<Conference_MediaPartners>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public bool Active { get; set; }
        public int FK_VenueId { get; set; }
        public System.DateTime startDt { get; set; }
        public System.DateTime endDt { get; set; }
        public string brochure { get; set; }
        public string SpeakerList { get; set; }
        public string shortImageUrl { get; set; }
        public string DisplayId { get; set; }
        public string ConfEmail { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConferenceImage> ConferenceImages { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Program> Programs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Track> Tracks { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AbstractsSubmitted> AbstractsSubmitteds { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pricing> Pricings { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AccommodationPricing> AccommodationPricings { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AccompanyPricing> AccompanyPricings { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConferenceTeam> ConferenceTeams { get; set; }
        public virtual Venue Venue { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Conference_RegClass_Mapping> Conference_RegClass_Mapping { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Registrations_Log> Registrations_Log { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Conference_MediaPartners> Conference_MediaPartners { get; set; }
    }
}
