<<<<<<< HEAD
=======
<<<<<<< HEAD
drop database medicinesearch_ashwini

use MedicineSearch_Ashwini
USE [MedicineSearch]
=======
drop table admin
drop table MEDECINE;
drop table Customer
drop table VENDOR
USE [MedicineSearch_Shiv]
>>>>>>> 130318104eaa67f81a20191fba19eabf36786141
GO

--ADMIN

/****** Object:  Table [dbo].[ADMIN]    Script Date: 10/25/2021 10:10:43 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ADMIN](
	[ADMIN_USER] [varchar](50) NOT NULL,
	[ADMIN_NAME] [varchar](50) NOT NULL,
	[ADMIN_PASSWORD] [varchar](50) NOT NULL,
 CONSTRAINT [PK_ADMIN] PRIMARY KEY CLUSTERED 
(
	[ADMIN_USER] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


--USER
/****** Object:  Table [dbo].[USER]    Script Date: 10/25/2021 10:11:20 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CUSTOMER](
	[USER_ID] [int] IDENTITY(1,1) NOT NULL,
	[USER_NAME] [varchar](50) NOT NULL,
	[USER_MOBILE] [varchar](10) NOT NULL,
	[USER_EMAIL] [varchar](50) NOT NULL,
	[USER_AREA] [varchar](50) NOT NULL,
	[USER_CITY] [varchar](50) NOT NULL,
	[USER_WALLETBAL] [decimal](18, 0) NOT NULL,
	[USER_PASSWORD] [varchar](50) NOT NULL,
	[ALLERGIC_TO] [varchar](50) NOT NULL,
 CONSTRAINT [PK_USER] PRIMARY KEY CLUSTERED 
(
	[USER_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Customer] ADD  CONSTRAINT [DF_USER_ALLERGIC_TO]  DEFAULT ('NONE') FOR [ALLERGIC_TO]
GO


--MEDICINE
/****** Object:  Table [dbo].[MEDECINE]    Script Date: 10/25/2021 10:11:01 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MEDECINE](
<<<<<<< HEAD
	[MEDICINE_ID] [int] IDENTITY(7000,1) NOT NULL,
=======

	[MEDICINE_ID] [int] IDENTITY(7000,1) NOT NULL ,
>>>>>>> 130318104eaa67f81a20191fba19eabf36786141
	[PROVIDER_ID] [int] NOT NULL,
	[MEDICINE_NAME] [varchar](50) NOT NULL,
	[MEDICINE_CATEGORY] [varchar](50) NOT NULL,
	[MEDICINE_DOSAGE] [int] NOT NULL,
	[MEDICINE_MDATE] [date] NOT NULL,
	[MEDICINE_EDATE] [date] NOT NULL,
	[MEDICINE_STOCK] [int] NOT NULL,
	[MEDICINE_PRICE] [decimal](18, 0) NOT NULL
 CONSTRAINT [PK_MEDECINE] PRIMARY KEY CLUSTERED 
(
	[MEDICINE_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[MEDECINE] ADD  CONSTRAINT [DF_MEDECINE_MEDICINE_STOCK]  DEFAULT ((10)) FOR [MEDICINE_STOCK]
GO

ALTER TABLE [dbo].[MEDECINE]  WITH CHECK ADD  CONSTRAINT [FK_MEDECINE_VENDOR] FOREIGN KEY([PROVIDER_ID])
REFERENCES [dbo].[VENDOR] ([VENDOR_ID])
GO

ALTER TABLE [dbo].[MEDECINE] CHECK CONSTRAINT [FK_MEDECINE_VENDOR]
GO

--VENDOR
/****** Object:  Table [dbo].[VENDOR]    Script Date: 10/25/2021 10:11:34 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[VENDOR](
	[VENDOR_ID] [int] IDENTITY(5000,1) NOT NULL,
	[VENDOR_ORG_NAME] [varchar](50) NOT NULL,
	[VENDOR_AREA] [varchar](50) NOT NULL,
	[VENDOR_CITY] [varchar](50) NOT NULL,
	[VENDOR_MOBILE] [varchar](10) NOT NULL,
	[VENDOR_WALLET] [decimal](18, 0) NOT NULL,
	[VENDOR_PASSWORD] [varchar](50) NOT NULL,
	[VENDOR_SPECIALITY] [varchar](50) NULL,
 CONSTRAINT [PK_VENDOR] PRIMARY KEY CLUSTERED 
(
	[VENDOR_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

>>>>>>> fa4e764d496f7e0d80eab6a35f69b5b5b4878082
