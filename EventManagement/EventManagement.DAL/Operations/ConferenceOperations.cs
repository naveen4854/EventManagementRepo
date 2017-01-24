﻿using EventManagement.DAL.Models;
using EventManagement.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.DAL.Operations
{
    public class ConferenceOperations
    {
        private EventManagementEntities managementConsoleEntities = new EventManagementEntities();
        public List<ConferenceDTO> GetConferences() {
            return managementConsoleEntities.Conferences.Select(q => new ConferenceDTO
            {
                Id = q.Id,
                Name = q.Name,
                Desc = q.Description,
                ShortDesc = q.ShortDescription
            }).ToList();
        }

        public ConferenceDTO GetConference(int Id)
        {
            var conf = managementConsoleEntities.Conferences.FirstOrDefault(q => q.Id == Id);
            return new ConferenceDTO
            {
                Id = conf.Id,
                Name = conf.Name,
                Desc = conf.Description,
                ShortDesc = conf.ShortDescription,
                ImageUrls = conf.ConferenceImages.Select(q => q.ImageUrl).ToList(),
                Venue = new VenueDTO
                {
                    Id = conf.Venue.Id,
                    Name = conf.Venue.Name,
                    Desc = conf.Venue.Description
                }
            };
        }

        public List<ProgramDTO> GetConferencePrograms(int id)
        {
            return managementConsoleEntities.Programs.Where(q => q.FK_ConferenceId == id).Select(q => new ProgramDTO
            {
                Id = q.Id,
                Name = q.Name,
                ImageUrl = q.ImageUrl,
                Info = q.Info,
                ProgramDt = q.ProgramDt,
                Title = q.Title
            }).ToList();
        }

        public List<TrackDTO> GetTracks(int id)
        {
            return managementConsoleEntities.Tracks.Where(q => q.FK_ConferenceId == id).Select(q => new TrackDTO
            {
                Id = q.Id,
                Name = q.Name,
                Desc = q.Description
            }).ToList();
        }

        public string GetAbstract(int id, int prgId)
        {
            return managementConsoleEntities.Programs.Where(q => q.FK_ConferenceId == id && q.Id == prgId).Select(q=>q.Abstract).FirstOrDefault();
        }

        public string GetConferenceBrochure(int id)
        {
            return managementConsoleEntities.Conferences.FirstOrDefault(q => q.Id == id).brochure;
        }

        public ConferenceDTO GetConferencePeriod(int id)
        {
            var conf = managementConsoleEntities.Conferences.FirstOrDefault(q => q.Id == id);
            return new ConferenceDTO
            {
                Id = conf.Id,
                StartDt = conf.startDt,
                EndDt = conf.endDt
            };
        }

        public ConferenceDTO GetConferenceTeam(int id)
        {
            var conf = managementConsoleEntities.ConferenceTeams.Where(q => q.FK_ConferenceId == id && !q.Chair).Select(q=>new ConferenceTeamDTO {
                ConferenceId = q.FK_ConferenceId,
                Name = q.Name,
                Info = q.Info,
                isChair = q.Chair,
                Biography = q.Biography,
                ImageUrl = q.ImageUrl
            }).ToList();
            return new ConferenceDTO
            {
                Team = conf
            };
        }

        public ConferenceDTO GetConferenceChair(int id)
        {
            var conf = managementConsoleEntities.ConferenceTeams.Where(q => q.FK_ConferenceId == id && q.Chair).Select(q => new ConferenceTeamDTO
            {
                ConferenceId = q.FK_ConferenceId,
                Name = q.Name,
                Info = q.Info,
                isChair = q.Chair,
                Biography = q.Biography,
                ImageUrl = q.ImageUrl
            }).ToList();
            return new ConferenceDTO
            {
                Team = conf
            };
        }

    }
}
