﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class EventManagementEntities : DbContext
    {
        public EventManagementEntities()
            : base("name=EventManagementEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Conference> Conferences { get; set; }
        public virtual DbSet<ConferenceImage> ConferenceImages { get; set; }
        public virtual DbSet<Program> Programs { get; set; }
        public virtual DbSet<Track> Tracks { get; set; }
        public virtual DbSet<AbstractsSubmitted> AbstractsSubmitteds { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Title> Titles { get; set; }
        public virtual DbSet<MST_RegistrationClass> MST_RegistrationClass { get; set; }
        public virtual DbSet<MST_RegistrationType> MST_RegistrationType { get; set; }
        public virtual DbSet<Pricing> Pricings { get; set; }
        public virtual DbSet<AccommodationPricing> AccommodationPricings { get; set; }
        public virtual DbSet<MST_AccomodationType> MST_AccomodationType { get; set; }
        public virtual DbSet<MST_Occupancy> MST_Occupancy { get; set; }
        public virtual DbSet<AccompanyPricing> AccompanyPricings { get; set; }
        public virtual DbSet<MST_Accompany> MST_Accompany { get; set; }
        public virtual DbSet<MemberType> MemberTypes { get; set; }
        public virtual DbSet<ConferenceTeam> ConferenceTeams { get; set; }
        public virtual DbSet<Venue> Venues { get; set; }
        public virtual DbSet<Conference_RegClass_Mapping> Conference_RegClass_Mapping { get; set; }
        public virtual DbSet<ELMAH_Error> ELMAH_Error { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Registrations_Log> Registrations_Log { get; set; }
        public virtual DbSet<MST_Status> MST_Status { get; set; }
        public virtual DbSet<Conference_MediaPartners> Conference_MediaPartners { get; set; }
    }
}
