USE [PTT-AssetMaintenanceDARR_Test]
GO

/****** Object: Table [dbo].[tblsoil_erosion] Script Date: 6/10/2017 11:10:21 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tpcp] (
    [id]             BIGINT        IDENTITY (1, 1) NOT NULL,
    [tp_rep_id] VARCHAR (50)  NULL,
    [cipsdetail]             VARCHAR (MAX) NULL,
	[cipsopinion]             VARCHAR (MAX) NULL,
	
	    [dcvgdetail]             VARCHAR (MAX) NULL,
	[dcvgopinion]             VARCHAR (MAX) NULL,
	
	    [ptsdetail]             VARCHAR (MAX) NULL,
	[ptsopinion]             VARCHAR (MAX) NULL,
	
	    [rovdetail]             VARCHAR (MAX) NULL,
	[rovopinion]             VARCHAR (MAX) NULL
);


