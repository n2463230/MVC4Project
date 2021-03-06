USE [master]
GO
/****** Object:  Database [FPMasterValues]    Script Date: 02/14/2014 12:29:15 ******/
CREATE DATABASE [FPMasterValues] ON  PRIMARY 
( NAME = N'FPMasterValues', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\FPMasterValues.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'FPMasterValues_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\FPMasterValues_log.ldf' , SIZE = 1536KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [FPMasterValues] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FPMasterValues].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FPMasterValues] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [FPMasterValues] SET ANSI_NULLS OFF
GO
ALTER DATABASE [FPMasterValues] SET ANSI_PADDING OFF
GO
ALTER DATABASE [FPMasterValues] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [FPMasterValues] SET ARITHABORT OFF
GO
ALTER DATABASE [FPMasterValues] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [FPMasterValues] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [FPMasterValues] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [FPMasterValues] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [FPMasterValues] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [FPMasterValues] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [FPMasterValues] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [FPMasterValues] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [FPMasterValues] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [FPMasterValues] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [FPMasterValues] SET  DISABLE_BROKER
GO
ALTER DATABASE [FPMasterValues] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [FPMasterValues] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [FPMasterValues] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [FPMasterValues] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [FPMasterValues] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [FPMasterValues] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [FPMasterValues] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [FPMasterValues] SET  READ_WRITE
GO
ALTER DATABASE [FPMasterValues] SET RECOVERY FULL
GO
ALTER DATABASE [FPMasterValues] SET  MULTI_USER
GO
ALTER DATABASE [FPMasterValues] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [FPMasterValues] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'FPMasterValues', N'ON'
GO
USE [FPMasterValues]
GO
/****** Object:  Table [dbo].[tblUserType]    Script Date: 02/14/2014 12:29:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblUserType](
	[Id] [int] NOT NULL,
	[UserType] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tblUserType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[tblUserType] ([Id], [UserType]) VALUES (1, N'Platform Client')
INSERT [dbo].[tblUserType] ([Id], [UserType]) VALUES (2, N'Platform Administrator')
INSERT [dbo].[tblUserType] ([Id], [UserType]) VALUES (3, N'Back office staff level 1')
INSERT [dbo].[tblUserType] ([Id], [UserType]) VALUES (4, N'Back office staff level 2')
INSERT [dbo].[tblUserType] ([Id], [UserType]) VALUES (5, N'Back office staff level 3')
INSERT [dbo].[tblUserType] ([Id], [UserType]) VALUES (6, N'Back office staff level 4')
INSERT [dbo].[tblUserType] ([Id], [UserType]) VALUES (7, N'Back office staff level 5')
/****** Object:  Table [dbo].[tblUserStatus]    Script Date: 02/14/2014 12:29:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblUserStatus](
	[Id] [int] NOT NULL,
	[UserStatus] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tblUserStatus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[tblUserStatus] ([Id], [UserStatus]) VALUES (1, N'RequestDone')
INSERT [dbo].[tblUserStatus] ([Id], [UserStatus]) VALUES (2, N'EmailVerified')
INSERT [dbo].[tblUserStatus] ([Id], [UserStatus]) VALUES (3, N'SecurityQuestionsAnswerSet')
INSERT [dbo].[tblUserStatus] ([Id], [UserStatus]) VALUES (4, N'Cancelled')
/****** Object:  Table [dbo].[tblSystemModules]    Script Date: 02/14/2014 12:29:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblSystemModules](
	[Id] [int] NOT NULL,
	[Module] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tblSystemModules] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[tblSystemModules] ([Id], [Module]) VALUES (1, N'UserAccountManagement')
INSERT [dbo].[tblSystemModules] ([Id], [Module]) VALUES (2, N'SystemConfiguration')
/****** Object:  Table [dbo].[tblSupportedLanguage]    Script Date: 02/14/2014 12:29:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblSupportedLanguage](
	[ID] [int] NOT NULL,
	[Language] [varchar](50) NOT NULL,
	[LanguageCode] [varchar](50) NULL,
 CONSTRAINT [PK_tblSupportedLanguage] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[tblSupportedLanguage] ([ID], [Language], [LanguageCode]) VALUES (1, N'Danish', N'da-DK')
INSERT [dbo].[tblSupportedLanguage] ([ID], [Language], [LanguageCode]) VALUES (2, N'India', N'en-IN')
INSERT [dbo].[tblSupportedLanguage] ([ID], [Language], [LanguageCode]) VALUES (3, N'English', N'en-US')
/****** Object:  Table [dbo].[tblSupportedCurrency]    Script Date: 02/14/2014 12:29:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblSupportedCurrency](
	[Id] [int] NOT NULL,
	[CurrencyISOCode] [varchar](3) NOT NULL,
	[CurrencyDescription] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tblSupportedCurrency] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[tblSupportedCurrency] ([Id], [CurrencyISOCode], [CurrencyDescription]) VALUES (1, N'DKK', N'Danish Krone')
/****** Object:  Table [dbo].[tblSupportedAccountType]    Script Date: 02/14/2014 12:29:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblSupportedAccountType](
	[Id] [int] NOT NULL,
	[AccountType] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tblSupportedAccountType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[tblSupportedAccountType] ([Id], [AccountType]) VALUES (1, N'Individual')
INSERT [dbo].[tblSupportedAccountType] ([Id], [AccountType]) VALUES (2, N'Company Privately Held')
INSERT [dbo].[tblSupportedAccountType] ([Id], [AccountType]) VALUES (3, N'Public Institute')
/****** Object:  Table [dbo].[tblPublicAuthorityIndustryList]    Script Date: 02/14/2014 12:29:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblPublicAuthorityIndustryList](
	[Id] [int] NOT NULL,
	[IndustryType] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tblPublicAuthorityIndustryList] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[tblPublicAuthorityIndustryList] ([Id], [IndustryType]) VALUES (1, N'Software')
INSERT [dbo].[tblPublicAuthorityIndustryList] ([Id], [IndustryType]) VALUES (2, N'Hardware')
INSERT [dbo].[tblPublicAuthorityIndustryList] ([Id], [IndustryType]) VALUES (3, N'Networks')
INSERT [dbo].[tblPublicAuthorityIndustryList] ([Id], [IndustryType]) VALUES (4, N'Microsoft')
INSERT [dbo].[tblPublicAuthorityIndustryList] ([Id], [IndustryType]) VALUES (5, N'Sports')
/****** Object:  Table [dbo].[tblKYCStatus]    Script Date: 02/14/2014 12:29:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblKYCStatus](
	[Id] [int] NOT NULL,
	[KYCStatus] [varchar](50) NULL,
 CONSTRAINT [PK_tblKYCStatus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[tblKYCStatus] ([Id], [KYCStatus]) VALUES (1, N'Green')
INSERT [dbo].[tblKYCStatus] ([Id], [KYCStatus]) VALUES (2, N'Yellow')
/****** Object:  Table [dbo].[tblCountryOfOperation]    Script Date: 02/14/2014 12:29:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblCountryOfOperation](
	[Id] [int] NOT NULL,
	[CountryISOCode] [varchar](3) NOT NULL,
	[CountryName] [varchar](255) NOT NULL,
	[DefaultLanguageId] [int] NOT NULL,
	[DefaultCurrencyId] [int] NOT NULL,
 CONSTRAINT [PK_tblCountryOfOperation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[tblCountryOfOperation] ([Id], [CountryISOCode], [CountryName], [DefaultLanguageId], [DefaultCurrencyId]) VALUES (1, N'DK', N'Denmark', 1, 1)
/****** Object:  Table [dbo].[tblCountryList]    Script Date: 02/14/2014 12:29:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblCountryList](
	[Id] [int] NOT NULL,
	[CountryISOCode] [varchar](3) NOT NULL,
	[Country] [varchar](100) NOT NULL,
 CONSTRAINT [PK_tblCountryList] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (1, N'AF', N'AFGHANISTAN')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (2, N'AX', N'ÅLAND ISLANDS')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (3, N'AL', N'ALBANIA')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (4, N'DZ', N'ALGERIA')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (5, N'AS', N'AMERICAN SAMOA')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (6, N'AD', N'ANDORRA')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (7, N'AO', N'ANGOLA')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (8, N'AI', N'ANGUILLA')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (9, N'AQ', N'ANTARCTICA')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (10, N'AG', N'ANTIGUA AND BARBUDA')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (11, N'AR', N'ARGENTINA')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (12, N'AM', N'ARMENIA')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (13, N'AW', N'ARUBA')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (14, N'AU', N'AUSTRALIA')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (15, N'AT', N'AUSTRIA')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (16, N'AZ', N'AZERBAIJAN')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (17, N'BS', N'BAHAMAS')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (18, N'BH', N'BAHRAIN')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (19, N'BD', N'BANGLADESH')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (20, N'BB', N'BARBADOS')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (21, N'BY', N'BELARUS')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (22, N'BE', N'BELGIUM')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (23, N'BZ', N'BELIZE')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (24, N'BJ', N'BENIN')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (25, N'BM', N'BERMUDA')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (26, N'BT', N'BHUTAN')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (27, N'BO', N'BOLIVIA, PLURINATIONAL STATE OF')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (28, N'BQ', N'BONAIRE, SINT EUSTATIUS AND SABA')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (29, N'BA', N'BOSNIA AND HERZEGOVINA')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (30, N'BW', N'BOTSWANA')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (31, N'BV', N'BOUVET ISLAND')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (32, N'BR', N'BRAZIL')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (33, N'IO', N'BRITISH INDIAN OCEAN TERRITORY')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (34, N'BN', N'BRUNEI DARUSSALAM')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (35, N'BG', N'BULGARIA')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (36, N'BF', N'BURKINA FASO')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (37, N'BI', N'BURUNDI')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (38, N'KH', N'CAMBODIA')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (39, N'CM', N'CAMEROON')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (40, N'CA', N'CANADA')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (41, N'CV', N'CAPE VERDE')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (42, N'KY', N'CAYMAN ISLANDS')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (43, N'CF', N'CENTRAL AFRICAN REPUBLIC')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (44, N'TD', N'CHAD')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (45, N'CL', N'CHILE')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (46, N'CN', N'CHINA')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (47, N'CX', N'CHRISTMAS ISLAND')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (48, N'CC', N'COCOS (KEELING) ISLANDS')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (49, N'CO', N'COLOMBIA')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (50, N'KM', N'COMOROS')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (51, N'CG', N'CONGO')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (52, N'CD', N'CONGO, THE DEMOCRATIC REPUBLIC OF THE')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (53, N'CK', N'COOK ISLANDS')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (54, N'CR', N'COSTA RICA')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (55, N'CI', N'CÔTE D''IVOIRE')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (56, N'HR', N'CROATIA')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (57, N'CU', N'CUBA')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (58, N'CW', N'CURAÇAO')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (59, N'CY', N'CYPRUS')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (60, N'CZ', N'CZECH REPUBLIC')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (61, N'DK', N'DENMARK')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (62, N'DJ', N'DJIBOUTI')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (63, N'DM', N'DOMINICA')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (64, N'DO', N'DOMINICAN REPUBLIC')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (65, N'EC', N'ECUADOR')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (66, N'EG', N'EGYPT')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (67, N'SV', N'EL SALVADOR')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (68, N'GQ', N'EQUATORIAL GUINEA')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (69, N'ER', N'ERITREA')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (70, N'EE', N'ESTONIA')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (71, N'ET', N'ETHIOPIA')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (72, N'FK', N'FALKLAND ISLANDS (MALVINAS)')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (73, N'FO', N'FAROE ISLANDS')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (74, N'FJ', N'FIJI')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (75, N'FI', N'FINLAND')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (76, N'FR', N'FRANCE')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (77, N'GF', N'FRENCH GUIANA')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (78, N'PF', N'FRENCH POLYNESIA')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (79, N'TF', N'FRENCH SOUTHERN TERRITORIES')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (80, N'GA', N'GABON')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (81, N'GM', N'GAMBIA')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (82, N'GE', N'GEORGIA')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (83, N'DE', N'GERMANY')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (84, N'GH', N'GHANA')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (85, N'GI', N'GIBRALTAR')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (86, N'GR', N'GREECE')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (87, N'GL', N'GREENLAND')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (88, N'GD', N'GRENADA')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (89, N'GP', N'GUADELOUPE')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (90, N'GU', N'GUAM')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (91, N'GT', N'GUATEMALA')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (92, N'GG', N'GUERNSEY')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (93, N'GN', N'GUINEA')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (94, N'GW', N'GUINEA-BISSAU')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (95, N'GY', N'GUYANA')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (96, N'HT', N'HAITI')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (97, N'HM', N'HEARD ISLAND AND MCDONALD ISLANDS')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (98, N'VA', N'HOLY SEE (VATICAN CITY STATE)')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (99, N'HN', N'HONDURAS')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (100, N'HK', N'HONG KONG')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (101, N'HU', N'HUNGARY')
GO
print 'Processed 100 total records'
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (102, N'IS', N'ICELAND')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (103, N'IN', N'INDIA')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (104, N'ID', N'INDONESIA')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (105, N'IR', N'IRAN, ISLAMIC REPUBLIC OF')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (106, N'IQ', N'IRAQ')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (107, N'IE', N'IRELAND')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (108, N'IM', N'ISLE OF MAN')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (109, N'IL', N'ISRAEL')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (110, N'IT', N'ITALY')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (111, N'JM', N'JAMAICA')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (112, N'JP', N'JAPAN')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (113, N'JE', N'JERSEY')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (114, N'JO', N'JORDAN')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (115, N'KZ', N'KAZAKHSTAN')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (116, N'KE', N'KENYA')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (117, N'KI', N'KIRIBATI')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (118, N'KP', N'KOREA, DEMOCRATIC PEOPLE''S REPUBLIC OF')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (119, N'KR', N'KOREA, REPUBLIC OF')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (120, N'KW', N'KUWAIT')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (121, N'KG', N'KYRGYZSTAN')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (122, N'LA', N'LAO PEOPLE''S DEMOCRATIC REPUBLIC')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (123, N'LV', N'LATVIA')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (124, N'LB', N'LEBANON')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (125, N'LS', N'LESOTHO')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (126, N'LR', N'LIBERIA')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (127, N'LY', N'LIBYA')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (128, N'LI', N'LIECHTENSTEIN')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (129, N'LT', N'LITHUANIA')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (130, N'LU', N'LUXEMBOURG')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (131, N'MO', N'MACAO')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (132, N'MK', N'MACEDONIA, THE FORMER YUGOSLAV REPUBLIC OF')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (133, N'MG', N'MADAGASCAR')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (134, N'MW', N'MALAWI')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (135, N'MY', N'MALAYSIA')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (136, N'MV', N'MALDIVES')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (137, N'ML', N'MALI')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (138, N'MT', N'MALTA')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (139, N'MH', N'MARSHALL ISLANDS')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (140, N'MQ', N'MARTINIQUE')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (141, N'MR', N'MAURITANIA')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (142, N'MU', N'MAURITIUS')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (143, N'YT', N'MAYOTTE')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (144, N'MX', N'MEXICO')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (145, N'FM', N'MICRONESIA, FEDERATED STATES OF')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (146, N'MD', N'MOLDOVA, REPUBLIC OF')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (147, N'MC', N'MONACO')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (148, N'MN', N'MONGOLIA')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (149, N'ME', N'MONTENEGRO')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (150, N'MS', N'MONTSERRAT')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (151, N'MA', N'MOROCCO')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (152, N'MZ', N'MOZAMBIQUE')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (153, N'MM', N'MYANMAR')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (154, N'NA', N'NAMIBIA')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (155, N'NR', N'NAURU')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (156, N'NP', N'NEPAL')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (157, N'NL', N'NETHERLANDS')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (158, N'NC', N'NEW CALEDONIA')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (159, N'NZ', N'NEW ZEALAND')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (160, N'NI', N'NICARAGUA')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (161, N'NE', N'NIGER')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (162, N'NG', N'NIGERIA')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (163, N'NU', N'NIUE')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (164, N'NF', N'NORFOLK ISLAND')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (165, N'MP', N'NORTHERN MARIANA ISLANDS')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (166, N'NO', N'NORWAY')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (167, N'OM', N'OMAN')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (168, N'PK', N'PAKISTAN')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (169, N'PW', N'PALAU')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (170, N'PS', N'PALESTINE, STATE OF')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (171, N'PA', N'PANAMA')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (172, N'PG', N'PAPUA NEW GUINEA')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (173, N'PY', N'PARAGUAY')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (174, N'PE', N'PERU')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (175, N'PH', N'PHILIPPINES')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (176, N'PN', N'PITCAIRN')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (177, N'PL', N'POLAND')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (178, N'PT', N'PORTUGAL')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (179, N'PR', N'PUERTO RICO')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (180, N'QA', N'QATAR')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (181, N'RE', N'RÉUNION')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (182, N'RO', N'ROMANIA')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (183, N'RU', N'RUSSIAN FEDERATION')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (184, N'RW', N'RWANDA')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (185, N'BL', N'SAINT BARTHÉLEMY')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (186, N'SH', N'SAINT HELENA, ASCENSION AND TRISTAN DA CUNHA')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (187, N'KN', N'SAINT KITTS AND NEVIS')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (188, N'LC', N'SAINT LUCIA')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (189, N'MF', N'SAINT MARTIN (FRENCH PART)')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (190, N'PM', N'SAINT PIERRE AND MIQUELON')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (191, N'VC', N'SAINT VINCENT AND THE GRENADINES')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (192, N'WS', N'SAMOA')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (193, N'SM', N'SAN MARINO')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (194, N'ST', N'SAO TOME AND PRINCIPE')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (195, N'SA', N'SAUDI ARABIA')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (196, N'SN', N'SENEGAL')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (197, N'RS', N'SERBIA')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (198, N'SC', N'SEYCHELLES')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (199, N'SL', N'SIERRA LEONE')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (200, N'SG', N'SINGAPORE')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (201, N'SX', N'SINT MAARTEN (DUTCH PART)')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (202, N'SK', N'SLOVAKIA')
GO
print 'Processed 200 total records'
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (203, N'SI', N'SLOVENIA')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (204, N'SB', N'SOLOMON ISLANDS')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (205, N'SO', N'SOMALIA')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (206, N'ZA', N'SOUTH AFRICA')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (207, N'GS', N'SOUTH GEORGIA AND THE SOUTH SANDWICH ISLANDS')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (208, N'SS', N'SOUTH SUDAN')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (209, N'ES', N'SPAIN')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (210, N'LK', N'SRI LANKA')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (211, N'SD', N'SUDAN')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (212, N'SR', N'SURINAME')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (213, N'SJ', N'SVALBARD AND JAN MAYEN')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (214, N'SZ', N'SWAZILAND')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (215, N'SE', N'SWEDEN')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (216, N'CH', N'SWITZERLAND')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (217, N'SY', N'SYRIAN ARAB REPUBLIC')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (218, N'TW', N'TAIWAN, PROVINCE OF CHINA')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (219, N'TJ', N'TAJIKISTAN')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (220, N'TZ', N'TANZANIA, UNITED REPUBLIC OF')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (221, N'TH', N'THAILAND')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (222, N'TL', N'TIMOR-LESTE')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (223, N'TG', N'TOGO')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (224, N'TK', N'TOKELAU')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (225, N'TO', N'TONGA')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (226, N'TT', N'TRINIDAD AND TOBAGO')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (227, N'TN', N'TUNISIA')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (228, N'TR', N'TURKEY')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (229, N'TM', N'TURKMENISTAN')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (230, N'TC', N'TURKS AND CAICOS ISLANDS')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (231, N'TV', N'TUVALU')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (232, N'UG', N'UGANDA')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (233, N'UA', N'UKRAINE')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (234, N'AE', N'UNITED ARAB EMIRATES')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (235, N'GB', N'UNITED KINGDOM')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (236, N'US', N'UNITED STATES')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (237, N'UM', N'UNITED STATES MINOR OUTLYING ISLANDS')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (238, N'UY', N'URUGUAY')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (239, N'UZ', N'UZBEKISTAN')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (240, N'VU', N'VANUATU')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (241, N'VE', N'VENEZUELA, BOLIVARIAN REPUBLIC OF')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (242, N'VN', N'VIET NAM')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (243, N'VG', N'VIRGIN ISLANDS, BRITISH')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (244, N'VI', N'VIRGIN ISLANDS, U.S.')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (245, N'WF', N'WALLIS AND FUTUNA')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (246, N'EH', N'WESTERN SAHARA')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (247, N'YE', N'YEMEN')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (248, N'ZM', N'ZAMBIA')
INSERT [dbo].[tblCountryList] ([Id], [CountryISOCode], [Country]) VALUES (249, N'ZW', N'ZIMBABWE')
/****** Object:  Table [dbo].[tblCompanyIndustryList]    Script Date: 02/14/2014 12:29:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblCompanyIndustryList](
	[Id] [int] NOT NULL,
	[IndustryType] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tblCompanyIndustryList] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[tblCompanyIndustryList] ([Id], [IndustryType]) VALUES (1, N'Reebok')
INSERT [dbo].[tblCompanyIndustryList] ([Id], [IndustryType]) VALUES (2, N'Bata')
INSERT [dbo].[tblCompanyIndustryList] ([Id], [IndustryType]) VALUES (3, N'Paragon')
INSERT [dbo].[tblCompanyIndustryList] ([Id], [IndustryType]) VALUES (4, N'Microsoft')
INSERT [dbo].[tblCompanyIndustryList] ([Id], [IndustryType]) VALUES (5, N'TCS')
/****** Object:  Table [dbo].[tblCities]    Script Date: 02/14/2014 12:29:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblCities](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[ZipCode] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tblCities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (1, N'CopenhagenK', N'1000-1499')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (2, N'CopenhagenV', N'1500-1799')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (3, N'FrederiksbergC', N'1800-1999')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (4, N'Frederiksberg', N'2000')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (5, N'CopenhagenØ', N'2100')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (6, N'CopenhagenN', N'2200')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (7, N'CopenhagenS', N'2300')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (8, N'CopenhagenNV', N'2400')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (9, N'CopenhagenSV', N'2450')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (10, N'Valby', N'2500')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (11, N'Glostrup', N'2600')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (12, N'Brøndby', N'2605')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (13, N'Rødovre', N'2610')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (14, N'Albertslund', N'2620')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (15, N'Vallensbæk', N'2625')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (16, N'Taastrup', N'2630')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (17, N'Ishøj', N'2635')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (18, N'Hedehusene', N'2640')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (19, N'Hvidovre', N'2650')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (20, N'BrøndbyStrand', N'2660')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (21, N'VallensbækStrand', N'2665')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (22, N'Greve', N'2670')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (23, N'SolrødStrand', N'2680')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (24, N'Karlslunde', N'2690')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (25, N'Brønshøj', N'2700')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (26, N'Vanløse', N'2720')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (27, N'Herlev', N'2730')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (28, N'Skovlunde', N'2740')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (29, N'Ballerup', N'2750')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (30, N'Måløv', N'2760')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (31, N'Smørum', N'2765')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (32, N'Kastrup', N'2770')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (33, N'Dragør', N'2791')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (34, N'KongensLyngby', N'2800')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (35, N'Gentofte', N'2820')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (36, N'Virum', N'2830')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (37, N'Holte', N'2840')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (38, N'Nærum', N'2850')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (39, N'Søborg', N'2860')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (40, N'Dyssegård', N'2870')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (41, N'Bagsværd', N'2880')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (42, N'Hellerup', N'2900')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (43, N'Charlottenlund', N'2920')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (44, N'Klampenborg', N'2930')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (45, N'Skodsborg', N'2942')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (46, N'Vedbæk', N'2950')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (47, N'RungstedKyst', N'2960')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (48, N'Hørsholm', N'2970')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (49, N'Kokkedal', N'2980')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (50, N'Nivå', N'2990')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (51, N'Helsingør', N'3000')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (52, N'Humlebæk', N'3050')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (53, N'Espergærde', N'3060')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (54, N'Snekkersten', N'3070')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (55, N'Tikøb', N'3080')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (56, N'Hornbæk', N'3100')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (57, N'Dronningmølle', N'3120')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (58, N'Ålsgårde', N'3140')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (59, N'Hellebæk', N'3150')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (60, N'Helsinge', N'3200')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (61, N'Vejby', N'3210')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (62, N'Tisvildeleje', N'3220')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (63, N'Græsted', N'3230')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (64, N'Gilleleje', N'3250')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (65, N'Frederiksværk', N'3300')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (66, N'Ølsted', N'3310')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (67, N'Skævinge', N'3320')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (68, N'Gørløse', N'3330')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (69, N'Liseleje', N'3360')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (70, N'Melby', N'3370')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (71, N'Hundested', N'3390')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (72, N'Hillerød', N'3400')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (73, N'Lillerød', N'3450')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (74, N'Birkerød', N'3460')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (75, N'Fredensborg', N'3480')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (76, N'Kvistgård', N'3490')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (77, N'Værløse', N'3500')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (78, N'Farum', N'3520')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (79, N'Lynge', N'3540')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (80, N'Slangerup', N'3550')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (81, N'Frederikssund', N'3600')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (82, N'Jægerspris', N'3630')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (83, N'Ølstykke', N'3650')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (84, N'Stenløse', N'3660')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (85, N'VeksøSjælland', N'3670')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (86, N'Roskilde', N'4000')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (87, N'Tune', N'4030')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (88, N'Jyllinge', N'4040')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (89, N'Skibby', N'4050')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (90, N'KirkeSåby', N'4060')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (91, N'KirkeHyllinge', N'4070')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (92, N'Ringsted', N'4100')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (93, N'VibySjælland', N'4130')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (94, N'Borup', N'4140')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (95, N'Herlufmagle', N'4160')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (96, N'Glumsø', N'4171')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (97, N'Fjenneslev', N'4173')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (98, N'JystrupMidtsjælland', N'4174')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (99, N'Sorø', N'4180')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (100, N'MunkeBjergby', N'4190')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (101, N'Slagelse', N'4200')
GO
print 'Processed 100 total records'
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (102, N'Korsør', N'4220')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (103, N'Skælskør', N'4230')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (104, N'Vemmelev', N'4241')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (105, N'Boeslunde', N'4242')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (106, N'Rude', N'4243')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (107, N'Fuglebjerg', N'4250')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (108, N'Dalmose', N'4261')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (109, N'Sandved', N'4262')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (110, N'Høng', N'4270')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (111, N'Gørlev', N'4281')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (112, N'RudsVedby', N'4291')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (113, N'Dianalund', N'4293')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (114, N'Stenlille', N'4295')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (115, N'Nyrup', N'4296')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (116, N'Holbæk', N'4300')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (117, N'Lejre', N'4320')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (118, N'Hvalsø', N'4330')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (119, N'Tølløse', N'4340')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (120, N'Ugerløse', N'4350')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (121, N'KirkeEskilstrup', N'4360')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (122, N'StoreMerløse', N'4370')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (123, N'Vipperød', N'4390')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (124, N'Kalundborg', N'4400')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (125, N'Regstrup', N'4420')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (126, N'Mørkøv', N'4440')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (127, N'Jyderup', N'4450')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (128, N'Snertinge', N'4460')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (129, N'Svebølle', N'4470')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (130, N'StoreFuglede', N'4480')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (131, N'JerslevSjælland', N'4490')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (132, N'NykøbingSjælland', N'4500')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (133, N'Svinninge', N'4520')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (134, N'Gislinge', N'4532')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (135, N'Hørve', N'4534')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (136, N'Fårevejle', N'4540')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (137, N'Asnæs', N'4550')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (138, N'Vig', N'4560')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (139, N'Grevinge', N'4571')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (140, N'NørreAsmindrup', N'4572')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (141, N'Højby', N'4573')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (142, N'Rørvig', N'4581')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (143, N'SjællandsOdde', N'4583')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (144, N'Føllenslev', N'4591')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (145, N'Sejerø', N'4592')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (146, N'Eskebjerg', N'4593')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (147, N'Køge', N'4600')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (148, N'Gadstrup', N'4621')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (149, N'Havdrup', N'4622')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (150, N'LilleSkensved', N'4623')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (151, N'Bjæverskov', N'4632')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (152, N'Faxe', N'4640')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (153, N'Hårlev', N'4652')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (154, N'Karise', N'4653')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (155, N'FaxeLadeplads', N'4654')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (156, N'StoreHeddinge', N'4660')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (157, N'Strøby', N'4671')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (158, N'Klippinge', N'4672')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (159, N'RødvigStevns', N'4673')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (160, N'Herfølge', N'4681')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (161, N'Tureby', N'4682')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (162, N'Rønnede', N'4683')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (163, N'Holmegaard', N'4684')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (164, N'Haslev', N'4690')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (165, N'Næstved', N'4700')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (166, N'Præstø', N'4720')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (167, N'Tappernøje', N'4733')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (168, N'Mern', N'4735')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (169, N'Karrebæksminde', N'4736')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (170, N'Lundby', N'4750')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (171, N'Vordingborg', N'4760')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (172, N'Kalvehave', N'4771')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (173, N'Langebæk', N'4772')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (174, N'Stensved', N'4773')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (175, N'Stege', N'4780')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (176, N'Borre', N'4791')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (177, N'Askeby', N'4792')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (178, N'BogøBy', N'4793')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (179, N'NykøbingFalster', N'4800')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (180, N'NørreAlslev', N'4840')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (181, N'Stubbekøbing', N'4850')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (182, N'Guldborg', N'4862')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (183, N'Eskilstrup', N'4863')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (184, N'Horbelev', N'4871')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (185, N'Idestrup', N'4872')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (186, N'Væggerløse', N'4873')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (187, N'Gedser', N'4874')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (188, N'Nysted', N'4880')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (189, N'TorebyLolland', N'4891')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (190, N'Kettinge', N'4892')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (191, N'ØsterUlslev', N'4894')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (192, N'Errindlev', N'4895')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (193, N'Nakskov', N'4900')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (194, N'Harpelunde', N'4912')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (195, N'Horslunde', N'4913')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (196, N'Søllested', N'4920')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (197, N'Maribo', N'4930')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (198, N'Bandholm', N'4941')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (199, N'TorrigLolland', N'4943')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (200, N'Fejø', N'4944')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (201, N'Nørreballe', N'4951')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (202, N'Stokkemarke', N'4952')
GO
print 'Processed 200 total records'
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (203, N'Vesterborg', N'4953')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (204, N'Holeby', N'4960')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (205, N'Rødby', N'4970')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (206, N'Dannemare', N'4983')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (207, N'Sakskøbing', N'4990')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (208, N'Rønne', N'3700')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (209, N'Aakirkeby', N'3720')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (210, N'Nexø', N'3730')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (211, N'Svaneke', N'3740')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (212, N'Østermarie', N'3751')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (213, N'Gudhjem', N'3760')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (214, N'Allinge', N'3770')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (215, N'Klemensker', N'3782')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (216, N'Hasle', N'3790')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (217, N'OdenseC', N'5000')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (218, N'OdenseC', N'5100')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (219, N'OdenseV', N'5200')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (220, N'OdenseNV', N'5210')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (221, N'OdenseSØ', N'5220')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (222, N'OdenseM', N'5230')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (223, N'OdenseNØ', N'5240')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (224, N'OdenseSV', N'5250')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (225, N'OdenseS', N'5260')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (226, N'OdenseN', N'5270')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (227, N'Marslev', N'5290')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (228, N'Kerteminde', N'5300')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (229, N'Agedrup', N'5320')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (230, N'Munkebo', N'5330')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (231, N'Rynkeby', N'5350')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (232, N'Mesinge', N'5370')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (233, N'Dalby', N'5380')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (234, N'Martofte', N'5390')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (235, N'Bogense', N'5400')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (236, N'Otterup', N'5450')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (237, N'Morud', N'5462')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (238, N'Harndrup', N'5463')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (239, N'BrenderupFyn', N'5464')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (240, N'Asperup', N'5466')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (241, N'Søndersø', N'5471')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (242, N'Veflinge', N'5474')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (243, N'Skamby', N'5485')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (244, N'Blommenslyst', N'5491')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (245, N'Vissenbjerg', N'5492')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (246, N'Middelfart', N'5500')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (247, N'Ullerslev', N'5540')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (248, N'Langeskov', N'5550')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (249, N'Aarup', N'5560')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (250, N'NørreAaby', N'5580')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (251, N'Gelsted', N'5591')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (252, N'Ejby', N'5592')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (253, N'Faaborg', N'5600')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (254, N'Assens', N'5610')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (255, N'Glamsbjerg', N'5620')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (256, N'Ebberup', N'5631')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (257, N'Millinge', N'5642')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (258, N'Broby', N'5672')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (259, N'Haarby', N'5683')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (260, N'Tommerup', N'5690')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (261, N'Svendborg', N'5700')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (262, N'Ringe', N'5750')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (263, N'VesterSkerninge', N'5762')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (264, N'Stenstrup', N'5771')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (265, N'Kværndrup', N'5772')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (266, N'Årslev', N'5792')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (267, N'Nyborg', N'5800')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (268, N'Ørbæk', N'5853')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (269, N'Gislev', N'5854')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (270, N'Ryslinge', N'5856')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (271, N'FerritslevFyn', N'5863')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (272, N'Frørup', N'5871')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (273, N'Hesselager', N'5874')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (274, N'SkårupFyn', N'5881')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (275, N'Vejstrup', N'5882')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (276, N'Oure', N'5883')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (277, N'Gudme', N'5884')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (278, N'GudbjergSydfyn', N'5892')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (279, N'Rudkøbing', N'5900')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (280, N'Humble', N'5932')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (281, N'Bagenkop', N'5935')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (282, N'Tranekær', N'5953')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (283, N'Marstal', N'5960')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (284, N'Ærøskøbing', N'5970')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (285, N'SøbyÆrø', N'5985')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (286, N'Kolding', N'6000')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (287, N'Egtved', N'6040')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (288, N'Almind', N'6051')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (289, N'Viuf', N'6052')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (290, N'Jordrup', N'6064')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (291, N'Christiansfeld', N'6070')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (292, N'Bjert', N'6091')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (293, N'SønderStenderup', N'6092')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (294, N'Sjølund', N'6093')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (295, N'Hejls', N'6094')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (296, N'Haderslev', N'6100')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (297, N'Aabenraa', N'6200')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (298, N'Rødekro', N'6230')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (299, N'Løgumkloster', N'6240')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (300, N'Bredebro', N'6261')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (301, N'Tønder', N'6270')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (302, N'Højer', N'6280')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (303, N'Gråsten', N'6300')
GO
print 'Processed 300 total records'
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (304, N'Broager', N'6310')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (305, N'Egernsund', N'6320')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (306, N'Padborg', N'6330')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (307, N'Kruså', N'6340')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (308, N'Tinglev', N'6360')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (309, N'Bylderup-Bov', N'6372')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (310, N'Bolderslev', N'6392')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (311, N'Sønderborg', N'6400')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (312, N'Nordborg', N'6430')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (313, N'Augustenborg', N'6440')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (314, N'Sydals', N'6470')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (315, N'Vojens', N'6500')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (316, N'Gram', N'6510')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (317, N'Toftlund', N'6520')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (318, N'Agerskov', N'6534')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (319, N'BranderupJylland', N'6535')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (320, N'Bevtoft', N'6541')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (321, N'Sommersted', N'6560')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (322, N'Vamdrup', N'6580')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (323, N'Vejen', N'6600')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (324, N'Gesten', N'6621')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (325, N'Bække', N'6622')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (326, N'Vorbasse', N'6623')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (327, N'Rødding', N'6630')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (328, N'Lunderskov', N'6640')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (329, N'Brørup', N'6650')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (330, N'Lintrup', N'6660')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (331, N'Holsted', N'6670')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (332, N'Hovborg', N'6682')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (333, N'Føvling', N'6683')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (334, N'Gørding', N'6690')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (335, N'Esbjerg', N'6700')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (336, N'EsbjergØ', N'6705')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (337, N'EsbjergV', N'6710')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (338, N'EsbjergN', N'6715')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (339, N'Fanø', N'6720')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (340, N'Tjæreborg', N'6731')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (341, N'Bramming', N'6740')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (342, N'Glejbjerg', N'6752')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (343, N'Agerbæk', N'6753')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (344, N'Ribe', N'6760')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (345, N'Gredstedbro', N'6771')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (346, N'Skærbæk', N'6780')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (347, N'Rømø', N'6792')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (348, N'Varde', N'6800')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (349, N'Årre', N'6818')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (350, N'Ansager', N'6823')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (351, N'NørreNebel', N'6830')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (352, N'Oksbøl', N'6840')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (353, N'JanderupVestjylland', N'6851')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (354, N'Billum', N'6852')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (355, N'VejersStrand', N'6853')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (356, N'Henne', N'6854')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (357, N'Outrup', N'6855')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (358, N'Blåvand', N'6857')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (359, N'Tistrup', N'6862')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (360, N'Ølgod', N'6870')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (361, N'Tarm', N'6880')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (362, N'Hemmet', N'6893')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (363, N'Skjern', N'6900')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (364, N'Videbæk', N'6920')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (365, N'Kibæk', N'6933')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (366, N'LemSt.', N'6940')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (367, N'Ringkøbing', N'6950')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (368, N'HvideSande', N'6960')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (369, N'Spjald', N'6971')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (370, N'Ørnhøj', N'6973')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (371, N'Tim', N'6980')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (372, N'Ulfborg', N'6990')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (373, N'Fredericia', N'7000')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (374, N'Børkop', N'7080')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (375, N'Vejle', N'7100')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (376, N'VejleØst', N'7120')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (377, N'Juelsminde', N'7130')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (378, N'Stouby', N'7140')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (379, N'Barrit', N'7150')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (380, N'Tørring', N'7160')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (381, N'Uldum', N'7171')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (382, N'Vonge', N'7173')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (383, N'Bredsten', N'7182')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (384, N'Randbøl', N'7183')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (385, N'Vandel', N'7184')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (386, N'Billund', N'7190')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (387, N'Grindsted', N'7200')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (388, N'Hejnsvig', N'7250')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (389, N'SønderOmme', N'7260')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (390, N'Stakroge', N'7270')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (391, N'SønderFelding', N'7280')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (392, N'Jelling', N'7300')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (393, N'Gadbjerg', N'7321')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (394, N'Give', N'7323')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (395, N'Brande', N'7330')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (396, N'Ejstrupholm', N'7361')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (397, N'Hampen', N'7362')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (398, N'Herning', N'7400')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (399, N'Ikast', N'7430')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (400, N'Bording', N'7441')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (401, N'Engesvang', N'7442')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (402, N'Sunds', N'7451')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (403, N'KarupJylland', N'7470')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (404, N'Vildbjerg', N'7480')
GO
print 'Processed 400 total records'
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (405, N'Aulum', N'7490')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (406, N'Holstebro', N'7500')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (407, N'Haderup', N'7540')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (408, N'Sørvad', N'7550')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (409, N'Hjerm', N'7560')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (410, N'Vemb', N'7570')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (411, N'Struer', N'7600')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (412, N'Lemvig', N'7620')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (413, N'Bøvlingbjerg', N'7650')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (414, N'Bækmarksbro', N'7660')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (415, N'Harboøre', N'7673')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (416, N'Thyborøn', N'7680')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (417, N'Thisted', N'7700')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (418, N'Hanstholm', N'7730')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (419, N'Frøstrup', N'7741')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (420, N'Vesløs', N'7742')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (421, N'Snedsted', N'7752')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (422, N'BedstedThy', N'7755')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (423, N'HurupThy', N'7760')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (424, N'Vestervig', N'7770')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (425, N'Thyholm', N'7790')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (426, N'Skive', N'7800')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (427, N'Vinderup', N'7830')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (428, N'Højslev', N'7840')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (429, N'StoholmJylland', N'7850')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (430, N'Spøttrup', N'7860')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (431, N'Roslev', N'7870')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (432, N'Fur', N'7884')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (433, N'NykøbingMors', N'7900')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (434, N'Erslev', N'7950')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (435, N'Karby', N'7960')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (436, N'RedstedMors', N'7970')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (437, N'Vils', N'7980')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (438, N'ØsterAssels', N'7990')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (439, N'ÅrhusC', N'8000')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (440, N'ÅrhusN', N'8200')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (441, N'ÅrhusV', N'8210')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (442, N'Brabrand', N'8220')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (443, N'Åbyhøj', N'8230')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (444, N'Risskov', N'8240')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (445, N'Egå', N'8250')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (446, N'VibyJylland', N'8260')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (447, N'Højbjerg', N'8270')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (448, N'Odder', N'8300')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (449, N'Samsø', N'8305')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (450, N'TranbjergJylland', N'8310')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (451, N'Mårslet', N'8320')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (452, N'Beder', N'8330')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (453, N'Malling', N'8340')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (454, N'Hundslund', N'8350')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (455, N'Solbjerg', N'8355')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (456, N'Hasselager', N'8361')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (457, N'Hørning', N'8362')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (458, N'Hadsten', N'8370')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (459, N'Trige', N'8380')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (460, N'Tilst', N'8381')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (461, N'Hinnerup', N'8382')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (462, N'Ebeltoft', N'8400')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (463, N'Rønde', N'8410')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (464, N'Knebel', N'8420')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (465, N'Balle', N'8444')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (466, N'Hammel', N'8450')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (467, N'HarlevJylland', N'8462')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (468, N'Galten', N'8464')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (469, N'Sabro', N'8471')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (470, N'Sporup', N'8472')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (471, N'Grenaa', N'8500')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (472, N'Lystrup', N'8520')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (473, N'Hjortshøj', N'8530')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (474, N'Skødstrup', N'8541')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (475, N'Hornslet', N'8543')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (476, N'Mørke', N'8544')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (477, N'Ryomgård', N'8550')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (478, N'Kolind', N'8560')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (479, N'Trustrup', N'8570')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (480, N'Nimtofte', N'8581')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (481, N'Glesborg', N'8585')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (482, N'ØrumDjurs', N'8586')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (483, N'Anholt', N'8592')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (484, N'Silkeborg', N'8600')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (485, N'Kjellerup', N'8620')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (486, N'Lemming', N'8632')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (487, N'Sorring', N'8641')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (488, N'AnsBy', N'8643')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (489, N'Them', N'8653')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (490, N'Bryrup', N'8654')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (491, N'Skanderborg', N'8660')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (492, N'Låsby', N'8670')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (493, N'Ry', N'8680')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (494, N'Horsens', N'8700')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (495, N'Daugård', N'8721')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (496, N'Hedensted', N'8722')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (497, N'Løsning', N'8723')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (498, N'Hovedgård', N'8732')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (499, N'Brædstrup', N'8740')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (500, N'Gedved', N'8751')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (501, N'Østbirk', N'8752')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (502, N'Flemming', N'8762')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (503, N'RaskMølle', N'8763')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (504, N'Klovborg', N'8765')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (505, N'NørreSnede', N'8766')
GO
print 'Processed 500 total records'
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (506, N'Stenderup', N'8781')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (507, N'Hornsyld', N'8783')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (508, N'Viborg', N'8800')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (509, N'Tjele', N'8830')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (510, N'Løgstrup', N'8831')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (511, N'Skals', N'8832')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (512, N'Rødkærsbro', N'8840')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (513, N'Bjerringbro', N'8850')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (514, N'Ulstrup', N'8860')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (515, N'Langå', N'8870')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (516, N'Thorsø', N'8881')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (517, N'Fårvang', N'8882')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (518, N'Gjern', N'8883')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (519, N'RandersC', N'8900')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (520, N'RandersNV', N'8920')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (521, N'RandersNØ', N'8930')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (522, N'RandersSV', N'8940')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (523, N'RandersSØ', N'8960')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (524, N'Ørsted', N'8950')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (525, N'Allingåbro', N'8961')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (526, N'Auning', N'8963')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (527, N'Havndal', N'8970')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (528, N'Spentrup', N'8981')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (529, N'GjerlevJylland', N'8983')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (530, N'Fårup', N'8990')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (531, N'Aalborg', N'9000')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (532, N'AalborgSV', N'9200')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (533, N'AalborgSØ', N'9210')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (534, N'AalborgØst', N'9220')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (535, N'SvenstrupJylland', N'9230')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (536, N'Nibe', N'9240')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (537, N'Gistrup', N'9260')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (538, N'Klarup', N'9270')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (539, N'Storvorde', N'9280')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (540, N'Kongerslev', N'9293')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (541, N'Sæby', N'9300')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (542, N'Vodskov', N'9310')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (543, N'Hjallerup', N'9320')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (544, N'Dronninglund', N'9330')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (545, N'Asaa', N'9340')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (546, N'Dybvad', N'9352')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (547, N'Gandrup', N'9362')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (548, N'Hals', N'9370')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (549, N'Vestbjerg', N'9380')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (550, N'Sulsted', N'9381')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (551, N'Tylstrup', N'9382')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (552, N'Nørresundby', N'9400')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (553, N'Vadum', N'9430')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (554, N'Aabybro', N'9440')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (555, N'Brovst', N'9460')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (556, N'Løkken-Vrå', N'9480')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (557, N'Pandrup', N'9490')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (558, N'Blokhus', N'9492')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (559, N'Saltum', N'9493')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (560, N'Hobro', N'9500')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (561, N'Arden', N'9510')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (562, N'Skørping', N'9520')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (563, N'Støvring', N'9530')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (564, N'Suldrup', N'9541')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (565, N'Mariager', N'9550')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (566, N'Hadsund', N'9560')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (567, N'Bælum', N'9574')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (568, N'Terndrup', N'9575')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (569, N'Aars', N'9600')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (570, N'Nørager', N'9610')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (571, N'Aalestrup', N'9620')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (572, N'Gedsted', N'9631')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (573, N'Møldrup', N'9632')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (574, N'Farsø', N'9640')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (575, N'Løgstør', N'9670')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (576, N'Ranum', N'9681')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (577, N'Fjerritslev', N'9690')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (578, N'Brønderslev', N'9700')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (579, N'JerslevJylland', N'9740')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (580, N'Østervrå', N'9750')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (581, N'Vrå', N'9760')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (582, N'Hjørring', N'9800')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (583, N'Tårs', N'9830')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (584, N'Hirtshals', N'9850')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (585, N'Sindal', N'9870')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (586, N'Bindslev', N'9881')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (587, N'Frederikshavn', N'9900')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (588, N'Læsø', N'9940')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (589, N'Strandby', N'9970')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (590, N'Jerup', N'9981')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (591, N'Ålbæk', N'9982')
INSERT [dbo].[tblCities] ([Id], [Name], [ZipCode]) VALUES (592, N'Skagen', N'9990')
/****** Object:  Table [dbo].[tblAccountStatus]    Script Date: 02/14/2014 12:29:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblAccountStatus](
	[Id] [int] NOT NULL,
	[Status] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
INSERT [dbo].[tblAccountStatus] ([Id], [Status]) VALUES (1, N'Active')
INSERT [dbo].[tblAccountStatus] ([Id], [Status]) VALUES (2, N'AuthorityLock')
INSERT [dbo].[tblAccountStatus] ([Id], [Status]) VALUES (3, N'FPLock')
INSERT [dbo].[tblAccountStatus] ([Id], [Status]) VALUES (4, N'Closed')
INSERT [dbo].[tblAccountStatus] ([Id], [Status]) VALUES (5, N'Inactive')
INSERT [dbo].[tblAccountStatus] ([Id], [Status]) VALUES (6, N'LockForDebitTransaction')
INSERT [dbo].[tblAccountStatus] ([Id], [Status]) VALUES (7, N'LockForCreditTransaction')
/****** Object:  Table [dbo].[tblAccountOpeningFields]    Script Date: 02/14/2014 12:29:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblAccountOpeningFields](
	[Id] [int] NOT NULL,
	[FieldName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tblAccountOpeningFields] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[tblAccountOpeningFields] ([Id], [FieldName]) VALUES (1, N'FirstName')
INSERT [dbo].[tblAccountOpeningFields] ([Id], [FieldName]) VALUES (2, N'MiddleName')
INSERT [dbo].[tblAccountOpeningFields] ([Id], [FieldName]) VALUES (3, N'LastName')
INSERT [dbo].[tblAccountOpeningFields] ([Id], [FieldName]) VALUES (4, N'Street')
INSERT [dbo].[tblAccountOpeningFields] ([Id], [FieldName]) VALUES (5, N'HouseNo')
INSERT [dbo].[tblAccountOpeningFields] ([Id], [FieldName]) VALUES (6, N'Floor')
INSERT [dbo].[tblAccountOpeningFields] ([Id], [FieldName]) VALUES (7, N'Side')
INSERT [dbo].[tblAccountOpeningFields] ([Id], [FieldName]) VALUES (8, N'ZipCode')
INSERT [dbo].[tblAccountOpeningFields] ([Id], [FieldName]) VALUES (9, N'City')
INSERT [dbo].[tblAccountOpeningFields] ([Id], [FieldName]) VALUES (10, N'Country')
INSERT [dbo].[tblAccountOpeningFields] ([Id], [FieldName]) VALUES (11, N'DateOfBirth')
INSERT [dbo].[tblAccountOpeningFields] ([Id], [FieldName]) VALUES (12, N'PrivatePhoneNo')
INSERT [dbo].[tblAccountOpeningFields] ([Id], [FieldName]) VALUES (13, N'FixedPhoneNumber')
INSERT [dbo].[tblAccountOpeningFields] ([Id], [FieldName]) VALUES (14, N'MobileNumber')
INSERT [dbo].[tblAccountOpeningFields] ([Id], [FieldName]) VALUES (15, N'WorkPhoneNumber')
INSERT [dbo].[tblAccountOpeningFields] ([Id], [FieldName]) VALUES (16, N'DirectPhoneNo')
INSERT [dbo].[tblAccountOpeningFields] ([Id], [FieldName]) VALUES (17, N'OfficeMobileNumber')
INSERT [dbo].[tblAccountOpeningFields] ([Id], [FieldName]) VALUES (18, N'CPRNumber')
INSERT [dbo].[tblAccountOpeningFields] ([Id], [FieldName]) VALUES (19, N'SocialSecurityNumber')
INSERT [dbo].[tblAccountOpeningFields] ([Id], [FieldName]) VALUES (20, N'CompanyName')
INSERT [dbo].[tblAccountOpeningFields] ([Id], [FieldName]) VALUES (21, N'CVRNumber')
INSERT [dbo].[tblAccountOpeningFields] ([Id], [FieldName]) VALUES (22, N'RegistrationNumberOfCompany')
INSERT [dbo].[tblAccountOpeningFields] ([Id], [FieldName]) VALUES (23, N'SelectionOfIndustryWhereCompanyOperates')
INSERT [dbo].[tblAccountOpeningFields] ([Id], [FieldName]) VALUES (24, N'BuildingNumber')
INSERT [dbo].[tblAccountOpeningFields] ([Id], [FieldName]) VALUES (25, N'DateOfIncorporation')
INSERT [dbo].[tblAccountOpeningFields] ([Id], [FieldName]) VALUES (26, N'RequestersFirstName')
INSERT [dbo].[tblAccountOpeningFields] ([Id], [FieldName]) VALUES (27, N'RequestersMiddleName')
INSERT [dbo].[tblAccountOpeningFields] ([Id], [FieldName]) VALUES (28, N'RequestersLastName')
INSERT [dbo].[tblAccountOpeningFields] ([Id], [FieldName]) VALUES (29, N'RequestersdesignationWithCompany')
INSERT [dbo].[tblAccountOpeningFields] ([Id], [FieldName]) VALUES (30, N'EmailAddress')
INSERT [dbo].[tblAccountOpeningFields] ([Id], [FieldName]) VALUES (31, N'InstituteName')
INSERT [dbo].[tblAccountOpeningFields] ([Id], [FieldName]) VALUES (32, N'RegistrationNumberOfPublicInstitute')
INSERT [dbo].[tblAccountOpeningFields] ([Id], [FieldName]) VALUES (33, N'SelectionOfIndustryWhereInstituteOperates')
INSERT [dbo].[tblAccountOpeningFields] ([Id], [FieldName]) VALUES (34, N'Gender')
INSERT [dbo].[tblAccountOpeningFields] ([Id], [FieldName]) VALUES (35, N'Industry')
INSERT [dbo].[tblAccountOpeningFields] ([Id], [FieldName]) VALUES (36, N'ResigtrationCountry')
