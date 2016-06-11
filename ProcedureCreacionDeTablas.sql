SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE PMS.CreacionTabla--<CreactionTabla, sysname, CreacionTabla> 
	-- Add the parameters for the stored procedure here
	--<@Param1, sysname, @p1> <Datatype_For_Param1, , int> = <Default_Value_For_Param1, , 0>, 
	--<@Param2, sysname, @p2> <Datatype_For_Param2, , int> = <Default_Value_For_Param2, , 0>
AS
BEGIN

		CREATE TABLE dbo.USUARIOS 
	(
		Id_Usuario				numeric(18,0) IDENTITY(1,1) NOT NULL,
		User_Nombre				nvarchar(255),
		User_Password			binary(32),
		Habilitado				numeric(18,0) DEFAULT 1,
		Intentos_login			numeric(18,0) DEFAULT 0,
		Primera_Vez				numeric(18,0),
		Reputacion				numeric(18,0)
		PRIMARY KEY(Id_Usuario)
	);
	
	CREATE TABLE dbo.EMPRESAS
	(	
		Id_Empresa				numeric(18,0) NOT NULL,
		Cuit_Empresa			nvarchar(50) UNIQUE,	
		RazonSocial				nvarchar(255),		
		FechaCreacion			datetime,
		Mail					nvarchar(50),
		DomCalle				nvarchar(100),
		NroCalle				numeric(18,0),
		Piso					numeric(18,0),
		Depto					nvarchar(50),
		CodigoPostal			nvarchar(50),
		PRIMARY KEY(Id_Empresa)
	);

	CREATE TABLE dbo.CLIENTES
	(
		Id_Cliente				numeric(18,0) NOT NULL,
		Dni_Cliente				numeric(18,0) UNIQUE,
		Apellido				nvarchar(255),
		Nombre					nvarchar(255),
		FechaNacimiento			datetime,
		Mail					nvarchar(255),
		DomCalle				nvarchar(255),
		NroCalle				numeric(18,0),
		Piso					numeric(18,0),
		Depto					nvarchar(50),
		Cod_Postal				nvarchar(50),
		PRIMARY KEY(Id_Cliente)
	);

	CREATE TABLE dbo.VISIBILIDADES
	(
		Id_Visibilidad			numeric(18,0),
		Descripcion				nvarchar(255),
		Precio					numeric(18,2),
		Porcentaje				numeric(18,2),
		Habilitado				numeric(18,0) DEFAULT 1,
		PRIMARY KEY(Id_Visibilidad)
	);
	
	CREATE TABLE dbo.RUBROS
	(
		Id_Rubro						numeric(18,0) IDENTITY(1,1) NOT NULL,
		Descripcion						nvarchar(255),
		PRIMARY KEY(Id_Rubro)	
	);
	
	CREATE TABLE dbo.TIPO_PUBLICACION
	(
		Id_Tipo						numeric(18,0) IDENTITY(1,1) NOT NULL,
		Descripcion					nvarchar(255),
		PRIMARY KEY(Id_Tipo)
	);
	
		CREATE TABLE dbo.PUBLICACION_ESTADOS
	(
		Id_Estado				numeric(18,0) IDENTITY(1,1) NOT NULL,
		Descripcion				nvarchar(255),
		PRIMARY KEY(Id_Estado)					
	);


	CREATE TABLE dbo.PUBLICACIONES
	(
		Id_Publicacion			numeric(18,0), -- RECORDAR, Debo insertas ids ya generadas, pero el tp dice que las ids de publicaciones deben ser autogeneradas y consecutivas, por ende va a haber que setearla a mano
		Descripcion				nvarchar(255),
		Stock					numeric(18,0),
		Fecha					datetime,
		FechaVencimiento		datetime,
		Precio					numeric(18,2),
		Id_Usuario				numeric(18,0),
		Id_Visibilidad			numeric(18,0),
		Id_Tipo					numeric(18,0),
		Id_Rubro				numeric(18,0),
		Id_Estado				numeric(18,0),
		PRIMARY KEY(Id_Publicacion),
		FOREIGN KEY(Id_Visibilidad) REFERENCES dbo.VISIBILIDADES(Id_visibilidad),
		FOREIGN KEY(Id_Usuario) 	REFERENCES dbo.USUARIOS(Id_Usuario),
		FOREIGN KEY(Id_Rubro) 		REFERENCES dbo.RUBROS(Id_Rubro),
		FOREIGN KEY(Id_Tipo) 		REFERENCES dbo.TIPO_PUBLICACION(Id_Tipo),
		FOREIGN KEY(Id_Estado) 		REFERENCES dbo.PUBLICACION_ESTADOS(Id_Estado),
		
	);

	CREATE TABLE dbo.CALIFICACIONES
	(
		Id_Calificacion			numeric(18,0),
		Cantidad_Estrellas		numeric(18,0),
		Descripcion				nvarchar(255),
		PRIMARY KEY(Id_Calificacion)
	);

	CREATE TABLE dbo.COMPRAS
	(
		Id_Compra				numeric(18,0) IDENTITY(1,1) NOT NULL,
		Cantidad				numeric(18,0),
		Monto					numeric(18,2),
		Fecha					datetime,
		Id_Cliente_Comprador	numeric(18,0),
		Id_Publicacion			numeric(18,0),
		Id_Calificacion			numeric(18,0),
		PRIMARY KEY(Id_Compra),
		FOREIGN KEY(Id_Cliente_Comprador) REFERENCES dbo.CLIENTES(Id_Cliente),
		FOREIGN KEY(Id_Publicacion) REFERENCES dbo.PUBLICACIONES(Id_Publicacion),
		FOREIGN KEY(Id_Calificacion) REFERENCES dbo.CALIFICACIONES(Id_Calificacion),
	);


	CREATE TABLE dbo.OFERTAS
	(
		Id_Oferta				numeric(18,0) IDENTITY(1,1) NOT NULL,
		Fecha					datetime,
		Monto					numeric(18,2),
		Id_Publicacion			numeric(18,0),
		Id_Cliente				numeric(18,0),
		PRIMARY KEY(Id_Oferta),
		FOREIGN KEY(Id_publicacion) REFERENCES dbo.PUBLICACIONES(Id_Publicacion),
		FOREIGN KEY(Id_Cliente) REFERENCES dbo.CLIENTES(Id_Cliente)
	);

	CREATE TABLE dbo.FORMASDEPAGO
	(
		Id_FormaPago			numeric(11,0) IDENTITY(1,1) NOT NULL,
		Descripcion				nvarchar(255),
		PRIMARY KEY(Id_FormaPago)
	);

	CREATE TABLE dbo.FACTURAS
	(
		Numero					numeric(18,0),
		Fecha					datetime,
		Total					numeric(18,2),
		Id_FormaPago			numeric(11,0),
		PRIMARY KEY(Numero),
		FOREIGN KEY(Id_FormaPago) REFERENCES dbo.FORMASDEPAGO(Id_FormaPago)
	);

	

	CREATE TABLE dbo.ITEMFACTURA
	(
		Id_ItemFactura			numeric(18,0) IDENTITY(1,1) NOT NULL,
		Monto					numeric(18,2),
		Cantidad				numeric(18,0),
		Id_Factura				numeric(18,0),
		Id_Publicacion			numeric(18,0),
		PRIMARY KEY(Id_ItemFactura),
		FOREIGN KEY(Id_Factura) REFERENCES dbo.FACTURAS(Numero),
		FOREIGN KEY(Id_Publicacion) REFERENCES dbo.PUBLICACIONES(Id_Publicacion)
	);

	CREATE TABLE dbo.ROLES
	(
		Id_Rol						numeric(18,0) IDENTITY(1,1) NOT NULL,
		Nombre						nvarchar(255),
		Habilitado					numeric(18,0) DEFAULT 1,
		PRIMARY KEY(Id_Rol)
	);

	CREATE TABLE dbo.ROLES_USUARIOS 
	(
		Id_Rol						numeric(18,0),
		Id_Usuario					numeric(18,0),
		PRIMARY KEY(Id_Rol, Id_Usuario),
		FOREIGN KEY(Id_Rol) REFERENCES dbo.ROLES(Id_Rol),
		FOREIGN KEY(Id_Usuario) REFERENCES dbo.USUARIOS(Id_Usuario)

	);


	CREATE TABLE dbo.FUNCIONALIDADES
	(
		Id_Funcionalidad			numeric(18,0) IDENTITY(1,1) NOT NULL,
		Nombre						nvarchar(255),
		PRIMARY KEY(Id_Funcionalidad)
	);
	
	CREATE TABLE dbo.FUNCIONALIDES_ROLES
	(
		Id_Funcionalidad			numeric(18,0),
		Id_Rol						numeric(18,0),
		PRIMARY KEY(Id_Funcionalidad,Id_Rol),
		FOREIGN KEY(Id_Rol) REFERENCES dbo.ROLES(Id_Rol),
		FOREIGN KEY(Id_Funcionalidad) REFERENCES dbo.FUNCIONALIDADES(Id_Funcionalidad)
	);
	
	
	
	SELECT DISTINCT			
		   Publ_Empresa_Cuit,
		   Publ_Empresa_Razon_Social,		   
		   Publ_Empresa_Fecha_Creacion,	
		   Publ_Empresa_Mail,
		   Publ_Empresa_Dom_Calle,
		   Publ_Empresa_Nro_Calle,
		   Publ_Empresa_Piso,
		   Publ_Empresa_Depto,	
		   Publ_Empresa_Cod_Postal
	INTO #TempEmpresas
	FROM gd_esquema.Maestra 
	WHERE Publ_Empresa_Cuit IS NOT NULL 
	
	SELECT DISTINCT 	
		   Publ_Cli_Dni,	
		   Publ_Cli_Apeliido,	
		   Publ_Cli_Nombre,
		   Publ_Cli_Fecha_Nac,
		   Publ_Cli_Mail,		
		   Publ_Cli_Dom_Calle,	
		   Publ_Cli_Nro_Calle,	
		   Publ_Cli_Piso,		
		   Publ_Cli_Depto,		
		   Publ_Cli_Cod_Postal
	INTO #TempClientes
	FROM gd_esquema.Maestra
	WHERE Publ_Cli_Dni is not null
	
	INSERT INTO #TempClientes
	SELECT DISTINCT 	
		   Cli_Dni,	
		   Cli_Apeliido,	
		   Cli_Nombre,
		   Cli_Fecha_Nac,
		   Cli_Mail,		
		   Cli_Dom_Calle,	
		   Cli_Nro_Calle,	
		   Cli_Piso,		
		   Cli_Depto,		
		   Cli_Cod_Postal
	FROM gd_esquema.Maestra
	WHERE Cli_Dni not in (select Cli_Dni from #TempClientes) AND Cli_Dni IS NOT NULL;
	
	
	INSERT INTO dbo.EMPRESAS 
	SELECT
		   ROW_NUMBER() OVER (ORDER BY (SELECT NULL)),
		   Publ_Empresa_Cuit,
		   Publ_Empresa_Razon_Social,
		   Publ_Empresa_Fecha_Creacion,
		   Publ_Empresa_Mail,
		   Publ_Empresa_Dom_Calle,
		   Publ_Empresa_Nro_Calle,
		   Publ_Empresa_Piso,
		   Publ_Empresa_Depto,
		   Publ_Empresa_Cod_Postal
	FROM #TempEmpresas
	WHERE Publ_Empresa_Cuit IS NOT NULL;
	


	DECLARE @CantidadEmpresas numeric(18,0);
	SELECT @CantidadEmpresas = COUNT(*) FROM #TempEmpresas;
	

	--DBCC CHECKIDENT('dbo.CLIENTES', RESEED, @CantidadEmpresas);

	INSERT INTO dbo.CLIENTES
	SELECT DISTINCT 	
		   ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) + @CantidadEmpresas,
		   *
	FROM #TempClientes
	WHERE Publ_Cli_Dni is not null;
	
	

	INSERT INTO dbo.USUARIOS (User_Nombre, Habilitado, User_Password)
	SELECT RazonSocial, 1, HASHBYTES('SHA2_256','1234')
	FROM dbo.EMPRESAS
	ORDER BY Id_Empresa;
	
	INSERT INTO dbo.USUARIOS (User_Nombre, Habilitado, User_Password)
	SELECT (Nombre + Apellido), 1 , HASHBYTES('SHA2_256','1234')
	FROM dbo.CLIENTES
	ORDER BY Id_Cliente;

	INSERT INTO dbo.VISIBILIDADES
	SELECT	DISTINCT
			Publicacion_Visibilidad_Cod,
			Publicacion_Visibilidad_Desc,
			Publicacion_Visibilidad_Precio,		
			Publicacion_Visibilidad_Porcentaje,
			1
	FROM gd_esquema.Maestra 
	WHERE Publicacion_Visibilidad_Cod IS NOT NULL;

	INSERT INTO dbo.TIPO_PUBLICACION
	SELECT DISTINCT
		Publicacion_Tipo
	FROM gd_esquema.Maestra 
	WHERE Publicacion_Tipo IS NOT NULL;
	
	INSERT INTO dbo.RUBROS
	SELECT DISTINCT
			Publicacion_Rubro_Descripcion
	FROM gd_esquema.Maestra 
	WHERE Publicacion_Rubro_Descripcion IS NOT NULL;
	
	INSERT INTO dbo.PUBLICACION_ESTADOS
	SELECT DISTINCT
			Publicacion_Estado
	FROM gd_esquema.Maestra 
	WHERE Publicacion_Estado IS NOT NULL;	

	INSERT INTO dbo.PUBLICACIONES
	SELECT DISTINCT				
			Publicacion_Cod,									
			Publicacion_Descripcion,		                    
			Publicacion_Stock,			                        
			Publicacion_Fecha,			                        
			Publicacion_Fecha_Venc,                             
			Publicacion_Precio,			                        			                        
			(SELECT top 1 Id_Usuario                                  
			   FROM dbo.USUARIOS Usuarios   
			  WHERE Id_Usuario IN (SELECT Id_Cliente FROM dbo.CLIENTES WHERE Dni_Cliente = Publ_Cli_Dni)
				OR Id_Usuario IN (SELECT Id_Empresa FROM dbo.EMPRESAS WHERE Cuit_Empresa = Publ_Empresa_Cuit)),		
			Publicacion_Visibilidad_Cod,
			(SELECT top 1 t.Id_Tipo
			   FROM dbo.TIPO_PUBLICACION t, gd_esquema.Maestra m
			  WHERE t.Descripcion = m.Publicacion_Tipo
			    AND m.Publicacion_Cod = Publicacion_Cod),
			(SELECT top 1 r.Id_Rubro
			   FROM dbo.RUBROS r, gd_esquema.Maestra m
			  WHERE r.Descripcion = m.Publicacion_Rubro_Descripcion
			    AND m.Publicacion_Cod = Publicacion_Cod),
			(SELECT top 1 e.Id_Estado
			   FROM dbo.PUBLICACION_ESTADOS e, gd_esquema.Maestra m
			  WHERE e.Descripcion = m.Publicacion_Estado
			    AND m.Publicacion_Cod = Publicacion_Cod)			
	FROM gd_esquema.Maestra WHERE Publicacion_Cod is not null;

	INSERT INTO dbo.OFERTAS	
	SELECT DISTINCT
		Oferta_Fecha,
		Oferta_Monto,
		Publicacion_Cod,
		(SELECT Id_Usuario
			   From dbo.USUARIOS
			  WHERE Id_Usuario = Cli_Dni)		
	FROM gd_esquema.Maestra WHERE Oferta_Monto IS NOT NULL;

	INSERT INTO dbo.CALIFICACIONES
	SELECT DISTINCT
		Calificacion_Codigo,
		Calificacion_Cant_Estrellas,
		Calificacion_Descripcion
	FROM gd_esquema.Maestra WHERE Calificacion_Codigo IS NOT NULL;

	INSERT INTO dbo.COMPRAS
	SELECT DISTINCT
		Compra_Cantidad,
		Publicacion_Precio,			
		Compra_Fecha,			
		(SELECT Id_Oferta
		 FROM OFERTAS
		 WHERE	Publicacion_Cod = Id_Publicacion
			And	Oferta_Monto = Monto
			And	Oferta_Fecha = Fecha),	--Monto tiene que ser unico.	
		Publicacion_Cod,
		Calificacion_Codigo
	FROM gd_esquema.Maestra WHERE Compra_Cantidad IS NOT NULL;

	INSERT INTO dbo.FORMASDEPAGO	
	SELECT DISTINCT
		Forma_Pago_Desc
	FROM gd_esquema.Maestra WHERE Forma_Pago_Desc IS NOT NULL;

	INSERT INTO dbo.FACTURAS
	SELECT DISTINCT			
		Factura_Nro,		
		Factura_Fecha,			
		Factura_Total,			
		(SELECT Id_FormaPago
		   FROM	FORMASDEPAGO
		  WHERE	Forma_Pago_Desc = Descripcion)	
	FROM gd_esquema.Maestra WHERE Forma_Pago_Desc IS NOT NULL;

	INSERT INTO dbo.ITEMFACTURA
	SELECT DISTINCT 
		Item_Factura_Monto,			
		Item_Factura_Cantidad,		
		Factura_Nro,
		Publicacion_Cod	
	FROM gd_esquema.Maestra WHERE Item_Factura_Monto IS NOT NULL;

	-- Asignacion de roles
	INSERT INTO dbo.ROLES (Nombre, Habilitado) VALUES
		('Administrador',1),('Cliente',1), ('Empresa',1);

	INSERT INTO dbo.ROLES_USUARIOS 
	SELECT 3,Id_Empresa FROM dbo.EMPRESAS;

	INSERT INTO dbo.ROLES_USUARIOS
	SELECT 2, Id_Cliente FROM dbo.CLIENTES;

	INSERT INTO dbo.USUARIOS (User_Nombre,User_Password,Habilitado) VALUES ('Admin',HASHBYTES('SHA2_256','1234'),1);
	INSERT INTO dbo.ROLES_USUARIOS (Id_Rol, Id_Usuario) SELECT 1, (SELECT TOP 1 Id_Usuario FROM dbo.USUARIOS WHERE User_Nombre='Admin');

	INSERT INTO dbo.FUNCIONALIDADES (Nombre) VALUES ('ConsultaRol'),
													('AltaRol'),
													('ModificacionRol'),
													('ConsultaUsuario'),
													('ModificacionUsuario'),
													('AltaUsuario'),
													('ConsultaRubro'),
													('AltaRubro'),
													('ModificacionRubro'),
													('AltaVisibilidad'),
													('ConsultaVisibilidad'),
													('ModificacionVisibilidad'),
													('CompraOferta'),
													('HistorialCliente'),
													('FacturasVendedor'),
													('ListadoEstadistico'),
													('Publicar'),
													('Calificar');

	INSERT INTO dbo.FUNCIONALIDES_ROLES (Id_Funcionalidad,Id_Rol) 
	SELECT Id_Funcionalidad,1 
	FROM dbo.FUNCIONALIDADES
	WHERE Nombre NOT LIKE '%Publicacion' 
		AND Nombre NOT LIKE '%CompraOferta' 
		AND Nombre NOT LIKE '%Calificar' 
		AND Nombre NOT LIKE '%HistorialCliente';

	INSERT INTO dbo.FUNCIONALIDES_ROLES (Id_Funcionalidad,Id_Rol)
	SELECT Id_Funcionalidad,2
	FROM dbo.FUNCIONALIDADES
	WHERE Nombre NOT LIKE '%Rol'
		AND Nombre NOT LIKE '%Rubro'
		AND Nombre NOT LIKE 'ListadoEstadistico'
		AND Nombre NOT LIKE '%Visibilidad'
		AND Nombre NOT LIKE '%Usuario';

	INSERT INTO dbo.FUNCIONALIDES_ROLES (Id_Funcionalidad,Id_Rol)
	SELECT Id_Funcionalidad, 3
	FROM dbo.FUNCIONALIDADES 
	WHERE Nombre LIKE '%Publicar' OR Nombre LIKE 'FacturasVendedor';				

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	--SELECT <@Param1, sysname, @p1>, <@Param2, sysname, @p2>

	--SELECT 
	--Id_Visibilidad	,
	--Descripcion		,
	--Precio			,
	--Porcentaje
	--FROM dbo.VISIBILIDADES
	--WHERE Descripcion = 
	--  AND Precio =
	--  And Porcentaje =

	--SELECT
	--	Descripcion 
	--FROM dbo.Rubros
	--Where 
	--		Descripcion =

	--SELECT 
	--	p.Id_Publicacion	,
	--	p.Descripcion		,
	--	p.Stock				,
	--	p.Fecha				,
	--	p.FechaVencimiento	,
	--	p.Precio			,
	--	(SELECT 
	--		u.User_Nombre 
	--	 FROM dbo.USUARIOS u
	--	 WHERE u.Id_Usuario = p.Id_Usuario),
	--	(SELECT 
	--		v.Descripcion
	--	 FROM dbo.VISIBILIDADES v
	--	 WHERE v.Id_Visibilidad = p.Id_Visibilidad),
	--	(SELECT 
	--		t.Descripcion
	--	 FROM dbo.TIPO_PUBLICACION t
	--	 WHERE t.Id_Tipo = p.Id_Tipo),
	--	(SELECT 
	--		r.Descripcion
	--	 FROM dbo.RUBROS r
	--	 WHERE r.Id_Rubro = r.Id_Rubro),
	--	(SELECT 
	--		e.Descripcion
	--	 FROM dbo.PUBLICACION_ESTADOS e
	--	 WHERE e.Id_Estado = e.Id_Estado)
	--FROM dbo.PUBLICACIONES p 
	--Where 
	--	p.  = 
	--	p.  = 
	--	p.  = 
	--	p.  = 
	--	p.  = 
	--	p.  = 




	--************************FUNCIONES/STORED PROCEDURES/TRIGGERS*****************************************

	--GETUSER
	CREATE FUNCTION [PMS].[getUser] (@userName nvarchar(255), @password binary(32))
	returns integer
	AS
BEGIN
DECLARE @resultExistence integer
DECLARE @resultLogin integer

	SET @resultExistence = (SELECT  USUARIOS.Id_Usuario FROM Pms.USUARIOS where User_Nombre like @userName)
	

	if @resultExistence >= 0 
	BEGIN
	SET @resultLogin = ( SELECT USUARIOS.Id_Usuario FROM Pms.USUARIOS where User_Password = HASHBYTES('SHA2_256',@password) AND User_Nombre like @userName);
	
	END
	else if @resultExistence IS NULL
	SET @resultLogin = -2;

	return @resultLogin

END
	-- /GETUSER


	--AumentarIntentos
	CREATE PROCEDURE [PMS].[AumentarIntentosFallidos] @userName nvarchar(255)

AS

DECLARE @intentosActuales integer

SET @intentosActuales = (SELECT Intentos_Login FROM PMS.USUARIOS WHERE User_Nombre like @userName) 


UPDATE PMS.USUARIOS SET Intentos_Login = (@intentosActuales + 1) WHERE User_nombre like @userName

--/AumentarIntentos


--LimpiarIntentos
CREATE PROCEDURE PMS.LimpiarIntentos @userName varchar(255)

AS

BEGIN
UPDATE PMS.USUARIOS SET Intentos_login = 0 WHERE User_Nombre LIKE @userName

END
--/LimpiarIntentos


--Trigger Intentos Fallidos
CREATE TRIGGER PMS.TriggerIntentosFallidos
ON PMS.USUARIOS
AFTER UPDATE
AS


BEGIN
DECLARE @intentos numeric(18,0)
DECLARE @userId numeric(18,0)

SELECT @intentos = (SELECT Intentos_Login FROM inserted)
SELECT @userId = (SELECT Id_Usuario FROM inserted)

if @intentos = 3 
UPDATE PMS.USUARIOS SET Habilitado = 0 WHERE Id_Usuario = @userId


END
--/TriggerIntentosFallidos




END
GO
