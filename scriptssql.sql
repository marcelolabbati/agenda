PRINT N'Agenda DATABASE...';  
GO  
CREATE DATABASE [DBAGENDA]
GO  
USE DBAGENDA
GO
PRINT N'Creating DBAGENDA.Contato...';  
GO  
CREATE TABLE [dbo].[Contato] (
    [ID]       INT           IDENTITY (1, 1) NOT NULL,
    [Nome]     VARCHAR (500) NOT NULL,
    [Telefone] VARCHAR (500) NOT NULL,
    [Email]    VARCHAR (200) NULL
);

