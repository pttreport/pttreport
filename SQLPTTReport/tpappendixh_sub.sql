USE [PTT-AssetMaintenanceDARR_Test]
GO

/****** Object: Table [dbo].[tblsoil_erosion] Script Date: 6/10/2017 11:10:21 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tpappendixh_sub] (
    [id]             BIGINT        IDENTITY (1, 1) NOT NULL,
    [appendixd_id] 	VARCHAR (50)  NULL,
    [routecode]             VARCHAR (MAX) NULL,
	[secondhalfyear]             VARCHAR (MAX) NULL,
	[firsthalfyear]             VARCHAR (MAX) NULL
);

