-- Crear tablas!

-- cargas
CREATE TABLE ORION.cargas(
	idcarga			int IDENTITY(1,1) NOT NULL,
	fecha_carga		date,
	idcliente		int,
	idtipo_pago		smallint,
	monto			numeric(18,2),
	idtarjeta		int,
	habilitado			bit default 1
) ON [PRIMARY]

-- ciudades
CREATE TABLE ORION.ciudades(
	idciudad		smallint IDENTITY(1,1) NOT NULL,
	descripcion		varchar(255),
	habilitado			bit default 1
) ON [PRIMARY]

-- clientes
CREATE TABLE ORION.clientes(
	idcliente			int IDENTITY(1,1) NOT NULL,
	nombre				varchar(50),
	apellido			varchar(50),
	dni					numeric(18,0),
	email				varchar(50),
	telefono			numeric(18,0),
	direccion			varchar(50),
	codigo_postal		varchar(8),
	fecha_nacimiento	date,
	idusuario			int,
	credito_actual		numeric(18,2) default 0,
	habilitado				bit default 1
) ON [PRIMARY]
ALTER TABLE orion.clientes ADD CONSTRAINT telefono_uniq UNIQUE NONCLUSTERED (telefono)


-- clientes_ciudades
CREATE TABLE ORION.clientes_ciudades(
	idcliente_ciudad	int IDENTITY(1,1) NOT NULL,
	idcliente			int,
	idciudad			int,
	habilitado				bit default 1
) ON [PRIMARY]

-- compras
CREATE TABLE ORION.compras(
	idcompra			int IDENTITY(1,1) NOT NULL,
	idcliente			int,
	fecha_compra		date,
	cantidad			smallint,
	idcupon				int,
	nro_cupon			int,
	habilitado				bit default 1
) ON [PRIMARY]

-- compras_estados
CREATE TABLE ORION.compras_estados(
	idcompra_estado		int IDENTITY(1,1) NOT NULL,
	descripcion			varchar(50)
) ON [PRIMARY]

-- consumos
CREATE TABLE ORION.consumos(
	idconsumo			int IDENTITY(1,1) NOT NULL,
	fecha_consumo		date,
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
	fecha_devolucion	date,
	idcompra			int,
	motivo				varchar(200)
) ON [PRIMARY]

-- facturas
CREATE TABLE ORION.facturas(
	idfactura			int IDENTITY(1,1) NOT NULL,
	fecha_generacion	date,
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
	descripcion			varchar(255),	
	habilitado			bit default 1
) ON [PRIMARY]

-- gift_cards
CREATE TABLE ORION.gift_cards(
	idgift_card			int IDENTITY(1,1) NOT NULL,
	fecha				date,
	monto				decimal(18,2),
	idcliente_origen	int,
	idcliente_destino	int,
	habilitado			bit
) ON [PRIMARY]

-- proveedores
CREATE TABLE ORION.proveedores(
	idproveedor		int IDENTITY(1,1) NOT NULL,
	fecha_alta			date,
	razon_social	varchar(100),
	email				varchar(50),
	telefono			numeric(18,0),
	direccion			varchar(100),
	codigo_postal			varchar(8),
	idciudad				int,
	cuit					char(11),
	idrubro					int,
	contacto				varchar(100),
	idusuario				int,
	habilitado				bit default 1,
	rubro					varchar(100)				-- SE ELIMINA AL FINAL
) ON [PRIMARY]
ALTER TABLE orion.proveedores ADD CONSTRAINT cuit_razon_uniq UNIQUE NONCLUSTERED (cuit,razon_social)
-- roles
CREATE TABLE ORION.roles(
	idrol				int IDENTITY(1,1) NOT NULL,
	descripcion			varchar(50),
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
	descripcion	 varchar(50)
) ON [PRIMARY]

-- tarjetas
CREATE TABLE ORION.tarjetas(
	idtarjeta				int IDENTITY(1,1) NOT NULL,
	fecha_alta				date,
	idtipo_tarjeta			tinyint,
	numero_tarjeta			varchar(16),
	digitos_verificadores	varchar(3),
	nombre_titular			varchar(50),
	dni_titular				varchar(8),
	fecha_vencimiento		date,
	idusuario				int,
	habilitado				bit default 1
) ON [PRIMARY]

-- tipos_pago
CREATE TABLE ORION.tipos_pago(
	idtipo_pago		int IDENTITY(1,1) NOT NULL,
	descripcion		varchar(50),
	habilitado		bit default 1,
	visible			bit default 1
) ON [PRIMARY]

-- tipos_tarjeta
CREATE TABLE ORION.tipos_tarjeta(
	idtipo_tarjeta		int IDENTITY(1,1) NOT NULL,
	descripcion			varchar(50),
	habilitado		bit default 1
) ON [PRIMARY]

-- usuarios
CREATE TABLE ORION.usuarios(
	idusuario			int IDENTITY(1,1) NOT NULL,
	fecha_alta			date,
	username			varchar(50),
	clave				char(64),
	idrol				smallint,
	idusuario_tipo		int NOT NULL,
	intentos_fallidos	tinyint default 0,
	habilitado			bit default 1
) ON [PRIMARY]

-- tipos_tarjeta
CREATE TABLE ORION.usuarios_tipos(
	idusuario_tipo		int IDENTITY(1,1) NOT NULL,
	descripcion			varchar(50),
	habilitado		bit default 1
) ON [PRIMARY]


-- ACA VAN LOS DATOS DE LA MIGRACION
-- Carga completa clientes, giftcards y cargas, tipos_pago, ciudades, clientes_ciudades:	3:01
select distinct cli_nombre, cli_apellido, Cli_Dni,Cli_Direccion, Cli_Telefono, Cli_Mail, Cli_Fecha_Nac, Cli_Ciudad,
Carga_Credito, Carga_Fecha, Cli_Dest_Dni, GiftCard_Fecha, GiftCard_Monto
into orion.clientes_temp
from gd_esquema.Maestra
	
		-- Agrego indices			
		CREATE INDEX idx_clientes_temp_cli_dest_dni ON ORION.clientes_temp(cli_dest_dni)
		CREATE INDEX idx_clientes_temp_cli_dni ON ORION.clientes_temp(cli_dni)
		
-- Clientes: 			??:??

insert into ORION.clientes(nombre, apellido, dni, email, telefono, direccion, localidad, codigo_postal,
fecha_nacimiento, idusuario, credito_actual, activo)
select distinct cli_nombre, Cli_Apellido, Cli_Dni,  Cli_Mail, Cli_Telefono, Cli_Direccion, Cli_Ciudad,
'' codpostal, Cli_Fecha_Nac, 0 idusuario, 0 credito, 1 habilitado
from ORION.clientes_temp

	CREATE INDEX idx_clientes_dni ON ORION.clientes(dni)

-- GiftCards:		00:03
insert into orion.gift_cards(fecha, monto, idcliente_origen, idcliente_destino)
select ct.giftcard_fecha, ct.giftcard_monto, c.idcliente, c2.idcliente
from orion.clientes_temp ct
left join orion.clientes c on c.dni = ct.cli_dni
left join orion.clientes c2 on c2.dni = ct.cli_dest_dni
where ct.giftcard_fecha is not null

--Cargas crédito		00:06
insert into orion.cargas(fecha_carga, idcliente, idtipo_pago, monto)
select carga_fecha, c.idcliente, case tipo_pago_desc when 'Efectivo' then 1 when 'Crédito' then 2 else 0 end,
ct.carga_credito
from orion.clientes_temp ct
left join orion.clientes c on c.dni = ct.cli_dni
where ct.carga_credito is not null

-- Tipos_pago			00:00
insert into ORION.tipos_pago(descripcion, visible) values('Sistema', 0)
insert into ORION.tipos_pago(descripcion) values('Efectivo')
insert into ORION.tipos_pago(descripcion) values('Crédito')

--Ciudades			00:00
insert into ORION.ciudades(descripcion) 
select distinct localidad from ORION.clientes

-- Clientes_ciudades		00:00

insert into ORION.clientes_ciudades(idcliente, idciudad)
select c.idcliente, ci.idciudad from ORION.clientes c
left join orion.ciudades ci on ci.descripcion = c.localidad

-- Carga general proveedores, cupones, devoluciones, compras, compras_estados,
 --facturas, rubros, cupones_ciudades, funcionalidades, roles, facturas, facturas_items		02:17

select cli_dni, Provee_RS,Provee_Dom,Provee_Ciudad,Provee_Telefono,Provee_CUIT,Provee_Rubro,
Groupon_Cantidad, Groupon_Codigo, Groupon_Descripcion,
Groupon_Devolucion_Fecha, Groupon_Entregado_Fecha, Groupon_Fecha, Groupon_Fecha_Compra, 
Groupon_Fecha_Venc, Groupon_Precio, Groupon_Precio_Ficticio, Factura_Nro, Factura_Fecha
into orion.proveedores_temp
from gd_esquema.Maestra

	-- Agrego indices		00:46
	CREATE INDEX idx_proveedores_temp_cli_dni ON ORION.proveedores_temp(cli_dni)
	CREATE INDEX idx_proveedores_temp_prove_cuit ON ORION.proveedores_temp(provee_cuit)
	CREATE INDEX idx_proveedores_temp_groupon_codigo ON ORION.proveedores_temp(groupon_codigo)
	CREATE INDEX idx_proveedores_temp_rs ON ORION.proveedores_temp(provee_rs)

-- Proveedores:  			00:46
insert into ORION.proveedores(razon_social, direccion, localidad, telefono, cuit, rubro)
select distinct Provee_RS,Provee_Dom,Provee_Ciudad,Provee_Telefono,Provee_CUIT,Provee_Rubro from orion.proveedores_temp
WHERE orion.proveedores_temp.provee_RS is not null

	-- Agrego indices		00:00
	CREATE INDEX idx_proveedores_prove_cuit ON ORION.proveedores(cuit)

	-- Actualizo la ciudad en la que trabaja 		00:00
	update ORION.proveedores set idciudad = (select idciudad from ORION.ciudades where descripcion = localidad)

-- Rubros					00:03
insert into orion.rubros(descripcion) 
select distinct rubro from ORION.proveedores

-- Actualizo a los proveedores su rubro y borro la columna de rubro	00:00
update ORION.proveedores set idrubro = (select idrubro from ORION.rubros where descripcion = rubro)
alter table orion.proveedores drop column rubro

-- Cupones				00:43
insert into ORION.cupones(idproveedor, descripcion, codigo, fecha_publicacion, fecha_vencimiento, precio_real, precio_ficticio,
cantidad_disponible)
select p.idproveedor, groupon_descripcion, groupon_codigo, groupon_fecha, groupon_fecha_venc, groupon_precio, groupon_precio_ficticio,
sum(isnull(groupon_cantidad,0))
from ORION.proveedores_temp ct
inner join ORION.proveedores p on p.cuit = ct.provee_cuit
group by p.idproveedor, groupon_descripcion,groupon_codigo, groupon_fecha, groupon_fecha_venc, groupon_precio, groupon_precio_ficticio


-- Compras_estados		00:00
insert into ORION.compras_estados(descripcion) values('Comprado')
insert into ORION.compras_estados(descripcion) values('Entregado')
insert into ORION.compras_estados(descripcion) values('Devuelto')
insert into ORION.compras_estados(descripcion) values('Vencido')

-- Compras				00:08
insert into orion.compras(idcliente, fecha_compra, cantidad, idcupon, nro_cupon)
select c.idcliente, pt.Groupon_Fecha_Compra, COUNT(distinct Groupon_Codigo), cu.idcupon, cu.idcupon
from orion.proveedores_temp pt
left join ORION.clientes c on c.dni = pt.cli_dni
left join ORION.cupones cu on cu.codigo = pt.Groupon_Codigo
where Groupon_Descripcion is not null and groupon_fecha_compra is not null and groupon_devolucion_Fecha is null and 
groupon_entregado_fecha is null
group by c.idcliente, pt.Groupon_Fecha_Compra, cu.idcupon, Groupon_Devolucion_Fecha, Groupon_Entregado_Fecha

-- Devoluciones			00:05
insert into ORION.devoluciones(fecha_devolucion, idcompra, motivo)
select Groupon_Devolucion_Fecha, co.idcompra, '- no especifica (carga inicial) -' 
from orion.proveedores_temp pt
left join ORION.clientes c on c.dni = pt.cli_dni
left join ORION.cupones cu on cu.codigo = pt.Groupon_Codigo
left join ORION.compras co on co.idcliente = c.idcliente and co.idcupon = cu.idcupon
where Groupon_Descripcion is not null and groupon_fecha_compra is not null and groupon_devolucion_Fecha is not null and 
groupon_entregado_fecha is null
group by  Groupon_Devolucion_Fecha, co.idcompra
order by Groupon_Devolucion_Fecha

-- Consumos				00:05
insert into ORION.consumos(fecha_consumo, idcompra)
select Groupon_Entregado_Fecha, co.idcompra
from orion.proveedores_temp pt
left join ORION.clientes c on c.dni = pt.cli_dni
left join ORION.cupones cu on cu.codigo = pt.Groupon_Codigo
left join ORION.compras co on co.idcliente = c.idcliente and co.idcupon = cu.idcupon
where Groupon_Descripcion is not null and groupon_fecha_compra is not null and groupon_devolucion_Fecha is null and 
groupon_entregado_fecha is not null
group by  Groupon_Entregado_Fecha, co.idcompra
order by Groupon_Entregado_Fecha

-- Facturas				00:01
insert into ORION.facturas(fecha_generacion, idproveedor, nro_factura)
select distinct Factura_Fecha, p.idproveedor, Factura_Nro
from ORION.proveedores_temp pt
left join orion.proveedores p on pt.Provee_CUIT = p.cuit
where Factura_Fecha is not null
order by Factura_Fecha, factura_nro

-- FActuras_items			
insert into ORION.facturas_items(idfactura, idconsumo)
select f.idfactura, con.idconsumo
from orion.proveedores_temp pt
left join ORION.clientes c on c.dni = pt.cli_dni
left join ORION.cupones cu on cu.codigo = pt.Groupon_Codigo
left join ORION.compras co on co.idcliente = c.idcliente and co.idcupon = cu.idcupon
left join ORION.consumos con on con.idcompra = co.idcompra
left join ORION.facturas f on f.nro_factura = pt.Factura_Nro
where Groupon_Descripcion is not null and groupon_fecha_compra is not null and groupon_devolucion_Fecha is null and 
groupon_entregado_fecha is null and pt.Factura_Nro is not null
order by f.idfactura, con.idconsumo


-- cupones_ciudades		00:00
insert into ORION.cupones_ciudades(idcupon, idciudad) select c.idcupon, p.idciudad from ORION.cupones c
left join orion.proveedores p on p.idproveedor = c.idproveedor

-- Usuarios_tipo			00:00
insert into ORION.usuarios_tipos(descripcion) values('Administrativo')
insert into ORION.usuarios_tipos(descripcion) values('Cliente')
insert into ORION.usuarios_tipos(descripcion) values('Proveedor')

-- Funcionalidades		00:00
insert into ORION.funcionalidades(descripcion) values('ABM de Cliente');
insert into ORION.funcionalidades(descripcion) values('ABM de Proveedor');
insert into ORION.funcionalidades(descripcion) values('ABM de Rol');
insert into ORION.funcionalidades(descripcion) values('Armar Cupón');
insert into ORION.funcionalidades(descripcion) values('Cargar Crédito');
insert into ORION.funcionalidades(descripcion) values('Comprar Cupón');
insert into ORION.funcionalidades(descripcion) values('Comprar GiftCard');
insert into ORION.funcionalidades(descripcion) values('Facturación a Proveedor');
insert into ORION.funcionalidades(descripcion) values('Historial de Compra de Cupones');
insert into ORION.funcionalidades(descripcion) values('Listado Estadístico');
insert into ORION.funcionalidades(descripcion) values('Pedir Devolución');
insert into ORION.funcionalidades(descripcion) values('Publicar Cupón');
insert into ORION.funcionalidades(descripcion) values('Registro de consumo de Cupón');
insert into ORION.funcionalidades(descripcion) values('Registro de Usuario');

-- Roles					00:00
Insert into orion.roles(descripcion) values('Administrador');
Insert into orion.roles(descripcion) values('Cliente');
Insert into orion.roles(descripcion) values('Proveedor');
Insert into orion.roles(descripcion) values('Administrador general');

-- Asigno las funcionalidades default de cada uno

	-- Clientes
	insert into ORION.roles_funcionalidades(idrol, idfuncionalidad) 
	select 2,idfuncionalidad from orion.funcionalidades where idfuncionalidad in (5, 6,7,9, 11,14)

	-- Proveedores
	insert into ORION.roles_funcionalidades(idrol, idfuncionalidad) 
	select 3,idfuncionalidad from orion.funcionalidades where idfuncionalidad in (4, 13 )

	-- Rol Administrador General
	insert into ORION.roles_funcionalidades(idrol, idfuncionalidad) select 4,idfuncionalidad from  orion.funcionalidades order by idfuncionalidad


-- Usuario administrativo
insert into ORION.usuarios(fecha_alta, username, clave, idrol, idusuario_tipo) values(
'20121001', 'admin', 'E6B87050BFCB8143FCB8DB0170A4DC9ED00D904DDD3E2A4AD1B1E8DC0FDC9BE7', 4,4)

-- Usuario clientes
insert into ORION.usuarios(fecha_alta, username, clave, idrol, idusuario_tipo)
select '20121001', dni, '8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92', 2, 2 from ORION.clientes

update ORION.clientes set idusuario = us.idusuario from ORION.usuarios us where us.username = cast(ORION.clientes.dni as varchar)
and us.idusuario_tipo = 2

-- Usuario proveedores
insert into ORION.usuarios(fecha_alta, username, clave, idrol, idusuario_tipo)
select '20121001', cuit, '8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C920',3,3 from ORION.proveedores

update ORION.proveedores set idusuario = us.idusuario from ORION.usuarios us where us.username = cast(ORION.proveedores.cuit as varchar)
and us.idusuario_tipo = 3


-- FINALMENTE, BORRO LAS TABLAS TEMPORALES
drop table orion.proveedores_temp
drop table orion.clientes_temp