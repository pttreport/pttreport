USE [PTT-AssetMaintenanceDARR_Test]
GO

/****** Object: Table [dbo].[tblsoil_erosion] Script Date: 6/10/2017 11:10:21 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[pironsu_icra] (
    [id]             BIGINT        IDENTITY (1, 1) NOT NULL,
    [pir_id] 		VARCHAR (50)  NULL,
    [sumresult]             VARCHAR (MAX) NULL,
    [watercontentmonitor]             VARCHAR (MAX) NULL,
    [dewpointupset]             VARCHAR (MAX) NULL,
	[co2dontent]             VARCHAR (MAX) NULL,
	[h2scontent]             VARCHAR (MAX) NULL,
	[detail]             VARCHAR (MAX) NULL,
	[opinion]             VARCHAR (MAX) NULL
);


