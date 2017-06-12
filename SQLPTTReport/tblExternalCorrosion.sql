USE [PTT-AssetMaintenanceDARR_Test]
GO

/****** Object: Table [dbo].[tblsoil_erosion] Script Date: 6/10/2017 11:10:21 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblexternal_corrosion] (
    [id]             BIGINT        IDENTITY (1, 1) NOT NULL,
    [quarter_rep_id] VARCHAR (50)  NULL,
    [workresult]             VARCHAR (MAX) NULL,
    [pspotentialsurvey]             VARCHAR (MAX) NULL,
    [bondboxinspection]             VARCHAR (MAX) NULL,
	[rectifierispection]             VARCHAR (MAX) NULL,
	[insulatingjoint]             VARCHAR (MAX) NULL,
	[ecresultfilename]             VARCHAR (MAX) NULL,
	[ecresultfilepath]             VARCHAR (MAX) NULL,
	[cdresultfilename]             VARCHAR (MAX) NULL,
	[cdresultfilepath]             VARCHAR (MAX) NULL,
	[planworkfuture]             VARCHAR (MAX) NULL,
	[problem]             VARCHAR (MAX) NULL,
    [opinion]            VARCHAR (MAX) NULL
);


