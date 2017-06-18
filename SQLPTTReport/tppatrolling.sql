USE [PTT-AssetMaintenanceDARR_Test]
GO

/****** Object: Table [dbo].[tblsoil_erosion] Script Date: 6/10/2017 11:10:21 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tppatrolling] (
    [id]             BIGINT        IDENTITY (1, 1) NOT NULL,
    [tp_rep_id] VARCHAR (50)  NULL,
    [gasdetector]             VARCHAR (MAX) NULL,
	[gassiteamount]             VARCHAR (MAX) NULL,
	[gassitedetail]             VARCHAR (MAX) NULL,
	
	    [labelandstealamount]             VARCHAR (MAX) NULL,
	[labelandstealdetail]             VARCHAR (MAX) NULL,
	
	[testpostdamageamount]             VARCHAR (MAX) NULL,
	    [testpostdamagedetail]             VARCHAR (MAX) NULL,
		
	[scourareaamount]             VARCHAR (MAX) NULL,
	[scourareadetail]             VARCHAR (MAX) NULL,
	
	    [buildingpipepathamount]             VARCHAR (MAX) NULL,
	[buildingpipepathdetail]             VARCHAR (MAX) NULL,
	
		    [rovfreespanamount]             VARCHAR (MAX) NULL,
	[rovfreespandetail]             VARCHAR (MAX) NULL,
	
	
    [opinion]            VARCHAR (MAX) NULL
);


