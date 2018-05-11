# agenda
agenda utilizando asp.net com mvc, rest e web api

1 - Criar um banco de dados com o script abaixo:

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



2 - Alterar a string de conexao do arquivo:
\agenda\Agenda.Utils\Agenda.Utils\Constantes.cs

3 - Rodar o projeto

