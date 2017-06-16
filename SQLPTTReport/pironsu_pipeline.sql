USE [PTT-AssetMaintenanceDARR_Test]
GO

/****** Object: Table [dbo].[tblsoil_erosion] Script Date: 6/10/2017 11:10:21 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[pironsu_pipeline] (
    [id]             BIGINT        IDENTITY (1, 1) NOT NULL,
    [pir_id] 		VARCHAR (50)  NULL,
    [startupyear]             VARCHAR (MAX) NULL,
    [designpresure]             VARCHAR (MAX) NULL,
    [station]             VARCHAR (MAX) NULL,
	[maop]             VARCHAR (MAX) NULL,
	[length]             VARCHAR (MAX) NULL,
	[wallthickness]             VARCHAR (MAX) NULL,
	[materialspec]             VARCHAR (MAX) NULL,
	[designlife]             VARCHAR (MAX) NULL,
	[externalcoating]             VARCHAR (MAX) NULL,
	[cathodicprotection]             VARCHAR (MAX) NULL,
	[op]             VARCHAR (MAX) NULL,
	[ot]             VARCHAR (MAX) NULL,
	[gfr]             VARCHAR (MAX) NULL,
    [opinion]            VARCHAR (MAX) NULL
);


