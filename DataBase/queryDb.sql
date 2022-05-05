USE [PruebaDanielMolina]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 5/05/2022 3:58:53 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[IdCliente] [int] IDENTITY(1,1) NOT NULL,
	[TipoIdentificacion] [int] NULL,
	[Identificacion] [varchar](100) NULL,
	[Nombres] [varchar](50) NULL,
	[Apellidos] [varchar](50) NULL,
	[RazonSocial] [varchar](50) NULL,
	[Celular] [varchar](50) NULL,
	[Telefono] [varchar](50) NULL,
	[Municipio] [varchar](50) NULL,
	[Departamento] [varchar](50) NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transaccion]    Script Date: 5/05/2022 3:58:53 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transaccion](
	[IdTransaccion] [int] IDENTITY(1,1) NOT NULL,
	[IdCliente] [int] NULL,
	[Saldo] [money] NULL,
	[TipoTransaccion] [int] NULL,
	[IdCuenta] [int] NOT NULL,
	[Fecha] [datetime] NULL,
 CONSTRAINT [PK_Cuenta] PRIMARY KEY CLUSTERED 
(
	[IdTransaccion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Clientes] ON 
GO
INSERT [dbo].[Clientes] ([IdCliente], [TipoIdentificacion], [Identificacion], [Nombres], [Apellidos], [RazonSocial], [Celular], [Telefono], [Municipio], [Departamento]) VALUES (1, 1, N'1099666333', N'Armando', N'Casas Castillo', N'', N'3112003399', N'8593312', N'Pueblo viejo', N'Magdalena')
GO
INSERT [dbo].[Clientes] ([IdCliente], [TipoIdentificacion], [Identificacion], [Nombres], [Apellidos], [RazonSocial], [Celular], [Telefono], [Municipio], [Departamento]) VALUES (2, 1, N'143631', N'Maria', N'Castro Viuda de Hernandez', N'', N'No tiene', N'2744458', N'Bogotá D.C.', N'Bogotá D.C.')
GO
INSERT [dbo].[Clientes] ([IdCliente], [TipoIdentificacion], [Identificacion], [Nombres], [Apellidos], [RazonSocial], [Celular], [Telefono], [Municipio], [Departamento]) VALUES (3, 2, N'900211632', N'', N'', N'Zapatos la feria', N'3009930001', N'7127435', N'Bucaramanga', N'Santander')
GO
SET IDENTITY_INSERT [dbo].[Clientes] OFF
GO
ALTER TABLE [dbo].[Transaccion]  WITH CHECK ADD  CONSTRAINT [FK_Transaccion_Clientes] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Clientes] ([IdCliente])
GO
ALTER TABLE [dbo].[Transaccion] CHECK CONSTRAINT [FK_Transaccion_Clientes]
GO
