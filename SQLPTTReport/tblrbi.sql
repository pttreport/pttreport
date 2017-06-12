USE [PTT-AssetMaintenanceDARR_Test]
GO

/****** Object: Table [dbo].[tblsoil_erosion] Script Date: 6/10/2017 11:10:21 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblrbi] (
    [id]             BIGINT        IDENTITY (1, 1) NOT NULL,
    [quarter_rep_id] VARCHAR (50)  NULL,
	[cplanwork]             VARCHAR (MAX) NULL,
	[cprogressresult]             VARCHAR (MAX) NULL,
	[cfutureplan]             VARCHAR (MAX) NULL,
	[cproblem]             VARCHAR (MAX) NULL,
    [copinion]             VARCHAR (MAX) NULL,
    [mplanwork]             VARCHAR (MAX) NULL,
	[mprogressresult]             VARCHAR (MAX) NULL,
	[mfutureplan]             VARCHAR (MAX) NULL,
	[mproblem]             VARCHAR (MAX) NULL,
	[mopinion]             VARCHAR (MAX) NULL,
);


