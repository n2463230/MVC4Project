USE [master]
GO
/****** Object:  Database [FPConfig]    Script Date: 02/14/2014 12:08:46 ******/
CREATE DATABASE [FPConfig] ON  PRIMARY 
( NAME = N'FPConfig', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\FPConfig.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'FPConfig_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\FPConfig_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [FPConfig] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FPConfig].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FPConfig] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [FPConfig] SET ANSI_NULLS OFF
GO
ALTER DATABASE [FPConfig] SET ANSI_PADDING OFF
GO
ALTER DATABASE [FPConfig] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [FPConfig] SET ARITHABORT OFF
GO
ALTER DATABASE [FPConfig] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [FPConfig] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [FPConfig] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [FPConfig] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [FPConfig] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [FPConfig] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [FPConfig] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [FPConfig] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [FPConfig] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [FPConfig] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [FPConfig] SET  DISABLE_BROKER
GO
ALTER DATABASE [FPConfig] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [FPConfig] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [FPConfig] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [FPConfig] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [FPConfig] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [FPConfig] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [FPConfig] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [FPConfig] SET  READ_WRITE
GO
ALTER DATABASE [FPConfig] SET RECOVERY FULL
GO
ALTER DATABASE [FPConfig] SET  MULTI_USER
GO
ALTER DATABASE [FPConfig] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [FPConfig] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'FPConfig', N'ON'
GO
USE [FPConfig]
GO
/****** Object:  Table [dbo].[tblAccountOpeningFormFields]    Script Date: 02/14/2014 12:08:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblAccountOpeningFormFields](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CountryId] [int] NOT NULL,
	[FieldId] [int] NOT NULL,
	[AccountTypeId] [int] NOT NULL,
	[IsRequired] [bit] NOT NULL,
	[IsVisible] [bit] NOT NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedBy] [varchar](50) NULL,
	[ModifiedOn] [datetime] NULL,
	[IPAddressOfLastAction] [varchar](50) NULL,
 CONSTRAINT [PK_tblAccountOpeningFormFields] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblPageSpecificPlaceholderConfig]    Script Date: 02/14/2014 12:08:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblPageSpecificPlaceholderConfig](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ModuleId] [int] NOT NULL,
	[TopFrameHTML] [varchar](50) NULL,
	[LeftFrameHTML] [varchar](50) NULL,
	[RightFrameHTML] [varchar](50) NULL,
	[BottomFrameHTML] [varchar](50) NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedBy] [varchar](50) NULL,
	[ModifiedOn] [datetime] NULL,
	[IPAddressOfLastAction] [varchar](50) NULL,
 CONSTRAINT [PK_tblPageSpecificPlaceholderConfig] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblMasterConfig]    Script Date: 02/14/2014 12:08:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblMasterConfig](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MinPasswordLength] [int] NOT NULL,
	[RequireNumberInPassword] [bit] NOT NULL,
	[RequireSpecialCharacterInPassword] [bit] NOT NULL,
	[MaxPasswordLife] [int] NOT NULL,
	[MaxLogonRetry] [int] NOT NULL,
	[PasswordHistoryCount] [int] NOT NULL,
	[AllowReusePasswordFromHistory] [bit] NOT NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedBy] [varchar](50) NULL,
	[ModifiedOn] [datetime] NULL,
	[IPAddressOfLastAction] [varchar](50) NULL,
	[DefaultEmailAddress] [varchar](255) NULL,
	[OutgoingEmailServer] [varchar](255) NULL,
	[SenderMailAddress] [varchar](255) NULL,
	[EmailAccountUserName] [varchar](50) NULL,
	[EmailAccountUserPassword] [nvarchar](max) NULL,
 CONSTRAINT [PK_tblMasterConfig] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblSystemWidePlaceholderConfig]    Script Date: 02/14/2014 12:08:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblSystemWidePlaceholderConfig](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GlobalTopFrameHTML] [varchar](50) NULL,
	[GlobalLeftFrameHTML] [varchar](50) NULL,
	[GlobalRightFrameHTML] [varchar](50) NULL,
	[GlobalBottomFrameHTML] [varchar](50) NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedBy] [varchar](50) NULL,
	[ModifiedOn] [datetime] NULL,
	[IPAddressOfLastAction] [varchar](50) NULL,
 CONSTRAINT [PK_tblSystemWidePlaceholderConfig] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblProcesses]    Script Date: 02/14/2014 12:08:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblProcesses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProcessName] [varchar](50) NOT NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedBy] [varchar](50) NULL,
	[ModifiedOn] [datetime] NULL,
	[IPAddressOfLastAction] [varchar](50) NULL,
 CONSTRAINT [PK_tblProcesses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[tblProcesses] ON
INSERT [dbo].[tblProcesses] ([Id], [ProcessName], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [IPAddressOfLastAction]) VALUES (1, N'User Registration Request', N'Paresh Rao', CAST(0x0000A2C300000000 AS DateTime), N'Paresh Rao', CAST(0x0000A2C300000000 AS DateTime), N'10.10.10.10')
INSERT [dbo].[tblProcesses] ([Id], [ProcessName], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [IPAddressOfLastAction]) VALUES (3, N'User Login', N'admin', CAST(0x0000A2C100CC8634 AS DateTime), N'admin', CAST(0x0000A2C200CC3255 AS DateTime), N'::1')
INSERT [dbo].[tblProcesses] ([Id], [ProcessName], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [IPAddressOfLastAction]) VALUES (4, N'Notification', N'admin', CAST(0x0000A2C100CD2246 AS DateTime), N'admin', CAST(0x0000A2C100CD2246 AS DateTime), N'::1')
INSERT [dbo].[tblProcesses] ([Id], [ProcessName], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [IPAddressOfLastAction]) VALUES (5, N'Advertisement', N'admin', CAST(0x0000A2C100CD3FC1 AS DateTime), N'admin', CAST(0x0000A2C100CD4078 AS DateTime), N'::1')
SET IDENTITY_INSERT [dbo].[tblProcesses] OFF
/****** Object:  Table [dbo].[tblProcessEmailTemplate]    Script Date: 02/14/2014 12:08:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblProcessEmailTemplate](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProcessId] [int] NOT NULL,
	[EmailContent] [ntext] NOT NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedBy] [varchar](50) NULL,
	[ModifiedOn] [datetime] NULL,
	[IPAddressOfLastAction] [varchar](50) NULL,
 CONSTRAINT [PK_tblProcessEmailTemplate] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblEmailQueue]    Script Date: 02/14/2014 12:08:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblEmailQueue](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Process] [int] NOT NULL,
	[Receiver] [varchar](255) NOT NULL,
	[UserId] [int] NULL,
	[FirstName] [varchar](50) NULL,
	[MiddleName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[HouseNo] [varchar](50) NULL,
	[Side] [varchar](50) NULL,
	[Door] [varchar](50) NULL,
	[Streetname] [varchar](255) NULL,
	[AdditionalAddress 1] [varchar](255) NULL,
	[AdditionalAddress 2] [varchar](255) NULL,
	[ZipCode] [varchar](50) NULL,
	[City] [varchar](255) NULL,
	[Country] [varchar](255) NULL,
	[DOB] [date] NULL,
	[Fixedphone] [varchar](50) NULL,
	[MobileNo] [varchar](50) NULL,
	[KYCStatus] [int] NULL,
	[AccountNo] [int] NULL,
	[AccountType] [varchar](50) NULL,
	[AdditionalInformation1] [varchar](max) NULL,
	[AdditionalInformation2] [varchar](max) NULL,
	[AdditionalInformation3] [varchar](max) NULL,
	[AdditionalInformation4] [varchar](max) NULL,
	[CreatedBy] [varchar](50) NULL,
	[CreatedOn] [datetime] NULL,
	[ErrorStatus] [varchar](max) NULL,
 CONSTRAINT [PK_tblEmailQueue] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[tblEmailQueue] ON
INSERT [dbo].[tblEmailQueue] ([Id], [Process], [Receiver], [UserId], [FirstName], [MiddleName], [LastName], [HouseNo], [Side], [Door], [Streetname], [AdditionalAddress 1], [AdditionalAddress 2], [ZipCode], [City], [Country], [DOB], [Fixedphone], [MobileNo], [KYCStatus], [AccountNo], [AccountType], [AdditionalInformation1], [AdditionalInformation2], [AdditionalInformation3], [AdditionalInformation4], [CreatedBy], [CreatedOn], [ErrorStatus]) VALUES (7, 4, N'jg@itmcsoft.com', 1, N'Jayesh', N'R.', N'Ginoya', N'11', N'Right', N'2', N'dbfdjbfldj', N'jgjlg', N'jllg', N'394305', N'Jamnagar', N'India', CAST(0x1F170B00 AS Date), N'99464644', N'64646464', NULL, 646464, N'Saving', N'nd;snf;dsn', N'nd;fns;nf', N'dk;nfd;nf', N'd;kfndfn', N'admin', CAST(0x0000917600000000 AS DateTime), N'The SMTP server requires a secure connection or the client was not authenticated. The server response was: 5.5.1 Authentication Required. Learn more at')
SET IDENTITY_INSERT [dbo].[tblEmailQueue] OFF
/****** Object:  Table [dbo].[tblEmailLog]    Script Date: 02/14/2014 12:08:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblEmailLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Process] [int] NOT NULL,
	[EmailBody] [varchar](max) NOT NULL,
	[Receiver] [varchar](255) NOT NULL,
	[SentTime] [datetime] NOT NULL,
 CONSTRAINT [PK_tblEmailLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[tblEmailLog] ON
INSERT [dbo].[tblEmailLog] ([Id], [Process], [EmailBody], [Receiver], [SentTime]) VALUES (1, 3, N'<html>
<head>
    <!-- If you delete this meta tag, Half Life 3 will never be released. -->
    <meta name="viewport" content="width=device-width" />
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <style type="text/css">
        /* ------------------------------------- 
		GLOBAL 
------------------------------------- */
        * {
            margin: 0;
            padding: 0;
        }

        * {
            font-family: "Helvetica Neue", "Helvetica", Helvetica, Arial, sans-serif;
        }

        img {
            max-width: 100%;
        }

        .collapse {
            margin: 0;
            padding: 0;
        }

        body {
            -webkit-font-smoothing: antialiased;
            -webkit-text-size-adjust: none;
            width: 100%!important;
            height: 100%;
        }


        /* ------------------------------------- 
		ELEMENTS 
------------------------------------- */
        a {
            color: #2BA6CB;
        }

        .btn {
            text-decoration: none;
            color: #FFF;
            background-color: #666;
            padding: 10px 16px;
            font-weight: bold;
            margin-right: 10px;
            text-align: center;
            cursor: pointer;
            display: inline-block;
        }

        p.callout {
            padding: 15px;
            background-color: #ECF8FF;
            margin-bottom: 15px;
        }

        .callout a {
            font-weight: bold;
            color: #2BA6CB;
        }

        table.social {
            /* 	padding:15px; */
            background-color: #ebebeb;
        }

        .social .soc-btn {
            padding: 3px 7px;
            font-size: 12px;
            margin-bottom: 10px;
            text-decoration: none;
            color: #FFF;
            font-weight: bold;
            display: block;
            text-align: center;
        }

        a.fb {
            background-color: #3B5998!important;
        }

        a.tw {
            background-color: #1daced!important;
        }

        a.gp {
            background-color: #DB4A39!important;
        }

        a.ms {
            background-color: #000!important;
        }

        .sidebar .soc-btn {
            display: block;
            width: 100%;
        }

        /* ------------------------------------- 
		HEADER 
------------------------------------- */
        table.head-wrap {
            width: 100%;
        }

        .header.container table td.logo {
            padding: 15px;
        }

        .header.container table td.label {
            padding: 15px;
            padding-left: 0px;
        }


        /* ------------------------------------- 
		BODY 
------------------------------------- */
        table.body-wrap {
            width: 100%;
        }


        /* ------------------------------------- 
		FOOTER 
------------------------------------- */
        table.footer-wrap {
            width: 100%;
            clear: both!important;
        }

        .footer-wrap .container td.content p {
            border-top: 1px solid rgb(215,215,215);
            padding-top: 15px;
        }

        .footer-wrap .container td.content p {
            font-size: 10px;
            font-weight: bold;
        }


        /* ------------------------------------- 
		TYPOGRAPHY 
------------------------------------- */
        h1, h2, h3, h4, h5, h6 {
            font-family: "HelveticaNeue-Light", "Helvetica Neue Light", "Helvetica Neue", Helvetica, Arial, "Lucida Grande", sans-serif;
            line-height: 1.1;
            margin-bottom: 15px;
            color: #000;
        }

            h1 small, h2 small, h3 small, h4 small, h5 small, h6 small {
                font-size: 60%;
                color: #6f6f6f;
                line-height: 0;
                text-transform: none;
            }

        h1 {
            font-weight: 200;
            font-size: 44px;
        }

        h2 {
            font-weight: 200;
            font-size: 37px;
        }

        h3 {
            font-weight: 500;
            font-size: 27px;
        }

        h4 {
            font-weight: 500;
            font-size: 23px;
        }

        h5 {
            font-weight: 900;
            font-size: 17px;
        }

        h6 {
            font-weight: 900;
            font-size: 14px;
            text-transform: uppercase;
            color: #444;
        }

        .collapse {
            margin: 0!important;
        }

        p, ul {
            margin-bottom: 10px;
            font-weight: normal;
            font-size: 14px;
            line-height: 1.6;
        }

            p.lead {
                font-size: 17px;
            }

            p.last {
                margin-bottom: 0px;
            }

            ul li {
                margin-left: 5px;
                list-style-position: inside;
            }

            /* ------------------------------------- 
		SIDEBAR 
------------------------------------- */
            ul.sidebar {
                background: #ebebeb;
                display: block;
                list-style-type: none;
            }

                ul.sidebar li {
                    display: block;
                    margin: 0;
                }

                    ul.sidebar li a {
                        text-decoration: none;
                        color: #666;
                        padding: 10px 16px;
                        /* 	font-weight:bold; */
                        margin-right: 10px;
                        /* 	text-align:center; */
                        cursor: pointer;
                        border-bottom: 1px solid #777777;
                        border-top: 1px solid #FFFFFF;
                        display: block;
                        margin: 0;
                    }

                        ul.sidebar li a.last {
                            border-bottom-width: 0px;
                        }

                        ul.sidebar li a h1, ul.sidebar li a h2, ul.sidebar li a h3, ul.sidebar li a h4, ul.sidebar li a h5, ul.sidebar li a h6, ul.sidebar li a p {
                            margin-bottom: 0!important;
                        }



        /* --------------------------------------------------- 
		RESPONSIVENESS
		Nuke it from orbit. Its the only way to be sure. 
------------------------------------------------------ */

        /* Set a max-width, and make it display as block so it will automatically stretch to that width, but will also shrink down on a phone or something */
        .container {
            display: block!important;
            max-width: 600px!important;
            margin: 0 auto!important; /* makes it centered */
            clear: both!important;
        }

        /* This should also be a block element, so that it will fill 100% of the .container */
        .content {
            padding: 15px;
            max-width: 600px;
            margin: 0 auto;
            display: block;
        }

            /* Lets make sure tables in the content area are 100% wide */
            .content table {
                width: 100%;
            }


        /* Odds and ends */
        .column {
            width: 300px;
            float: left;
        }

            .column tr td {
                padding: 15px;
            }

        .column-wrap {
            padding: 0!important;
            margin: 0 auto;
            max-width: 600px!important;
        }

        .column table {
            width: 100%;
        }

        .social .column {
            width: 280px;
            min-width: 279px;
            float: left;
        }

        /* Be sure to place a .clear element after each set of columns, just to be safe */
        .clear {
            display: block;
            clear: both;
        }


        /* ------------------------------------------- 
		PHONE
		For clients that support media queries.
		Nothing fancy. 
-------------------------------------------- */
        @media only screen and (max-width: 600px) {

            a[class="btn"] {
                display: block!important;
                margin-bottom: 10px!important;
                background-image: none!important;
                margin-right: 0!important;
            }

            div[class="column"] {
                width: auto!important;
                float: none!important;
            }

            table.social div[class="column"] {
                width: auto!important;
            }
        }
    </style>
</head>

<body bgcolor="#FFFFFF">

    <!-- HEADER -->

    <!-- /HEADER -->


    <!-- BODY -->
    <table class="body-wrap">
        <tr>
            <td></td>
            <td class="container" bgcolor="#FFFFFF">

                <div class="content">
                    <table style="font-size: 12px">
                        <tr>
                            <td>
                                <h2>User Login</h2>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                        </tr>
                        <tr>
                            <td>
                                <h5>Hi, Anuj P Rohila { 15-12-1990 00:00:00 } </h5>
                                <table>
                                    <tr>
                                        <td>10 Left 1 Gopal Krishna
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Garden
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Siillk
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Surat India 394305
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>0261-123456 , 9999999999
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Account Info : 134646464 , Saving
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Hello This is Additional1 <br /> Hello This is Additional2 <br /> Hello This is Additional3 <br /> Hello This is Additional4 
                                        </td>
                                    </tr>
                                </table>
                                <p></p>
                                <p>
                                    This is testing of user.
                                </p>
                                <p>
                                </p>
                                <!-- /Callout Panel -->

                                <!-- social & contact -->
                                <table class="social" width="100%">
                                    <tr>
                                        <td>

                                            <!-- column 1 -->
                                            <table align="left" class="column">
                                                <tr>
                                                    <td>

                                                        <h5 class="">Connect with Us:</h5>
                                                        <p class=""><a href="#" class="soc-btn fb">Facebook</a> <a href="#" class="soc-btn tw">Twitter</a> <a href="#" class="soc-btn gp">Google+</a></p>


                                                    </td>
                                                </tr>
                                            </table>
                                            <!-- /column 1 -->

                                            <!-- column 2 -->
                                            <table align="left" class="column">
                                                <tr>
                                                    <td>

                                                        <h5 class="">Contact Info:</h5>
                                                        <p>
                                                            Phone: <strong>XXX.XXX.XXXX</strong><br />
                                                            Email: <strong><a href="emailto:hseldon@trantor.com">xxx@xxx.com</a></strong>
                                                        </p>

                                                    </td>
                                                </tr>
                                            </table>
                                            <!-- /column 2 -->

                                            <span class="clear"></span>

                                        </td>
                                    </tr>
                                </table>
                                <!-- /social & contact -->

                            </td>
                        </tr>
                    </table>
                </div>
                <!-- /content -->

            </td>
            <td></td>
        </tr>
    </table>
    <!-- /BODY -->

    <!-- FOOTER -->
    <table class="footer-wrap">
        <tr>
            <td></td>
            <td class="container">

                <!-- content -->
                <div class="content">
                    <table>
                        <tr>
                            <td align="center">
                                <p>
                                    <a href="#">Terms</a> |
						
                                    <a href="#">Privacy</a> |
						
                                    <a href="#">
                                        <unsubscribe>Unsubscribe</unsubscribe>
                                    </a>
                                </p>
                            </td>
                        </tr>
                    </table>
                </div>
                <!-- /content -->

            </td>
            <td></td>
        </tr>
    </table>
    <!-- /FOOTER -->

</body>
</html>
', N'aro@itmcsoft.com', CAST(0x0000A2C3009C57EF AS DateTime))
INSERT [dbo].[tblEmailLog] ([Id], [Process], [EmailBody], [Receiver], [SentTime]) VALUES (2, 4, N'<html>
<head>
    <!-- If you delete this meta tag, Half Life 3 will never be released. -->
    <meta name="viewport" content="width=device-width" />
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <style type="text/css">
        /* ------------------------------------- 
		GLOBAL 
------------------------------------- */
        * {
            margin: 0;
            padding: 0;
        }

        * {
            font-family: "Helvetica Neue", "Helvetica", Helvetica, Arial, sans-serif;
        }

        img {
            max-width: 100%;
        }

        .collapse {
            margin: 0;
            padding: 0;
        }

        body {
            -webkit-font-smoothing: antialiased;
            -webkit-text-size-adjust: none;
            width: 100%!important;
            height: 100%;
        }


        /* ------------------------------------- 
		ELEMENTS 
------------------------------------- */
        a {
            color: #2BA6CB;
        }

        .btn {
            text-decoration: none;
            color: #FFF;
            background-color: #666;
            padding: 10px 16px;
            font-weight: bold;
            margin-right: 10px;
            text-align: center;
            cursor: pointer;
            display: inline-block;
        }

        p.callout {
            padding: 15px;
            background-color: #ECF8FF;
            margin-bottom: 15px;
        }

        .callout a {
            font-weight: bold;
            color: #2BA6CB;
        }

        table.social {
            /* 	padding:15px; */
            background-color: #ebebeb;
        }

        .social .soc-btn {
            padding: 3px 7px;
            font-size: 12px;
            margin-bottom: 10px;
            text-decoration: none;
            color: #FFF;
            font-weight: bold;
            display: block;
            text-align: center;
        }

        a.fb {
            background-color: #3B5998!important;
        }

        a.tw {
            background-color: #1daced!important;
        }

        a.gp {
            background-color: #DB4A39!important;
        }

        a.ms {
            background-color: #000!important;
        }

        .sidebar .soc-btn {
            display: block;
            width: 100%;
        }

        /* ------------------------------------- 
		HEADER 
------------------------------------- */
        table.head-wrap {
            width: 100%;
        }

        .header.container table td.logo {
            padding: 15px;
        }

        .header.container table td.label {
            padding: 15px;
            padding-left: 0px;
        }


        /* ------------------------------------- 
		BODY 
------------------------------------- */
        table.body-wrap {
            width: 100%;
        }


        /* ------------------------------------- 
		FOOTER 
------------------------------------- */
        table.footer-wrap {
            width: 100%;
            clear: both!important;
        }

        .footer-wrap .container td.content p {
            border-top: 1px solid rgb(215,215,215);
            padding-top: 15px;
        }

        .footer-wrap .container td.content p {
            font-size: 10px;
            font-weight: bold;
        }


        /* ------------------------------------- 
		TYPOGRAPHY 
------------------------------------- */
        h1, h2, h3, h4, h5, h6 {
            font-family: "HelveticaNeue-Light", "Helvetica Neue Light", "Helvetica Neue", Helvetica, Arial, "Lucida Grande", sans-serif;
            line-height: 1.1;
            margin-bottom: 15px;
            color: #000;
        }

            h1 small, h2 small, h3 small, h4 small, h5 small, h6 small {
                font-size: 60%;
                color: #6f6f6f;
                line-height: 0;
                text-transform: none;
            }

        h1 {
            font-weight: 200;
            font-size: 44px;
        }

        h2 {
            font-weight: 200;
            font-size: 37px;
        }

        h3 {
            font-weight: 500;
            font-size: 27px;
        }

        h4 {
            font-weight: 500;
            font-size: 23px;
        }

        h5 {
            font-weight: 900;
            font-size: 17px;
        }

        h6 {
            font-weight: 900;
            font-size: 14px;
            text-transform: uppercase;
            color: #444;
        }

        .collapse {
            margin: 0!important;
        }

        p, ul {
            margin-bottom: 10px;
            font-weight: normal;
            font-size: 14px;
            line-height: 1.6;
        }

            p.lead {
                font-size: 17px;
            }

            p.last {
                margin-bottom: 0px;
            }

            ul li {
                margin-left: 5px;
                list-style-position: inside;
            }

            /* ------------------------------------- 
		SIDEBAR 
------------------------------------- */
            ul.sidebar {
                background: #ebebeb;
                display: block;
                list-style-type: none;
            }

                ul.sidebar li {
                    display: block;
                    margin: 0;
                }

                    ul.sidebar li a {
                        text-decoration: none;
                        color: #666;
                        padding: 10px 16px;
                        /* 	font-weight:bold; */
                        margin-right: 10px;
                        /* 	text-align:center; */
                        cursor: pointer;
                        border-bottom: 1px solid #777777;
                        border-top: 1px solid #FFFFFF;
                        display: block;
                        margin: 0;
                    }

                        ul.sidebar li a.last {
                            border-bottom-width: 0px;
                        }

                        ul.sidebar li a h1, ul.sidebar li a h2, ul.sidebar li a h3, ul.sidebar li a h4, ul.sidebar li a h5, ul.sidebar li a h6, ul.sidebar li a p {
                            margin-bottom: 0!important;
                        }



        /* --------------------------------------------------- 
		RESPONSIVENESS
		Nuke it from orbit. Its the only way to be sure. 
------------------------------------------------------ */

        /* Set a max-width, and make it display as block so it will automatically stretch to that width, but will also shrink down on a phone or something */
        .container {
            display: block!important;
            max-width: 600px!important;
            margin: 0 auto!important; /* makes it centered */
            clear: both!important;
        }

        /* This should also be a block element, so that it will fill 100% of the .container */
        .content {
            padding: 15px;
            max-width: 600px;
            margin: 0 auto;
            display: block;
        }

            /* Lets make sure tables in the content area are 100% wide */
            .content table {
                width: 100%;
            }


        /* Odds and ends */
        .column {
            width: 300px;
            float: left;
        }

            .column tr td {
                padding: 15px;
            }

        .column-wrap {
            padding: 0!important;
            margin: 0 auto;
            max-width: 600px!important;
        }

        .column table {
            width: 100%;
        }

        .social .column {
            width: 280px;
            min-width: 279px;
            float: left;
        }

        /* Be sure to place a .clear element after each set of columns, just to be safe */
        .clear {
            display: block;
            clear: both;
        }


        /* ------------------------------------------- 
		PHONE
		For clients that support media queries.
		Nothing fancy. 
-------------------------------------------- */
        @media only screen and (max-width: 600px) {

            a[class="btn"] {
                display: block!important;
                margin-bottom: 10px!important;
                background-image: none!important;
                margin-right: 0!important;
            }

            div[class="column"] {
                width: auto!important;
                float: none!important;
            }

            table.social div[class="column"] {
                width: auto!important;
            }
        }
    </style>
</head>

<body bgcolor="#FFFFFF">

    <!-- HEADER -->

    <!-- /HEADER -->


    <!-- BODY -->
    <table class="body-wrap">
        <tr>
            <td></td>
            <td class="container" bgcolor="#FFFFFF">

                <div class="content">
                    <table style="font-size: 12px">
                        <tr>
                            <td>
                                <h2>Notification</h2>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                        </tr>
                        <tr>
                            <td>
                                <h5>Hi, Jayesh J Ginoya { 10-10-1988 00:00:00 } </h5>
                                <table>
                                    <tr>
                                        <td>13 Right 2 Ganpat
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Raju Pan Wala
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>In upper
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Vadodara India 390002
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>64464-446464 , 64646464644
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Account Info : 74644646 , Saving
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Hello This is Additional1 <br /> Hello This is Additional2 <br /> Hello This is Additional3 <br /> Hello This is Additional4 
                                        </td>
                                    </tr>
                                </table>
                                <p></p>
                                <p>
                                    This is testing of user.
                                </p>
                                <p>
                                </p>
                                <!-- /Callout Panel -->

                                <!-- social & contact -->
                                <table class="social" width="100%">
                                    <tr>
                                        <td>

                                            <!-- column 1 -->
                                            <table align="left" class="column">
                                                <tr>
                                                    <td>

                                                        <h5 class="">Connect with Us:</h5>
                                                        <p class=""><a href="#" class="soc-btn fb">Facebook</a> <a href="#" class="soc-btn tw">Twitter</a> <a href="#" class="soc-btn gp">Google+</a></p>


                                                    </td>
                                                </tr>
                                            </table>
                                            <!-- /column 1 -->

                                            <!-- column 2 -->
                                            <table align="left" class="column">
                                                <tr>
                                                    <td>

                                                        <h5 class="">Contact Info:</h5>
                                                        <p>
                                                            Phone: <strong>XXX.XXX.XXXX</strong><br />
                                                            Email: <strong><a href="emailto:hseldon@trantor.com">xxx@xxx.com</a></strong>
                                                        </p>

                                                    </td>
                                                </tr>
                                            </table>
                                            <!-- /column 2 -->

                                            <span class="clear"></span>

                                        </td>
                                    </tr>
                                </table>
                                <!-- /social & contact -->

                            </td>
                        </tr>
                    </table>
                </div>
                <!-- /content -->

            </td>
            <td></td>
        </tr>
    </table>
    <!-- /BODY -->

    <!-- FOOTER -->
    <table class="footer-wrap">
        <tr>
            <td></td>
            <td class="container">

                <!-- content -->
                <div class="content">
                    <table>
                        <tr>
                            <td align="center">
                                <p>
                                    <a href="#">Terms</a> |
						
                                    <a href="#">Privacy</a> |
						
                                    <a href="#">
                                        <unsubscribe>Unsubscribe</unsubscribe>
                                    </a>
                                </p>
                            </td>
                        </tr>
                    </table>
                </div>
                <!-- /content -->

            </td>
            <td></td>
        </tr>
    </table>
    <!-- /FOOTER -->

</body>
</html>
', N'anuj.rohila94@gmail.com', CAST(0x0000A2C3009C7EDE AS DateTime))
INSERT [dbo].[tblEmailLog] ([Id], [Process], [EmailBody], [Receiver], [SentTime]) VALUES (3, 5, N'<html>
<head>
    <title></title>
</head>
<body>
    <table>
        <tr>
            <td>
                Receiver
            </td>
            <td>
                aro@itmcsoft.com
            </td>
        </tr>
        <tr>
            <td>
                FirstName
            </td>
            <td>
                Nisarg
            </td>
        </tr>
        <tr>
            <td>
                MiddleName
            </td>
            <td>
                S
            </td>
        </tr>
        <tr>
            <td>
                LastName
            </td>
            <td>
                Shah
            </td>
        </tr>
        <tr>
            <td>
                HouseNo
            </td>
            <td>
                979
            </td>
        </tr>
        <tr>
            <td>
                Side
            </td>
            <td>
                Upper
            </td>
        </tr>
        <tr>
            <td>
                Door
            </td>
            <td>
                5
            </td>
        </tr>
        <tr>
            <td>
                Streetname
            </td>
            <td>
                Cascade Complex
            </td>
        </tr>
        <tr>
            <td>
                AdditionalAddress_1
            </td>
            <td>
                Channi Circle
            </td>
        </tr>
        <tr>
            <td>
                AdditionalAddress_2
            </td>
            <td>
                Nizampura
            </td>
        </tr>
        <tr>
            <td>
                ZipCode
            </td>
            <td>
                39002
            </td>
        </tr>
        <tr>
            <td>
                City
            </td>
            <td>
                vadodara
            </td>
        </tr>
        <tr>
            <td>
                Country
            </td>
            <td>
                India
            </td>
        </tr>
        <tr>
            <td>
                DOB
            </td>
            <td>
                10-10-1987 00:00:00
            </td>
        </tr>
        <tr>
            <td>
                Fixedphone
            </td>
            <td>
                164-64646464
            </td>
        </tr>
        <tr>
            <td>
                MobileNo
            </td>
            <td>
                6464646464
            </td>
        </tr>
        <tr>
            <td>
                KYCStatus
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                AccountNo
            </td>
            <td>
                4664646
            </td>
        </tr>
        <tr>
            <td>
                AccountType
            </td>
            <td>
                Current
            </td>
        </tr>
        <tr>
            <td>
                AdditionalInformation1
            </td>
            <td>
                Hello This is Additional1
            </td>
        </tr>
        <tr>
            <td>
                AdditionalInformation2
            </td>
            <td>
                Hello This is Additional2
            </td>
        </tr>
        <tr>
            <td>
                AdditionalInformation3
            </td>
            <td>
                Hello This is Additional3
            </td>
        </tr>
        <tr>
            <td>
                AdditionalInformation4
            </td>
            <td>
                Hello This is Additional4
            </td>
        </tr>
        <tr>
            <td>
                CreatedBy
            </td>
            <td>
                admin
            </td>
        </tr>
        <tr>
            <td>
                CreatedOn
            </td>
            <td>
                28-01-2014 15:29:10
            </td>
        </tr>
        <tr>
            <td>
                ProcessName
            </td>
            <td>
                Advertisement
            </td>
        </tr>
    </table>
</body>
</html>
', N'aro@itmcsoft.com', CAST(0x0000A2C701151EE7 AS DateTime))
INSERT [dbo].[tblEmailLog] ([Id], [Process], [EmailBody], [Receiver], [SentTime]) VALUES (4, 3, N'<html>
<head>
    <title></title>
</head>
<body>
    <table>
        <tr>
            <td>
                Receiver
            </td>
            <td>
                anuj.rohila94@gmail.com
            </td>
        </tr>
        <tr>
            <td>
                FirstName
            </td>
            <td>
                Anuj
            </td>
        </tr>
        <tr>
            <td>
                MiddleName
            </td>
            <td>
                Pawan
            </td>
        </tr>
        <tr>
            <td>
                LastName
            </td>
            <td>
                Rohila
            </td>
        </tr>
        <tr>
            <td>
                HouseNo
            </td>
            <td>
                10
            </td>
        </tr>
        <tr>
            <td>
                Side
            </td>
            <td>
                Left
            </td>
        </tr>
        <tr>
            <td>
                Door
            </td>
            <td>
                1
            </td>
        </tr>
        <tr>
            <td>
                Streetname
            </td>
            <td>
                Gopal Krishna 
            </td>
        </tr>
        <tr>
            <td>
                AdditionalAddress_1
            </td>
            <td>
                labsd
            </td>
        </tr>
        <tr>
            <td>
                AdditionalAddress_2
            </td>
            <td>
                bljbblbl
            </td>
        </tr>
        <tr>
            <td>
                ZipCode
            </td>
            <td>
                394305
            </td>
        </tr>
        <tr>
            <td>
                City
            </td>
            <td>
                Surat
            </td>
        </tr>
        <tr>
            <td>
                Country
            </td>
            <td>
                Gujarat
            </td>
        </tr>
        <tr>
            <td>
                DOB
            </td>
            <td>
                15-12-1990 00:00:00
            </td>
        </tr>
        <tr>
            <td>
                Fixedphone
            </td>
            <td>
                12345678
            </td>
        </tr>
        <tr>
            <td>
                MobileNo
            </td>
            <td>
                9694646464
            </td>
        </tr>
        <tr>
            <td>
                KYCStatus
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                AccountNo
            </td>
            <td>
                5454464
            </td>
        </tr>
        <tr>
            <td>
                AccountType
            </td>
            <td>
                Saving
            </td>
        </tr>
        <tr>
            <td>
                AdditionalInformation1
            </td>
            <td>
                dnsfnsdfn;
            </td>
        </tr>
        <tr>
            <td>
                AdditionalInformation2
            </td>
            <td>
                n;dnf;dsn
            </td>
        </tr>
        <tr>
            <td>
                AdditionalInformation3
            </td>
            <td>
                ds;nd;n
            </td>
        </tr>
        <tr>
            <td>
                AdditionalInformation4
            </td>
            <td>
                k;dndsnf;d
            </td>
        </tr>
        <tr>
            <td>
                CreatedBy
            </td>
            <td>
                admin
            </td>
        </tr>
        <tr>
            <td>
                CreatedOn
            </td>
            <td>
                10-10-2012 00:00:00
            </td>
        </tr>
        <tr>
            <td>
                ProcessName
            </td>
            <td>
                User Login
            </td>
        </tr>
    </table>
</body>
</html>
', N'anuj.rohila94@gmail.com', CAST(0x0000A2C701163090 AS DateTime))
INSERT [dbo].[tblEmailLog] ([Id], [Process], [EmailBody], [Receiver], [SentTime]) VALUES (5, 3, N'<html>
<head>
    <title></title>
</head>
<body>
    <table>
        <tr>
            <td>
                Receiver
            </td>
            <td>
                anuj.rohila94@gmail.com
            </td>
        </tr>
        <tr>
            <td>
                FirstName
            </td>
            <td>
                Anuj
            </td>
        </tr>
        <tr>
            <td>
                MiddleName
            </td>
            <td>
                P
            </td>
        </tr>
        <tr>
            <td>
                LastName
            </td>
            <td>
                Rohila
            </td>
        </tr>
        <tr>
            <td>
                HouseNo
            </td>
            <td>
                10
            </td>
        </tr>
        <tr>
            <td>
                Side
            </td>
            <td>
                Left
            </td>
        </tr>
        <tr>
            <td>
                Door
            </td>
            <td>
                1
            </td>
        </tr>
        <tr>
            <td>
                Streetname
            </td>
            <td>
                Gopal Krishna
            </td>
        </tr>
        <tr>
            <td>
                AdditionalAddress_1
            </td>
            <td>
                jgjlg
            </td>
        </tr>
        <tr>
            <td>
                AdditionalAddress_2
            </td>
            <td>
                jllg
            </td>
        </tr>
        <tr>
            <td>
                ZipCode
            </td>
            <td>
                390002
            </td>
        </tr>
        <tr>
            <td>
                City
            </td>
            <td>
                Surat
            </td>
        </tr>
        <tr>
            <td>
                Country
            </td>
            <td>
                India
            </td>
        </tr>
        <tr>
            <td>
                DOB
            </td>
            <td>
                15-12-1990 00:00:00
            </td>
        </tr>
        <tr>
            <td>
                Fixedphone
            </td>
            <td>
                99464644
            </td>
        </tr>
        <tr>
            <td>
                MobileNo
            </td>
            <td>
                64646464
            </td>
        </tr>
        <tr>
            <td>
                KYCStatus
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                AccountNo
            </td>
            <td>
                646464
            </td>
        </tr>
        <tr>
            <td>
                AccountType
            </td>
            <td>
                Saving
            </td>
        </tr>
        <tr>
            <td>
                AdditionalInformation1
            </td>
            <td>
                nd;snf;dsn
            </td>
        </tr>
        <tr>
            <td>
                AdditionalInformation2
            </td>
            <td>
                nd;fns;nf
            </td>
        </tr>
        <tr>
            <td>
                AdditionalInformation3
            </td>
            <td>
                dk;nfd;nf
            </td>
        </tr>
        <tr>
            <td>
                AdditionalInformation4
            </td>
            <td>
                d;kfndfn
            </td>
        </tr>
        <tr>
            <td>
                CreatedBy
            </td>
            <td>
                admin
            </td>
        </tr>
        <tr>
            <td>
                CreatedOn
            </td>
            <td>
                15-12-2001 00:00:00
            </td>
        </tr>
        <tr>
            <td>
                ProcessName
            </td>
            <td>
                User Login
            </td>
        </tr>
    </table>
</body>
</html>
', N'anuj.rohila94@gmail.com', CAST(0x0000A2C7012DE12A AS DateTime))
SET IDENTITY_INSERT [dbo].[tblEmailLog] OFF
/****** Object:  ForeignKey [FK_tblProcessEmailTemplate_tblProcesses]    Script Date: 02/14/2014 12:08:55 ******/
ALTER TABLE [dbo].[tblProcessEmailTemplate]  WITH CHECK ADD  CONSTRAINT [FK_tblProcessEmailTemplate_tblProcesses] FOREIGN KEY([ProcessId])
REFERENCES [dbo].[tblProcesses] ([Id])
GO
ALTER TABLE [dbo].[tblProcessEmailTemplate] CHECK CONSTRAINT [FK_tblProcessEmailTemplate_tblProcesses]
GO
/****** Object:  ForeignKey [FK_tblEmailQueue_tblProcesses]    Script Date: 02/14/2014 12:08:55 ******/
ALTER TABLE [dbo].[tblEmailQueue]  WITH CHECK ADD  CONSTRAINT [FK_tblEmailQueue_tblProcesses] FOREIGN KEY([Process])
REFERENCES [dbo].[tblProcesses] ([Id])
GO
ALTER TABLE [dbo].[tblEmailQueue] CHECK CONSTRAINT [FK_tblEmailQueue_tblProcesses]
GO
/****** Object:  ForeignKey [FK_tblEmailLog_tblProcesses]    Script Date: 02/14/2014 12:08:55 ******/
ALTER TABLE [dbo].[tblEmailLog]  WITH CHECK ADD  CONSTRAINT [FK_tblEmailLog_tblProcesses] FOREIGN KEY([Process])
REFERENCES [dbo].[tblProcesses] ([Id])
GO
ALTER TABLE [dbo].[tblEmailLog] CHECK CONSTRAINT [FK_tblEmailLog_tblProcesses]
GO
