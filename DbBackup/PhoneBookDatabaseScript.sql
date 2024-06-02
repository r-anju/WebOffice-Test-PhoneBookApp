USE [master]
GO
/****** Object:  Database [PhonebookDatabase]    Script Date: 02-06-2024 13:41:34 ******/
CREATE DATABASE [PhonebookDatabase]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PhonebookDatabase', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\PhonebookDatabase.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'PhonebookDatabase_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\PhonebookDatabase_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [PhonebookDatabase] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PhonebookDatabase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PhonebookDatabase] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PhonebookDatabase] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PhonebookDatabase] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PhonebookDatabase] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PhonebookDatabase] SET ARITHABORT OFF 
GO
ALTER DATABASE [PhonebookDatabase] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PhonebookDatabase] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PhonebookDatabase] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PhonebookDatabase] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PhonebookDatabase] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PhonebookDatabase] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PhonebookDatabase] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PhonebookDatabase] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PhonebookDatabase] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PhonebookDatabase] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PhonebookDatabase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PhonebookDatabase] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PhonebookDatabase] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PhonebookDatabase] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PhonebookDatabase] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PhonebookDatabase] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PhonebookDatabase] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PhonebookDatabase] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PhonebookDatabase] SET  MULTI_USER 
GO
ALTER DATABASE [PhonebookDatabase] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PhonebookDatabase] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PhonebookDatabase] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PhonebookDatabase] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [PhonebookDatabase]
GO
/****** Object:  Table [dbo].[Contacts]    Script Date: 02-06-2024 13:41:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contacts](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ContactName] [nvarchar](64) NULL,
	[PhoneNumber] [nvarchar](32) NULL,
	[EmailAddress] [nvarchar](64) NULL,
	[UserReferenceId] [bigint] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Contacts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 02-06-2024 13:41:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[NickName] [nvarchar](64) NULL,
	[EmailAddress] [nvarchar](128) NULL,
	[Password] [nvarchar](64) NULL,
	[OneTimePassword] [nvarchar](8) NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Contacts] ON 
GO
INSERT [dbo].[Contacts] ([Id], [ContactName], [PhoneNumber], [EmailAddress], [UserReferenceId], [IsDeleted]) VALUES (2, N'Anju', N'07902384423', N'anjuofficial98@gmail.com', 3, 1)
GO
INSERT [dbo].[Contacts] ([Id], [ContactName], [PhoneNumber], [EmailAddress], [UserReferenceId], [IsDeleted]) VALUES (3, N'Anju R Anju R', N'07902384424', N'anjuofficial96@gmail.com', 3, 1)
GO
INSERT [dbo].[Contacts] ([Id], [ContactName], [PhoneNumber], [EmailAddress], [UserReferenceId], [IsDeleted]) VALUES (4, N'Anju R', N'07902384423', N'anjuofficial98@gmail.com', 3, 0)
GO
INSERT [dbo].[Contacts] ([Id], [ContactName], [PhoneNumber], [EmailAddress], [UserReferenceId], [IsDeleted]) VALUES (5, N'Anju 2', N'987654323', N'anjuofficial99@gmail.com', 3, 0)
GO
SET IDENTITY_INSERT [dbo].[Contacts] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([Id], [NickName], [EmailAddress], [Password], [OneTimePassword], [IsDeleted]) VALUES (1, N'Anju R', N'anjuofficial98@gmail.com', N'ccd58ac47e2909a4ef7fdbf58505b3e5', NULL, 0)
GO
INSERT [dbo].[Users] ([Id], [NickName], [EmailAddress], [Password], [OneTimePassword], [IsDeleted]) VALUES (2, N'Anju R', N'anjuofficial99@gmail.com', N'ccd58ac47e2909a4ef7fdbf58505b3e5', NULL, 0)
GO
INSERT [dbo].[Users] ([Id], [NickName], [EmailAddress], [Password], [OneTimePassword], [IsDeleted]) VALUES (3, N'Anju R', N'anjuofficial97@gmail.com', N'00d84b8e24ddf050be579e1e8546377d', NULL, 0)
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Users]    Script Date: 02-06-2024 13:41:34 ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [IX_Users] UNIQUE NONCLUSTERED 
(
	[EmailAddress] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Contacts] ADD  CONSTRAINT [DF_Contacts_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Contacts]  WITH CHECK ADD  CONSTRAINT [FK_Contacts_Users] FOREIGN KEY([UserReferenceId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Contacts] CHECK CONSTRAINT [FK_Contacts_Users]
GO
USE [master]
GO
ALTER DATABASE [PhonebookDatabase] SET  READ_WRITE 
GO
