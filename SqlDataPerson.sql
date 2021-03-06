USE [TestDB]
GO
/****** Object:  Table [dbo].[Person]    Script Date: 17.09.2021 22:03:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LastName] [nvarchar](200) NOT NULL,
	[FirstName] [nvarchar](200) NOT NULL,
	[MiddleName] [nvarchar](200) NULL,
	[BirthDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Person] ON 

INSERT [dbo].[Person] ([Id], [LastName], [FirstName], [MiddleName], [BirthDate]) VALUES (1, N'Ibrogimov', N'Ibrogim', N'Ibrogimovich', CAST(N'1991-10-10T00:00:00.000' AS DateTime))
INSERT [dbo].[Person] ([Id], [LastName], [FirstName], [MiddleName], [BirthDate]) VALUES (3, N'Amirov', N'Amir', N'Amiorovich', CAST(N'2000-05-15T00:00:00.000' AS DateTime))
INSERT [dbo].[Person] ([Id], [LastName], [FirstName], [MiddleName], [BirthDate]) VALUES (7, N'Osimov', N'Osim', N'Osimovich', CAST(N'1997-07-10T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Person] OFF
GO
