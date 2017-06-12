USE [PTT-AssetMaintenanceDARR_Test]
GO

/****** Object: Table [dbo].[tblsoil_erosion] Script Date: 6/10/2017 11:10:21 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblcleaning_pig] (
    [id]             BIGINT        IDENTITY (1, 1) NOT NULL,
    [quarter_rep_id] VARCHAR (50)  NULL,
    [planwork]             VARCHAR (MAX) NULL,
	[pwroutecode]             VARCHAR (MAX) NULL,
	[pwdimeter]             VARCHAR (MAX) NULL,
	[pwpipelinesection]             VARCHAR (MAX) NULL,
	[pwnumberpig]             VARCHAR (MAX) NULL,
    [pwplaning]             VARCHAR (MAX) NULL,
    [workingresult]             VARCHAR (MAX) NULL,
	[notethat]             VARCHAR (MAX) NULL,
	[froutecode]             VARCHAR (MAX) NULL,
	[fdimeter]             VARCHAR (MAX) NULL,
	[fpipelinesection]             VARCHAR (MAX) NULL,
	[fnumberpig]             VARCHAR (MAX) NULL,
	[fplaning]             VARCHAR (MAX) NULL,
	[problem]             VARCHAR (MAX) NULL,
    [opinion]            VARCHAR (MAX) NULL
);


