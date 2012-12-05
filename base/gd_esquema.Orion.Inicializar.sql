-- Crear tablas!

-- cargas
CREATE TABLE ORION.cargas(
	idcarga			int IDENTITY(1,1) NOT NULL,
	fecha_carga		datetime,
	idcliente		int,
	idtipo_pago		smallint,
	monto			numeric(18,2),
	idtarjeta		int,
	activo			bit default 1
) ON [PRIMARY]

-- ciudades
CREATE TABLE ORION.ciudades(
	idciudad		smallint IDENTITY(1,1) NOT NULL,
	descripcion		nvarchar(255),
	activo			bit default 1
) ON [PRIMARY]

-- clientes
CREATE TABLE ORION.clientes(
	idcliente			int IDENTITY(1,1) NOT NULL,
	nombre				nvarchar(255),
	apellido			nvarchar(255),
	dni					numeric(18,0),
	email				nvarchar(255),
	telefono			numeric(18,0),
	direccion			nvarchar(255),
	localidad			nvarchar(255),
	codigo_postal			nvarchar(8),
	fecha_nacimiento	datetime,
	idusuario			int,
	credito_actual		numeric(18,2) default 0,
	activo				bit default 1
) ON [PRIMARY]

-- clientes_ciudades
CREATE TABLE ORION.clientes_ciudades(
	idcliente_ciudad	int IDENTITY(1,1) NOT NULL,
	idcliente			int,
	idciudad			int,
	activo				bit default 1
) ON [PRIMARY]

-- compras
CREATE TABLE ORION.compras(
	idcompra			int IDENTITY(1,1) NOT NULL,
	idcliente			int,
	fecha_compra		datetime,
	cantidad			smallint,
	idcupon				int,
	nro_cupon			int,
	activo				bit default 1
) ON [PRIMARY]

-- compras_estados
CREATE TABLE ORION.compras_estados(
	idcompra_estado		int IDENTITY(1,1) NOT NULL,
	descripcion			nvarchar(50)
) ON [PRIMARY]

-- consumos
CREATE TABLE ORION.consumos(
	idconsumo			int IDENTITY(1,1) NOT NULL,
	fecha_consumo		datetime,
	idcompra			int,
	facturado			bit default 0
) ON [PRIMARY]

-- cupones
CREATE TABLE [ORION].[cupones](
	[idcupon] [int] IDENTITY(1,1) NOT NULL,
	[idproveedor] [int] NULL,
	[descripcion] [varchar](200) NULL,
	[codigo] [varchar](50) NULL,
	[fecha_alta] [date] NULL,
	[fecha_publicacion] [date] NULL,
	[fecha_vencimiento] [date] NULL,
	[fecha_vencimiento_canje] [date] NULL,
	[precio_real] [decimal](18, 2) NULL,
	[precio_ficticio] [decimal](18, 2) NULL,
	[cantidad_disponible] [smallint] NULL,
	[cantidad_max_usuario] [smallint] NULL,
	[habilitado] [bit] NULL,
	[publicado] [bit] default 0,
	[fecha_pubilcacion_real] [date] NULL
) ON [PRIMARY]

-- cupones_ciudades
CREATE TABLE ORION.cupones_ciudades(
	idcupon_ciudad		int IDENTITY(1,1) NOT NULL,
	idcupon				int,
	idciudad			int,
	habilitado			bit default 1
) ON [PRIMARY]

-- devoluciones
CREATE TABLE ORION.devoluciones(
	iddevolucion		int IDENTITY(1,1) NOT NULL,
	fecha_devolucion	datetime,
	idcompra			int,
	motivo				nvarchar(255)
) ON [PRIMARY]

-- facturas
CREATE TABLE ORION.facturas(
	idfactura			int IDENTITY(1,1) NOT NULL,
	fecha_generacion	datetime,
	idproveedor			int,
	nro_factura			numeric(18,0),
	monto_total			decimal(18,2),
	habilitado			bit default 1
) ON [PRIMARY]

-- facturas_items
CREATE TABLE ORION.facturas_items(
	idfactura_item		int IDENTITY(1,1) NOT NULL,
	idfactura			int,
	idconsumo			int
) ON [PRIMARY]

-- funcionalidades
CREATE TABLE ORION.funcionalidades(
	idfuncionalidad		int IDENTITY(1,1) NOT NULL,
	descripcion			nvarchar(255),	
	habilitado			bit default 1
) ON [PRIMARY]

-- gift_cards
CREATE TABLE ORION.gift_cards(
	idgift_card			int IDENTITY(1,1) NOT NULL,
	fecha				datetime,
	monto				decimal(18,2),
	idcliente_origen	int,
	idcliente_destino	int,
	habilitado			bit
) ON [PRIMARY]

-- proveedores
CREATE TABLE ORION.proveedores(
	idproveedor		int IDENTITY(1,1) NOT NULL,
	fecha_alta			datetime,
	razon_social	nvarchar(100),
	email				nvarchar(255),
	telefono			numeric(18,0),
	direccion			nvarchar(255),
	localidad			nvarchar(255),
	codigo_postal			nvarchar(8),
	idciudad				int,
	cuit					nvarchar(20),
	idrubro					nvarchar(100),
	contacto				nvarchar(100),
	idusuario				int,
	habilitado				bit default 1,
	rubro					nvarchar(100)				-- SE ELIMINA AL FINAL
) ON [PRIMARY]

-- roles
CREATE TABLE ORION.roles(
	idrol				int IDENTITY(1,1) NOT NULL,
	descripcion			nvarchar(50),
	habilitado			bit default 1
) ON [PRIMARY]

-- roles_funcionalidades
CREATE TABLE ORION.roles_funcionalidades(
	idrol_funcionalidad		int IDENTITY(1,1) NOT NULL,
	idrol					int,
	idfuncionalidad			int,
	habilitado				bit default 1
) ON [PRIMARY]

-- rubros
CREATE TABLE ORION.rubros(
	idrubro		int IDENTITY(1,1) NOT NULL,
	descripcion	 nvarchar(50)
) ON [PRIMARY]

-- tarjetas
CREATE TABLE ORION.tarjetas(
	idtarjeta				int IDENTITY(1,1) NOT NULL,
	fecha_alta				datetime,
	idtipo_tarjeta			tinyint,
	numero_tarjeta			nvarchar(50),
	digitos_verificadores	nvarchar(3),
	nombre_titular			nvarchar(50),
	dni_titular				nvarchar(8),
	fecha_vencimiento		datetime,
	idusuario				int,
	habilitado				bit default 1
) ON [PRIMARY]

-- tipos_pago
CREATE TABLE ORION.tipos_pago(
	idtipo_pago		int IDENTITY(1,1) NOT NULL,
	descripcion		nvarchar(50),
	habilitado		bit default 1
) ON [PRIMARY]

-- tipos_tarjeta
CREATE TABLE ORION.tipos_tarjeta(
	idtipo_tarjeta		int IDENTITY(1,1) NOT NULL,
	descripcion			nvarchar(50),
	habilitado		bit default 1
) ON [PRIMARY]

-- usuarios
CREATE TABLE ORION.usuarios(
	idusuario			int IDENTITY(1,1) NOT NULL,
	fecha_alta			datetime,
	username			nvarchar(50),
	clave				char(64),
	idrol				smallint,
	idusuario_tipo		int NOT NULL,
	intentos_fallidos	tinyint default 0,
	habilitado			bit default 1
) ON [PRIMARY]

-- tipos_tarjeta
CREATE TABLE ORION.usuarios_tipos(
	idusuario_tipo		int IDENTITY(1,1) NOT NULL,
	descripcion			nvarchar(50),
	habilitado		bit default 1
) ON [PRIMARY]
