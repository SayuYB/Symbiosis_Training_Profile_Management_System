﻿CREATE TABLE [dbo].[LinkedIns] (
    [LinkID]                   INT            IDENTITY (1, 1) NOT NULL,
    [FullName]                 NVARCHAR (MAX) NOT NULL,
    [ProfilePicturePath]       NVARCHAR (MAX) NOT NULL,
    [Email]                    NVARCHAR (MAX) NOT NULL,
    [PhoneNumber]              NVARCHAR (MAX) NOT NULL,
    [Headline]                 NVARCHAR (MAX) NOT NULL,
    [Summary]                  NVARCHAR (MAX) NOT NULL,
    [JobTitle]                 NVARCHAR (MAX) NOT NULL,
    [CompanyName]              NVARCHAR (MAX) NOT NULL,
    [EmploymentStartDate]      DATETIME2 (7)  NULL,
    [EmploymentEndDate]        DATETIME2 (7)  NULL,
    [JobResponsibilities]      NVARCHAR (MAX) NOT NULL,
    [Degree]                   NVARCHAR (MAX) NOT NULL,
    [InstitutionName]          NVARCHAR (MAX) NOT NULL,
    [GraduationDate]           DATETIME2 (7)  NULL,
    [Skills]                   NVARCHAR (MAX) NOT NULL,
    [Certifications]           NVARCHAR (MAX) NOT NULL,
    [Projects]                 NVARCHAR (MAX) NOT NULL,
    [Languages]                NVARCHAR (MAX) NOT NULL,
    [Awards]                   NVARCHAR (MAX) NOT NULL,
    [VolunteerExperience]      NVARCHAR (MAX) NOT NULL,
    [ProfessionalAffiliations] NVARCHAR (MAX) NOT NULL,
    [Interests]                NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_LinkedIns] PRIMARY KEY CLUSTERED ([LinkID] ASC)
);

