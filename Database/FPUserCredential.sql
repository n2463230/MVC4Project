USE [master]
GO
/****** Object:  Database [FPUserCredential]    Script Date: 02/14/2014 12:29:42 ******/
CREATE DATABASE [FPUserCredential] ON  PRIMARY 
( NAME = N'FPUserCredential', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\FPUserCredential.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'FPUserCredential_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\FPUserCredential_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [FPUserCredential] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FPUserCredential].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FPUserCredential] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [FPUserCredential] SET ANSI_NULLS OFF
GO
ALTER DATABASE [FPUserCredential] SET ANSI_PADDING OFF
GO
ALTER DATABASE [FPUserCredential] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [FPUserCredential] SET ARITHABORT OFF
GO
ALTER DATABASE [FPUserCredential] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [FPUserCredential] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [FPUserCredential] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [FPUserCredential] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [FPUserCredential] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [FPUserCredential] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [FPUserCredential] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [FPUserCredential] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [FPUserCredential] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [FPUserCredential] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [FPUserCredential] SET  DISABLE_BROKER
GO
ALTER DATABASE [FPUserCredential] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [FPUserCredential] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [FPUserCredential] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [FPUserCredential] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [FPUserCredential] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [FPUserCredential] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [FPUserCredential] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [FPUserCredential] SET  READ_WRITE
GO
ALTER DATABASE [FPUserCredential] SET RECOVERY FULL
GO
ALTER DATABASE [FPUserCredential] SET  MULTI_USER
GO
ALTER DATABASE [FPUserCredential] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [FPUserCredential] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'FPUserCredential', N'ON'
GO
USE [FPUserCredential]
GO
/****** Object:  Table [dbo].[tblUserLoginQuestions]    Script Date: 02/14/2014 12:29:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblUserLoginQuestions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[SecretQuestion] [varbinary](max) NOT NULL,
	[Answer] [varbinary](max) NOT NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedBy] [varchar](50) NULL,
	[ModifiedOn] [datetime] NULL,
	[IPAddressOfLastAction] [varchar](50) NULL,
 CONSTRAINT [PK_tblUserLoginQuestions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblUserLoginCredentials]    Script Date: 02/14/2014 12:29:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblUserLoginCredentials](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[LoginPassword] [varbinary](max) NOT NULL,
	[LastPasswordChanged] [datetime] NULL,
	[LastFailedLogin] [datetime] NULL,
	[FailedLoginCount] [int] NULL,
	[IsLocked] [bit] NOT NULL,
	[UserType] [int] NOT NULL,
	[Key] [varbinary](max) NOT NULL,
	[Salt] [varbinary](max) NOT NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedBy] [varchar](50) NULL,
	[ModifiedOn] [datetime] NULL,
	[IPAddressOfLastAction] [varchar](50) NULL,
 CONSTRAINT [PK_tblUserLoginCredentials] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
