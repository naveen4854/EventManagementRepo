/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
USE [Eventmandb]
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([Id], [Name]) VALUES (1, N'Speaking')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (2, N'Poster Presentation')
SET IDENTITY_INSERT [dbo].[Category] OFF
SET IDENTITY_INSERT [dbo].[Title] ON 

INSERT [dbo].[Title] ([Id], [Name]) VALUES (1, N'Mr.')
INSERT [dbo].[Title] ([Id], [Name]) VALUES (2, N'Dr.')
INSERT [dbo].[Title] ([Id], [Name]) VALUES (3, N'Mrs.')
SET IDENTITY_INSERT [dbo].[Title] OFF
SET IDENTITY_INSERT [dbo].[Country] ON 

INSERT [dbo].[Country] ([Id], [Name]) VALUES (1, N'India')
INSERT [dbo].[Country] ([Id], [Name]) VALUES (2, N'Pakistan')
INSERT [dbo].[Country] ([Id], [Name]) VALUES (3, N'Argentina')
SET IDENTITY_INSERT [dbo].[Country] OFF