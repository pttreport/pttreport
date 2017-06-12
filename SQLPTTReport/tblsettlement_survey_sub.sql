USE [PTT-AssetMaintenanceDARR_Test]
GO

/****** Object: Table [dbo].[tblsoil_erosion] Script Date: 6/10/2017 11:10:21 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblsettlement_survey_sub] (
    [id]             BIGINT        IDENTITY (1, 1) NOT NULL,
    [ss_id]			VARCHAR (50)  NULL,
    [area]             VARCHAR (MAX) NULL,
    [pipe]             VARCHAR (MAX) NULL,
    [station]             VARCHAR (MAX) NULL,
	[action]             VARCHAR (MAX) NULL,
	[progress]             VARCHAR (MAX) NULL,
    [remark]            VARCHAR (MAX) NULL
);