-- Crear tablas!
begin transaction tran1

USE [GD2C2012]
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- cargas
CREATE TABLE ORION.cargas(
	idcarga			int IDENTITY(1,1) NOT NULL,
	fecha_carga		date NOT NULL,
	idcliente		int NOT NULL,
	idtipo_pago		smallint NOT NULL,
	monto			numeric(18,2) NOT NULL,
	idtarjeta		int,
	activo			bit default 1,
) ON [PRIMARY]
alter table orion.cargas add constraint pk_cargas primary key (idcarga)

-- ciudades
CREATE TABLE ORION.ciudades(
	idciudad		smallint IDENTITY(1,1) NOT NULL,
	descripcion		varchar(50) NOT NULL,
	activo			bit default 1
) ON [PRIMARY]
alter table orion.ciudades add constraint pk_ciudades primary key (idciudad)
-- clientes
CREATE TABLE ORION.clientes(
	idcliente			int IDENTITY(1,1) NOT NULL,
	nombre				varchar(50) NOT NULL,
	apellido			varchar(50) NOT NULL,
	dni					numeric(18,0) NOT NULL,
	email				varchar(50) NOT NULL,
	telefono			numeric(18,0) NOT NULL,
	direccion			varchar(100) NOT NULL,
	codigo_postal		varchar(8),
	fecha_nacimiento	date NOT NULL,
	idusuario			int NOT NULL,
	credito_actual		numeric(18,2) default 0 NOT NULL,
	solicitar_datos		bit default 0,
	habilitado			bit default 1,
	localidad			varchar(100)				-- SE ELIMINA AL FINAL
) ON [PRIMARY]
alter table orion.clientes add constraint pk_clientes primary key (idcliente)
ALTER TABLE orion.clientes ADD CONSTRAINT telefono_uniq UNIQUE NONCLUSTERED (telefono)


-- clientes_ciudades
CREATE TABLE ORION.clientes_ciudades(
	idcliente_ciudad	int IDENTITY(1,1) NOT NULL,
	idcliente			int NOT NULL,
	idciudad			smallint NOT NULL,
	activo				bit default 1
) ON [PRIMARY]
alter table orion.clientes_ciudades add constraint pk_clientes_ciudades primary key (idcliente_ciudad)

-- compras
CREATE TABLE ORION.compras(
	idcompra			int IDENTITY(1,1) NOT NULL,
	idcliente			int NOT NULL,
	fecha_compra		date NOT NULL,
	cantidad			smallint NOT NULL,
	idcupon				int NOT NULL,
	nro_cupon			int NOT NULL,
	idcompra_estado		tinyint NOT NULL,
	activo				bit default 1
) ON [PRIMARY]
alter table orion.compras add constraint pk_compras primary key (idcompra)

-- compras_estados
CREATE TABLE ORION.compras_estados(
	idcompra_estado		tinyint IDENTITY(1,1) NOT NULL,
	descripcion			varchar(50) NOT NULL,
	activo				bit default 1
) ON [PRIMARY]
alter table orion.compras_estados add constraint pk_compras_estados primary key (idcompra_estado)

-- consumos
CREATE TABLE ORION.consumos(
	idconsumo			int IDENTITY(1,1) NOT NULL,
	fecha_consumo		date NOT NULL,
	idcompra			int NOT NULL,
	facturado			bit default 0,
	activo				bit default 1
) ON [PRIMARY]
alter table orion.consumos add constraint pk_consumos primary key (idconsumo)

-- cupones
CREATE TABLE ORION.cupones(
	idcupon 				int IDENTITY(1,1) NOT NULL,
	idproveedor 			int  NOT NULL,
	descripcion 			varchar(200) NOT NULL,
	codigo 					varchar(50) NOT NULL,
	fecha_alta 				date NOT NULL,
	fecha_publicacion 		date NOT NULL,
	fecha_vencimiento 		date NOT NULL,
	fecha_vencimiento_canje date NOT NULL,
	precio_real 			decimal(18, 2) NOT NULL,
	precio_ficticio 		decimal(18, 2) NOT NULL,
	cantidad_disponible 	smallint NOT NULL,
	cantidad_max_usuario 	smallint NOT NULL,
	publicado 				bit default 0,
	fecha_publicacion_real 	date NOT NULL,
	activo				bit default 1
) ON [PRIMARY]
alter table orion.cupones add constraint pk_cupones primary key (idcupon)

-- cupones_ciudades
CREATE TABLE ORION.cupones_ciudades(
	idcupon_ciudad		int IDENTITY(1,1) NOT NULL,
	idcupon				int NOT NULL,
	idciudad			smallint NOT NULL,
	activo				bit default 1
) ON [PRIMARY]
alter table orion.cupones_ciudades add constraint pk_cupones_ciudades primary key (idcupon_ciudad)

-- devoluciones
CREATE TABLE ORION.devoluciones(
	iddevolucion		int IDENTITY(1,1) NOT NULL,
	fecha_devolucion	date NOT NULL,
	idcompra			int NOT NULL,
	motivo				varchar(200) NOT NULL,
	activo				bit default 1
) ON [PRIMARY]
alter table orion.devoluciones add constraint pk_devoluciones primary key (iddevolucion)

-- facturas
CREATE TABLE ORION.facturas(
	idfactura			int IDENTITY(1,1) NOT NULL,
	fecha_generacion	date NOT NULL,
	idproveedor			int NOT NULL,
	nro_factura			numeric(18,0) NOT NULL,
	monto_total			decimal(18,2) NOT NULL,
	activo				bit default 1
) ON [PRIMARY]
alter table orion.facturas add constraint pk_facturas primary key (idfactura)

-- facturas_items
CREATE TABLE ORION.facturas_items(
	idfactura_item		int IDENTITY(1,1) NOT NULL,
	idfactura			int NOT NULL,
	idconsumo			int NOT NULL,
	activo				bit default 1
) ON [PRIMARY]
alter table orion.facturas_items add constraint pk_facturas_items primary key (idfactura_item)

-- funcionalidades
CREATE TABLE ORION.funcionalidades(
	idfuncionalidad		int IDENTITY(1,1) NOT NULL,
	descripcion			varchar(50) NOT NULL,	
	activo				bit default 1
) ON [PRIMARY]
alter table orion.funcionalidades add constraint pk_funcionalidades primary key (idfuncionalidad)

-- gift_cards
CREATE TABLE ORION.gift_cards(
	idgift_card			int IDENTITY(1,1) NOT NULL,
	fecha				date NOT NULL,
	monto				decimal(18,2) NOT NULL,
	idcliente_origen	int NOT NULL,
	idcliente_destino	int NOT NULL,
	activo				bit default 1
) ON [PRIMARY]
alter table orion.gift_cards add constraint pk_gift_cards primary key (idgift_card)

-- proveedores
CREATE TABLE ORION.proveedores(
	idproveedor		int IDENTITY(1,1) NOT NULL,
	fecha_alta		date  NOT NULL,
	razon_social	varchar(100) NOT NULL,
	email			varchar(50) NOT NULL,
	telefono		numeric(18,0) NOT NULL,
	direccion		varchar(100) NOT NULL,
	codigo_postal	varchar(8) NOT NULL default '-',
	idciudad		smallint NOT NULL,
	cuit			char(11) NOT NULL,
	idrubro			int NOT NULL,
	contacto		varchar(50) NOT NULL,
	idusuario		int NOT NULL,
	habilitado		bit default 1 NOT NULL,
	rubro			varchar(100)				-- SE ELIMINA AL FINAL	
) ON [PRIMARY]
ALTER TABLE orion.proveedores ADD CONSTRAINT cuit_razon_uniq UNIQUE NONCLUSTERED (cuit,razon_social)
alter table orion.proveedores add constraint pk_proveedores primary key (idproveedor)

-- roles
CREATE TABLE ORION.roles(
	idrol				int IDENTITY(1,1) NOT NULL,
	descripcion			varchar(50) NOT NULL,
	activo				bit default 1
) ON [PRIMARY]
alter table orion.roles add constraint pk_roles primary key (idrol)

-- roles_funcionalidades
CREATE TABLE ORION.roles_funcionalidades(
	idrol_funcionalidad		int IDENTITY(1,1) NOT NULL,
	idrol					int NOT NULL,
	idfuncionalidad			int NOT NULL,
	activo					bit default 1
) ON [PRIMARY]
alter table orion.roles_funcionalidades add constraint pk_roles_funcionalidades primary key (idrol_funcionalidad)

-- rubros
CREATE TABLE ORION.rubros(
	idrubro			int IDENTITY(1,1) NOT NULL,
	descripcion	 	varchar(50) NOT NULL,
	activo			bit default 1
) ON [PRIMARY]
alter table orion.rubros add constraint pk_rubros primary key (idrubro)

-- tarjetas
CREATE TABLE ORION.tarjetas(
	idtarjeta				int IDENTITY(1,1) NOT NULL,
	fecha_alta				date NOT NULL,
	idtipo_tarjeta			tinyint NOT NULL,
	numero_tarjeta			varchar(16) NOT NULL,
	digitos_verificadores	varchar(3) NOT NULL,
	nombre_titular			varchar(50) NOT NULL,
	dni_titular				int  NOT NULL,
	mes_vencimiento			tinyint	NOT NULL,
	anio_vencimiento		smallint NOT NULL,
	idusuario				int NOT NULL,
	activo				bit default 1
) ON [PRIMARY]
alter table orion.tarjetas add constraint pk_tarjetas primary key (idtarjeta)

-- tipos_pago
CREATE TABLE ORION.tipos_pago(
	idtipo_pago		int IDENTITY(1,1) NOT NULL,
	descripcion		varchar(50) NOT NULL,
	visible			bit default 1,
	activo			bit default 1
) ON [PRIMARY]
alter table orion.tipos_pago add constraint pk_tipos_pago primary key (idtipo_pago)

-- tipos_tarjeta
CREATE TABLE ORION.tipos_tarjeta(
	idtipo_tarjeta		tinyint IDENTITY(1,1) NOT NULL,
	descripcion			varchar(50) NOT NULL,
	activo				bit default 1
) ON [PRIMARY]
alter table orion.tipos_tarjeta add constraint pk_tipos_tarjeta primary key (idtipo_tarjeta)

-- tipos_usuario
CREATE TABLE ORION.tipos_usuario(
	idtipo_usuario		int IDENTITY(1,1) NOT NULL,
	descripcion			varchar(50) NOT NULL,
	activo				bit default 1
) ON [PRIMARY]
alter table orion.tipos_usuario add constraint pk_tipos_usuario primary key (idtipo_usuario)

CREATE TABLE ORION.tipos_usuario_rol(
	idtipo_usuario_rol		int IDENTITY(1,1) NOT NULL,
	idtipo_usuario			int NOT NULL,
	idrol					int	NOT NULL,
	activo					bit default 1
) ON [PRIMARY]
alter table orion.tipos_usuario_rol add constraint pk_tipos_usuario_rol primary key (idtipo_usuario_rol)


-- usuarios
CREATE TABLE ORION.usuarios(
	idusuario			int IDENTITY(1,1) NOT NULL,
	fecha_alta			date NOT NULL,
	username			varchar(50) NOT NULL,
	clave				char(64) NOT NULL,
	idrol				int NOT NULL,
	idtipo_usuario		int NOT NULL,
	intentos_fallidos	tinyint default 0,
	habilitado			bit default 1
) ON [PRIMARY]
alter table orion.usuarios add constraint pk_usuarios primary key (idusuario)

GO
-- Agrego los FK
alter table orion.cargas add constraint fk_cargas_idcliente foreign key (idcliente) references orion.clientes (idcliente)
alter table orion.cargas add constraint fk_cargas_idtarjeta foreign key (idtarjeta) references orion.tarjetas (idtarjeta)

alter table orion.clientes add constraint fk_clientes_idusuario foreign key (idusuario) references orion.usuarios (idusuario)

alter table orion.clientes_ciudades add constraint fk_clientes_ciudades_idcliente foreign key (idcliente) references orion.clientes (idcliente)
alter table orion.clientes_ciudades add constraint fk_clientes_ciudades_idciudad foreign key (idciudad) references orion.ciudades (idciudad)

alter table orion.cupones_ciudades add constraint fk_cupones_ciudades_idcupon foreign key (idcupon) references orion.cupones (idcupon)
alter table orion.cupones_ciudades add constraint fk_cupones_ciudades_idciudad foreign key (idciudad) references orion.ciudades (idciudad)

alter table orion.compras add constraint fk_compras_idcliente foreign key (idcliente) references orion.clientes (idcliente)
alter table orion.compras add constraint fk_compras_idcupon foreign key (idcupon) references orion.cupones (idcupon)
alter table orion.compras add constraint fk_compras_idcompra_estado foreign key (idcompra_estado) references orion.compras_estados (idcompra_estado)

alter table orion.consumos add constraint fk_consumos_idcompra foreign key (idcompra) references orion.compras (idcompra)

alter table orion.cupones add constraint fk_cupones_idproveedor foreign key (idproveedor) references orion.proveedores (idproveedor)

alter table orion.devoluciones add constraint fk_devoluciones_idcompra foreign key (idcompra) references orion.compras (idcompra)

alter table orion.facturas add constraint fk_facturas_idproveedor foreign key (idproveedor) references orion.proveedores (idproveedor)

alter table orion.facturas_items add constraint fk_facturas_items_idfactura foreign key (idfactura) references orion.facturas (idfactura)

alter table orion.gift_cards add constraint fk_gift_cards_idcliente_origen foreign key (idcliente_origen) references orion.clientes (idcliente)
alter table orion.gift_cards add constraint fk_gift_cards_idcliente_destino foreign key (idcliente_destino) references orion.clientes (idcliente)

alter table orion.proveedores add constraint fk_proveedores_idrubro foreign key (idrubro) references orion.rubros (idrubro)
alter table orion.proveedores add constraint fk_proveedores_idusuario foreign key (idusuario) references orion.usuarios (idusuario)

alter table orion.roles_funcionalidades add constraint fk_roles_funcionalidades_idrol foreign key (idrol) references orion.roles(idrol)
alter table orion.roles_funcionalidades add constraint fk_roles_funcionalidades_idfuncionalidad foreign key (idfuncionalidad) references orion.funcionalidades(idfuncionalidad)

alter table orion.tarjetas add constraint fk_tarjetas_idtipo_tarjeta foreign key (idtipo_tarjeta) references orion.tipos_tarjeta(idtipo_tarjeta)
alter table orion.tarjetas add constraint fk_tarjetas_idisuario foreign key (idusuario) references orion.usuarios(idusuario)

alter table orion.tipos_usuario_rol add constraint fk_tipos_usuario_rol_idtipo_usuario foreign key (idtipo_usuario) references orion.tipos_usuario (idtipo_usuario)
alter table orion.tipos_usuario_rol add constraint fk_tipos_usuario_rol_idrol foreign key (idrol) references orion.roles (idrol)

alter table orion.usuarios add constraint fk_usuarios_idrol foreign key (idrol) references orion.roles (idrol)
alter table orion.usuarios add constraint fk_usuarios_idtipo_usuario foreign key (idtipo_usuario) references orion.tipos_usuario(idtipo_usuario)

GO
-- Creo los Stored Procedures
-- =============================================
-- Description:	Inserta un registro en la tabla de clientes y devueve en output el idcliente generado
-- =============================================
CREATE PROCEDURE [ORION].[Clientes_Grabar]
	@fecha date = null, @nombre varchar(50), @apellido varchar(50), @dni int, @mail varchar(50), @telefono varchar(50), 
	@direccion varchar(100), @codpost varchar(8), @fechanac date, @idusuario int, @idcliente int = 0 output
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	-- Si es un alta
	if (@idcliente = 0) begin
		-- Me fijo antes que no haya otro "duplicado"
		if exists (select idcliente from ORION.clientes where dni = @dni or telefono = @telefono) begin
			return 1	-- Cliente duplicado
		end
		else begin
			insert into ORION.clientes(nombre, apellido, dni, email, telefono, direccion, codigo_postal, fecha_nacimiento, idusuario, credito_actual)
			values(@nombre, @apellido, @dni, @mail, @telefono,@direccion, @codpost, @fechanac, @idusuario, 10)
			
			set @idcliente = @@IDENTITY
			
			--Carga inicial de $15!
			insert into ORION.cargas(idcliente, idtipo_pago, fecha_carga, monto) values(@idcliente, 1, @fecha, '10')
			return 0
		end
	end
	else begin --Es una modificacion
		-- me tengo que fijar que no haya OTRO idcliente diferente con el mismo telefono o dni
		if exists (select idcliente from ORION.clientes where (dni = @dni or telefono = @telefono) and idcliente <> @idcliente) begin
			return 1	-- Cliente duplicado
		end
		else begin
			update ORION.clientes set nombre = @nombre, apellido = @apellido, dni = @dni, email = @mail, telefono = @telefono, 
			direccion = @direccion, codigo_postal = @codpost, fecha_nacimiento = @fechanac
			where idusuario = @idusuario
			
			return 0
		end
				
    end
END
GO
-- =============================================
-- Loguea al usuario y si es necesario lo banea por intentos fallidos
-- =============================================
CREATE PROCEDURE [ORION].[LoguearUsuario]
	@username varchar(50), @passhashed char(64)
AS
BEGIN
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    
	declare @idusuario int
	declare @clave		char(64)
	declare @idtipo_usuario	tinyint
	declare @idrol		int
	declare @intentos_fallidos	tinyint

	
	select @idusuario = idusuario, @clave = clave, @idtipo_usuario = idtipo_usuario, @idrol = idrol, @intentos_fallidos = intentos_fallidos
	from ORION.usuarios where username = @username and habilitado = 1
	
	-- Si no es nulo, existe. 
	if (@idusuario is not null) begin
		if (@clave = @passhashed) begin
			-- Reseteo los intentos fallidos
			update ORION.usuarios set intentos_fallidos = 0 where idusuario = @idusuario
			
			-- Devuelvo los datos
			select @idusuario idusuario, @idrol idrol, @idtipo_usuario idtipo_usuario
		end
		else begin
			if (@intentos_fallidos = 2) begin -- a la tercera lo banea
				-- -1 -1 -1 indica que fue baneado
				select -1 idusuario, -1 idrol, -1 idtipo_usuario
				
				update ORION.usuarios set habilitado = 0 where idusuario = @idusuario
			end
			else begin
				update ORION.usuarios set intentos_fallidos = intentos_fallidos + 1 where idusuario = @idusuario
				select 0 idusuario, 0 idrol, 0 idtipo_usuario
			end
		end
	end
	else begin
		-- Devuelvo 0 0 0 para indicar que el logueo no fue satisfactorio
		select 0 idusuario, 0 idrol, 0 idtipo_usuario
	end
END

GO
-- =============================================
-- Description:	Inhabilita el rol deseado
-- =============================================
CREATE PROCEDURE [ORION].[Roles_Inhabilitar]
	@idrol int, @forzar bit
AS 
BEGIN
	SET NOCOUNT ON

	declare @retstatus tinyint
	set @retstatus = 0 -- OK por default
	
	if (not exists(select idusuario from ORION.usuarios where idrol = @idrol and habilitado = 1))
		update ORION.roles set activo = 0 where idrol = @idrol --Inhabilito el rol
	else begin
		if (@forzar = 0) 	
			set @retstatus = 1	-- Hay usuarios asociados
		else begin
			update ORION.usuarios set habilitado = 0 where idrol = @idrol
			update ORION.roles set activo = 0 where idrol = @idrol --Inhabilito el rol		
		end
	end
		
	return @retstatus
	
END

GO

-- =============================================
-- Description:	Obtiene los roles existentes en el sistema, opcionalmente puede pedirse un filtro
-- =============================================
CREATE PROCEDURE [ORION].[Roles_Obtener]
	@filtro varchar(60) = '', @solo_habilitados bit = 0
AS
BEGIN
	
	if (@filtro = '') begin
		if (@solo_habilitados = 1) begin
			select idrol, descripcion, activo as estado,
			case when exists(select idtipo_usuario_rol from orion.tipos_usuario_rol where idrol = orion.roles.idrol and idtipo_usuario = 1) then 'S' else 'N' end administrativo,
			case when exists(select idtipo_usuario_rol from orion.tipos_usuario_rol where idrol = orion.roles.idrol and idtipo_usuario = 2) then 'S' else 'N' end cliente,
			case when exists(select idtipo_usuario_rol from orion.tipos_usuario_rol where idrol = orion.roles.idrol and idtipo_usuario = 3) then 'S' else 'N' end proveedor
			
			from ORION.roles where activo = 1 order by descripcion 
		end 
		else begin
			select idrol, descripcion, activo as estado,
			case when exists(select idtipo_usuario_rol from orion.tipos_usuario_rol where idrol = orion.roles.idrol and idtipo_usuario = 1) then 'S' else 'N' end administrativo,
			case when exists(select idtipo_usuario_rol from orion.tipos_usuario_rol where idrol = orion.roles.idrol and idtipo_usuario = 2) then 'S' else 'N' end cliente,
			case when exists(select idtipo_usuario_rol from orion.tipos_usuario_rol where idrol = orion.roles.idrol and idtipo_usuario = 3) then 'S' else 'N' end proveedor
			from ORION.roles order by descripcion
		end
		
	end
	else begin
		if (@solo_habilitados = 1) begin
			select idrol, descripcion, activo as estado,
			case when exists(select idtipo_usuario_rol from orion.tipos_usuario_rol where idrol = orion.roles.idrol and idtipo_usuario = 1) then 'S' else 'N' end administrativo,
			case when exists(select idtipo_usuario_rol from orion.tipos_usuario_rol where idrol = orion.roles.idrol and idtipo_usuario = 2) then 'S' else 'N' end cliente,
			case when exists(select idtipo_usuario_rol from orion.tipos_usuario_rol where idrol = orion.roles.idrol and idtipo_usuario = 3) then 'S' else 'N' end proveedor
			from ORION.roles where activo = 1 and descripcion like '%' + @filtro + '%'
			order by descripcion 
		end 
		else begin
			select idrol, descripcion, activo as estado,
			case when exists(select idtipo_usuario_rol from orion.tipos_usuario_rol where idrol = orion.roles.idrol and idtipo_usuario = 1) then 'S' else 'N' end administrativo,
			case when exists(select idtipo_usuario_rol from orion.tipos_usuario_rol where idrol = orion.roles.idrol and idtipo_usuario = 2) then 'S' else 'N' end cliente,
			case when exists(select idtipo_usuario_rol from orion.tipos_usuario_rol where idrol = orion.roles.idrol and idtipo_usuario = 3) then 'S' else 'N' end proveedor
			from ORION.roles 
			where descripcion like '%' + @filtro + '%'
			order by descripcion
		end
		
	end
END

GO

-- =============================================
-- Description:	Inserta o actualiza el usuario
-- =============================================
CREATE PROCEDURE [ORION].[Usuarios_Grabar]
	@fechaalta date, @idusuario int = 0 output, @username varchar(50), @pass char(64) = null, @idrol int, @idtipo_usuario tinyint, @habilitado bit = 1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	--Si vino, es una actualizacion
	if (@idusuario > 0) begin
		-- solo si la clave vino se cambia
		if (@pass is not null) begin
			update ORION.usuarios set username = @username, clave = @pass, 
				idrol = @idrol ,idtipo_usuario = @idtipo_usuario, habilitado = @habilitado where idusuario = @idusuario
		end
		else begin
			update ORION.usuarios set username = @username, 
				idrol = @idrol ,idtipo_usuario = @idtipo_usuario, habilitado = @habilitado where idusuario = @idusuario
		end
		return 0
	end
	else begin
		--Sino, es un alta. Verifico que no haya otro usuario asi antes
		If (exists(select idusuario from ORION.usuarios where username = @username and idusuario <> @idusuario)) begin

			return 1
		end
		else begin
			--Si no existe, puedo insertar
			insert into ORION.usuarios(fecha_alta, username, clave, idrol, idtipo_usuario, habilitado) 
			values(@fechaalta, @username, @pass, @idrol, @idtipo_usuario, @habilitado)
			
			set @idusuario = @@IDENTITY
			
			return 0
		end
    end
END

GO

-- ACA VAN LOS DATOS DE LA MIGRACION
-- Carga completa clientes, giftcards y cargas, tipos_pago, ciudades, clientes_ciudades:	3:55
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
'' codpostal, Cli_Fecha_Nac, 0 idusuario, 0 credito, 1 activo
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
insert into ORION.tipos_usuario(descripcion) values('Administrativo')
insert into ORION.tipos_usuario(descripcion) values('Cliente')
insert into ORION.tipos_usuario(descripcion) values('Proveedor')

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
insert into ORION.usuarios(fecha_alta, username, clave, idrol, idtipo_usuario) values(
'20121001', 'admin', 'E6B87050BFCB8143FCB8DB0170A4DC9ED00D904DDD3E2A4AD1B1E8DC0FDC9BE7', 4,4)

-- Usuario clientes
insert into ORION.usuarios(fecha_alta, username, clave, idrol, idtipo_usuario)
select '20121001', dni, '8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92', 2, 2 from ORION.clientes

update ORION.clientes set idusuario = us.idusuario from ORION.usuarios us where us.username = cast(ORION.clientes.dni as varchar)
and us.idtipo_usuario = 2

-- Usuario proveedores
insert into ORION.usuarios(fecha_alta, username, clave, idrol, idtipo_usuario)
select '20121001', cuit, '8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C920',3,3 from ORION.proveedores

update ORION.proveedores set idusuario = us.idusuario from ORION.usuarios us where us.username = cast(ORION.proveedores.cuit as varchar)
and us.idtipo_usuario = 3


-- FINALMENTE, BORRO LAS TABLAS TEMPORALES
drop table orion.proveedores_temp
drop table orion.clientes_temp

rollback