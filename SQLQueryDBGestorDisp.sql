USE [master]
GO
/****** Object:  Database [dbGestDisp ]    Script Date: 14/06/2021 04:59:06 p. m. ******/
CREATE DATABASE [dbGestDisp ]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'dbGestDisp', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\dbGestDisp .mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'dbGestDisp _log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\dbGestDisp _log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [dbGestDisp ] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dbGestDisp ].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [dbGestDisp ] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [dbGestDisp ] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [dbGestDisp ] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [dbGestDisp ] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [dbGestDisp ] SET ARITHABORT OFF 
GO
ALTER DATABASE [dbGestDisp ] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [dbGestDisp ] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [dbGestDisp ] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [dbGestDisp ] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [dbGestDisp ] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [dbGestDisp ] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [dbGestDisp ] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [dbGestDisp ] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [dbGestDisp ] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [dbGestDisp ] SET  DISABLE_BROKER 
GO
ALTER DATABASE [dbGestDisp ] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [dbGestDisp ] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [dbGestDisp ] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [dbGestDisp ] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [dbGestDisp ] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [dbGestDisp ] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [dbGestDisp ] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [dbGestDisp ] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [dbGestDisp ] SET  MULTI_USER 
GO
ALTER DATABASE [dbGestDisp ] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [dbGestDisp ] SET DB_CHAINING OFF 
GO
ALTER DATABASE [dbGestDisp ] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [dbGestDisp ] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [dbGestDisp ] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [dbGestDisp ] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [dbGestDisp ] SET QUERY_STORE = OFF
GO
USE [dbGestDisp ]
GO
/****** Object:  Table [dbo].[catArea]    Script Date: 14/06/2021 04:59:06 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[catArea](
	[idArea] [nchar](1) NOT NULL,
	[nombArea] [nchar](30) NOT NULL,
 CONSTRAINT [PK_catArea] PRIMARY KEY CLUSTERED 
(
	[idArea] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[catDisp]    Script Date: 14/06/2021 04:59:06 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[catDisp](
	[idDisp] [nchar](3) NOT NULL,
	[nombDisp] [nchar](30) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[catEdo]    Script Date: 14/06/2021 04:59:06 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[catEdo](
	[idEdo] [nchar](1) NOT NULL,
	[nombEdo] [nchar](15) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[catEmp]    Script Date: 14/06/2021 04:59:06 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[catEmp](
	[numEmp] [char](10) NOT NULL,
	[nombEmp] [varchar](50) NULL,
 CONSTRAINT [PK_catEmp] PRIMARY KEY CLUSTERED 
(
	[numEmp] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[catRadio]    Script Date: 14/06/2021 04:59:06 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[catRadio](
	[idRadio] [nchar](8) NOT NULL,
 CONSTRAINT [PK_catRadio] PRIMARY KEY CLUSTERED 
(
	[idRadio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[catSucursal]    Script Date: 14/06/2021 04:59:06 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[catSucursal](
	[idsuc] [nchar](10) NOT NULL,
	[nombre] [nchar](15) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbRadioCtrol]    Script Date: 14/06/2021 04:59:06 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbRadioCtrol](
	[idCtrl] [int] NULL,
	[radio] [nchar](10) NULL,
	[numbemp] [nchar](10) NULL,
	[estado] [nchar](10) NULL,
	[area] [nchar](10) NULL,
	[obsr] [nchar](10) NULL,
	[fechaasignacion] [nchar](10) NULL
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [dbGestDisp ] SET  READ_WRITE 
GO
