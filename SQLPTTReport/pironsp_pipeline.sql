USE [PTT-AssetMaintenanceDARR_Test]
GO

/****** Object: Table [dbo].[tblsoil_erosion] Script Date: 6/10/2017 11:10:21 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[pironsp_pipeline] (
    [id]             BIGINT        IDENTITY (1, 1) NOT NULL,
    [pir_id] 		VARCHAR (50)  NULL,
    [startupyear]             VARCHAR (MAX) NULL,
    [designpresure]             VARCHAR (MAX) NULL,
    [station]             VARCHAR (MAX) NULL,
	[maop]             VARCHAR (MAX) NULL,
	[length]             VARCHAR (MAX) NULL,
	[maopdesign]             VARCHAR (MAX) NULL,
	[wallthickness]             VARCHAR (MAX) NULL,
	[olc]             VARCHAR (MAX) NULL,
	[materialspec]             VARCHAR (MAX) NULL,
	[designlife]             VARCHAR (MAX) NULL,
	[externalcoating]             VARCHAR (MAX) NULL,
	[cathodicprotection]             VARCHAR (MAX) NULL,
	[op]             VARCHAR (MAX) NULL,
	[ot]             VARCHAR (MAX) NULL,
	[gfr]             VARCHAR (MAX) NULL,
	[lastilipig]             VARCHAR (MAX) NULL,
    [crusedforrem]             VARCHAR (MAX) NULL,
    [proboffailure]             VARCHAR (MAX) NULL,
	[assessmentdate]             VARCHAR (MAX) NULL,
	[overallremainlife]             VARCHAR (MAX) NULL,
	[remainlife]             VARCHAR (MAX) NULL,
	[overalldesignlife]             VARCHAR (MAX) NULL,
	[inspectionyear]             VARCHAR (MAX) NULL,
	[b31gpsi]             VARCHAR (MAX) NULL,
	[burstpressure]             VARCHAR (MAX) NULL,
	[erf]             VARCHAR (MAX) NULL,
    [opinion]            VARCHAR (MAX) NULL
);


