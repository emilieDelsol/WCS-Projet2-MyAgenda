USE [master]
GO
/****** Object:  Database [MyAgenda]    Script Date: 05/11/2020 11:18:09 ******/
CREATE DATABASE [MyAgenda]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MyAgenda', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\MyAgenda.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MyAgenda_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\MyAgenda_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [MyAgenda] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MyAgenda].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MyAgenda] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MyAgenda] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MyAgenda] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MyAgenda] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MyAgenda] SET ARITHABORT OFF 
GO
ALTER DATABASE [MyAgenda] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [MyAgenda] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MyAgenda] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MyAgenda] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MyAgenda] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MyAgenda] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MyAgenda] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MyAgenda] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MyAgenda] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MyAgenda] SET  ENABLE_BROKER 
GO
ALTER DATABASE [MyAgenda] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MyAgenda] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MyAgenda] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MyAgenda] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MyAgenda] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MyAgenda] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MyAgenda] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MyAgenda] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MyAgenda] SET  MULTI_USER 
GO
ALTER DATABASE [MyAgenda] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MyAgenda] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MyAgenda] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MyAgenda] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MyAgenda] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MyAgenda] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [MyAgenda] SET QUERY_STORE = OFF
GO
USE [MyAgenda]
GO
/****** Object:  Table [dbo].[Agenda]    Script Date: 05/11/2020 11:18:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Agenda](
	[IdAgenda] [int] IDENTITY(1,1) NOT NULL,
	[FK_IdAppointment] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdAgenda] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Appointment]    Script Date: 05/11/2020 11:18:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Appointment](
	[IdAppointment] [int] IDENTITY(1,1) NOT NULL,
	[Rdv] [varchar](90) NOT NULL,
	[BeginDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[AppointmentDescription] [varchar](1000) NULL,
	[AppointmentAddress] [varchar](500) NULL,
	[Contact] [varchar](100) NULL,
	[Email] [varchar](90) NULL,
	[Phone] [varchar](90) NULL,
	[Importance] [bit] NULL,
	[Recurence] [bit] NULL,
	[Reminder] [bit] NULL,
	[Pro] [bit] NULL,
	[Perso] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdAppointment] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Appointment] ON 

INSERT [dbo].[Appointment] ([IdAppointment], [Rdv], [BeginDate], [EndDate], [AppointmentDescription], [AppointmentAddress], [Contact], [Email], [Phone], [Importance], [Recurence], [Reminder], [Pro], [Perso]) VALUES (1, N'My first all user entry', CAST(N'2002-08-08T16:00:00.000' AS DateTime), CAST(N'2002-08-08T16:15:00.000' AS DateTime), N'This is my first all user entry RDV', N'1 place du Capitole 31000 Toulouse', N'Monsieur X', N'monsieurx@monsieurx.com', N'0601234567', 0, 0, 0, 0, 0)
INSERT [dbo].[Appointment] ([IdAppointment], [Rdv], [BeginDate], [EndDate], [AppointmentDescription], [AppointmentAddress], [Contact], [Email], [Phone], [Importance], [Recurence], [Reminder], [Pro], [Perso]) VALUES (2, N'My first second user entry', CAST(N'2022-08-08T16:00:00.000' AS DateTime), CAST(N'2022-08-08T16:15:00.000' AS DateTime), N'This is my first all user entry RDV', N'1 place du Capitole 31000 Toulouse', N'Monsieur X', N'monsieurx@monsieurx.com', N'0601234567', 0, 0, 0, 0, 0)
INSERT [dbo].[Appointment] ([IdAppointment], [Rdv], [BeginDate], [EndDate], [AppointmentDescription], [AppointmentAddress], [Contact], [Email], [Phone], [Importance], [Recurence], [Reminder], [Pro], [Perso]) VALUES (3, N'My perso user entry', CAST(N'2022-08-08T16:00:00.000' AS DateTime), CAST(N'2022-08-08T16:15:00.000' AS DateTime), N'This is my first all user entry RDV', N'1 place du Capitole 31000 Toulouse', N'Monsieur X', N'monsieurx@monsieurx.com', N'0601234567', 0, 0, 0, 0, 1)
INSERT [dbo].[Appointment] ([IdAppointment], [Rdv], [BeginDate], [EndDate], [AppointmentDescription], [AppointmentAddress], [Contact], [Email], [Phone], [Importance], [Recurence], [Reminder], [Pro], [Perso]) VALUES (4, N'My pro user entry', CAST(N'2022-08-08T16:00:00.000' AS DateTime), CAST(N'2022-08-08T16:15:00.000' AS DateTime), N'This is my first all user entry RDV', N'1 place du Capitole 31000 Toulouse', N'Monsieur X', N'monsieurx@monsieurx.com', N'0601234567', 0, 0, 0, 1, 0)
INSERT [dbo].[Appointment] ([IdAppointment], [Rdv], [BeginDate], [EndDate], [AppointmentDescription], [AppointmentAddress], [Contact], [Email], [Phone], [Importance], [Recurence], [Reminder], [Pro], [Perso]) VALUES (5, N'My pro user entry', CAST(N'2022-08-08T16:00:00.000' AS DateTime), CAST(N'2022-08-08T16:15:00.000' AS DateTime), N'This is my first all user entry RDV', N'1 place du Capitole 31000 Toulouse', N'Monsieur X', N'monsieurx@monsieurx.com', N'0601234567', 0, 0, 0, 1, 0)
INSERT [dbo].[Appointment] ([IdAppointment], [Rdv], [BeginDate], [EndDate], [AppointmentDescription], [AppointmentAddress], [Contact], [Email], [Phone], [Importance], [Recurence], [Reminder], [Pro], [Perso]) VALUES (6, N'My new user entry', CAST(N'2000-08-08T16:00:00.000' AS DateTime), CAST(N'2000-08-08T16:15:00.000' AS DateTime), N'This is my first all user entry RDV', N'1 place du Capitole 31000 Toulouse', N'Monsieur X', N'monsieurx@monsieurx.com', N'0601234567', 0, 0, 0, 0, 0)
INSERT [dbo].[Appointment] ([IdAppointment], [Rdv], [BeginDate], [EndDate], [AppointmentDescription], [AppointmentAddress], [Contact], [Email], [Phone], [Importance], [Recurence], [Reminder], [Pro], [Perso]) VALUES (7, N'My first all user entry', CAST(N'1998-08-08T16:00:00.000' AS DateTime), CAST(N'1998-08-08T16:15:00.000' AS DateTime), N'This is my first all user entry RDV', N'1 place du Capitole 31000 Toulouse', N'Monsieur X', N'monsieurx@monsieurx.com', N'0601234567', 0, 0, 0, 0, 0)
INSERT [dbo].[Appointment] ([IdAppointment], [Rdv], [BeginDate], [EndDate], [AppointmentDescription], [AppointmentAddress], [Contact], [Email], [Phone], [Importance], [Recurence], [Reminder], [Pro], [Perso]) VALUES (8, N'My first all user entry', CAST(N'1996-08-08T16:00:00.000' AS DateTime), CAST(N'1996-08-08T16:15:00.000' AS DateTime), N'', N'1 place du Capitole 31000 Toulouse', N'Monsieur X', N'monsieurx@monsieurx.com', N'0601234567', 0, 0, 0, 0, 0)
INSERT [dbo].[Appointment] ([IdAppointment], [Rdv], [BeginDate], [EndDate], [AppointmentDescription], [AppointmentAddress], [Contact], [Email], [Phone], [Importance], [Recurence], [Reminder], [Pro], [Perso]) VALUES (9, N'My first all user entry without desc', CAST(N'1995-08-08T16:00:00.000' AS DateTime), CAST(N'1995-08-08T16:15:00.000' AS DateTime), N'test', N'1 place du Capitole 31000 Toulouse', N'Monsieur X', N'monsieurx@monsieurx.com', N'0601234567', 0, 0, 0, 0, 0)
SET IDENTITY_INSERT [dbo].[Appointment] OFF
GO
ALTER TABLE [dbo].[Appointment] ADD  DEFAULT (NULL) FOR [AppointmentDescription]
GO
ALTER TABLE [dbo].[Appointment] ADD  DEFAULT (NULL) FOR [AppointmentAddress]
GO
ALTER TABLE [dbo].[Appointment] ADD  DEFAULT (NULL) FOR [Contact]
GO
ALTER TABLE [dbo].[Appointment] ADD  DEFAULT (NULL) FOR [Email]
GO
ALTER TABLE [dbo].[Appointment] ADD  DEFAULT (NULL) FOR [Phone]
GO
ALTER TABLE [dbo].[Appointment] ADD  DEFAULT (NULL) FOR [Importance]
GO
ALTER TABLE [dbo].[Appointment] ADD  DEFAULT (NULL) FOR [Recurence]
GO
ALTER TABLE [dbo].[Appointment] ADD  DEFAULT (NULL) FOR [Reminder]
GO
ALTER TABLE [dbo].[Appointment] ADD  DEFAULT (NULL) FOR [Pro]
GO
ALTER TABLE [dbo].[Appointment] ADD  DEFAULT (NULL) FOR [Perso]
GO
ALTER TABLE [dbo].[Agenda]  WITH CHECK ADD FOREIGN KEY([FK_IdAppointment])
REFERENCES [dbo].[Appointment] ([IdAppointment])
GO
USE [master]
GO
ALTER DATABASE [MyAgenda] SET  READ_WRITE 
GO
