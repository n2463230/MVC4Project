USE [master]
GO
/****** Object:  Database [FPUserProfile]    Script Date: 02/14/2014 12:30:49 ******/
CREATE DATABASE [FPUserProfile] ON  PRIMARY 
( NAME = N'FPUserProfile', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\FPUserProfile.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'FPUserProfile_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\FPUserProfile_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [FPUserProfile] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FPUserProfile].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FPUserProfile] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [FPUserProfile] SET ANSI_NULLS OFF
GO
ALTER DATABASE [FPUserProfile] SET ANSI_PADDING OFF
GO
ALTER DATABASE [FPUserProfile] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [FPUserProfile] SET ARITHABORT OFF
GO
ALTER DATABASE [FPUserProfile] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [FPUserProfile] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [FPUserProfile] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [FPUserProfile] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [FPUserProfile] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [FPUserProfile] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [FPUserProfile] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [FPUserProfile] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [FPUserProfile] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [FPUserProfile] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [FPUserProfile] SET  DISABLE_BROKER
GO
ALTER DATABASE [FPUserProfile] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [FPUserProfile] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [FPUserProfile] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [FPUserProfile] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [FPUserProfile] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [FPUserProfile] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [FPUserProfile] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [FPUserProfile] SET  READ_WRITE
GO
ALTER DATABASE [FPUserProfile] SET RECOVERY FULL
GO
ALTER DATABASE [FPUserProfile] SET  MULTI_USER
GO
ALTER DATABASE [FPUserProfile] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [FPUserProfile] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'FPUserProfile', N'ON'
GO
USE [FPUserProfile]
GO
/****** Object:  Table [dbo].[tblUserRegistrationRequests]    Script Date: 02/14/2014 12:30:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblUserRegistrationRequests](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserEmail] [varbinary](max) NOT NULL,
	[RegistrationDate] [datetime] NOT NULL,
	[UserStatus] [int] NOT NULL,
	[RegistrationIP] [varchar](50) NOT NULL,
	[CountryOfRegistration] [int] NOT NULL,
	[NewsLetter] [bit] NOT NULL,
	[LoginPassword] [varbinary](max) NOT NULL,
	[Salt] [varbinary](max) NULL,
	[Key] [varbinary](max) NULL,
 CONSTRAINT [PK_tblUserRegistrationRequests] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblRegisteredUser]    Script Date: 02/14/2014 12:30:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblRegisteredUser](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserEmail] [varbinary](max) NOT NULL,
	[CountryOfRegistration] [int] NOT NULL,
	[NewsLetter] [bit] NOT NULL,
	[RegistrationDate] [datetime] NOT NULL,
	[RegistrationIP] [varchar](50) NOT NULL,
	[ConfirmationDate] [datetime] NOT NULL,
	[ConfirmationIP] [varchar](50) NULL,
	[ModifiedBy] [varchar](50) NULL,
	[ModifiedOn] [datetime] NULL,
	[IPAddressOfLastAction] [varchar](50) NULL,
 CONSTRAINT [PK_tblRegisteredUser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblChangeUserEMailRequest]    Script Date: 02/14/2014 12:30:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblChangeUserEMailRequest](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VerificationId] [uniqueidentifier] NOT NULL,
	[UserId] [int] NOT NULL,
	[UserNewEMailId] [varbinary](max) NOT NULL,
	[EMailVerificationLinkStatusId] [int] NOT NULL,
	[UserOldEMailId] [varbinary](max) NOT NULL,
	[ModifiedBy] [varchar](50) NULL,
	[ModifiedOn] [datetime] NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[IPAddressOfLastAction] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[vGetRegisteredUsersEmailAddress]    Script Date: 02/14/2014 12:30:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vGetRegisteredUsersEmailAddress] AS

SELECT UserEmail FROM tblUserRegistrationRequests
UNION ALL
SELECT UserEmail FROM tblRegisteredUser
GO
/****** Object:  View [dbo].[vGetExportUserDetails]    Script Date: 02/14/2014 12:30:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[vGetExportUserDetails] as 

   SELECT 
  ROW_NUMBER() OVER(ORDER BY RegistrationDate DESC) AS ID,
  a.id as UserID,
  a.NewsLetter,
  a.UserEmail, 
  a.RegistrationDate, 
  
(SELECT 
CASE IsLocked WHEN 1 THEN 'unLock' WHEN 0 THEN 'Lock' END AS UserStatus
FROM [FPUserCredential].[dbo].[tblUserLoginCredentials] WHERE UserId = a.id) as RegistrationStatus, 
    
  
  (SELECT COUNT(*)  FROM [FPDepositAccount].[dbo].[tblAccountUserLink] where UserId = a.Id) as NoOfAccountAssociated
  FROM tblRegisteredUser a
  where a.NewsLetter =1


  /****** Script for SelectTopNRows command from SSMS  ******/

--  SELECT        ROW_NUMBER() OVER (ORDER BY RegistrationDate DESC) AS ID, a.UserEmail as 'User EMail', a.RegistrationDate as 'Registration Date',  '' AS 'Registration Status',
--    (SELECT        COUNT(*)
--      FROM            [FPDepositAccount].[dbo].[tblAccountUserLink]
--      WHERE        UserId = a.Id) AS NoOfAccountAssociated
--FROM            tblRegisteredUser a
--WHERE        a.NewsLetter = 1
GO
