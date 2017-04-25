using EventManagement.DAL.Models;
using EventManagement.DataModels;
using EventManagement.DataModels.Enum;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.DAL.Operations
{
    public class ConferenceOperations
    {
        private EventManagementEntities managementConsoleEntities = new EventManagementEntities();
        public List<ConferenceDTO> GetConferences()
        {
            return managementConsoleEntities.Conferences.Select(q => new ConferenceDTO
            {
                Id = q.Id,
                Name = q.Name,
                Desc = q.Description,
                ShortDesc = q.ShortDescription,
                StartDt = q.startDt,
                EndDt = q.endDt,
                ShortImgUrl = q.shortImageUrl,
                DisplayId = q.DisplayId
            }).ToList();
        }

        public List<VenueDTO> GetVenues()
        {
            return managementConsoleEntities.Venues.Select(q => new VenueDTO
            {
                Id = q.Id,
                Name = q.Name,
                Desc = q.Description,
                Address = q.Address,
                Telephone = q.Telephone,
                Map = new MapDTO { Latitude = q.latitude, Longitude = q.longitude }
            }).ToList();
        }

        public bool UpdateVenue(VenueDTO obj)
        {
            Venue venue;
            using (var entities = new EventManagementEntities())
            {
                venue = entities.Venues.Where(q => q.Id == obj.Id).FirstOrDefault();
            }
            if (venue != null)
            {
                venue.Name = obj.Name;
                venue.Description = obj.Desc;
                venue.Address = obj.Address;
                venue.Telephone = obj.Telephone;
                venue.latitude = obj.Map.Latitude;
                venue.longitude = obj.Map.Longitude;
            }
            using (var entitiesX = new EventManagementEntities())
            {
                entitiesX.Entry(venue).State = EntityState.Modified;
                entitiesX.SaveChanges();
            }
            return true;
        }

        public void AddCountry(CountryModel country)
        {
            var c = new Country
            {
                Name = country.Name,
                CallingCode = country.CallingCodes
            };
            using (var entities = new EventManagementEntities())
            {
                entities.Countries.Add(c);
                entities.SaveChanges();
            }
        }

        public IEnumerable<RegistrationClass> GetConferenceRegClassMapping(int id)
        {
            return managementConsoleEntities.Conference_RegClass_Mapping.Where(q => q.FK_ConferenceId == id).Select(q => new RegistrationClass
            {
                Id = q.FK_RegClassId,
                FromDt = q.FromDt,
                ToDt = q.ToDt,
                Name = q.MST_RegistrationClass.Name
            });
        }

        public IEnumerable<RegistrationTypeDTO> GetConferencePrices(int id)
        {
            var c = managementConsoleEntities.MST_RegistrationType.Select(q => new RegistrationTypeDTO
            {
                Id = q.Id,
                Name = q.Name,
                IsActive = q.IsActive,
                PricingTypes = q.Pricings.Where(x => x.FK_ConferenceId == id).Select(x => new PricingType
                {
                    RegClassId = x.FK_RegClass,
                    Name = x.MST_RegistrationClass.Name,
                    IsActive = true,
                    Price = x.Amout
                })
            });
            return c;
        }

        public int GetConferenceId(string key)
        {
            return managementConsoleEntities.Conferences.FirstOrDefault(q => q.DisplayId == key).Id;
        }

        public bool DeleteVenue(int id)
        {
            Venue venue;
            using (var entities = new EventManagementEntities())
            {
                venue = entities.Venues.Where(q => q.Id == id).FirstOrDefault();
            }
            using (var entitiesX = new EventManagementEntities())
            {
                entitiesX.Entry(venue).State = EntityState.Deleted;
                entitiesX.SaveChanges();
            }
            return true;
        }

        public IEnumerable<ProgramDTO> GetPostersByConf(int id)
        {
            return managementConsoleEntities.Programs.Where(q => q.FK_ConferenceId == id && q.isPoster).Select(q => new ProgramDTO
            {
                Id = q.Id,
                Name = q.Name,
                ImageUrl = q.ImageUrl,
                Info = q.Info,
                ProgramDt = q.ProgramDt,
                Title = q.Title,
                ConferenceId = q.FK_ConferenceId,
                Abstract = q.Abstract
            }).ToList();
        }

        public VenueDTO GetVenue(int id)
        {
            var venue = managementConsoleEntities.Venues.FirstOrDefault(q => q.Id == id);
            return new VenueDTO
            {
                Id = venue.Id,
                Name = venue.Name,
                Desc = venue.Description,
                Address = venue.Address,
                Telephone = venue.Telephone,
                Map = new MapDTO { Latitude = venue.latitude, Longitude = venue.longitude }
            };
        }

        public bool DeleteConference(int id)
        {
            Conference conf;
            using (var entities = new EventManagementEntities())
            {
                conf = entities.Conferences.Where(q => q.Id == id).FirstOrDefault();
            }
            using (var entitiesX = new EventManagementEntities())
            {
                entitiesX.Entry(conf).State = EntityState.Deleted;
                entitiesX.SaveChanges();
            }
            return true;
        }

        public bool UpdateConference(ConferenceDTO obj)
        {
            Conference conf;
            using (var entities = new EventManagementEntities())
            {
                conf = entities.Conferences.Where(q => q.Id == obj.Id).FirstOrDefault();
            }
            if (conf != null)
            {
                conf.Name = obj.Name;
                conf.Description = obj.Desc;
                conf.startDt = obj.StartDt;
                conf.endDt = obj.EndDt;
                conf.ShortDescription = obj.ShortDesc;
                conf.FK_VenueId = obj.Venue.Id;
                conf.shortImageUrl = obj.ShortImgUrl ?? conf.shortImageUrl;
                conf.DisplayId = obj.DisplayId;
                conf.ConfEmail = obj.ConfEmail;
            }
            using (var entitiesX = new EventManagementEntities())
            {
                entitiesX.Entry(conf).State = EntityState.Modified;
                entitiesX.SaveChanges();
            }
            return true;
        }

        public bool UpdateTrack(TrackDTO obj)
        {
            Track track;
            using (var entities = new EventManagementEntities())
            {
                track = entities.Tracks.Where(q => q.Id == obj.Id).FirstOrDefault();
            }
            if (track != null)
            {
                track.Name = obj.Name;
                track.Description = obj.Desc;
            }
            using (var entitiesX = new EventManagementEntities())
            {
                entitiesX.Entry(track).State = EntityState.Modified;
                entitiesX.SaveChanges();
            }
            return true;
        }

        public bool DeleteTrack(int id)
        {
            Track track;
            using (var entities = new EventManagementEntities())
            {
                track = entities.Tracks.Where(q => q.Id == id).FirstOrDefault();
            }
            using (var entitiesX = new EventManagementEntities())
            {
                entitiesX.Entry(track).State = EntityState.Deleted;
                entitiesX.SaveChanges();
            }
            return true;
        }

        public TrackDTO GetTrack(int id)
        {
            var track = managementConsoleEntities.Tracks.Where(q => q.Id == id).FirstOrDefault();
            return new TrackDTO
            {
                Id = track.Id,
                Name = track.Name,
                Desc = track.Description,
                ConferenceId = track.FK_ConferenceId
            };
        }

        public bool AddVenue(VenueDTO obj)
        {
            var a = new Venue
            {
                Name = obj.Name,
                Description = obj.Desc,
                Address = obj.Address,
                Telephone = obj.Telephone,
                latitude = obj.Map.Latitude,
                longitude = obj.Map.Longitude,
            };
            using (var entities = new EventManagementEntities())
            {
                entities.Venues.Add(a);
                entities.SaveChanges();
            }
            return true;
        }

        public string GetCategory(int category)
        {
            return managementConsoleEntities.Categories.FirstOrDefault(q => q.Id == category).Name;
        }

        public string GetCountry(int country)
        {
            return managementConsoleEntities.Countries.FirstOrDefault(q => q.Id == country).Name;
        }

        public bool AddConference(ConferenceDTO obj)
        {
            var a = new Conference
            {
                Name = obj.Name.Trim(),
                //DisplayId = obj.Name.Trim().Replace(' ','_'),
                Description = obj.Desc,
                ShortDescription = obj.ShortDesc,
                FK_VenueId = obj.Venue.Id,
                startDt = obj.StartDt,
                endDt = obj.EndDt,
                shortImageUrl = obj.ShortImgUrl ?? "",
                DisplayId = obj.DisplayId,
                ConfEmail = obj.ConfEmail
            };
            using (var entities = new EventManagementEntities())
            {
                entities.Conferences.Add(a);
                entities.SaveChanges();
            }
            return true;
        }

        public string GetConferenceKey(int conferenceId)
        {
            return managementConsoleEntities.Conferences.FirstOrDefault(q => q.Id == conferenceId).DisplayId;
        }

        public bool DeleteConferenceImage(int id)
        {
            ConferenceImage img;
            using (var entities = new EventManagementEntities())
            {
                img = entities.ConferenceImages.Where(q => q.Id == id).FirstOrDefault();
            }
            using (var entitiesX = new EventManagementEntities())
            {
                entitiesX.Entry(img).State = EntityState.Deleted;
                entitiesX.SaveChanges();
            }
            return true;
        }

        public IEnumerable<MemberTypeDTO> GetMemberTypes()
        {
            return managementConsoleEntities.MemberTypes.Select(q => new MemberTypeDTO { Id = q.Id, Name = q.Type, Description = q.Description });
        }

        public bool UpdateTeamMember(TeamMemberDTO obj)
        {
            ConferenceTeam teamMem;
            using (var entities = new EventManagementEntities())
            {
                teamMem = entities.ConferenceTeams.Where(q => q.Id == obj.Id).FirstOrDefault();
            }
            if (teamMem != null)
            {
                teamMem.Name = obj.Name;
                teamMem.Biography = obj.Biography;
                teamMem.Chair = obj.isChair;
                teamMem.FK_MemberType = obj.MemberTypeId;
                teamMem.Info = obj.Info;
                teamMem.ImageUrl = obj.ImageUrl;
            }
            using (var entitiesX = new EventManagementEntities())
            {
                entitiesX.Entry(teamMem).State = EntityState.Modified;
                entitiesX.SaveChanges();
            }
            return true;
        }

        public ProgramDTO DeleteProgram(int id)
        {
            Program prg;
            using (var entities = new EventManagementEntities())
            {
                prg = entities.Programs.Where(q => q.Id == id).FirstOrDefault();
            }
            using (var entitiesX = new EventManagementEntities())
            {
                entitiesX.Entry(prg).State = EntityState.Deleted;
                entitiesX.SaveChanges();
            }
            return new ProgramDTO { Id = prg.Id, ConferenceId = prg.FK_ConferenceId };
        }

        public string GetConferenceEmailId(int id)
        {
            return managementConsoleEntities.Conferences.FirstOrDefault(q => q.Id == id).ConfEmail;
        }

        public bool UpdateProgram(ProgramDTO obj)
        {
            Program prg;
            using (var entities = new EventManagementEntities())
            {
                prg = entities.Programs.Where(q => q.Id == obj.Id).FirstOrDefault();
            }
            if (prg != null)
            {
                prg.Name = obj.Name;
                prg.ImageUrl = obj.ImageUrl;
                prg.Info = obj.Info;
                prg.ProgramDt = obj.ProgramDt;
                prg.Title = obj.Title;
                prg.Abstract = obj.Abstract;
                prg.isPoster = obj.isPoster;
            }
            using (var entitiesX = new EventManagementEntities())
            {
                entitiesX.Entry(prg).State = EntityState.Modified;
                entitiesX.SaveChanges();
            }
            return true;
        }

        public ProgramDTO GetProgram(int id)
        {
            var prg = managementConsoleEntities.Programs.FirstOrDefault(q => q.Id == id);

            return new ProgramDTO
            {
                Id = prg.Id,
                Name = prg.Name,
                ImageUrl = prg.ImageUrl,
                Info = prg.Info,
                ProgramDt = prg.ProgramDt,
                Title = prg.Title,
                Abstract = prg.Abstract,
                isPoster = prg.isPoster
            };
        }

        public TeamMemberDTO DeleteTeamMember(int id)
        {
            ConferenceTeam teamMem;
            using (var entities = new EventManagementEntities())
            {
                teamMem = entities.ConferenceTeams.Where(q => q.Id == id).FirstOrDefault();
            }
            using (var entitiesX = new EventManagementEntities())
            {
                entitiesX.Entry(teamMem).State = EntityState.Deleted;
                entitiesX.SaveChanges();
            }
            return new TeamMemberDTO { Id = teamMem.Id, ConferenceId = teamMem.FK_ConferenceId };
        }

        public TeamMemberDTO GetTeamMember(int id)
        {
            var teamMem = managementConsoleEntities.ConferenceTeams.Where(q => q.Id == id).FirstOrDefault();
            return new TeamMemberDTO
            {
                Id = teamMem.Id,
                ConferenceId = teamMem.FK_ConferenceId,
                Name = teamMem.Name,
                Info = teamMem.Info,
                isChair = teamMem.Chair,
                Biography = teamMem.Biography,
                ImageUrl = teamMem.ImageUrl,
                MemberTypeId = teamMem.FK_MemberType
            };
        }

        public int GetAccPrice(int accTypeId, int occId, int confId)
        {
            return managementConsoleEntities.AccommodationPricings.Where(q => q.FK_AccomodationTypeId == accTypeId && q.FK_OccupancyId == occId && q.FK_ConferenceId == confId).FirstOrDefault().Amout;
        }

        public int GetAccompanyPrice(int accompanyId, int confId)
        {
            return managementConsoleEntities.AccompanyPricings.Where(q => q.FK_conferenceId == confId && q.FK_AccompanyId == accompanyId).FirstOrDefault().Amount;
        }

        public IEnumerable<AccompanyPriceDTO> GetAllAccompanyPrice(int id)
        {
            var acc = managementConsoleEntities.AccompanyPricings.Where(q => q.FK_conferenceId == id).Select(q => new AccompanyPriceDTO
            {
                Id = q.MST_Accompany.Id,
                Name = q.MST_Accompany.Name,
                Value = q.MST_Accompany.Value,
                Amount = q.Amount,
            });
            return acc;
        }

        public int GetRegPrice(int regTypeId, int regClassId, int confId)
        {
            return managementConsoleEntities.Pricings.Where(q => q.FK_RegClass == regClassId && q.FK_RegType == regTypeId && q.FK_ConferenceId == confId).FirstOrDefault().Amout;
        }

        public bool AddTrack(TrackDTO obj)
        {
            var a = new Track
            {
                Name = obj.Name,
                Description = obj.Desc,
                FK_ConferenceId = obj.ConferenceId
            };
            using (var entities = new EventManagementEntities())
            {
                entities.Tracks.Add(a);
                entities.SaveChanges();
            }
            return true;
        }

        public List<string> GetConferenceImages(int id)
        {
            return managementConsoleEntities.ConferenceImages.Where(q => q.FK_ConferenceId == id).Select(q => q.ImageUrl).ToList();
        }

        public List<ConferenceImageDTO> GetConferenceImagesDTO(int id)
        {
            return managementConsoleEntities.ConferenceImages.Where(q => q.FK_ConferenceId == id).Select(q => new ConferenceImageDTO
            {
                Id = q.Id,
                ImageUrl = q.ImageUrl,
                ConferenceId = q.FK_ConferenceId
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
                StartDt = conf.startDt,
                EndDt = conf.endDt,
                DisplayId = conf.DisplayId,
                ConfEmail = conf.ConfEmail,
                Venue = new VenueDTO
                {
                    Id = conf.Venue.Id,
                    Name = conf.Venue.Name,
                    Desc = conf.Venue.Description,
                    Address = conf.Venue.Address,
                    Email = conf.ConfEmail,
                    Telephone = conf.Venue.Telephone,
                    Map = new MapDTO { Latitude = conf.Venue.latitude, Longitude = conf.Venue.longitude }
                }
            };
        }

        public bool AddConferenceTeam(TeamMemberDTO obj)
        {
            var a = new ConferenceTeam
            {
                Name = obj.Name,
                Biography = obj.Biography,
                Chair = obj.isChair,
                ImageUrl = obj.ImageUrl,
                Info = obj.Info,
                FK_ConferenceId = obj.ConferenceId,
                FK_MemberType = obj.MemberTypeId
            };
            using (var entities = new EventManagementEntities())
            {
                entities.ConferenceTeams.Add(a);
                entities.SaveChanges();
            }
            return true;
        }

        public bool PostConferenceImage(ConferenceImageDTO conferenceImage)
        {
            var a = new ConferenceImage
            {
                ImageUrl = conferenceImage.Name,
                FK_ConferenceId = conferenceImage.ConferenceId
            };
            using (var entities = new EventManagementEntities())
            {
                entities.ConferenceImages.Add(a);
                entities.SaveChanges();
            }
            return true;
        }

        public bool AddProgram(ProgramDTO obj)
        {
            var a = new Program
            {
                Name = obj.Name,
                Info = obj.Info,
                Title = obj.Title,
                ImageUrl = obj.ImageUrl,
                FK_ConferenceId = obj.ConferenceId,
                ProgramDt = obj.ProgramDt.Date,
                Abstract = obj.Abstract,
                isPoster = obj.isPoster
            };
            using (var entities = new EventManagementEntities())
            {
                entities.Programs.Add(a);
                entities.SaveChanges();
            }
            return true;
        }

        public List<ProgramDTO> GetProgramsByConf(int id)
        {
            return managementConsoleEntities.Programs.Where(q => q.FK_ConferenceId == id && !q.isPoster).Select(q => new ProgramDTO
            {
                Id = q.Id,
                Name = q.Name,
                ImageUrl = q.ImageUrl,
                Info = q.Info,
                ProgramDt = q.ProgramDt,
                Title = q.Title,
                ConferenceId = q.FK_ConferenceId,
                Abstract = q.Abstract
            }).ToList();
        }

        public List<TrackDTO> GetConferenceTracks(int id)
        {
            return managementConsoleEntities.Tracks.Where(q => q.FK_ConferenceId == id).Select(q => new TrackDTO
            {
                Id = q.Id,
                Name = q.Name,
                Desc = q.Description,
                ConferenceId = q.FK_ConferenceId
            }).ToList();
        }

        public string GetAbstract(int id, int prgId)
        {
            return managementConsoleEntities.Programs.Where(q => q.FK_ConferenceId == id && q.Id == prgId).Select(q => q.Abstract).FirstOrDefault();
        }

        public int PostAbstract(AbstractSubmitDTO obj)
        {
            var a = new AbstractsSubmitted
            {
                SubmittedBy = obj.SubmittedBy,
                EmailId = obj.EmailId,
                FK_CategoryId = obj.Category,
                FK_ContryId = obj.Country,
                DocName = obj.DocUrl,
                Organisation = obj.Organisation,
                FK_TrackID = obj.Track,
                FK_TitleId = obj.Title,
                FK_ConferenceId = obj.ConferenceId,
                Telephone = obj.Telephone
            };
            var id = -1;
            using (var entities = new EventManagementEntities())
            {
                entities.AbstractsSubmitteds.Add(a);
                entities.SaveChanges();
                id = a.Id;
            }
            return id;
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
            var conf = managementConsoleEntities.ConferenceTeams.Where(q => q.FK_ConferenceId == id && q.MemberType.Type == MemberTypeEnum.OCM).Select(q => new TeamMemberDTO
            {
                Id = q.Id,
                ConferenceId = q.FK_ConferenceId,
                Name = q.Name,
                Info = q.Info,
                isChair = q.Chair,
                Biography = q.Biography,
                ImageUrl = q.ImageUrl,
                MemberTypeId = q.FK_MemberType
            }).ToList();
            return new ConferenceDTO
            {
                Team = conf
            };
        }

        public ConferenceDTO GetAllConferenceTeam(int id)
        {
            var conf = managementConsoleEntities.ConferenceTeams.Where(q => q.FK_ConferenceId == id && !(q.MemberType.Type == MemberTypeEnum.SA)).Select(q => new TeamMemberDTO
            {
                Id = q.Id,
                ConferenceId = q.FK_ConferenceId,
                Name = q.Name,
                Info = q.Info,
                isChair = q.Chair,
                Biography = q.Biography,
                ImageUrl = q.ImageUrl,
                MemberTypeId = q.FK_MemberType
            }).ToList();
            return new ConferenceDTO
            {
                Team = conf
            };
        }

        public ConferenceDTO GetConferenceChair(int id)
        {
            var conf = managementConsoleEntities.ConferenceTeams.Where(q => q.FK_ConferenceId == id && q.MemberType.Type == MemberTypeEnum.Chair).Select(q => new TeamMemberDTO
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

        public IEnumerable<TeamMemberDTO> GetScientificAdvisors()
        {
            var team = managementConsoleEntities.ConferenceTeams.Where(q => q.MemberType.Type == MemberTypeEnum.SA).Select(q => new TeamMemberDTO
            {
                Id = q.Id,
                Name = q.Name,
                Info = q.Info,
                isChair = q.Chair,
                Biography = q.Biography,
                ImageUrl = q.ImageUrl,
                MemberTypeId = q.FK_MemberType
            }).ToList();

            return team;
        }

        public List<CountryModel> GetCountries()
        {
            return managementConsoleEntities.Countries.Select(q => new CountryModel
            {
                Id = q.Id,
                Name = q.Name,
            }).ToList();
        }

        public List<CategoryModel> GetCategories()
        {
            return managementConsoleEntities.Categories.Select(q => new CategoryModel
            {
                Id = q.Id,
                Name = q.Name,
            }).ToList();
        }

        public List<TitleModel> GetTitles()
        {
            return managementConsoleEntities.Titles.Select(q => new TitleModel
            {
                Id = q.Id,
                Name = q.Name,
            }).ToList();
        }
    }
}
