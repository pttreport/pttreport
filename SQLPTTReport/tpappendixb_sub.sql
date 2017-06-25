USE [PTT-AssetMaintenanceDARR_Test]
GO

/****** Object: Table [dbo].[tblsoil_erosion] Script Date: 6/10/2017 11:10:21 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tpappendixb_sub] (
    [id]             BIGINT        IDENTITY (1, 1) NOT NULL,
    [appendixb_id] 	VARCHAR (50)  NULL,
    [routecode]             VARCHAR (MAX) NULL,
	[buildingwork]             VARCHAR (MAX) NULL,
	[scour]             VARCHAR (MAX) NULL,
	[label]             VARCHAR (MAX) NULL,
	[testpost]             VARCHAR (MAX) NULL,
	[trespass]             VARCHAR (MAX) NULL,
	[gasleak]             VARCHAR (MAX) NULL,
	[abnormal]             VARCHAR (MAX) NULL
);


