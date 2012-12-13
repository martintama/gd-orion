begin transaction tran1
-- Crear tablas!
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
	idtarjeta		int
) ON [PRIMARY]
alter table orion.cargas add constraint pk_cargas primary key (idcarga)

-- ciudades
CREATE TABLE ORION.ciudades(
	idciudad		smallint IDENTITY(1,1) NOT NULL,
	descripcion		varchar(50) NOT NULL
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
	solicitar_datos		bit default 0
) ON [PRIMARY]
alter table orion.clientes add constraint pk_clientes primary key (idcliente)
ALTER TABLE orion.clientes ADD CONSTRAINT telefono_uniq UNIQUE NONCLUSTERED (telefono)


-- clientes_ciudades
CREATE TABLE ORION.clientes_ciudades(
	idcliente_ciudad	int IDENTITY(1,1) NOT NULL,
	idcliente			int NOT NULL,
	idciudad			smallint NOT NULL
) ON [PRIMARY]
alter table orion.clientes_ciudades add constraint pk_clientes_ciudades primary key (idcliente_ciudad)

-- compras
CREATE TABLE ORION.compras(
	idcompra			int IDENTITY(1,1) NOT NULL,
	idcliente			int NOT NULL,
	codigo 				varchar(50) NOT NULL,
	fecha_compra		date NOT NULL,
	cantidad			smallint NOT NULL,
	idcupon				int NOT NULL,
	idcompra_estado		tinyint NOT NULL
) ON [PRIMARY]
alter table orion.compras add constraint pk_compras primary key (idcompra)
--ALTER TABLE orion.compras ADD CONSTRAINT uniq_compras_codigo UNIQUE NONCLUSTERED (codigo)

-- compras_estados
CREATE TABLE ORION.compras_estados(
	idcompra_estado		tinyint IDENTITY(1,1) NOT NULL,
	descripcion			varchar(50) NOT NULL
) ON [PRIMARY]
alter table orion.compras_estados add constraint pk_compras_estados primary key (idcompra_estado)

-- consumos
CREATE TABLE ORION.consumos(
	idconsumo			int IDENTITY(1,1) NOT NULL,
	fecha_consumo		date NOT NULL,
	idcompra			int NOT NULL,
	facturado			bit default 0
) ON [PRIMARY]
alter table orion.consumos add constraint pk_consumos primary key (idconsumo)
ALTER TABLE orion.consumos ADD CONSTRAINT uniq_consumos_compra_idcompra UNIQUE NONCLUSTERED (idcompra)
-- cupones
CREATE TABLE ORION.cupones(
	idcupon 				int IDENTITY(1,1) NOT NULL,
	idproveedor 			int  NOT NULL,
	descripcion 			varchar(200) NOT NULL,
	fecha_alta 				date NOT NULL,
	fecha_publicacion 		date NOT NULL,
	fecha_vencimiento 		date NOT NULL,
	fecha_vencimiento_canje date NOT NULL,
	precio_real 			decimal(18, 2) NOT NULL,
	precio_ficticio 		decimal(18, 2) NOT NULL,
	cantidad_disponible 	smallint NOT NULL,
	cantidad_max_usuario 	smallint NOT NULL,
	publicado 				bit default 0,
	fecha_publicacion_real 	date
) ON [PRIMARY]
alter table orion.cupones add constraint pk_cupones primary key (idcupon)

-- cupones_ciudades
CREATE TABLE ORION.cupones_ciudades(
	idcupon_ciudad		int IDENTITY(1,1) NOT NULL,
	idcupon				int NOT NULL,
	idciudad			smallint NOT NULL
) ON [PRIMARY]
alter table orion.cupones_ciudades add constraint pk_cupones_ciudades primary key (idcupon_ciudad)

-- devoluciones
CREATE TABLE ORION.devoluciones(
	iddevolucion		int IDENTITY(1,1) NOT NULL,
	fecha_devolucion	date NOT NULL,
	idcompra			int NOT NULL,
	motivo				varchar(200) NOT NULL
) ON [PRIMARY]
alter table orion.devoluciones add constraint pk_devoluciones primary key (iddevolucion)
ALTER TABLE orion.devoluciones ADD CONSTRAINT uniq_devoluciones_compra UNIQUE NONCLUSTERED (idcompra)
-- facturas
CREATE TABLE ORION.facturas(
	idfactura			int IDENTITY(1,1) NOT NULL,
	fecha_generacion	datetime NOT NULL,
	idproveedor			int NOT NULL,
	nro_factura			numeric(18,0) NOT NULL,
	monto_total			decimal(18,2) NOT NULL
) ON [PRIMARY]
alter table orion.facturas add constraint pk_facturas primary key (idfactura)

-- facturas_items
CREATE TABLE ORION.facturas_items(
	idfactura_item		int IDENTITY(1,1) NOT NULL,
	idfactura			int NOT NULL,
	idconsumo			int NOT NULL
) ON [PRIMARY]
alter table orion.facturas_items add constraint pk_facturas_items primary key (idfactura_item)

-- funcionalidades
CREATE TABLE ORION.funcionalidades(
	idfuncionalidad		int IDENTITY(1,1) NOT NULL,
	descripcion			varchar(50) NOT NULL
) ON [PRIMARY]
alter table orion.funcionalidades add constraint pk_funcionalidades primary key (idfuncionalidad)

-- gift_cards
CREATE TABLE ORION.gift_cards(
	idgift_card			int IDENTITY(1,1) NOT NULL,
	fecha				date NOT NULL,
	monto				decimal(18,2) NOT NULL,
	idcliente_origen	int NOT NULL,
	idcliente_destino	int NOT NULL
) ON [PRIMARY]
alter table orion.gift_cards add constraint pk_gift_cards primary key (idgift_card)

-- gift cards montos
CREATE TABLE ORION.gift_cards_montos(
	idmonto				smallint identity(1,1) not null,
	monto				decimal(18,2) default 0
) on [PRIMARY]
alter table orion.gift_cards_montos add constraint pk_gift_cards_montos primary key (idmonto)

-- proveedores
CREATE TABLE ORION.proveedores(
	idproveedor		int IDENTITY(1,1) NOT NULL,
	razon_social	varchar(100) NOT NULL,
	email			varchar(50) NOT NULL,
	telefono		numeric(18,0) NOT NULL,
	direccion		varchar(100) NOT NULL,
	codigo_postal	varchar(8) NOT NULL default '-',
	idciudad		smallint NOT NULL,
	cuit			char(11) NOT NULL,
	idrubro			int NOT NULL,
	contacto		varchar(50) NOT NULL,
	idusuario		int NOT NULL
) ON [PRIMARY]
alter table orion.proveedores add constraint pk_proveedores primary key (idproveedor)
ALTER TABLE orion.proveedores ADD CONSTRAINT uniq_proveedores_cuit UNIQUE NONCLUSTERED (cuit)
ALTER TABLE orion.proveedores ADD CONSTRAINT uniq_proveedores_razon_social UNIQUE NONCLUSTERED (razon_social)

-- roles
CREATE TABLE ORION.roles(
	idrol				int IDENTITY(1,1) NOT NULL,
	descripcion			varchar(50) NOT NULL,
	habilitado				bit default 1
) ON [PRIMARY]
alter table orion.roles add constraint pk_roles primary key (idrol)

-- roles_funcionalidades
CREATE TABLE ORION.roles_funcionalidades(
	idrol_funcionalidad		int IDENTITY(1,1) NOT NULL,
	idrol					int NOT NULL,
	idfuncionalidad			int NOT NULL
) ON [PRIMARY]
alter table orion.roles_funcionalidades add constraint pk_roles_funcionalidades primary key (idrol_funcionalidad)

-- rubros
CREATE TABLE ORION.rubros(
	idrubro			int IDENTITY(1,1) NOT NULL,
	descripcion	 	varchar(50) NOT NULL
) ON [PRIMARY]
alter table orion.rubros add constraint pk_rubros primary key (idrubro)

-- tarjetas
CREATE TABLE ORION.tarjetas(
	idtarjeta				int IDENTITY(1,1) NOT NULL,
	idtipo_tarjeta			tinyint NOT NULL,
	numero_tarjeta			varchar(16) NOT NULL,
	digitos_verificadores	varchar(3) NOT NULL,
	nombre_titular			varchar(50) NOT NULL,
	dni_titular				int  NOT NULL,
	mes_vencimiento			tinyint	NOT NULL,
	anio_vencimiento		smallint NOT NULL,
	idcliente				int NOT NULL
) ON [PRIMARY]
alter table orion.tarjetas add constraint pk_tarjetas primary key (idtarjeta)

-- tipos_pago
CREATE TABLE ORION.tipos_pago(
	idtipo_pago		int IDENTITY(1,1) NOT NULL,
	descripcion		varchar(50) NOT NULL,
	visible			bit default 1
) ON [PRIMARY]
alter table orion.tipos_pago add constraint pk_tipos_pago primary key (idtipo_pago)

-- tipos_tarjeta
CREATE TABLE ORION.tipos_tarjeta(
	idtipo_tarjeta		tinyint IDENTITY(1,1) NOT NULL,
	descripcion			varchar(50) NOT NULL
) ON [PRIMARY]
alter table orion.tipos_tarjeta add constraint pk_tipos_tarjeta primary key (idtipo_tarjeta)

-- tipos_usuario
CREATE TABLE ORION.tipos_usuario(
	idtipo_usuario		int IDENTITY(1,1) NOT NULL,
	descripcion			varchar(50) NOT NULL
) ON [PRIMARY]
alter table orion.tipos_usuario add constraint pk_tipos_usuario primary key (idtipo_usuario)

CREATE TABLE ORION.tipos_usuario_rol(
	idtipo_usuario_rol		int IDENTITY(1,1) NOT NULL,
	idtipo_usuario			int NOT NULL,
	idrol					int	NOT NULL
) ON [PRIMARY]
alter table orion.tipos_usuario_rol add constraint pk_tipos_usuario_rol primary key (idtipo_usuario_rol)


-- usuarios
CREATE TABLE ORION.usuarios(
	idusuario			int IDENTITY(1,1) NOT NULL,
	username			varchar(50) NOT NULL,
	clave				char(64) NOT NULL,
	idrol				int NOT NULL,
	idtipo_usuario		int NOT NULL,
	intentos_fallidos	tinyint default 0,
	habilitado			bit default 1
) ON [PRIMARY]
alter table orion.usuarios add constraint pk_usuarios primary key (idusuario)

GO
-- Agrego los FK E INDICES
alter table orion.cargas add constraint fk_cargas_idcliente foreign key (idcliente) references orion.clientes (idcliente)
alter table orion.cargas add constraint fk_cargas_idtarjeta foreign key (idtarjeta) references orion.tarjetas (idtarjeta)
create index idx_cargas_idcliente on ORION.cargas(idcliente)
create index idx_cargas_idtarjeta on ORION.cargas(idtarjeta)

alter table orion.clientes add constraint fk_clientes_idusuario foreign key (idusuario) references orion.usuarios (idusuario)
create index idx_clientes_idusuario on ORION.clientes(idusuario)

alter table orion.clientes_ciudades add constraint fk_clientes_ciudades_idcliente foreign key (idcliente) references orion.clientes (idcliente)
alter table orion.clientes_ciudades add constraint fk_clientes_ciudades_idciudad foreign key (idciudad) references orion.ciudades (idciudad)
create index idx_clientes_ciudades_idcliente on ORION.clientes_ciudades(idcliente)
create index idx_clientes_ciudades_idciudad on ORION.clientes_ciudades(idciudad)


alter table orion.cupones_ciudades add constraint fk_cupones_ciudades_idcupon foreign key (idcupon) references orion.cupones (idcupon)
alter table orion.cupones_ciudades add constraint fk_cupones_ciudades_idciudad foreign key (idciudad) references orion.ciudades (idciudad)
create index idx_cupones_ciudades_idcupon on ORION.cupones_ciudades(idcupon)
create index idx_cupones_ciudades_idciudad on ORION.cupones_ciudades(idciudad)


alter table orion.compras add constraint fk_compras_idcliente foreign key (idcliente) references orion.clientes (idcliente)
alter table orion.compras add constraint fk_compras_idcupon foreign key (idcupon) references orion.cupones (idcupon)
alter table orion.compras add constraint fk_compras_idcompra_estado foreign key (idcompra_estado) references orion.compras_estados (idcompra_estado)
create index idx_compras_idcliente on ORION.compras(idcliente)
create index idx_compras_idcupon on ORION.compras(idcupon)
create index idx_compras_idcompra_estado on ORION.compras(idcompra_estado)

alter table orion.consumos add constraint fk_consumos_idcompra foreign key (idcompra) references orion.compras (idcompra)
create index idx_consumos_idcompra on ORION.consumos(idcompra)

alter table orion.cupones add constraint fk_cupones_idproveedor foreign key (idproveedor) references orion.proveedores (idproveedor)
create index idx_cupones_idproveedor on ORION.cupones(idproveedor)

alter table orion.devoluciones add constraint fk_devoluciones_idcompra foreign key (idcompra) references orion.compras (idcompra)
create index idx_devoluciones_idcompra on ORION.devoluciones(idcompra)

alter table orion.facturas add constraint fk_facturas_idproveedor foreign key (idproveedor) references orion.proveedores (idproveedor)
create index idx_facturas_idproveedor on ORION.facturas(idproveedor)

alter table orion.facturas_items add constraint fk_facturas_items_idfactura foreign key (idfactura) references orion.facturas (idfactura)
create index idx_facturas_items_idfactura on ORION.facturas_items(idfactura)

alter table orion.gift_cards add constraint fk_gift_cards_idcliente_origen foreign key (idcliente_origen) references orion.clientes (idcliente)
alter table orion.gift_cards add constraint fk_gift_cards_idcliente_destino foreign key (idcliente_destino) references orion.clientes (idcliente)
create index idx_gift_cards_idcliente_origen on ORION.gift_cards(idcliente_origen)
create index idx_gift_cards_idcliente_destino on ORION.gift_cards(idcliente_destino)

alter table orion.proveedores add constraint fk_proveedores_idrubro foreign key (idrubro) references orion.rubros (idrubro)
alter table orion.proveedores add constraint fk_proveedores_idusuario foreign key (idusuario) references orion.usuarios (idusuario)
create index idx_proveedores_idrubro on ORION.proveedores(idrubro)
create index idx_proveedores_idusuario on ORION.proveedores(idusuario)

alter table orion.roles_funcionalidades add constraint fk_roles_funcionalidades_idrol foreign key (idrol) references orion.roles(idrol)
alter table orion.roles_funcionalidades add constraint fk_roles_funcionalidades_idfuncionalidad foreign key (idfuncionalidad) references orion.funcionalidades(idfuncionalidad)
create index idx_roles_funcionalidades_idrol on ORION.roles_funcionalidades(idrol)
create index idx_roles_funcionalidades_idfuncionalidad on ORION.roles_funcionalidades(idfuncionalidad)

alter table orion.tarjetas add constraint fk_tarjetas_idtipo_tarjeta foreign key (idtipo_tarjeta) references orion.tipos_tarjeta(idtipo_tarjeta)
alter table orion.tarjetas add constraint fk_tarjetas_idcliente foreign key (idcliente) references orion.clientes(idcliente)
create index idx_tarjetas_idtipo_tarjeta on ORION.tarjetas(idtipo_tarjeta)
create index idx_tarjetas_idcliente on ORION.tarjetas(idcliente)

alter table orion.tipos_usuario_rol add constraint fk_tipos_usuario_rol_idtipo_usuario foreign key (idtipo_usuario) references orion.tipos_usuario (idtipo_usuario)
alter table orion.tipos_usuario_rol add constraint fk_tipos_usuario_rol_idrol foreign key (idrol) references orion.roles (idrol)
create index idx_tipos_usuario_rol_idtipo_usuario on ORION.tipos_usuario_rol(idtipo_usuario)
create index idx_tipos_usuario_rol_idrol on ORION.tipos_usuario_rol(idrol)

alter table orion.usuarios add constraint fk_usuarios_idrol foreign key (idrol) references orion.roles (idrol)
alter table orion.usuarios add constraint fk_usuarios_idtipo_usuario foreign key (idtipo_usuario) references orion.tipos_usuario(idtipo_usuario)
create index idx_usuarios_idrol on ORION.usuarios(idrol)
create index idx_usuarios_idtipo_usuario on ORION.usuarios(idtipo_usuario)

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
			
			--Carga inicial de $10!
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
CREATE PROCEDURE [ORION].[Usuarios_Loguear]
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
	declare @idcliente	int
	declare @idproveedor	int
       
	select @idusuario = u.idusuario, @clave = clave, @idtipo_usuario = idtipo_usuario, @idrol = idrol, @intentos_fallidos = intentos_fallidos,
	@idcliente = c.idcliente, @idproveedor = p.idproveedor
	from ORION.usuarios u left join ORION.clientes c on c.idusuario = u.idusuario left join ORION.proveedores p on p.idusuario = u.idusuario  
	where username = @username and u.habilitado = 1
	
	-- Si no es nulo, existe. 
	if (@idusuario is not null) begin
		if (@clave = @passhashed) begin
			-- Reseteo los intentos fallidos
			update ORION.usuarios set intentos_fallidos = 0 where idusuario = @idusuario
			
			-- Devuelvo los datos
			select @idusuario idusuario, @idrol idrol, @idtipo_usuario idtipo_usuario, @idcliente idcliente, @idproveedor idproveedor
		end
		else begin
			if (@intentos_fallidos = 2) begin -- a la tercera lo banea
				-- -1 -1 -1 indica que fue baneado
				select -1 idusuario, -1 idrol, -1 idtipo_usuario, -1 idcliente, -1 idproveedor
				
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
		select 0 idusuario, 0 idrol, 0 idtipo_usuario, 0 idcliente, 0 idproveedor
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
		update ORION.roles set habilitado = 0 where idrol = @idrol --Inhabilito el rol
	else begin
		if (@forzar = 0) 	
			set @retstatus = 1	-- Hay usuarios asociados
		else begin
			update ORION.usuarios set habilitado = 0 where idrol = @idrol
			update ORION.roles set habilitado = 0 where idrol = @idrol --Inhabilito el rol		
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
			select idrol, descripcion, habilitado as estado,
			case when exists(select idtipo_usuario_rol from orion.tipos_usuario_rol where idrol = orion.roles.idrol and idtipo_usuario = 1) then 'S' else 'N' end administrativo,
			case when exists(select idtipo_usuario_rol from orion.tipos_usuario_rol where idrol = orion.roles.idrol and idtipo_usuario = 2) then 'S' else 'N' end cliente,
			case when exists(select idtipo_usuario_rol from orion.tipos_usuario_rol where idrol = orion.roles.idrol and idtipo_usuario = 3) then 'S' else 'N' end proveedor
			
			from ORION.roles where habilitado = 1 order by descripcion 
		end 
		else begin
			select idrol, descripcion, habilitado as estado,
			case when exists(select idtipo_usuario_rol from orion.tipos_usuario_rol where idrol = orion.roles.idrol and idtipo_usuario = 1) then 'S' else 'N' end administrativo,
			case when exists(select idtipo_usuario_rol from orion.tipos_usuario_rol where idrol = orion.roles.idrol and idtipo_usuario = 2) then 'S' else 'N' end cliente,
			case when exists(select idtipo_usuario_rol from orion.tipos_usuario_rol where idrol = orion.roles.idrol and idtipo_usuario = 3) then 'S' else 'N' end proveedor
			from ORION.roles order by descripcion
		end
		
	end
	else begin
		if (@solo_habilitados = 1) begin
			select idrol, descripcion, habilitado as estado,
			case when exists(select idtipo_usuario_rol from orion.tipos_usuario_rol where idrol = orion.roles.idrol and idtipo_usuario = 1) then 'S' else 'N' end administrativo,
			case when exists(select idtipo_usuario_rol from orion.tipos_usuario_rol where idrol = orion.roles.idrol and idtipo_usuario = 2) then 'S' else 'N' end cliente,
			case when exists(select idtipo_usuario_rol from orion.tipos_usuario_rol where idrol = orion.roles.idrol and idtipo_usuario = 3) then 'S' else 'N' end proveedor
			from ORION.roles where habilitado = 1 and descripcion like '%' + @filtro + '%'
			order by descripcion 
		end 
		else begin
			select idrol, descripcion, habilitado as estado,
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
	@idusuario int = 0 output, @username varchar(50), @pass char(64) = null, @idrol int, @idtipo_usuario tinyint, @habilitado bit = 1
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
			insert into ORION.usuarios(username, clave, idrol, idtipo_usuario, habilitado) 
			values(@username, @pass, @idrol, @idtipo_usuario, @habilitado)
			
			set @idusuario = @@IDENTITY
			
			return 0
		end
    end
END

GO

-- =============================================
-- Description:	Inserta un registro en la tabla de proveedores y devueve en output el idproveedor generado
-- =============================================
CREATE PROCEDURE [ORION].[Proveedores_Grabar]
	@idproveedor int output, @razon_social varchar(50), @mail varchar(50), @telefono varchar(50), 
	@direccion varchar(100), @codpost varchar(8), @idciudad int, @cuit varchar(11), @idrubro int, 
	@contacto varchar(50), @idusuario int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	-- Si es un alta
	if (@idproveedor = 0) begin
		-- Me fijo antes que no haya otro "duplicado"
		if exists (select idproveedor from ORION.proveedores where cuit = @cuit or razon_social = @razon_social) begin
			return 1	-- Proveedor duplicado
		end
		else begin
			insert into ORION.proveedores(razon_social, email, telefono, direccion, codigo_postal, idciudad, cuit, idrubro, contacto, idusuario)
			values(@razon_social, @mail, @telefono, @direccion, @codpost, @idciudad, @cuit, @idrubro, @contacto, @idusuario)
			
			set @idproveedor = @@IDENTITY
			return 0
		end
	end
	else begin --Es una modificacion
		-- me tengo que fijar que no haya OTRO idcliente diferente con el mismo telefono o dni
		if exists (select idproveedor from ORION.proveedores where (cuit = @cuit or razon_social = @razon_social) and idproveedor <> @idproveedor) begin
			return 1	-- Proveedor duplicado
		end
		else begin
			update ORION.proveedores set razon_social = @razon_social, email = @mail, telefono = @telefono, direccion = @direccion, codigo_postal = @codpost,
			idciudad= @idciudad, cuit = @cuit, idrubro = @idrubro, contacto = @contacto where idproveedor = @idproveedor
			
			return 0
		end
				
    end
END

GO
-- =============================================
-- Description:	Comprar GiftCard
-- =============================================
CREATE PROCEDURE [ORION].[GiftCard_Comprar]
	@idcliente_origen int, @idcliente_destino int, @monto decimal(18,2), @fecha date
AS
BEGIN
	Insert into ORION.gift_cards(fecha, idcliente_origen, idcliente_destino, monto)
	values(@fecha, @idcliente_origen, @idcliente_destino, @monto)
	
	
END
GO

-- =============================================
-- Description:	Crea un nuevo rol y devuelve el idrol creado
-- =============================================
CREATE PROCEDURE [ORION].[Roles_Crear]
	@idrol int = 0 output, @descripcion varchar(50)
AS 
BEGIN
	SET NOCOUNT ON

	Insert into orion.roles(descripcion) values(@descripcion)
	
	set @idrol = @@IDENTITY	
	
END

GO

-- =============================================
-- Description:	Procedimiento de compra de un cupón
-- =============================================
CREATE PROCEDURE ORION.Cupones_Comprar
	@fecha date, @idcliente int, @cantidad smallint, @idcupon int, @codigo varchar(12) output
AS
BEGIN
	declare @cantcompras smallint
	declare @monto decimal(18,2)
	
	-- Genero el código de la compra
	select @cantcompras = (COUNT(1)+1) from ORION.compras where idcupon = @idcupon
	set @codigo = 'C' + RIGHT('00000' + cast(@idcupon as varchar), 6) + RIGHT('0000' + cast(@cantcompras as varchar), 5)
	
	-- Cargo la compra
	insert into ORION.compras(idcliente, codigo, fecha_compra, cantidad, idcupon, idcompra_estado)
	values(@idcliente, @codigo, @fecha, @cantidad, @idcupon, 1)

	-- Saco el monto del cupón
	select @monto = precio_real from ORION.cupones where idcupon = @idcupon
	
	-- Actualiza el crédito del cliente
	update ORION.clientes set credito_actual = credito_actual - @monto where idcliente = @idcliente
	
	-- Y actualizo el stock de los cupones
	update ORION.cupones set cantidad_disponible = cantidad_disponible - @cantidad where idcupon = @idcupon
	
END
GO


-- ACA VAN LOS DATOS DE LA MIGRACION
-- Cargo algunas tablas de "Indices" primero

-- gift_cards_montos
insert into ORION.gift_cards_montos(monto) values ('25')
insert into ORION.gift_cards_montos(monto) values ('30')
insert into ORION.gift_cards_montos(monto) values ('50')
insert into ORION.gift_cards_montos(monto) values ('75')
insert into ORION.gift_cards_montos(monto) values ('100')

-- Compras_estados		00:00
insert into ORION.compras_estados(descripcion) values('Comprado')
insert into ORION.compras_estados(descripcion) values('Entregado')
insert into ORION.compras_estados(descripcion) values('Devuelto')
insert into ORION.compras_estados(descripcion) values('Vencido')

-- Tipos_pago			00:00
insert into ORION.tipos_pago(descripcion, visible) values('Sistema', 0)
insert into ORION.tipos_pago(descripcion) values('Efectivo')
insert into ORION.tipos_pago(descripcion) values('Crédito')
insert into ORION.tipos_pago(descripcion, visible) values('GiftCard', 0)


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

-- Roles del administrador
insert into ORION.roles_funcionalidades(idrol, idfuncionalidad) 
select 1,idfuncionalidad from orion.funcionalidades where idfuncionalidad in (1,2,3,8,10,12)

-- Roles del clientes
insert into ORION.roles_funcionalidades(idrol, idfuncionalidad) 
select 2,idfuncionalidad from orion.funcionalidades where idfuncionalidad in (5,6,7,9,11,14)

-- Roles de Proveedores
insert into ORION.roles_funcionalidades(idrol, idfuncionalidad) 
select 3,idfuncionalidad from orion.funcionalidades where idfuncionalidad in (4, 13)

-- Roles del Administrador General
insert into ORION.roles_funcionalidades(idrol, idfuncionalidad) select 4,idfuncionalidad from  orion.funcionalidades order by idfuncionalidad

-- Asociación de roles y tipos de usuario
insert into ORION.tipos_usuario_rol(idtipo_usuario, idrol) values(1, 1);
insert into ORION.tipos_usuario_rol(idtipo_usuario, idrol) values(2, 2);
insert into ORION.tipos_usuario_rol(idtipo_usuario, idrol) values(3, 3);

-- Usuario administrativo
insert into ORION.usuarios(username, clave, idrol, idtipo_usuario) values('admin', 'E6B87050BFCB8143FCB8DB0170A4DC9ED00D904DDD3E2A4AD1B1E8DC0FDC9BE7', 4,1)


-- Carga completa clientes, giftcards y cargas, tipos_pago, ciudades, clientes_ciudades:	02:39
select distinct cli_nombre, cli_apellido, Cli_Dni,Cli_Direccion, Cli_Telefono, Cli_Mail, Cli_Fecha_Nac, Cli_Ciudad,
Carga_Credito, Carga_Fecha, Cli_Dest_Dni, GiftCard_Fecha, GiftCard_Monto, tipo_pago_desc
into orion.clientes_temp
from gd_esquema.Maestra
where Provee_RS is null

	
	-- Agrego indices	00:07
	CREATE INDEX idx_clientes_temp_cli_dest_dni ON ORION.clientes_temp(cli_dest_dni)
	CREATE INDEX idx_clientes_temp_cli_dni ON ORION.clientes_temp(cli_dni)

--Ciudades			00:10
insert into ORION.ciudades(descripcion) select distinct cli_ciudad from ORION.clientes_temp

-- Usuario clientes		00:00
insert into ORION.usuarios(username, clave, idrol, idtipo_usuario)
select distinct cli_dni, '8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92', 2, 2 from ORION.clientes_temp
	
-- Clientes: 			00:05
insert into ORION.clientes(nombre, apellido, dni, email, telefono, direccion, codigo_postal,
fecha_nacimiento, idusuario, credito_actual)
select distinct cli_nombre, Cli_Apellido, Cli_Dni,  Cli_Mail, Cli_Telefono, Cli_Direccion,
'' codpostal, Cli_Fecha_Nac, u.idusuario idusuario, 0 credito
from ORION.clientes_temp ct
left join ORION.usuarios u on u.username = cast(ct.cli_dni as varchar)

	-- Agrego indices	00:00
	CREATE INDEX idx_clientes_dni ON ORION.clientes(dni)


-- Clientes_ciudades		00:15
insert into ORION.clientes_ciudades(idcliente, idciudad)
select distinct c.idcliente, (Select idciudad from ORION.ciudades where descripcion = ct.cli_ciudad)
from ORION.clientes_temp ct
left join ORION.usuarios u on u.username = cast(ct.cli_dni as varchar)
left join ORION.clientes c on c.idusuario = u.idusuario


-- GiftCards:		00:06
insert into orion.gift_cards(fecha, monto, idcliente_origen, idcliente_destino)
select ct.giftcard_fecha, ct.giftcard_monto, c.idcliente, c2.idcliente
from orion.clientes_temp ct
left join orion.clientes c on c.dni = ct.cli_dni
left join orion.clientes c2 on c2.dni = ct.cli_dest_dni
where ct.giftcard_fecha is not null

--Cargas crédito		00:07
insert into orion.cargas(fecha_carga, idcliente, idtipo_pago, monto)
select carga_fecha, c.idcliente, case tipo_pago_desc when 'Efectivo' then 2 when 'Crédito' then 3 else 1 end,
ct.carga_credito
from orion.clientes_temp ct
left join orion.clientes c on c.dni = ct.cli_dni
where ct.carga_credito is not null

-- Carga general proveedores, cupones, devoluciones, compras, compras_estados,
 --facturas, rubros, cupones_ciudades, funcionalidades, roles, facturas, facturas_items		02:18

select cli_dni, Provee_RS,Provee_Dom,Provee_Ciudad,Provee_Telefono,replace(Provee_CUIT,'-','') provee_cuit,Provee_Rubro,
Groupon_Cantidad, Groupon_Codigo, Groupon_Descripcion,
Groupon_Devolucion_Fecha, Groupon_Entregado_Fecha, Groupon_Fecha, Groupon_Fecha_Compra, 
Groupon_Fecha_Venc, Groupon_Precio, Groupon_Precio_Ficticio, Factura_Nro, Factura_Fecha
into orion.proveedores_temp
from gd_esquema.Maestra
where Provee_RS is not null

	-- Agrego indices		01:01
	CREATE INDEX idx_proveedores_temp_cli_dni ON ORION.proveedores_temp(cli_dni)
	CREATE INDEX idx_proveedores_temp_prove_cuit ON ORION.proveedores_temp(provee_cuit)
	CREATE INDEX idx_proveedores_temp_groupon_codigo ON ORION.proveedores_temp(groupon_codigo)
	CREATE INDEX idx_proveedores_temp_rs ON ORION.proveedores_temp(provee_rs)


-- Rubros					00:02
insert into orion.rubros(descripcion) select distinct provee_rubro from ORION.proveedores_temp where provee_rubro is not null order by provee_rubro 

-- Usuario proveedores		00:00
insert into ORION.usuarios(username, clave, idrol, idtipo_usuario)
select distinct provee_cuit, '8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92', 3,3  from ORION.proveedores_temp where provee_cuit is not null

-- Proveedores:  			00:35
insert into ORION.proveedores(razon_social, direccion, idciudad, telefono, cuit, idrubro, email,contacto, idusuario)
select distinct Provee_RS,Provee_Dom,(select idciudad from ORION.ciudades where descripcion = provee_ciudad),
Provee_Telefono,Provee_CUIT,(select idrubro from orion.rubros where descripcion = Provee_Rubro),'', '-',
u.idusuario from orion.proveedores_temp pt
left join ORION.usuarios u on u.username = cast(pt.provee_cuit as varchar)
WHERE pt.provee_RS is not null


	-- Agrego indices		00:00
	CREATE INDEX idx_proveedores_prove_cuit ON ORION.proveedores(cuit)

-- Cupones				00:08		46429 reg.
insert into ORION.cupones(idproveedor, descripcion, fecha_alta, fecha_publicacion, fecha_vencimiento, precio_real, precio_ficticio,
cantidad_disponible, fecha_vencimiento_canje, cantidad_max_usuario, fecha_publicacion_real, publicado)
select p.idproveedor, groupon_descripcion, groupon_fecha, groupon_fecha, groupon_fecha_venc, groupon_precio, 
groupon_precio_ficticio, Groupon_Cantidad, DATEADD(d, 10, groupon_fecha_venc), 5, groupon_fecha,1
from ORION.proveedores_temp pt inner join ORION.proveedores p on p.cuit = pt.provee_cuit
where groupon_entregado_fecha is null and groupon_devolucion_fecha is null 
and factura_fecha is null
group by p.idproveedor, groupon_descripcion, groupon_fecha, groupon_fecha_venc, groupon_precio, groupon_precio_ficticio, Groupon_Cantidad
order by pt.groupon_fecha


-- Compras				00:13		116520 reg.
insert into orion.compras(idcliente, fecha_compra, cantidad, idcupon, idcompra_estado, codigo)
select c.idcliente, pt.Groupon_Fecha_Compra,  COUNT(distinct 1), cu.idcupon, 1, pt.Groupon_Codigo
from orion.proveedores_temp pt
inner join ORION.clientes c on c.dni = pt.cli_dni
inner join ORION.cupones cu on cu.descripcion = pt.Groupon_Descripcion and cu.fecha_alta = pt.Groupon_Fecha and 
cu.cantidad_disponible = pt.Groupon_Cantidad and cu.fecha_publicacion = pt.Groupon_Fecha and cu.fecha_vencimiento = pt.Groupon_Fecha_Venc 
and cu.precio_real = pt.Groupon_Precio and cu.precio_ficticio = pt.Groupon_Precio_Ficticio 
inner join ORION.proveedores p on p.idproveedor = cu.idproveedor
where Groupon_Descripcion is not null and groupon_fecha_compra is not null and groupon_devolucion_Fecha is null and 
groupon_entregado_fecha is null and factura_fecha is null and p.cuit = pt.provee_cuit
group by c.idcliente, pt.Groupon_Fecha_Compra, cu.idcupon, Groupon_Devolucion_Fecha, Groupon_Entregado_Fecha, pt.Groupon_Codigo
order by Groupon_Fecha_Compra

	-- Agrego indices	00:00
	CREATE INDEX idx_compras_codigo ON ORION.compras(codigo)

-- Devoluciones			00:16
	insert into ORION.devoluciones(fecha_devolucion, idcompra, motivo)
	select Groupon_Devolucion_Fecha, co.idcompra, '- no especifica (migración inicial) -' 
	from orion.proveedores_temp pt
	left join ORION.clientes c on c.dni = pt.cli_dni
	--left join ORION.cupones cu on cu.codigo = pt.Groupon_Codigo
	inner join ORION.compras co on co.idcliente = c.idcliente and co.codigo = pt.groupon_codigo and co.fecha_compra = pt.groupon_fecha_Compra
	where Groupon_Descripcion is not null and groupon_fecha_compra is not null and groupon_devolucion_Fecha is not null and 
	groupon_entregado_fecha is null
	group by  Groupon_Devolucion_Fecha, co.idcompra
	order by Groupon_Devolucion_Fecha

-- Actualizo el estado de todas las devoluciones 00:00
update ORION.compras set idcompra_estado = 3 where idcompra in (select idcompra from ORION.devoluciones)

-- Consumos				00:17
insert into ORION.consumos(fecha_consumo, idcompra)
select Groupon_Entregado_Fecha, co.idcompra
from orion.proveedores_temp pt
inner join ORION.clientes c on c.dni = pt.cli_dni
--inner join ORION.cupones cu on cu.codigo = pt.Groupon_Codigo
inner join ORION.compras co on co.idcliente = c.idcliente and co.codigo = pt.groupon_codigo and co.fecha_compra = pt.groupon_fecha_Compra
where Groupon_Descripcion is not null and groupon_fecha_compra is not null and groupon_devolucion_Fecha is null and 
groupon_entregado_fecha is not null
group by  Groupon_Entregado_Fecha, co.idcompra
order by Groupon_Entregado_Fecha

update ORION.compras set idcompra_estado = 2 where idcompra in (select idcompra from ORION.consumos)

-- Actualizo la tabla de compras según el estado en el que quedó la compra 00:00
update orion.compras set idcompra_Estado = 4 where fecha_compra <= '2012-12-26' and idcompra_Estado = 1

-- Actualizo el credito de todos los clientes de acuerdo a las compras que tuvieron. Primero cargo el total de "cargas"
update ORION.clientes set credito_actual = (select SUM(monto) from ORION.cargas where orion.cargas.idcliente = orion.clientes.idcliente group by idcliente)
-- A continuación le sumo los gift cards
update ORION.clientes set credito_actual = credito_actual + isnull((select SUM(monto) from ORION.gift_cards where orion.gift_cards.idcliente_destino = orion.clientes.idcliente group by idcliente_destino),0)
-- Y le resto los cupones que se canjearon o se vencieron (Se omiten los que se devolvieron)
update ORION.clientes set credito_actual = credito_actual - 
	isnull((select sum(cu.precio_real) total from ORION.compras c left join ORION.cupones cu on cu.idcupon = c.idcupon where c.idcompra_estado in (1,2,4) and c.idcliente = ORION.clientes.idcliente group by c.idcliente
),0)

-- Facturas				00:01
-- Se carga primero con monto cero y despues se actualiza
insert into ORION.facturas(fecha_generacion, idproveedor, nro_factura, monto_total)
select distinct Factura_Fecha, p.idproveedor, Factura_Nro, 0
from ORION.proveedores_temp pt
inner join orion.proveedores p on pt.Provee_CUIT = p.cuit
where Factura_Fecha is not null
order by Factura_Fecha, factura_nro


-- FActuras_items		00:05
insert into ORION.facturas_items(idfactura, idconsumo)
select  f.idfactura, con.idconsumo
from orion.proveedores_temp pt
inner join ORION.clientes c on c.dni = pt.cli_dni
inner join ORION.compras co on co.idcliente = c.idcliente and co.codigo = pt.groupon_codigo
inner join ORION.consumos con on con.idcompra = co.idcompra 
inner join ORION.facturas f on f.nro_factura = pt.Factura_Nro
where Groupon_Descripcion is not null and groupon_fecha_compra is not null and groupon_devolucion_Fecha is null and 
groupon_entregado_fecha is null and pt.Factura_Nro is not null
order by f.idfactura, con.idconsumo


-- Actualizo el importe de las facturas
update ORION.facturas set 
orion.facturas.monto_total = 
(select SUM(cu.precio_real * 0.5)
from ORION.facturas_items fi
inner join ORION.facturas f on F.idfactura = fi.idfactura
inner join ORION.consumos c on c.idconsumo = fi.idconsumo
inner join ORION.compras co on co.idcompra = c.idcompra
inner join ORION.cupones cu on cu.idcupon = co.idcupon
where f.idfactura = ORION.facturas.idfactura
group by f.idfactura)

-- y seteo como "facturado" los consumos que ya están
update ORION.consumos set facturado = 1 where idconsumo in (
select c.idconsumo from ORION.facturas_items fi
inner join ORION.facturas f on f.idfactura = fi.idfactura
inner join ORION.consumos c on c.idconsumo = fi.idconsumo
inner join ORION.compras co on co.idcompra = c.idcompra
inner join ORION.cupones cu on cu.idcupon = co.idcupon)

-- cupones_ciudades		00:00
insert into ORION.cupones_ciudades(idcupon, idciudad) select c.idcupon, p.idciudad from ORION.cupones c
left join orion.proveedores p on p.idproveedor = c.idproveedor

-- Actualizo el stock de cupones de acuerdo a los cajneados	y los que queden por canjear		00:06
update ORION.cupones set cantidad_disponible = cantidad_disponible - (select COUNT(1) from ORION.compras where idcompra_estado in (2,1) and idcupon = ORION.cupones.idcupon)

-- FINALMENTE, BORRO LAS TABLAS TEMPORALES
drop table orion.proveedores_temp
drop table orion.clientes_temp

commit	