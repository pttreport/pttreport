USE [PTT-AssetMaintenanceDARR_Test]
GO

/****** Object: Table [dbo].[tblsoil_erosion] Script Date: 6/10/2017 11:10:21 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[piroffsp_iccs] (
    [id]             BIGINT        IDENTITY (1, 1) NOT NULL,
    [pir_id] 		VARCHAR (50)  NULL,
    [ci]             VARCHAR (MAX) NULL,
    [cicomment]             VARCHAR (MAX) NULL,
	[cc]             VARCHAR (MAX) NULL,
    [cccomment]             VARCHAR (MAX) NULL,
	[cp]             VARCHAR (MAX) NULL,
    [cpcomment]             VARCHAR (MAX) NULL,
    [opinion]            VARCHAR (MAX) NULL
);


