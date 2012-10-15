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
	cod_postal			nvarchar(8),
	fecha_nacimiento	datetime,
	idusuario			int,
	credito_actual		numeric(18,2) default 0,
	activo				bit default 1
) ON [PRIMARY]

-- clientes_ciudades
CREATE TABLE ORION.clietes_ciudades(
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
	nro_cupon			nvarchar(50),
	idtipo_pago			int,
	monto				numeric(18,2),
	idtarjeta			int,
	activo				bit default 1
) ON [PRIMARY]

--PAUSA
-- compras_estados
CREATE TABLE ORION.cargas(
	idcarga		int IDENTITY(1,1) NOT NULL,
	fecha_carga datetime,
	idcliente	int,
	idtipo_pago	smallint,
	monto		money,
	idtarjeta	int,
	activo		bit
) ON [PRIMARY]

-- consumos
CREATE TABLE ORION.cargas(
	idcarga		int IDENTITY(1,1) NOT NULL,
	fecha_carga datetime,
	idcliente	int,
	idtipo_pago	smallint,
	monto		money,
	idtarjeta	int,
	activo		bit
) ON [PRIMARY]

-- cupones
CREATE TABLE ORION.cargas(
	idcarga		int IDENTITY(1,1) NOT NULL,
	fecha_carga datetime,
	idcliente	int,
	idtipo_pago	smallint,
	monto		money,
	idtarjeta	int,
	activo		bit
) ON [PRIMARY]

-- cupones_ciudades
CREATE TABLE ORION.cargas(
	idcarga		int IDENTITY(1,1) NOT NULL,
	fecha_carga datetime,
	idcliente	int,
	idtipo_pago	smallint,
	monto		money,
	idtarjeta	int,
	activo		bit
) ON [PRIMARY]

-- devoluciones
CREATE TABLE ORION.cargas(
	idcarga		int IDENTITY(1,1) NOT NULL,
	fecha_carga datetime,
	idcliente	int,
	idtipo_pago	smallint,
	monto		money,
	idtarjeta	int,
	activo		bit
) ON [PRIMARY]

-- facturas
CREATE TABLE ORION.cargas(
	idcarga		int IDENTITY(1,1) NOT NULL,
	fecha_carga datetime,
	idcliente	int,
	idtipo_pago	smallint,
	monto		money,
	idtarjeta	int,
	activo		bit
) ON [PRIMARY]

-- facturas_items
CREATE TABLE ORION.cargas(
	idcarga		int IDENTITY(1,1) NOT NULL,
	fecha_carga datetime,
	idcliente	int,
	idtipo_pago	smallint,
	monto		money,
	idtarjeta	int,
	activo		bit
) ON [PRIMARY]

-- funcionalidades
CREATE TABLE ORION.cargas(
	idcarga		int IDENTITY(1,1) NOT NULL,
	fecha_carga datetime,
	idcliente	int,
	idtipo_pago	smallint,
	monto		money,
	idtarjeta	int,
	activo		bit
) ON [PRIMARY]

-- gift_cards
CREATE TABLE ORION.cargas(
	idcarga		int IDENTITY(1,1) NOT NULL,
	fecha_carga datetime,
	idcliente	int,
	idtipo_pago	smallint,
	monto		money,
	idtarjeta	int,
	activo		bit
) ON [PRIMARY]

-- proveedores
CREATE TABLE ORION.cargas(
	idcarga		int IDENTITY(1,1) NOT NULL,
	fecha_carga datetime,
	idcliente	int,
	idtipo_pago	smallint,
	monto		money,
	idtarjeta	int,
	activo		bit
) ON [PRIMARY]

-- publicaciones
CREATE TABLE ORION.cargas(
	idcarga		int IDENTITY(1,1) NOT NULL,
	fecha_carga datetime,
	idcliente	int,
	idtipo_pago	smallint,
	monto		money,
	idtarjeta	int,
	activo		bit
) ON [PRIMARY]

-- roles
CREATE TABLE ORION.cargas(
	idcarga		int IDENTITY(1,1) NOT NULL,
	fecha_carga datetime,
	idcliente	int,
	idtipo_pago	smallint,
	monto		money,
	idtarjeta	int,
	activo		bit
) ON [PRIMARY]
-- roles_funcionalidades
CREATE TABLE ORION.cargas(
	idcarga		int IDENTITY(1,1) NOT NULL,
	fecha_carga datetime,
	idcliente	int,
	idtipo_pago	smallint,
	monto		money,
	idtarjeta	int,
	activo		bit
) ON [PRIMARY]

-- rubros
CREATE TABLE ORION.cargas(
	idcarga		int IDENTITY(1,1) NOT NULL,
	fecha_carga datetime,
	idcliente	int,
	idtipo_pago	smallint,
	monto		money,
	idtarjeta	int,
	activo		bit
) ON [PRIMARY]

-- tarjetas
CREATE TABLE ORION.cargas(
	idcarga		int IDENTITY(1,1) NOT NULL,
	fecha_carga datetime,
	idcliente	int,
	idtipo_pago	smallint,
	monto		money,
	idtarjeta	int,
	activo		bit
) ON [PRIMARY]

-- tipos_pago
CREATE TABLE ORION.cargas(
	idcarga		int IDENTITY(1,1) NOT NULL,
	fecha_carga datetime,
	idcliente	int,
	idtipo_pago	smallint,
	monto		money,
	idtarjeta	int,
	activo		bit
) ON [PRIMARY]

-- tipos_tarjeta
CREATE TABLE ORION.cargas(
	idcarga		int IDENTITY(1,1) NOT NULL,
	fecha_carga datetime,
	idcliente	int,
	idtipo_pago	smallint,
	monto		money,
	idtarjeta	int,
	activo		bit
) ON [PRIMARY]

-- usuarios
CREATE TABLE ORION.cargas(
	idcarga		int IDENTITY(1,1) NOT NULL,
	fecha_carga datetime,
	idcliente	int,
	idtipo_pago	smallint,
	monto		money,
	idtarjeta	int,
	activo		bit
) ON [PRIMARY]
