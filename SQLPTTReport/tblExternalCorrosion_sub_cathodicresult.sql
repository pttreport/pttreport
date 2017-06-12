USE [PTT-AssetMaintenanceDARR_Test]
GO

/****** Object: Table [dbo].[tblsoil_erosion] Script Date: 6/10/2017 11:10:21 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblexternalcorrosion_sub_cathodicresult] (
    [id]             BIGINT        IDENTITY (1, 1) NOT NULL,
    [ec_id]			VARCHAR (50)  NULL,
    [month]             VARCHAR (MAX) NULL,
    [inspectiontype]             VARCHAR (MAX) NULL,
    [region]             VARCHAR (MAX) NULL,
	[progress]             VARCHAR (MAX) NULL
);