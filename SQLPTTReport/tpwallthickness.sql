﻿USE [PTT-AssetMaintenanceDARR_Test]
GO

/****** Object: Table [dbo].[tblsoil_erosion] Script Date: 6/10/2017 11:10:21 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tpwallthickness] (
    [id]             BIGINT        IDENTITY (1, 1) NOT NULL,
    [tp_rep_id] 	VARCHAR (50)  NULL,
    [checkresult]             VARCHAR (MAX) NULL,
	[pipe]             VARCHAR (MAX) NULL,
	
	    [station]             VARCHAR (MAX) NULL,
	[pipeposition]             VARCHAR (MAX) NULL,
	
	    [opinion]             VARCHAR (MAX) NULL
);


