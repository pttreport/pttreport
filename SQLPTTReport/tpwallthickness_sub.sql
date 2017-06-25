USE [PTT-AssetMaintenanceDARR_Test]
GO

/****** Object: Table [dbo].[tblsoil_erosion] Script Date: 6/10/2017 11:10:21 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tpwallthickness_sub] (
    [id]             BIGINT        IDENTITY (1, 1) NOT NULL,
    [wtn_id] 	VARCHAR (50)  NULL,
    [bvstation]             VARCHAR (MAX) NULL,
	[routecode]             VARCHAR (MAX) NULL,
	[inspectiondate]             VARCHAR (MAX) NULL,
	[point]             VARCHAR (MAX) NULL,
	[diameter]             VARCHAR (MAX) NULL,
	[tavg]             VARCHAR (MAX) NULL,
	[tmin]             VARCHAR (MAX) NULL
);


