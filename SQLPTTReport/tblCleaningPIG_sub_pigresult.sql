USE [PTT-AssetMaintenanceDARR_Test]
GO

/****** Object: Table [dbo].[tblsoil_erosion] Script Date: 6/10/2017 11:10:21 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblcleaningpig_sub_pigresult] (
    [id]             BIGINT        IDENTITY (1, 1) NOT NULL,
    [cp_id]			VARCHAR (50)  NULL,
    [routecode]             VARCHAR (MAX) NULL,
    [sectionlength]             VARCHAR (MAX) NULL,
    [status]             VARCHAR (MAX) NULL
);