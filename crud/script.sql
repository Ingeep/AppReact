USE [GestorData]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 4/8/2022 11:42:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[ClienteId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_Completo] [varchar](200) NOT NULL,
	[Cedula] [nvarchar](100) NOT NULL,
	[Direccion] [varchar](max) NOT NULL,
	[Sector] [nvarchar](100) NOT NULL,
	[Ciudad] [varchar](200) NOT NULL,
	[Provincia] [varchar](200) NOT NULL,
	[Telefono] [nvarchar](100) NOT NULL,
	[Correo_Electronico] [nvarchar](200) NULL,
	[Fotografia] [nvarchar](300) NULL,
 CONSTRAINT [Pk_ClienteId] PRIMARY KEY CLUSTERED 
(
	[ClienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Factura]    Script Date: 4/8/2022 11:42:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Factura](
	[FacturaId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](200) NOT NULL,
	[Precio] [decimal](16, 2) NOT NULL,
	[Categoria] [varchar](200) NOT NULL,
	[ClienteId] [int] NULL,
	[ServicioId] [int] NULL,
 CONSTRAINT [Pk_Factura] PRIMARY KEY CLUSTERED 
(
	[FacturaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Servicio]    Script Date: 4/8/2022 11:42:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Servicio](
	[ServicioId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](200) NOT NULL,
	[Precio] [decimal](16, 2) NOT NULL,
	[Categoria] [varchar](200) NOT NULL,
 CONSTRAINT [Pk_ServicioId] PRIMARY KEY CLUSTERED 
(
	[ServicioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cliente] ON 

INSERT [dbo].[Cliente] ([ClienteId], [Nombre_Completo], [Cedula], [Direccion], [Sector], [Ciudad], [Provincia], [Telefono], [Correo_Electronico], [Fotografia]) VALUES (1, N'Oseas isai Pozo almonte', N'402-3945654-2', N' A/ carretera mella 3 1/2 casa #11', N'Centro de la ciudad', N'San pedro de macorís', N'SPM', N'809-339-2312', N'OseasPozo@hotmail.com', N'https://eloutput.com/app/uploads-eloutput.com/2020/01/baby-yoda-figura-sideshow.jpg')
INSERT [dbo].[Cliente] ([ClienteId], [Nombre_Completo], [Cedula], [Direccion], [Sector], [Ciudad], [Provincia], [Telefono], [Correo_Electronico], [Fotografia]) VALUES (2, N'gregory albert', N'023-2345323-4', N'calle central # 12', N'villa hermosa', N'la romana', N'la romana', N'809-654-4322', N'gregoryalbert@gmail.com', N'https://th.bing.com/th/id/R.1e11ee8523c69cddb4cdb46acf3a48b5?rik=Sq4pGN47IxSrVA&riu=http%3a%2f%2fdibujando.net%2ffiles%2ffs%2fp%2fi%2f2012%2f254%2fichigo_40724.jpg&ehk=mTKMTZgW3a5RlcOyz2II6B7CNiXDRpPLELx5Gj%2boV3o%3d&risl=&pid=ImgRaw&r=0')
SET IDENTITY_INSERT [dbo].[Cliente] OFF
GO
SET IDENTITY_INSERT [dbo].[Servicio] ON 

INSERT [dbo].[Servicio] ([ServicioId], [Nombre], [Precio], [Categoria]) VALUES (1, N'servicio nombre', CAST(12.34 AS Decimal(16, 2)), N'Categoria nombre')
SET IDENTITY_INSERT [dbo].[Servicio] OFF
GO
ALTER TABLE [dbo].[Factura]  WITH CHECK ADD  CONSTRAINT [Fk_clienteId] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Cliente] ([ClienteId])
GO
ALTER TABLE [dbo].[Factura] CHECK CONSTRAINT [Fk_clienteId]
GO
ALTER TABLE [dbo].[Factura]  WITH CHECK ADD  CONSTRAINT [Fk_ServicioId] FOREIGN KEY([ServicioId])
REFERENCES [dbo].[Servicio] ([ServicioId])
GO
ALTER TABLE [dbo].[Factura] CHECK CONSTRAINT [Fk_ServicioId]
GO
