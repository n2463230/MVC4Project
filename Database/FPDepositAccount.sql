USE [master]
GO
/****** Object:  Database [FPDepositAccount]    Script Date: 02/14/2014 12:09:13 ******/
CREATE DATABASE [FPDepositAccount] ON  PRIMARY 
( NAME = N'FPDepositAccount', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\FPDepositAccount.mdf' , SIZE = 6144KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'FPDepositAccount_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\FPDepositAccount_log.ldf' , SIZE = 8384KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [FPDepositAccount] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FPDepositAccount].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FPDepositAccount] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [FPDepositAccount] SET ANSI_NULLS OFF
GO
ALTER DATABASE [FPDepositAccount] SET ANSI_PADDING OFF
GO
ALTER DATABASE [FPDepositAccount] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [FPDepositAccount] SET ARITHABORT OFF
GO
ALTER DATABASE [FPDepositAccount] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [FPDepositAccount] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [FPDepositAccount] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [FPDepositAccount] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [FPDepositAccount] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [FPDepositAccount] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [FPDepositAccount] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [FPDepositAccount] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [FPDepositAccount] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [FPDepositAccount] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [FPDepositAccount] SET  DISABLE_BROKER
GO
ALTER DATABASE [FPDepositAccount] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [FPDepositAccount] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [FPDepositAccount] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [FPDepositAccount] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [FPDepositAccount] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [FPDepositAccount] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [FPDepositAccount] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [FPDepositAccount] SET  READ_WRITE
GO
ALTER DATABASE [FPDepositAccount] SET RECOVERY FULL
GO
ALTER DATABASE [FPDepositAccount] SET  MULTI_USER
GO
ALTER DATABASE [FPDepositAccount] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [FPDepositAccount] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'FPDepositAccount', N'ON'
GO
USE [FPDepositAccount]
GO
/****** Object:  Table [dbo].[tblDepositAccount]    Script Date: 02/14/2014 12:09:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblDepositAccount](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[AccountTypeId] [int] NOT NULL,
	[AccountCurrency] [int] NOT NULL,
	[AccountStatus] [int] NOT NULL,
	[OpeningDate] [datetime] NOT NULL,
	[KYCFlag] [int] NOT NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedBy] [varchar](50) NULL,
	[ModifiedOn] [datetime] NULL,
	[IPAddressOfLastAction] [varchar](50) NULL,
	[AccountNumber] [nvarchar](max) NULL,
 CONSTRAINT [PK_tblDepositAccount] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblCompanyAccountLink]    Script Date: 02/14/2014 12:09:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblCompanyAccountLink](
	[AccountId] [int] NOT NULL,
	[CompanyName] [varbinary](max) NOT NULL,
	[RegistrationCountry] [int] NOT NULL,
	[IncorporationDate] [date] NOT NULL,
	[RegistrationNo] [varbinary](max) NOT NULL,
	[Industry] [int] NOT NULL,
	[CompanyType] [int] NOT NULL,
	[OfficeNo] [varchar](50) NOT NULL,
	[Side] [varchar](50) NULL,
	[Streetname] [varchar](255) NOT NULL,
	[AdditionalAddress 1] [varchar](255) NULL,
	[AdditionalAddress 2] [varchar](255) NULL,
	[ZipCode] [varchar](50) NOT NULL,
	[City] [varchar](255) NOT NULL,
	[Country] [varchar](255) NOT NULL,
	[Fixedphone] [varchar](50) NULL,
	[MobileNo] [varchar](50) NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedBy] [varchar](50) NULL,
	[ModifiedOn] [datetime] NULL,
	[IPAddressOfLastAction] [varchar](50) NULL,
	[CVRNo] [varbinary](max) NOT NULL,
	[Floor] [varchar](50) NULL,
	[WorkPhoneNo] [varchar](50) NULL,
	[PrivatePhoneNo] [varchar](50) NULL,
	[DirectPhoneNo] [varchar](50) NULL,
	[OfficeMobileNo] [varchar](50) NULL,
	[RequesterFirstName] [varchar](50) NULL,
	[RequestersMiddleName] [varchar](50) NULL,
	[RequestersLastName] [varchar](50) NULL,
	[RequestersDesignation] [varchar](50) NULL,
 CONSTRAINT [PK_tblCompanyAccountLink] PRIMARY KEY CLUSTERED 
(
	[AccountId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblAccountUserLink]    Script Date: 02/14/2014 12:09:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblAccountUserLink](
	[UserId] [int] NOT NULL,
	[AccountId] [int] NOT NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[ModifiedBy] [varchar](50) NULL,
	[ModifiedOn] [datetime] NULL,
	[Reason] [varchar](250) NULL,
 CONSTRAINT [PK_tblAccountUserLink] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[AccountId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblAccountOwner]    Script Date: 02/14/2014 12:09:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblAccountOwner](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AccountId] [int] NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[MiddleName] [varchar](50) NULL,
	[LastName] [varchar](50) NOT NULL,
	[Streetname] [varchar](255) NOT NULL,
	[HouseNo] [varchar](50) NOT NULL,
	[Floor] [varchar](50) NULL,
	[Side] [varchar](50) NULL,
	[AdditionalAddress 1] [varchar](255) NULL,
	[AdditionalAddress 2] [varchar](255) NULL,
	[ZipCode] [varchar](50) NOT NULL,
	[City] [varchar](255) NOT NULL,
	[Country] [varchar](255) NOT NULL,
	[DOB] [date] NOT NULL,
	[Gender] [char](1) NULL,
	[Fixedphone] [varchar](50) NULL,
	[MobileNo] [varchar](50) NULL,
	[SocialSecurityNo] [varbinary](max) NOT NULL,
	[EmailAddress] [varbinary](max) NOT NULL,
	[KYCStatus] [int] NOT NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedBy] [varchar](50) NULL,
	[ModifiedOn] [datetime] NULL,
	[IPAddressOfLastAction] [varchar](50) NULL,
	[WorkPhoneNo] [varchar](50) NULL,
	[DirectPhoneNo] [varchar](50) NULL,
	[OfficeMobileNo] [varchar](50) NULL,
	[PrivatePhoneNo] [varchar](50) NULL,
	[AddressVerificationDocumentPath] [nvarchar](max) NULL,
	[IdentityVerificationDocumentPath] [nvarchar](max) NULL,
 CONSTRAINT [PK_tblAccountOwner] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblPublicAuthorityAccountLink]    Script Date: 02/14/2014 12:09:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblPublicAuthorityAccountLink](
	[AccountId] [int] NOT NULL,
	[PublicAuthorityName] [varbinary](max) NOT NULL,
	[CVRNo] [varbinary](max) NOT NULL,
	[Industry] [int] NOT NULL,
	[OfficeNo] [varchar](50) NOT NULL,
	[Side] [varchar](50) NULL,
	[Streetname] [varchar](255) NOT NULL,
	[AdditionalAddress 1] [varchar](255) NULL,
	[AdditionalAddress 2] [varchar](255) NULL,
	[ZipCode] [varchar](50) NOT NULL,
	[City] [varchar](255) NOT NULL,
	[Country] [varchar](255) NOT NULL,
	[Fixedphone] [varchar](50) NULL,
	[MobileNo] [varchar](50) NULL,
	[RegistrationCountry] [int] NOT NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedBy] [varchar](50) NULL,
	[ModifiedOn] [datetime] NULL,
	[IPAddressOfLastAction] [varchar](50) NULL,
	[WorkPhoneNo] [varchar](50) NULL,
	[DirectPhoneNo] [varchar](50) NULL,
	[OfficeMobileNo] [varchar](50) NULL,
	[PrivatePhoneNo] [varchar](50) NULL,
	[Floor] [varchar](50) NULL,
	[RegistrationNo] [varbinary](max) NULL,
 CONSTRAINT [PK_tblPublicAuthorityAccountLink] PRIMARY KEY CLUSTERED 
(
	[AccountId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblDepositTransactions]    Script Date: 02/14/2014 12:09:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblDepositTransactions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AccountId] [int] NOT NULL,
	[TransactionAmount] [varbinary](max) NOT NULL,
	[Description] [varchar](max) NOT NULL,
	[IsCredit] [bit] NOT NULL,
	[TransactionDate] [datetime] NOT NULL,
	[TransactionSourceIP] [varchar](50) NOT NULL,
	[UserId] [int] NOT NULL,
	[CCReferenceNo] [varchar](100) NULL,
	[OtherReferenceno] [varchar](100) NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedBy] [varchar](50) NULL,
	[ModifiedOn] [datetime] NULL,
	[IPAddressOfModification] [varchar](50) NULL,
 CONSTRAINT [PK_tblDepositTransactions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[vGetRegisteredUsersByAccountNumber]    Script Date: 02/14/2014 12:09:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vGetRegisteredUsersByAccountNumber] as 



--SELECT C.*, A.AccountNumber, d.IsLocked, case d.IsLocked when 1 then 'unLock' when 0 then 'Lock' end as UserStatus
--FROM [FPDepositAccount].[dbo].[tblDepositAccount] A JOIN [dbo].[tblAccountUserLink] B ON a.id = b.AccountId
--JOIN [FPUserProfile].[dbo].[tblRegisteredUser] C on b.UserId = c.Id
--JOIN [FPUserCredential].[dbo].[tblUserLoginCredentials] D on c.id = d.UserId


SELECT        C.Id, C.UserEmail, C.CountryOfRegistration, C.NewsLetter, C.RegistrationDate, C.RegistrationIP, C.ConfirmationDate, C.ConfirmationIP, C.ModifiedBy, C.ModifiedOn, C.IPAddressOfLastAction, A.AccountNumber, 
                         D.IsLocked, CASE d .IsLocked WHEN 1 THEN 'unLock' WHEN 0 THEN 'Lock' END AS UserStatus
FROM            tblDepositAccount AS A INNER JOIN
                         tblAccountUserLink AS B ON A.Id = B.AccountId RIGHT OUTER JOIN
                         FPUserProfile.dbo.tblRegisteredUser AS C ON B.UserId = C.Id LEFT OUTER JOIN
                         FPUserCredential.dbo.tblUserLoginCredentials AS D ON C.Id = D.UserId
GO
/****** Object:  ForeignKey [FK_tblCompanyAccountLink_tblDepositAccount]    Script Date: 02/14/2014 12:09:20 ******/
ALTER TABLE [dbo].[tblCompanyAccountLink]  WITH CHECK ADD  CONSTRAINT [FK_tblCompanyAccountLink_tblDepositAccount] FOREIGN KEY([AccountId])
REFERENCES [dbo].[tblDepositAccount] ([Id])
GO
ALTER TABLE [dbo].[tblCompanyAccountLink] CHECK CONSTRAINT [FK_tblCompanyAccountLink_tblDepositAccount]
GO
/****** Object:  ForeignKey [FK_tblAccountUserLink_tblDepositAccount]    Script Date: 02/14/2014 12:09:20 ******/
ALTER TABLE [dbo].[tblAccountUserLink]  WITH CHECK ADD  CONSTRAINT [FK_tblAccountUserLink_tblDepositAccount] FOREIGN KEY([AccountId])
REFERENCES [dbo].[tblDepositAccount] ([Id])
GO
ALTER TABLE [dbo].[tblAccountUserLink] CHECK CONSTRAINT [FK_tblAccountUserLink_tblDepositAccount]
GO
/****** Object:  ForeignKey [FK_tblAccountOwner_tblDepositAccount]    Script Date: 02/14/2014 12:09:20 ******/
ALTER TABLE [dbo].[tblAccountOwner]  WITH CHECK ADD  CONSTRAINT [FK_tblAccountOwner_tblDepositAccount] FOREIGN KEY([AccountId])
REFERENCES [dbo].[tblDepositAccount] ([Id])
GO
ALTER TABLE [dbo].[tblAccountOwner] CHECK CONSTRAINT [FK_tblAccountOwner_tblDepositAccount]
GO
/****** Object:  ForeignKey [FK_tblPublicAuthorityAccountLink_tblDepositAccount]    Script Date: 02/14/2014 12:09:20 ******/
ALTER TABLE [dbo].[tblPublicAuthorityAccountLink]  WITH CHECK ADD  CONSTRAINT [FK_tblPublicAuthorityAccountLink_tblDepositAccount] FOREIGN KEY([AccountId])
REFERENCES [dbo].[tblDepositAccount] ([Id])
GO
ALTER TABLE [dbo].[tblPublicAuthorityAccountLink] CHECK CONSTRAINT [FK_tblPublicAuthorityAccountLink_tblDepositAccount]
GO
/****** Object:  ForeignKey [FK_tblDepositTransactions_tblDepositAccount]    Script Date: 02/14/2014 12:09:20 ******/
ALTER TABLE [dbo].[tblDepositTransactions]  WITH CHECK ADD  CONSTRAINT [FK_tblDepositTransactions_tblDepositAccount] FOREIGN KEY([AccountId])
REFERENCES [dbo].[tblDepositAccount] ([Id])
GO
ALTER TABLE [dbo].[tblDepositTransactions] CHECK CONSTRAINT [FK_tblDepositTransactions_tblDepositAccount]
GO
