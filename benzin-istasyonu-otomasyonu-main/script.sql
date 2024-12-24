USE [master]
GO
/****** Object:  Database [BenzinIstasyonu]    Script Date: 25.12.2024 18:13:24 ******/
CREATE DATABASE [BenzinIstasyonu]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BenzinIstasyonu', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\BenzinIstasyonu.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BenzinIstasyonu_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\BenzinIstasyonu_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [BenzinIstasyonu] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BenzinIstasyonu].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BenzinIstasyonu] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BenzinIstasyonu] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BenzinIstasyonu] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BenzinIstasyonu] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BenzinIstasyonu] SET ARITHABORT OFF 
GO
ALTER DATABASE [BenzinIstasyonu] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BenzinIstasyonu] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BenzinIstasyonu] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BenzinIstasyonu] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BenzinIstasyonu] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BenzinIstasyonu] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BenzinIstasyonu] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BenzinIstasyonu] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BenzinIstasyonu] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BenzinIstasyonu] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BenzinIstasyonu] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BenzinIstasyonu] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BenzinIstasyonu] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BenzinIstasyonu] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BenzinIstasyonu] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BenzinIstasyonu] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BenzinIstasyonu] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BenzinIstasyonu] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BenzinIstasyonu] SET  MULTI_USER 
GO
ALTER DATABASE [BenzinIstasyonu] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BenzinIstasyonu] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BenzinIstasyonu] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BenzinIstasyonu] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BenzinIstasyonu] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BenzinIstasyonu] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [BenzinIstasyonu] SET QUERY_STORE = ON
GO
ALTER DATABASE [BenzinIstasyonu] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [BenzinIstasyonu]
GO
/****** Object:  Table [dbo].[BillingTbl]    Script Date: 25.12.2024 18:13:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BillingTbl](
	[Bid] [int] IDENTITY(1,1) NOT NULL,
	[Machine] [int] NOT NULL,
	[Fuel] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Bid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FuelTbl]    Script Date: 9.02.2024 05:13:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FuelTbl](
	[Fid] [int] IDENTITY(1,1) NOT NULL,
	[FName] [varchar](50) NOT NULL,
	[FPrice] [int] NOT NULL,
	[FSupplier] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Fid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MachineTbl]    Script Date: 9.02.2024 05:13:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MachineTbl](
	[MId] [int] IDENTITY(1,1) NOT NULL,
	[Fuel] [int] NOT NULL,
	[Company] [varchar](50) NOT NULL,
	[Description] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StaffTbl]    Script Date: 9.02.2024 05:13:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StaffTbl](
	[Stid] [int] IDENTITY(2000,1) NOT NULL,
	[StName] [varchar](50) NOT NULL,
	[StPass] [varchar](50) NOT NULL,
	[StPhone] [varchar](50) NOT NULL,
	[StAdd] [varchar](50) NOT NULL,
 CONSTRAINT [PK_StaffTbl] PRIMARY KEY CLUSTERED 
(
	[Stid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SupplierTbl]    Script Date: 9.02.2024 05:13:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SupplierTbl](
	[Supid] [int] IDENTITY(1,1) NOT NULL,
	[SupName] [varchar](50) NOT NULL,
	[SupPhone] [varchar](50) NOT NULL,
	[SupAdd] [varchar](100) NOT NULL,
 CONSTRAINT [PK_SupplierTbl] PRIMARY KEY CLUSTERED 
(
	[Supid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[BillingTbl] ON 

INSERT [dbo].[BillingTbl] ([Bid], [Machine], [Fuel], [Quantity], [Price]) VALUES (3009, 1, 9, 50, 30000)
INSERT [dbo].[BillingTbl] ([Bid], [Machine], [Fuel], [Quantity], [Price]) VALUES (3010, 3, 9, 20, 1000)
INSERT [dbo].[BillingTbl] ([Bid], [Machine], [Fuel], [Quantity], [Price]) VALUES (3011, 1, 9, 50, 30000)
SET IDENTITY_INSERT [dbo].[BillingTbl] OFF
GO
SET IDENTITY_INSERT [dbo].[FuelTbl] ON 

INSERT [dbo].[FuelTbl] ([Fid], [FName], [FPrice], [FSupplier]) VALUES (9, N'motorin', 6000, 8)
INSERT [dbo].[FuelTbl] ([Fid], [FName], [FPrice], [FSupplier]) VALUES (10, N'benzin', 10000, 8)
SET IDENTITY_INSERT [dbo].[FuelTbl] OFF
GO
SET IDENTITY_INSERT [dbo].[MachineTbl] ON 

INSERT [dbo].[MachineTbl] ([MId], [Fuel], [Company], [Description]) VALUES (1, 1, N'2', N'haha')
INSERT [dbo].[MachineTbl] ([MId], [Fuel], [Company], [Description]) VALUES (3, 0, N'3', N'biraz')
SET IDENTITY_INSERT [dbo].[MachineTbl] OFF
GO
SET IDENTITY_INSERT [dbo].[StaffTbl] ON 

INSERT [dbo].[StaffTbl] ([Stid], [StName], [StPass], [StPhone], [StAdd]) VALUES (2006, N'arman', N'123', N'1234', N'asd')
INSERT [dbo].[StaffTbl] ([Stid], [StName], [StPass], [StPhone], [StAdd]) VALUES (2009, N'arman', N'123', N'1234', N'asd')
INSERT [dbo].[StaffTbl] ([Stid], [StName], [StPass], [StPhone], [StAdd]) VALUES (2011, N'mete', N'1324', N'123', N'ankara')
SET IDENTITY_INSERT [dbo].[StaffTbl] OFF
GO
SET IDENTITY_INSERT [dbo].[SupplierTbl] ON 

INSERT [dbo].[SupplierTbl] ([Supid], [SupName], [SupPhone], [SupAdd]) VALUES (1, N'asd', N'123', N'asd')
INSERT [dbo].[SupplierTbl] ([Supid], [SupName], [SupPhone], [SupAdd]) VALUES (3, N'asds', N'54534', N'asdas')
INSERT [dbo].[SupplierTbl] ([Supid], [SupName], [SupPhone], [SupAdd]) VALUES (5, N'amar', N'678678678', N'ufo')
INSERT [dbo].[SupplierTbl] ([Supid], [SupName], [SupPhone], [SupAdd]) VALUES (7, N'memet', N'232443', N'ankara')
INSERT [dbo].[SupplierTbl] ([Supid], [SupName], [SupPhone], [SupAdd]) VALUES (8, N'arman', N'123', N'eskişehir')
SET IDENTITY_INSERT [dbo].[SupplierTbl] OFF
GO
ALTER TABLE [dbo].[BillingTbl]  WITH CHECK ADD  CONSTRAINT [FK4] FOREIGN KEY([Machine])
REFERENCES [dbo].[MachineTbl] ([MId])
GO
ALTER TABLE [dbo].[BillingTbl] CHECK CONSTRAINT [FK4]
GO
USE [master]
GO
ALTER DATABASE [BenzinIstasyonu] SET  READ_WRITE 
GO
