USE [GD2C2012]
GO

/****** Object:  Table [gd_esquema].[Maestra]    Script Date: 10/15/2012 22:08:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [gd_esquema].[Maestra](
	[Cli_Nombre] [nvarchar](255) NULL,
	[Cli_Apellido] [nvarchar](255) NULL,
	[Cli_Dni] [numeric](18, 0) NULL,
	[Cli_Direccion] [nvarchar](255) NULL,
	[Cli_Telefono] [numeric](18, 0) NULL,
	[Cli_Mail] [nvarchar](255) NULL,
	[Cli_Fecha_Nac] [datetime] NULL,
	[Cli_Ciudad] [nvarchar](255) NULL,
	[Carga_Credito] [numeric](18, 2) NULL,
	[Carga_Fecha] [datetime] NULL,
	[Tipo_Pago_Desc] [nvarchar](100) NULL,
	[Cli_Dest_Nombre] [nvarchar](255) NULL,
	[Cli_Dest_Apellido] [nvarchar](255) NULL,
	[Cli_Dest_Dni] [numeric](18, 0) NULL,
	[Cli_Dest_Direccion] [nvarchar](255) NULL,
	[Cli_Dest_Telefono] [numeric](18, 0) NULL,
	[Cli_Dest_Mail] [nvarchar](255) NULL,
	[Cli_Dest_Fecha_Nac] [datetime] NULL,
	[Cli_Dest_Ciudad] [nvarchar](255) NULL,
	[GiftCard_Fecha] [datetime] NULL,
	[GiftCard_Monto] [numeric](18, 2) NULL,
	[Provee_RS] [nvarchar](100) NULL,
	[Provee_Dom] [nvarchar](100) NULL,
	[Provee_Ciudad] [nvarchar](255) NULL,
	[Provee_Telefono] [numeric](18, 0) NULL,
	[Provee_CUIT] [nvarchar](20) NULL,
	[Provee_Rubro] [nvarchar](100) NULL,
	[Groupon_Precio] [numeric](18, 2) NULL,
	[Groupon_Precio_Ficticio] [numeric](18, 2) NULL,
	[Groupon_Fecha] [datetime] NULL,
	[Groupon_Fecha_Venc] [datetime] NULL,
	[Groupon_Cantidad] [numeric](18, 0) NULL,
	[Groupon_Descripcion] [nvarchar](255) NULL,
	[Groupon_Fecha_Compra] [datetime] NULL,
	[Groupon_Codigo] [nvarchar](50) NULL,
	[Groupon_Devolucion_Fecha] [datetime] NULL,
	[Groupon_Entregado_Fecha] [datetime] NULL,
	[Factura_Nro] [numeric](18, 0) NULL,
	[Factura_Fecha] [datetime] NULL
) ON [PRIMARY]

GO


	