USE [PTT-AssetMaintenanceDARR_Test]
GO

/****** Object: Table [dbo].[tblsoil_erosion] Script Date: 6/10/2017 11:10:21 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblexternalcorrosion_sub_cipsstatus] (
    [id]             BIGINT        IDENTITY (1, 1) NOT NULL,
    [ec_id]			VARCHAR (50)  NULL,
    [routecode]             VARCHAR (MAX) NULL,
    [pipelinename]             VARCHAR (MAX) NULL,
    [status]             VARCHAR (MAX) NULL
);