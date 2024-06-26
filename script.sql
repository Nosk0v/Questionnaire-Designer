USE [master]
GO
/****** Object:  Database [Constructor]    Script Date: 23.06.2024 22:09:48 ******/
CREATE DATABASE [Constructor]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Constructor', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Constructor.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Constructor_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Constructor_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Constructor] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Constructor].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Constructor] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Constructor] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Constructor] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Constructor] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Constructor] SET ARITHABORT OFF 
GO
ALTER DATABASE [Constructor] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Constructor] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Constructor] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Constructor] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Constructor] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Constructor] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Constructor] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Constructor] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Constructor] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Constructor] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Constructor] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Constructor] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Constructor] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Constructor] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Constructor] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Constructor] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Constructor] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Constructor] SET RECOVERY FULL 
GO
ALTER DATABASE [Constructor] SET  MULTI_USER 
GO
ALTER DATABASE [Constructor] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Constructor] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Constructor] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Constructor] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Constructor] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Constructor] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Constructor', N'ON'
GO
ALTER DATABASE [Constructor] SET QUERY_STORE = OFF
GO
USE [Constructor]
GO
/****** Object:  Table [dbo].[Answer]    Script Date: 23.06.2024 22:09:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Answer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Answer] [nvarchar](200) NULL,
	[QuestionID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Forms]    Script Date: 23.06.2024 22:09:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Forms](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Question]    Script Date: 23.06.2024 22:09:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Question](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [text] NULL,
	[QuestionType] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Questionnaire]    Script Date: 23.06.2024 22:09:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Questionnaire](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FormsID] [int] NULL,
	[QuestionID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuestionType]    Script Date: 23.06.2024 22:09:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuestionType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Answer] ON 

INSERT [dbo].[Answer] ([ID], [Answer], [QuestionID]) VALUES (9, N'5', 3)
INSERT [dbo].[Answer] ([ID], [Answer], [QuestionID]) VALUES (10, N'4', 3)
INSERT [dbo].[Answer] ([ID], [Answer], [QuestionID]) VALUES (11, N'21', 3)
INSERT [dbo].[Answer] ([ID], [Answer], [QuestionID]) VALUES (12, N'1', 3)
INSERT [dbo].[Answer] ([ID], [Answer], [QuestionID]) VALUES (13, N'30 000 км', 4)
INSERT [dbo].[Answer] ([ID], [Answer], [QuestionID]) VALUES (14, N'45 000 км', 4)
INSERT [dbo].[Answer] ([ID], [Answer], [QuestionID]) VALUES (15, N'10 000 км', 4)
INSERT [dbo].[Answer] ([ID], [Answer], [QuestionID]) VALUES (16, N'Я не знаю', 4)
SET IDENTITY_INSERT [dbo].[Answer] OFF
GO
SET IDENTITY_INSERT [dbo].[Forms] ON 

INSERT [dbo].[Forms] ([ID], [Name], [Description]) VALUES (3, N'География', N'Тест на общие знания по планете')
INSERT [dbo].[Forms] ([ID], [Name], [Description]) VALUES (4, N'Тест по географии 2.0', N'Тест только на экватор')
SET IDENTITY_INSERT [dbo].[Forms] OFF
GO
SET IDENTITY_INSERT [dbo].[Question] ON 

INSERT [dbo].[Question] ([ID], [Description], [QuestionType]) VALUES (3, N'Сколько материков на земле?', 2)
INSERT [dbo].[Question] ([ID], [Description], [QuestionType]) VALUES (4, N'Сколько длина экватора?', 2)
SET IDENTITY_INSERT [dbo].[Question] OFF
GO
SET IDENTITY_INSERT [dbo].[Questionnaire] ON 

INSERT [dbo].[Questionnaire] ([ID], [FormsID], [QuestionID]) VALUES (5, 3, 4)
INSERT [dbo].[Questionnaire] ([ID], [FormsID], [QuestionID]) VALUES (6, 3, 3)
INSERT [dbo].[Questionnaire] ([ID], [FormsID], [QuestionID]) VALUES (7, 4, 4)
SET IDENTITY_INSERT [dbo].[Questionnaire] OFF
GO
SET IDENTITY_INSERT [dbo].[QuestionType] ON 

INSERT [dbo].[QuestionType] ([ID], [Name]) VALUES (1, N'Ввести')
INSERT [dbo].[QuestionType] ([ID], [Name]) VALUES (2, N'Выбор из нескольких')
SET IDENTITY_INSERT [dbo].[QuestionType] OFF
GO
ALTER TABLE [dbo].[Answer]  WITH CHECK ADD FOREIGN KEY([QuestionID])
REFERENCES [dbo].[Question] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Question]  WITH CHECK ADD FOREIGN KEY([QuestionType])
REFERENCES [dbo].[QuestionType] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Questionnaire]  WITH CHECK ADD FOREIGN KEY([FormsID])
REFERENCES [dbo].[Forms] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Questionnaire]  WITH CHECK ADD FOREIGN KEY([QuestionID])
REFERENCES [dbo].[Question] ([ID])
ON DELETE CASCADE
GO
USE [master]
GO
ALTER DATABASE [Constructor] SET  READ_WRITE 
GO
