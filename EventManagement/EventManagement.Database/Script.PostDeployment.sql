USE [Eventmandb]
GO
SET IDENTITY_INSERT [dbo].[MST_AccomodationType] ON 

INSERT [dbo].[MST_AccomodationType] ([Id], [Name], [IsActive]) VALUES (1, N'For 2 Nights', 1)
INSERT [dbo].[MST_AccomodationType] ([Id], [Name], [IsActive]) VALUES (2, N'For 3 Nights', 1)
INSERT [dbo].[MST_AccomodationType] ([Id], [Name], [IsActive]) VALUES (3, N'For 4 Nights', 1)
SET IDENTITY_INSERT [dbo].[MST_AccomodationType] OFF
SET IDENTITY_INSERT [dbo].[MST_Occupancy] ON 

INSERT [dbo].[MST_Occupancy] ([Id], [Name], [IsActive], [OccValue]) VALUES (1, N'Single', 1, 1)
INSERT [dbo].[MST_Occupancy] ([Id], [Name], [IsActive], [OccValue]) VALUES (2, N'Double', 1, 2)
INSERT [dbo].[MST_Occupancy] ([Id], [Name], [IsActive], [OccValue]) VALUES (3, N'Triple', 1, 3)
SET IDENTITY_INSERT [dbo].[MST_Occupancy] OFF
SET IDENTITY_INSERT [dbo].[Venue] ON 

INSERT [dbo].[Venue] ([Id], [Name], [Description]) VALUES (2, N'Dubai', N'Dubai is a city within the United Arab Emirates, placed within the emirate. The emirate of dubai is found on the southeast coast of the Persian Gulf and has the largest population within the UAE (2,106,177) and therefore the second-largest land territory by area (4,114 km2) after Abu Dhabi. Abu Dhabi and Dubai are the only 2 emirates to possess veto power over essential matters of national importance within the country''s legislature. The city of Dubai is found on the emirate''s northern lineation and heads up the Dubai-Sharjah-Ajman metropolitan space. As of 2012, Dubai was the 22nd most expensive city in the world and the most expensive city in the Middle East. Dubai was rated as one of the best places to live in the Middle East by U.S. global consulting firm Mercer There square measure 52 establishments in Dubai that supply higher education programs, and they are classified into 3 categories; federal institutions, institutions within the Free Zones and establishments outside the Free Zones. the foremost popular field of study among students in Dubai is Business (42% of students), followed by Society, Law and religion (19%).')
SET IDENTITY_INSERT [dbo].[Venue] OFF
SET IDENTITY_INSERT [dbo].[Conference] ON 

INSERT [dbo].[Conference] ([Id], [Name], [Description], [ShortDescription], [Active], [FK_VenueId], [startDt], [endDt], [brochure], [SpeakerList], [shortImageUrl]) VALUES (8, N'Global summit on Nursing and medical devices expo                       ', N'The aim of nanotechnology 2018 is to present the newest analysis and results of scientists associated with nanotechnology topics. This conference provides opportunities for delegates/speakers to exchange new concepts and application experiences face to face, to ascertain business or research relations as well on realize world partners for future collaboration and with a target to support young personalities and their analysis talents by giving an opportunity to fulfil the specialists within the field of nanotechnology. We tend to hope that the conference results constituted vital contribution to the knowledge in these up-to-date scientific fields. Nanotechnology 2018 is a vital platform for uplifting international and knowledge base exchange at the forefront of technology needs. The conference covers all frontier topics in nanotechnology and includes comprehensive lectures and invited talks by eminent personalities from around the world in addition to contributed papers each oral and poster presentations. Nanotechnology Dubai 2018 conference organizing committee is looking forward to welcoming you in Dubai. ', N'Theme: Emerging New Innovation in the field of Nano.', 0, 2, CAST(N'1901-01-08T00:00:00.000' AS DateTime), CAST(N'1901-01-09T00:00:00.000' AS DateTime), NULL, NULL, N'event2.jpg')
INSERT [dbo].[Conference] ([Id], [Name], [Description], [ShortDescription], [Active], [FK_VenueId], [startDt], [endDt], [brochure], [SpeakerList], [shortImageUrl]) VALUES (9, N'Global Summit on Otolaryngology & Rhinology                    ', N'Otolaryngology is a combined study of Otology and Rhinology or Ear, Nose and Throat. The Otolaryngology diseases can affect some of our most important senses, including hearing, smell and taste. As hearing and speech are important aspects of human development and this conference may offers a comprehensive otolaryngology study and the recent development and research in this area. “Cochlear Implants” & “Endoscopic sinus surgery” are the biggest recent development enabling deaf to gain sense of hearing and the surgery for Sino-nasal problems. Otolaryngology Conference provides the excellent opportunity to meet experts, exchange information, and strengthen the collaboration among Researchers from both academia and industry. Otolaryngology is an event designed in a way to provide an exclusive platform for new researchers, scholars, physicians, ENT surgeons, students and educators to present and discuss the most recent innovations, trends, and concerns, practical challenges encountered and the solutions adopted in the concerned field. ', NULL, 0, 2, CAST(N'2017-02-02T15:28:04.300' AS DateTime), CAST(N'2017-02-07T15:28:04.300' AS DateTime), NULL, NULL, N'event2.jpg')
INSERT [dbo].[Conference] ([Id], [Name], [Description], [ShortDescription], [Active], [FK_VenueId], [startDt], [endDt], [brochure], [SpeakerList], [shortImageUrl]) VALUES (10, N'Global Congress and Expo on Vaccine and Vaccination Techniques ', N'Vaccine congress gathers diverse disciplines involved in the research and development of vaccines and associated technologies for disease control through immunization.  This global platform brings experts, Scientists, research scholars, academic and industry professionals to explore their work and enhance their skills for the improvement of our Scientific Community. Cognizance Scientific also provides an international exposure for young researchers and scholars through their research work by meeting expertise within the field of vaccines and enhancing their knowledge.   The Conference comprises with symposium, workshops, Exhibitions, Young research forum, Poster sessions, renowned speakers and eminent keynote presentations.      The global vaccines market is expected to grasp USD 48.03 Billion by 2021 from USD 32.24 Billion in 2017 at a CAGR of 8.3% from 2017 to 2021.  The major factor driving the growth of this market are high prevalence of diseases, rising government and nongovernment funding for vaccine development, increasing investments by companies, and increasing focus on immunization programs. ', N'Vaccines research and Advance approach towards vaccination techniques for global cause Safety', 0, 2, CAST(N'2017-02-02T15:30:54.350' AS DateTime), CAST(N'2017-02-07T15:30:54.350' AS DateTime), NULL, NULL, N'event2.jpg')
INSERT [dbo].[Conference] ([Id], [Name], [Description], [ShortDescription], [Active], [FK_VenueId], [startDt], [endDt], [brochure], [SpeakerList], [shortImageUrl]) VALUES (11, N'International Congress and Expo on Nanotechnology               ', N'The aim of nanotechnology 2018 is to present the newest analysis and results of scientists associated with nanotechnology topics. This conference provides opportunities for delegates/speakers to exchange new concepts and application experiences face to face, to ascertain business or research relations as well on realize world partners for future collaboration and with a target to support young personalities and their analysis talents by giving an opportunity to fulfil the specialists within the field of nanotechnology. We tend to hope that the conference results constituted vital contribution to the knowledge in these up-to-date scientific fields. Nanotechnology 2018 is a vital platform for uplifting international and knowledge base exchange at the forefront of technology needs. The conference covers all frontier topics in nanotechnology and includes comprehensive lectures and invited talks by eminent personalities from around the world in addition to contributed papers each oral and poster presentations. Nanotechnology Dubai 2018 conference organizing committee is looking forward to welcoming you in Dubai.  Nanotechnology applications are outlined comprehensively because the creation and use of materials, devices and systems through the manipulation of matter at scales of less than a hundred nanometres. The study covers nanomaterials (nanoparticles, nanotubes, nanostructured materials and nanocomposites), Nano tools (nanolithography tools and scanning probe microscopes) and Nano devices (Nano sensors and Nano electronics). A pragmatic decision was created to exclude certain types of materials and devices from the report that technically works the definition of nanotechnology. These exceptions include carbon black nanoparticles used to reinforce tires and different rubber products; photographic silver and dye nanoparticles; and carbon used for water filtration. In the case of pharmaceutical applications, this report measures the worth of the particles that the particle manufacturer receives. research dollars invested with into planning higher particles, or higher delivery approaches, are not enclosed. the worth created through clinical test success and ultimate Food and Drug Administration (FDA) approval and entrance as a prescription medicine don''t seem to be enclosed.  ', N'Emerging New Innovation in the field of Nanotechnology', 0, 2, CAST(N'2017-02-02T15:32:44.250' AS DateTime), CAST(N'2017-02-07T15:32:44.250' AS DateTime), NULL, NULL, N'event2.jpg')
INSERT [dbo].[Conference] ([Id], [Name], [Description], [ShortDescription], [Active], [FK_VenueId], [startDt], [endDt], [brochure], [SpeakerList], [shortImageUrl]) VALUES (12, N'International conference and expo on  separation science and technology', N'Separation science and technology 2018 aims to promote scientific information interchange between academic scientists, research scholars and researchers to share their experiences and research results on all aspects of Separation Science. This conference also provides opportunities for the delegates to exchange new ideas and application experiences face to face, to establish business / research relations, and to find partners for future collaboration. World renowned scientists will address key developments and applications, productivity and financial challenges, and novel approaches related to separation science and analysis focusing on the latest innovations in technologies. . The scientific program will offer plenary lectures, submitted oral presentations and poster sessions. Outside the session lecture theatres, you will also find numerous exhibitors presenting their contributions. All honorable authors are kindly encouraged to contribute to and help shape the conference through submissions of their research abstracts, papers and e-posters', N'Current Advance in Separation Science and Technology', 0, 2, CAST(N'2017-02-02T15:34:13.453' AS DateTime), CAST(N'2017-02-07T15:34:13.453' AS DateTime), NULL, NULL, N'event2.jpg')
SET IDENTITY_INSERT [dbo].[Conference] OFF
SET IDENTITY_INSERT [dbo].[AccommodationPricing] ON 

INSERT [dbo].[AccommodationPricing] ([Id], [FK_ConferenceId], [FK_AccomodationTypeId], [FK_OccupancyId], [Amout]) VALUES (1, 8, 1, 1, 360)
INSERT [dbo].[AccommodationPricing] ([Id], [FK_ConferenceId], [FK_AccomodationTypeId], [FK_OccupancyId], [Amout]) VALUES (2, 8, 1, 2, 400)
INSERT [dbo].[AccommodationPricing] ([Id], [FK_ConferenceId], [FK_AccomodationTypeId], [FK_OccupancyId], [Amout]) VALUES (3, 8, 1, 3, 440)
INSERT [dbo].[AccommodationPricing] ([Id], [FK_ConferenceId], [FK_AccomodationTypeId], [FK_OccupancyId], [Amout]) VALUES (4, 8, 3, 1, 540)
INSERT [dbo].[AccommodationPricing] ([Id], [FK_ConferenceId], [FK_AccomodationTypeId], [FK_OccupancyId], [Amout]) VALUES (5, 8, 3, 2, 600)
INSERT [dbo].[AccommodationPricing] ([Id], [FK_ConferenceId], [FK_AccomodationTypeId], [FK_OccupancyId], [Amout]) VALUES (6, 8, 3, 3, 660)
INSERT [dbo].[AccommodationPricing] ([Id], [FK_ConferenceId], [FK_AccomodationTypeId], [FK_OccupancyId], [Amout]) VALUES (7, 8, 2, 1, 720)
INSERT [dbo].[AccommodationPricing] ([Id], [FK_ConferenceId], [FK_AccomodationTypeId], [FK_OccupancyId], [Amout]) VALUES (8, 8, 2, 2, 800)
INSERT [dbo].[AccommodationPricing] ([Id], [FK_ConferenceId], [FK_AccomodationTypeId], [FK_OccupancyId], [Amout]) VALUES (9, 8, 2, 3, 880)
SET IDENTITY_INSERT [dbo].[AccommodationPricing] OFF
SET IDENTITY_INSERT [dbo].[MST_Accompany] ON 

INSERT [dbo].[MST_Accompany] ([Id], [Name], [Value], [isActive]) VALUES (1, N'One', 1, 1)
INSERT [dbo].[MST_Accompany] ([Id], [Name], [Value], [isActive]) VALUES (2, N'Two', 2, 1)
INSERT [dbo].[MST_Accompany] ([Id], [Name], [Value], [isActive]) VALUES (3, N'Three', 3, 1)
INSERT [dbo].[MST_Accompany] ([Id], [Name], [Value], [isActive]) VALUES (4, N'Four', 4, 1)
SET IDENTITY_INSERT [dbo].[MST_Accompany] OFF
SET IDENTITY_INSERT [dbo].[AccompanyPricing] ON 

INSERT [dbo].[AccompanyPricing] ([Id], [FK_conferenceId], [FK_AccompanyId], [Amount]) VALUES (1, 8, 1, 200)
INSERT [dbo].[AccompanyPricing] ([Id], [FK_conferenceId], [FK_AccompanyId], [Amount]) VALUES (2, 8, 2, 300)
INSERT [dbo].[AccompanyPricing] ([Id], [FK_conferenceId], [FK_AccompanyId], [Amount]) VALUES (4, 8, 3, 400)
SET IDENTITY_INSERT [dbo].[AccompanyPricing] OFF
SET IDENTITY_INSERT [dbo].[MST_RegistrationClass] ON 

INSERT [dbo].[MST_RegistrationClass] ([Id], [Name], [IsActive]) VALUES (1, N'Academia', 1)
INSERT [dbo].[MST_RegistrationClass] ([Id], [Name], [IsActive]) VALUES (2, N'Business', 1)
SET IDENTITY_INSERT [dbo].[MST_RegistrationClass] OFF
SET IDENTITY_INSERT [dbo].[MST_RegistrationType] ON 

INSERT [dbo].[MST_RegistrationType] ([Id], [Name], [IsActive]) VALUES (1, N'Speaker Registration', 1)
INSERT [dbo].[MST_RegistrationType] ([Id], [Name], [IsActive]) VALUES (2, N'Poster Registration', 1)
INSERT [dbo].[MST_RegistrationType] ([Id], [Name], [IsActive]) VALUES (3, N'Delegate Registration', 1)
INSERT [dbo].[MST_RegistrationType] ([Id], [Name], [IsActive]) VALUES (4, N'Student Delegate', 1)
INSERT [dbo].[MST_RegistrationType] ([Id], [Name], [IsActive]) VALUES (5, N'Accompanying Person', 0)
SET IDENTITY_INSERT [dbo].[MST_RegistrationType] OFF
SET IDENTITY_INSERT [dbo].[Pricing] ON 

INSERT [dbo].[Pricing] ([Id], [FK_ConferenceId], [FK_RegType], [FK_RegClass], [Amout]) VALUES (1, 8, 1, 1, 699)
INSERT [dbo].[Pricing] ([Id], [FK_ConferenceId], [FK_RegType], [FK_RegClass], [Amout]) VALUES (2, 8, 1, 2, 799)
INSERT [dbo].[Pricing] ([Id], [FK_ConferenceId], [FK_RegType], [FK_RegClass], [Amout]) VALUES (3, 8, 2, 1, 399)
INSERT [dbo].[Pricing] ([Id], [FK_ConferenceId], [FK_RegType], [FK_RegClass], [Amout]) VALUES (4, 8, 2, 2, 499)
INSERT [dbo].[Pricing] ([Id], [FK_ConferenceId], [FK_RegType], [FK_RegClass], [Amout]) VALUES (5, 8, 3, 1, 599)
INSERT [dbo].[Pricing] ([Id], [FK_ConferenceId], [FK_RegType], [FK_RegClass], [Amout]) VALUES (6, 8, 3, 2, 699)
INSERT [dbo].[Pricing] ([Id], [FK_ConferenceId], [FK_RegType], [FK_RegClass], [Amout]) VALUES (7, 8, 4, 1, 299)
INSERT [dbo].[Pricing] ([Id], [FK_ConferenceId], [FK_RegType], [FK_RegClass], [Amout]) VALUES (8, 8, 4, 2, 299)
SET IDENTITY_INSERT [dbo].[Pricing] OFF
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([Id], [Name]) VALUES (1, N'Speaking')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (2, N'Poster Presentation')
SET IDENTITY_INSERT [dbo].[Category] OFF
SET IDENTITY_INSERT [dbo].[Country] ON 

INSERT [dbo].[Country] ([Id], [Name]) VALUES (1, N'India')
INSERT [dbo].[Country] ([Id], [Name]) VALUES (2, N'Pakistan')
INSERT [dbo].[Country] ([Id], [Name]) VALUES (3, N'Argentina')
SET IDENTITY_INSERT [dbo].[Country] OFF
SET IDENTITY_INSERT [dbo].[Title] ON 

INSERT [dbo].[Title] ([Id], [Name]) VALUES (1, N'Mr.')
INSERT [dbo].[Title] ([Id], [Name]) VALUES (2, N'Dr.')
INSERT [dbo].[Title] ([Id], [Name]) VALUES (3, N'Mrs.')
SET IDENTITY_INSERT [dbo].[Title] OFF
SET IDENTITY_INSERT [dbo].[Track] ON 

INSERT [dbo].[Track] ([Id], [Name], [Description], [FK_ConferenceId]) VALUES (2, N'Nanoscience and Technology', NULL, 8)
INSERT [dbo].[Track] ([Id], [Name], [Description], [FK_ConferenceId]) VALUES (3, N'Nano Medicine', NULL, 8)
INSERT [dbo].[Track] ([Id], [Name], [Description], [FK_ConferenceId]) VALUES (4, N'Adult Health Nursing', NULL, 8)
INSERT [dbo].[Track] ([Id], [Name], [Description], [FK_ConferenceId]) VALUES (5, N'Critical Care Nursing & Emergency Nursing', NULL, 8)
INSERT [dbo].[Track] ([Id], [Name], [Description], [FK_ConferenceId]) VALUES (6, N'Cardiac Nursing', NULL, 8)
INSERT [dbo].[Track] ([Id], [Name], [Description], [FK_ConferenceId]) VALUES (7, N'Clinical Nursing', NULL, 8)
INSERT [dbo].[Track] ([Id], [Name], [Description], [FK_ConferenceId]) VALUES (8, N'Dental Nursing', NULL, 8)
INSERT [dbo].[Track] ([Id], [Name], [Description], [FK_ConferenceId]) VALUES (9, N'Environmental Health Nursing', NULL, 8)
INSERT [dbo].[Track] ([Id], [Name], [Description], [FK_ConferenceId]) VALUES (10, N'Legal Nursing', NULL, 8)
INSERT [dbo].[Track] ([Id], [Name], [Description], [FK_ConferenceId]) VALUES (11, N'Nursing Education and Research', NULL, 8)
INSERT [dbo].[Track] ([Id], [Name], [Description], [FK_ConferenceId]) VALUES (12, N'Types of Nursing', NULL, 8)
INSERT [dbo].[Track] ([Id], [Name], [Description], [FK_ConferenceId]) VALUES (13, N'Women Health Nursing', NULL, 8)
INSERT [dbo].[Track] ([Id], [Name], [Description], [FK_ConferenceId]) VALUES (14, N'Psychiatric and Mental Health Nursing', NULL, 8)
INSERT [dbo].[Track] ([Id], [Name], [Description], [FK_ConferenceId]) VALUES (15, N'Public Health', NULL, 8)
INSERT [dbo].[Track] ([Id], [Name], [Description], [FK_ConferenceId]) VALUES (16, N'Anatomy and Physiology of Ear, Nose, and Throat', NULL, 9)
INSERT [dbo].[Track] ([Id], [Name], [Description], [FK_ConferenceId]) VALUES (17, N'Innovation and Research in Otolaryngology ', NULL, 9)
INSERT [dbo].[Track] ([Id], [Name], [Description], [FK_ConferenceId]) VALUES (18, N'Rhinology and Otology', NULL, 9)
INSERT [dbo].[Track] ([Id], [Name], [Description], [FK_ConferenceId]) VALUES (19, N'Laryngology', NULL, 9)
INSERT [dbo].[Track] ([Id], [Name], [Description], [FK_ConferenceId]) VALUES (20, N'Surgery Approaches for Ear, Nose and Throat', NULL, 9)
INSERT [dbo].[Track] ([Id], [Name], [Description], [FK_ConferenceId]) VALUES (21, N'Head and Neck Surgery', NULL, 9)
INSERT [dbo].[Track] ([Id], [Name], [Description], [FK_ConferenceId]) VALUES (22, N'Sino nasal Disorders and Surgical Treatment', NULL, 9)
INSERT [dbo].[Track] ([Id], [Name], [Description], [FK_ConferenceId]) VALUES (23, N'Facial Plastic and Reconstructive Surgery', NULL, 9)
INSERT [dbo].[Track] ([Id], [Name], [Description], [FK_ConferenceId]) VALUES (24, N'Pediatric Otolaryngology', NULL, 9)
INSERT [dbo].[Track] ([Id], [Name], [Description], [FK_ConferenceId]) VALUES (25, N'Phoniatry and Obstructive sleep apnea', NULL, 9)
INSERT [dbo].[Track] ([Id], [Name], [Description], [FK_ConferenceId]) VALUES (26, N'Cancer Vaccine', NULL, 10)
INSERT [dbo].[Track] ([Id], [Name], [Description], [FK_ConferenceId]) VALUES (27, N'Vaccine Research and Development', NULL, 10)
INSERT [dbo].[Track] ([Id], [Name], [Description], [FK_ConferenceId]) VALUES (28, N'Advance in Vaccine and Vaccination', NULL, 10)
INSERT [dbo].[Track] ([Id], [Name], [Description], [FK_ConferenceId]) VALUES (29, N'Treatment methods in Vaccines', NULL, 10)
INSERT [dbo].[Track] ([Id], [Name], [Description], [FK_ConferenceId]) VALUES (30, N'DNA Vaccine ', NULL, 10)
INSERT [dbo].[Track] ([Id], [Name], [Description], [FK_ConferenceId]) VALUES (31, N'Immunization and Infectious Diseases', NULL, 10)
INSERT [dbo].[Track] ([Id], [Name], [Description], [FK_ConferenceId]) VALUES (32, N'Human Vaccines', NULL, 10)
INSERT [dbo].[Track] ([Id], [Name], [Description], [FK_ConferenceId]) VALUES (33, N'Vaccine Safety and Efficacy ', NULL, 10)
INSERT [dbo].[Track] ([Id], [Name], [Description], [FK_ConferenceId]) VALUES (34, N'Future Growth of Vaccine and Vaccination', NULL, 10)
INSERT [dbo].[Track] ([Id], [Name], [Description], [FK_ConferenceId]) VALUES (35, N'Pediatric Vaccine ', NULL, 10)
INSERT [dbo].[Track] ([Id], [Name], [Description], [FK_ConferenceId]) VALUES (36, N'Geriatric Vaccine', NULL, 10)
INSERT [dbo].[Track] ([Id], [Name], [Description], [FK_ConferenceId]) VALUES (37, N'Veterinary Vaccine', NULL, 10)
INSERT [dbo].[Track] ([Id], [Name], [Description], [FK_ConferenceId]) VALUES (38, N'Disease Prevention, Control and Therapeutic Vaccines ', NULL, 10)
INSERT [dbo].[Track] ([Id], [Name], [Description], [FK_ConferenceId]) VALUES (39, N'Disease Prevention, Control and Therapeutic Vaccines ', NULL, 11)
INSERT [dbo].[Track] ([Id], [Name], [Description], [FK_ConferenceId]) VALUES (40, N'Nanoscience and Technology', NULL, 11)
INSERT [dbo].[Track] ([Id], [Name], [Description], [FK_ConferenceId]) VALUES (41, N'Nano Medicine', NULL, 11)
INSERT [dbo].[Track] ([Id], [Name], [Description], [FK_ConferenceId]) VALUES (42, N'Nano Electronics', NULL, 11)
INSERT [dbo].[Track] ([Id], [Name], [Description], [FK_ConferenceId]) VALUES (43, N'Molecular Nanotechnology', NULL, 11)
INSERT [dbo].[Track] ([Id], [Name], [Description], [FK_ConferenceId]) VALUES (44, N'Nano Toxicology', NULL, 11)
INSERT [dbo].[Track] ([Id], [Name], [Description], [FK_ConferenceId]) VALUES (45, N'Nano Topography', NULL, 11)
INSERT [dbo].[Track] ([Id], [Name], [Description], [FK_ConferenceId]) VALUES (46, N'Nano Fluidics', NULL, 11)
INSERT [dbo].[Track] ([Id], [Name], [Description], [FK_ConferenceId]) VALUES (47, N'Nano Weapons', NULL, 11)
INSERT [dbo].[Track] ([Id], [Name], [Description], [FK_ConferenceId]) VALUES (48, N'Nano Biotechnology', NULL, 11)
INSERT [dbo].[Track] ([Id], [Name], [Description], [FK_ConferenceId]) VALUES (49, N'Nanotechnology in Water treatment', NULL, 11)
INSERT [dbo].[Track] ([Id], [Name], [Description], [FK_ConferenceId]) VALUES (50, N'Nano Composites', NULL, 11)
INSERT [dbo].[Track] ([Id], [Name], [Description], [FK_ConferenceId]) VALUES (51, N'Nanoscale', NULL, 11)
INSERT [dbo].[Track] ([Id], [Name], [Description], [FK_ConferenceId]) VALUES (52, N'Advanced Nanomaterials', NULL, 11)
INSERT [dbo].[Track] ([Id], [Name], [Description], [FK_ConferenceId]) VALUES (53, N'Membrane science and TechnologyNanomaterials', NULL, 12)
INSERT [dbo].[Track] ([Id], [Name], [Description], [FK_ConferenceId]) VALUES (54, N'Solvent extraction', NULL, 12)
INSERT [dbo].[Track] ([Id], [Name], [Description], [FK_ConferenceId]) VALUES (55, N'Solid phase extraction', NULL, 12)
INSERT [dbo].[Track] ([Id], [Name], [Description], [FK_ConferenceId]) VALUES (56, N'Solid phase extraction', NULL, 12)
INSERT [dbo].[Track] ([Id], [Name], [Description], [FK_ConferenceId]) VALUES (57, N'Absorption and Adsorption Technology', NULL, 12)
INSERT [dbo].[Track] ([Id], [Name], [Description], [FK_ConferenceId]) VALUES (58, N'Solid phase extraction', NULL, 12)
INSERT [dbo].[Track] ([Id], [Name], [Description], [FK_ConferenceId]) VALUES (59, N'Chromatography', NULL, 12)
INSERT [dbo].[Track] ([Id], [Name], [Description], [FK_ConferenceId]) VALUES (60, N'Advances in chromatographic instrumentation', NULL, 12)
INSERT [dbo].[Track] ([Id], [Name], [Description], [FK_ConferenceId]) VALUES (61, N'New stationary phases for GC and HPLC', NULL, 12)
INSERT [dbo].[Track] ([Id], [Name], [Description], [FK_ConferenceId]) VALUES (62, N'Hyphenated techniques', NULL, 12)
INSERT [dbo].[Track] ([Id], [Name], [Description], [FK_ConferenceId]) VALUES (63, N'Sample preparation techniques', NULL, 12)
INSERT [dbo].[Track] ([Id], [Name], [Description], [FK_ConferenceId]) VALUES (64, N'Phases equilibria', NULL, 12)
SET IDENTITY_INSERT [dbo].[Track] OFF
SET IDENTITY_INSERT [dbo].[AbstractsSubmitted] ON 

INSERT [dbo].[AbstractsSubmitted] ([Id], [SubmittedBy], [EmailId], [Telephone], [Organisation], [FK_CategoryId], [FK_TrackID], [DocName], [FK_TitleId], [FK_ContryId], [FK_ConferenceId]) VALUES (1, N'sai rudhra', N'saikrishnarudhra@gmail.com', NULL, N'MGHS', 1, 3, N'11922bbd-ade0-490a-8c7c-c0827a190577_configuration Mail ID.docx', 1, 1, 8)
SET IDENTITY_INSERT [dbo].[AbstractsSubmitted] OFF
SET IDENTITY_INSERT [dbo].[Program] ON 

INSERT [dbo].[Program] ([Id], [Name], [Info], [Title], [ImageUrl], [Abstract], [FK_ConferenceId], [ProgramDt]) VALUES (1, N'tstconf', N't1_info', N'asd', NULL, NULL, 8, CAST(N'2017-02-06T00:21:11.497' AS DateTime))
SET IDENTITY_INSERT [dbo].[Program] OFF
SET IDENTITY_INSERT [dbo].[ConferenceTeam] ON 

INSERT [dbo].[ConferenceTeam] ([Id], [FK_ConferenceId], [Name], [Info], [Chair], [Biography], [ImageUrl]) VALUES (3, 8, N'asd', N'asd', 0, N'asd', N'9ee8c9f2-e163-4b18-99b1-417f49a2dc94_left side.jpeg')
SET IDENTITY_INSERT [dbo].[ConferenceTeam] OFF
SET IDENTITY_INSERT [dbo].[ConferenceImages] ON 

INSERT [dbo].[ConferenceImages] ([Id], [FK_ConferenceId], [ImageUrl], [Active]) VALUES (5, 8, N'c6334584-4b3f-49d7-afd7-e669675d5dd2_7.jpg', 0)
INSERT [dbo].[ConferenceImages] ([Id], [FK_ConferenceId], [ImageUrl], [Active]) VALUES (6, 8, N'a519c5bc-cd49-4b74-aa1b-f8f6270ed205_7.jpg', 0)
INSERT [dbo].[ConferenceImages] ([Id], [FK_ConferenceId], [ImageUrl], [Active]) VALUES (7, 8, N'2e43db53-b4b8-48d3-a35a-01173dde4b12_Cosmetics-Europe-week-to-focus-on-delivering-innovation-and-growth.jpg', 0)
INSERT [dbo].[ConferenceImages] ([Id], [FK_ConferenceId], [ImageUrl], [Active]) VALUES (8, 8, N'9f5619ab-041b-4342-90d3-d1987023a597_gc-nursing-awards.jpg', 0)
INSERT [dbo].[ConferenceImages] ([Id], [FK_ConferenceId], [ImageUrl], [Active]) VALUES (9, 8, N'c9591074-f8f6-45b1-ba44-a8e56af357ba_gc-nursing-awards.jpg', 0)
INSERT [dbo].[ConferenceImages] ([Id], [FK_ConferenceId], [ImageUrl], [Active]) VALUES (10, 8, N'485bb055-8595-4109-bc07-a023842b5638_Nurse_with_child_wardsns.com_.jpg', 0)
INSERT [dbo].[ConferenceImages] ([Id], [FK_ConferenceId], [ImageUrl], [Active]) VALUES (11, 8, N'72220e5a-fc20-4aba-839b-a73b8522fd5a_Nursing-Program.jpg', 0)
INSERT [dbo].[ConferenceImages] ([Id], [FK_ConferenceId], [ImageUrl], [Active]) VALUES (12, 9, N'62dea002-1d8b-424e-9a74-93306e88c0a8_1.jpg', 0)
INSERT [dbo].[ConferenceImages] ([Id], [FK_ConferenceId], [ImageUrl], [Active]) VALUES (13, 9, N'35662744-663b-4934-a17a-873e7377d03d_5.jpg', 0)
INSERT [dbo].[ConferenceImages] ([Id], [FK_ConferenceId], [ImageUrl], [Active]) VALUES (14, 9, N'7822097e-e865-4af2-afa7-b936e0b6629c_6.jpg', 0)
INSERT [dbo].[ConferenceImages] ([Id], [FK_ConferenceId], [ImageUrl], [Active]) VALUES (15, 9, N'59679965-d6e1-434f-8756-7a1cd4f89d54_7.jpg', 0)
INSERT [dbo].[ConferenceImages] ([Id], [FK_ConferenceId], [ImageUrl], [Active]) VALUES (16, 10, N'686c4326-0226-4fcf-802b-94a982c54121_6.jpg', 0)
INSERT [dbo].[ConferenceImages] ([Id], [FK_ConferenceId], [ImageUrl], [Active]) VALUES (17, 10, N'a59e881a-ad93-4949-b3fb-0f622044e24f_8.jpg', 0)
INSERT [dbo].[ConferenceImages] ([Id], [FK_ConferenceId], [ImageUrl], [Active]) VALUES (18, 10, N'b3e3b8be-59f4-4e79-afe7-24083f8f5a6c_4.jpg', 0)
INSERT [dbo].[ConferenceImages] ([Id], [FK_ConferenceId], [ImageUrl], [Active]) VALUES (19, 11, N'1e004833-5994-4627-9cc0-f6660f837209_7.jpg', 0)
INSERT [dbo].[ConferenceImages] ([Id], [FK_ConferenceId], [ImageUrl], [Active]) VALUES (20, 11, N'80df66b4-9477-44f3-8079-6ae82cdce852_Cosmetics-Europe-week-to-focus-on-delivering-innovation-and-growth.jpg', 0)
INSERT [dbo].[ConferenceImages] ([Id], [FK_ConferenceId], [ImageUrl], [Active]) VALUES (21, 12, N'a3c758b5-888d-460d-8a90-35cf169924da_2.jpg', 0)
SET IDENTITY_INSERT [dbo].[ConferenceImages] OFF
