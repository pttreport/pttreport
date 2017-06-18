USE [PTT-AssetMaintenanceDARR_Test]
GO

/****** Object: Table [dbo].[tblsoil_erosion] Script Date: 6/10/2017 11:10:21 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[pironsp_ecra] (
    [id]             BIGINT        IDENTITY (1, 1) NOT NULL,
    [pir_id] 		VARCHAR (50)  NULL,
    [sumresult]             VARCHAR (MAX) NULL,
    [cp]             VARCHAR (MAX) NULL,
	[nscp]             VARCHAR (MAX) NULL,
    [cds]             VARCHAR (MAX) NULL,
	[ac]             VARCHAR (MAX) NULL,
	[ecdmp]             VARCHAR (MAX) NULL,
	[ecrp]             VARCHAR (MAX) NULL,
	[detail]             VARCHAR (MAX) NULL,
    [opinion]            VARCHAR (MAX) NULL
);


