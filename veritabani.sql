USE [master]
GO
/****** Object:  Database [YoklamaTakipDB]    Script Date: 3.06.2025 00:07:00 ******/
CREATE DATABASE [YoklamaTakipDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'YoklamaTakipDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\YoklamaTakipDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'YoklamaTakipDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\YoklamaTakipDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [YoklamaTakipDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [YoklamaTakipDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [YoklamaTakipDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [YoklamaTakipDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [YoklamaTakipDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [YoklamaTakipDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [YoklamaTakipDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [YoklamaTakipDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [YoklamaTakipDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [YoklamaTakipDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [YoklamaTakipDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [YoklamaTakipDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [YoklamaTakipDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [YoklamaTakipDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [YoklamaTakipDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [YoklamaTakipDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [YoklamaTakipDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [YoklamaTakipDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [YoklamaTakipDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [YoklamaTakipDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [YoklamaTakipDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [YoklamaTakipDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [YoklamaTakipDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [YoklamaTakipDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [YoklamaTakipDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [YoklamaTakipDB] SET  MULTI_USER 
GO
ALTER DATABASE [YoklamaTakipDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [YoklamaTakipDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [YoklamaTakipDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [YoklamaTakipDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [YoklamaTakipDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [YoklamaTakipDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [YoklamaTakipDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [YoklamaTakipDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [YoklamaTakipDB]
GO
/****** Object:  Table [dbo].[Dersler]    Script Date: 3.06.2025 00:07:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dersler](
	[DersID] [int] IDENTITY(1,1) NOT NULL,
	[DersAdi] [nvarchar](100) NOT NULL,
	[DersKodu] [nvarchar](20) NOT NULL,
	[Aktif] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[DersID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kullanicilar]    Script Date: 3.06.2025 00:07:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kullanicilar](
	[KullaniciID] [int] IDENTITY(1,1) NOT NULL,
	[KullaniciAdi] [nvarchar](50) NOT NULL,
	[Sifre] [nvarchar](100) NOT NULL,
	[Ad] [nvarchar](50) NOT NULL,
	[Soyad] [nvarchar](50) NOT NULL,
	[Rol] [nvarchar](20) NOT NULL,
	[Aktif] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[KullaniciID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OgrenciDers]    Script Date: 3.06.2025 00:07:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OgrenciDers](
	[OgrenciDersID] [int] IDENTITY(1,1) NOT NULL,
	[KullaniciID] [int] NOT NULL,
	[DersID] [int] NOT NULL,
	[KayitTarihi] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[OgrenciDersID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OgretmenDers]    Script Date: 3.06.2025 00:07:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OgretmenDers](
	[OgretmenDersID] [int] IDENTITY(1,1) NOT NULL,
	[KullaniciID] [int] NOT NULL,
	[DersID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[OgretmenDersID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[YoklamaDetay]    Script Date: 3.06.2025 00:07:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[YoklamaDetay](
	[YoklamaDetayID] [int] IDENTITY(1,1) NOT NULL,
	[YoklamaID] [int] NOT NULL,
	[OgrenciID] [int] NOT NULL,
	[Durum] [nvarchar](10) NOT NULL,
	[Notlar] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[YoklamaDetayID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Yoklamalar]    Script Date: 3.06.2025 00:07:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Yoklamalar](
	[YoklamaID] [int] IDENTITY(1,1) NOT NULL,
	[DersID] [int] NOT NULL,
	[OgretmenID] [int] NOT NULL,
	[Tarih] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[YoklamaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Dersler] ON 

INSERT [dbo].[Dersler] ([DersID], [DersAdi], [DersKodu], [Aktif]) VALUES (1, N'Matematik', N'MAT101', 1)
INSERT [dbo].[Dersler] ([DersID], [DersAdi], [DersKodu], [Aktif]) VALUES (2, N'Fizik', N'FIZ101', 1)
INSERT [dbo].[Dersler] ([DersID], [DersAdi], [DersKodu], [Aktif]) VALUES (3, N'C# Programlama', N'CS101', 1)
INSERT [dbo].[Dersler] ([DersID], [DersAdi], [DersKodu], [Aktif]) VALUES (4, N'Veritabanı Yönetimi', N'DB202', 1)
INSERT [dbo].[Dersler] ([DersID], [DersAdi], [DersKodu], [Aktif]) VALUES (5, N'Algoritma Tasarımı', N'ALG303', 1)
SET IDENTITY_INSERT [dbo].[Dersler] OFF
GO
SET IDENTITY_INSERT [dbo].[Kullanicilar] ON 

INSERT [dbo].[Kullanicilar] ([KullaniciID], [KullaniciAdi], [Sifre], [Ad], [Soyad], [Rol], [Aktif]) VALUES (1, N'admin', N'1234', N'admin', N'admin', N'Yönetici', 1)
INSERT [dbo].[Kullanicilar] ([KullaniciID], [KullaniciAdi], [Sifre], [Ad], [Soyad], [Rol], [Aktif]) VALUES (3, N'a', N'1234', N'aaa', N'aaa', N'Öğrenci', 1)
INSERT [dbo].[Kullanicilar] ([KullaniciID], [KullaniciAdi], [Sifre], [Ad], [Soyad], [Rol], [Aktif]) VALUES (4, N'b', N'1234', N'bbb', N'bbb', N'Öğretmen', 1)
INSERT [dbo].[Kullanicilar] ([KullaniciID], [KullaniciAdi], [Sifre], [Ad], [Soyad], [Rol], [Aktif]) VALUES (6, N'umutkilavuz', N'1234', N'umut', N'kılavuz', N'Öğrenci', 1)
INSERT [dbo].[Kullanicilar] ([KullaniciID], [KullaniciAdi], [Sifre], [Ad], [Soyad], [Rol], [Aktif]) VALUES (7, N'sagis', N'1234', N'mustafa', N'nazli', N'Öğretmen', 1)
INSERT [dbo].[Kullanicilar] ([KullaniciID], [KullaniciAdi], [Sifre], [Ad], [Soyad], [Rol], [Aktif]) VALUES (8, N'ardat', N'1234', N'arda', N'tunca', N'Öğrenci', 1)
INSERT [dbo].[Kullanicilar] ([KullaniciID], [KullaniciAdi], [Sifre], [Ad], [Soyad], [Rol], [Aktif]) VALUES (9, N'alikoc', N'1234', N'ali', N'koç', N'Öğretmen', 1)
INSERT [dbo].[Kullanicilar] ([KullaniciID], [KullaniciAdi], [Sifre], [Ad], [Soyad], [Rol], [Aktif]) VALUES (10, N'azizyildirim', N'1234', N'aziz', N'yıldırım', N'Öğretmen', 1)
SET IDENTITY_INSERT [dbo].[Kullanicilar] OFF
GO
SET IDENTITY_INSERT [dbo].[OgrenciDers] ON 

INSERT [dbo].[OgrenciDers] ([OgrenciDersID], [KullaniciID], [DersID], [KayitTarihi]) VALUES (1, 3, 1, CAST(N'2025-06-02T19:18:40.847' AS DateTime))
INSERT [dbo].[OgrenciDers] ([OgrenciDersID], [KullaniciID], [DersID], [KayitTarihi]) VALUES (5, 3, 3, CAST(N'2025-06-02T20:17:00.877' AS DateTime))
INSERT [dbo].[OgrenciDers] ([OgrenciDersID], [KullaniciID], [DersID], [KayitTarihi]) VALUES (6, 6, 2, CAST(N'2025-06-02T21:32:59.530' AS DateTime))
INSERT [dbo].[OgrenciDers] ([OgrenciDersID], [KullaniciID], [DersID], [KayitTarihi]) VALUES (8, 8, 5, CAST(N'2025-06-02T23:05:43.443' AS DateTime))
INSERT [dbo].[OgrenciDers] ([OgrenciDersID], [KullaniciID], [DersID], [KayitTarihi]) VALUES (9, 8, 3, CAST(N'2025-06-02T23:05:44.933' AS DateTime))
INSERT [dbo].[OgrenciDers] ([OgrenciDersID], [KullaniciID], [DersID], [KayitTarihi]) VALUES (19, 8, 2, CAST(N'2025-06-02T23:46:37.217' AS DateTime))
INSERT [dbo].[OgrenciDers] ([OgrenciDersID], [KullaniciID], [DersID], [KayitTarihi]) VALUES (20, 8, 1, CAST(N'2025-06-02T23:46:40.400' AS DateTime))
INSERT [dbo].[OgrenciDers] ([OgrenciDersID], [KullaniciID], [DersID], [KayitTarihi]) VALUES (21, 6, 5, CAST(N'2025-06-02T23:47:05.180' AS DateTime))
INSERT [dbo].[OgrenciDers] ([OgrenciDersID], [KullaniciID], [DersID], [KayitTarihi]) VALUES (22, 6, 4, CAST(N'2025-06-02T23:47:08.917' AS DateTime))
SET IDENTITY_INSERT [dbo].[OgrenciDers] OFF
GO
SET IDENTITY_INSERT [dbo].[OgretmenDers] ON 

INSERT [dbo].[OgretmenDers] ([OgretmenDersID], [KullaniciID], [DersID]) VALUES (9, 4, 1)
INSERT [dbo].[OgretmenDers] ([OgretmenDersID], [KullaniciID], [DersID]) VALUES (1, 4, 2)
INSERT [dbo].[OgretmenDers] ([OgretmenDersID], [KullaniciID], [DersID]) VALUES (8, 4, 3)
INSERT [dbo].[OgretmenDers] ([OgretmenDersID], [KullaniciID], [DersID]) VALUES (10, 4, 4)
INSERT [dbo].[OgretmenDers] ([OgretmenDersID], [KullaniciID], [DersID]) VALUES (7, 4, 5)
INSERT [dbo].[OgretmenDers] ([OgretmenDersID], [KullaniciID], [DersID]) VALUES (3, 7, 1)
INSERT [dbo].[OgretmenDers] ([OgretmenDersID], [KullaniciID], [DersID]) VALUES (4, 9, 1)
INSERT [dbo].[OgretmenDers] ([OgretmenDersID], [KullaniciID], [DersID]) VALUES (6, 9, 4)
INSERT [dbo].[OgretmenDers] ([OgretmenDersID], [KullaniciID], [DersID]) VALUES (5, 10, 5)
SET IDENTITY_INSERT [dbo].[OgretmenDers] OFF
GO
SET IDENTITY_INSERT [dbo].[YoklamaDetay] ON 

INSERT [dbo].[YoklamaDetay] ([YoklamaDetayID], [YoklamaID], [OgrenciID], [Durum], [Notlar]) VALUES (1, 3, 6, N'Gelmedi', N'')
INSERT [dbo].[YoklamaDetay] ([YoklamaDetayID], [YoklamaID], [OgrenciID], [Durum], [Notlar]) VALUES (2, 4, 6, N'Gelmedi', N'')
INSERT [dbo].[YoklamaDetay] ([YoklamaDetayID], [YoklamaID], [OgrenciID], [Durum], [Notlar]) VALUES (5, 7, 6, N'Gelmedi', N'')
INSERT [dbo].[YoklamaDetay] ([YoklamaDetayID], [YoklamaID], [OgrenciID], [Durum], [Notlar]) VALUES (6, 8, 6, N'Gelmedi', N'')
INSERT [dbo].[YoklamaDetay] ([YoklamaDetayID], [YoklamaID], [OgrenciID], [Durum], [Notlar]) VALUES (7, 9, 6, N'Gelmedi', N'')
INSERT [dbo].[YoklamaDetay] ([YoklamaDetayID], [YoklamaID], [OgrenciID], [Durum], [Notlar]) VALUES (8, 10, 6, N'Gelmedi', N'')
INSERT [dbo].[YoklamaDetay] ([YoklamaDetayID], [YoklamaID], [OgrenciID], [Durum], [Notlar]) VALUES (9, 11, 6, N'Gelmedi', N'')
INSERT [dbo].[YoklamaDetay] ([YoklamaDetayID], [YoklamaID], [OgrenciID], [Durum], [Notlar]) VALUES (10, 3, 8, N'Gelmedi', N'')
SET IDENTITY_INSERT [dbo].[YoklamaDetay] OFF
GO
SET IDENTITY_INSERT [dbo].[Yoklamalar] ON 

INSERT [dbo].[Yoklamalar] ([YoklamaID], [DersID], [OgretmenID], [Tarih]) VALUES (3, 2, 4, CAST(N'2025-06-02' AS Date))
INSERT [dbo].[Yoklamalar] ([YoklamaID], [DersID], [OgretmenID], [Tarih]) VALUES (4, 2, 4, CAST(N'2025-06-03' AS Date))
INSERT [dbo].[Yoklamalar] ([YoklamaID], [DersID], [OgretmenID], [Tarih]) VALUES (7, 2, 4, CAST(N'2025-06-04' AS Date))
INSERT [dbo].[Yoklamalar] ([YoklamaID], [DersID], [OgretmenID], [Tarih]) VALUES (8, 2, 4, CAST(N'2025-06-05' AS Date))
INSERT [dbo].[Yoklamalar] ([YoklamaID], [DersID], [OgretmenID], [Tarih]) VALUES (9, 2, 4, CAST(N'2025-06-06' AS Date))
INSERT [dbo].[Yoklamalar] ([YoklamaID], [DersID], [OgretmenID], [Tarih]) VALUES (10, 2, 4, CAST(N'2025-06-07' AS Date))
INSERT [dbo].[Yoklamalar] ([YoklamaID], [DersID], [OgretmenID], [Tarih]) VALUES (11, 2, 4, CAST(N'2025-06-08' AS Date))
SET IDENTITY_INSERT [dbo].[Yoklamalar] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Dersler__9DCB30EFC4D850CA]    Script Date: 3.06.2025 00:07:00 ******/
ALTER TABLE [dbo].[Dersler] ADD UNIQUE NONCLUSTERED 
(
	[DersKodu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Kullanic__5BAE6A75CCB2E658]    Script Date: 3.06.2025 00:07:00 ******/
ALTER TABLE [dbo].[Kullanicilar] ADD UNIQUE NONCLUSTERED 
(
	[KullaniciAdi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ_OgrenciDers]    Script Date: 3.06.2025 00:07:00 ******/
ALTER TABLE [dbo].[OgrenciDers] ADD  CONSTRAINT [UQ_OgrenciDers] UNIQUE NONCLUSTERED 
(
	[KullaniciID] ASC,
	[DersID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ_OgretmenDers]    Script Date: 3.06.2025 00:07:00 ******/
ALTER TABLE [dbo].[OgretmenDers] ADD  CONSTRAINT [UQ_OgretmenDers] UNIQUE NONCLUSTERED 
(
	[KullaniciID] ASC,
	[DersID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ_YoklamaDetay]    Script Date: 3.06.2025 00:07:00 ******/
ALTER TABLE [dbo].[YoklamaDetay] ADD  CONSTRAINT [UQ_YoklamaDetay] UNIQUE NONCLUSTERED 
(
	[YoklamaID] ASC,
	[OgrenciID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ_Yoklama]    Script Date: 3.06.2025 00:07:00 ******/
ALTER TABLE [dbo].[Yoklamalar] ADD  CONSTRAINT [UQ_Yoklama] UNIQUE NONCLUSTERED 
(
	[DersID] ASC,
	[Tarih] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Dersler] ADD  DEFAULT ((1)) FOR [Aktif]
GO
ALTER TABLE [dbo].[Kullanicilar] ADD  DEFAULT ((1)) FOR [Aktif]
GO
ALTER TABLE [dbo].[OgrenciDers] ADD  DEFAULT (getdate()) FOR [KayitTarihi]
GO
ALTER TABLE [dbo].[OgrenciDers]  WITH CHECK ADD  CONSTRAINT [FK_OgrenciDers_Dersler] FOREIGN KEY([DersID])
REFERENCES [dbo].[Dersler] ([DersID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OgrenciDers] CHECK CONSTRAINT [FK_OgrenciDers_Dersler]
GO
ALTER TABLE [dbo].[OgrenciDers]  WITH CHECK ADD  CONSTRAINT [FK_OgrenciDers_Kullanicilar] FOREIGN KEY([KullaniciID])
REFERENCES [dbo].[Kullanicilar] ([KullaniciID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OgrenciDers] CHECK CONSTRAINT [FK_OgrenciDers_Kullanicilar]
GO
ALTER TABLE [dbo].[OgretmenDers]  WITH CHECK ADD FOREIGN KEY([DersID])
REFERENCES [dbo].[Dersler] ([DersID])
GO
ALTER TABLE [dbo].[OgretmenDers]  WITH CHECK ADD FOREIGN KEY([KullaniciID])
REFERENCES [dbo].[Kullanicilar] ([KullaniciID])
GO
ALTER TABLE [dbo].[YoklamaDetay]  WITH CHECK ADD FOREIGN KEY([OgrenciID])
REFERENCES [dbo].[Kullanicilar] ([KullaniciID])
GO
ALTER TABLE [dbo].[YoklamaDetay]  WITH CHECK ADD FOREIGN KEY([YoklamaID])
REFERENCES [dbo].[Yoklamalar] ([YoklamaID])
GO
ALTER TABLE [dbo].[Yoklamalar]  WITH CHECK ADD FOREIGN KEY([DersID])
REFERENCES [dbo].[Dersler] ([DersID])
GO
ALTER TABLE [dbo].[Yoklamalar]  WITH CHECK ADD FOREIGN KEY([OgretmenID])
REFERENCES [dbo].[Kullanicilar] ([KullaniciID])
GO
ALTER TABLE [dbo].[Kullanicilar]  WITH CHECK ADD CHECK  (([Rol]='Yönetici' OR [Rol]='Öğrenci' OR [Rol]='Öğretmen'))
GO
ALTER TABLE [dbo].[YoklamaDetay]  WITH CHECK ADD CHECK  (([Durum]='Gelmedi' OR [Durum]='Geldi'))
GO
USE [master]
GO
ALTER DATABASE [YoklamaTakipDB] SET  READ_WRITE 
GO
