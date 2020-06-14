USE [master]
GO

/****** Object:  Database [Project_Manager]    Script Date: 6/12/2020 8:34:43 PM ******/
CREATE DATABASE [Project_Manager]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Project_Manager', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Project_Manager.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Project_Manager_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Project_Manager_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO

ALTER DATABASE [Project_Manager] SET COMPATIBILITY_LEVEL = 140
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Project_Manager].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [Project_Manager] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [Project_Manager] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [Project_Manager] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [Project_Manager] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [Project_Manager] SET ARITHABORT OFF 
GO

ALTER DATABASE [Project_Manager] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [Project_Manager] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [Project_Manager] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [Project_Manager] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [Project_Manager] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [Project_Manager] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [Project_Manager] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [Project_Manager] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [Project_Manager] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [Project_Manager] SET  DISABLE_BROKER 
GO

ALTER DATABASE [Project_Manager] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [Project_Manager] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [Project_Manager] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [Project_Manager] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [Project_Manager] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [Project_Manager] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [Project_Manager] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [Project_Manager] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [Project_Manager] SET  MULTI_USER 
GO

ALTER DATABASE [Project_Manager] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [Project_Manager] SET DB_CHAINING OFF 
GO

ALTER DATABASE [Project_Manager] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [Project_Manager] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [Project_Manager] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [Project_Manager] SET QUERY_STORE = OFF
GO

ALTER DATABASE [Project_Manager] SET  READ_WRITE 
GO
