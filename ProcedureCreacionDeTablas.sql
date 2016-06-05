-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
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

	CREATE TABLE PMS.USUARIOS 
	(
		Id_Usuario				numeric(18,0)IDENTITY(1,1) NOT NULL,
		User_Nombre				nvarchar(255),
		User_Password			binary,
		PRIMARY KEY(Id_Usuario)
	);

	CREATE TABLE PMS.EMPRESAS
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

	CREATE TABLE PMS.CLIENTES
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

	CREATE TABLE PMS.VISIBILIDADES
	(
		Id_Visibilidad			numeric(18,0),
		Descripcion				nvarchar(255),
		Precio					numeric(18,2),
		Porcentaje				numeric(18,2),
		PRIMARY KEY(Id_Visibilidad)
	);

	CREATE TABLE PMS.PUBLICACIONES
	(
		Id_Publicacion			numeric(18,0), -- RECORDAR, Debo insertas ids ya generadas, pero el tp dice que las ids de publicaciones deben ser autogeneradas y consecutivas, por ende va a haber que setearla a mano
		Descripcion				nvarchar(255),
		Stock					numeric(18,0),
		Fecha					datetime,
		FechaVencimiento		datetime,
		Precio					numeric(18,2),
		Tipo					nvarchar(255),
		Id_Usuario				numeric(18,0),
		Id_Visibilidad			numeric(18,0),
		PRIMARY KEY(Id_Publicacion),
		FOREIGN KEY(Id_Visibilidad) REFERENCES PMS.VISIBILIDADES(Id_visibilidad),
		FOREIGN KEY(Id_Usuario) REFERENCES PMS.USUARIOS(Id_Usuario)
	);

	CREATE TABLE PMS.PUBLICACION_ESTADOS
	(
		Id_Estado				numeric(18,0) IDENTITY(1,1) NOT NULL,
		Estado					nvarchar(255),
		PRIMARY KEY(Id_Estado)					
	);

	CREATE TABLE PMS.COMPRAS
	(
		Id_Compra				numeric(18,0) NOT NULL,
		Cantidad				numeric(18,0),
		Monto					numeric(18,2),
		Fecha					datetime,
		Id_Cliente_Comprador	numeric(18,0),
		Id_Publicacion			numeric(18,0),
		PRIMARY KEY(Id_Compra),
		FOREIGN KEY(Id_Cliente_Comprador) REFERENCES PMS.CLIENTES(Id_Cliente),
		FOREIGN KEY(Id_Publicacion) REFERENCES PMS.PUBLICACIONES(Id_Publicacion),
	);


	CREATE TABLE PMS.OFERTAS
	(
		Id_Oferta				numeric(18,0) NOT NULL,
		Fecha					datetime,
		Monto					numeric(18,2),
		Cantidad				numeric(18,0),
		Id_Publicacion			numeric(18,0),
		Id_Cliente				numeric(18,0),
		PRIMARY KEY(Id_Oferta),
		FOREIGN KEY(Id_publicacion) REFERENCES PMS.PUBLICACIONES(Id_Publicacion),
		FOREIGN KEY(Id_Cliente) REFERENCES PMS.CLIENTES(Id_Cliente)
	);

	CREATE TABLE PMS.FORMASDEPAGO
	(
		Id_FormaPago			numeric(11,0) IDENTITY(1,1) NOT NULL,
		Descripcion				nvarchar(255),
		PRIMARY KEY(Id_FormaPago)
	);

	CREATE TABLE PMS.FACTURAS
	(
		Numero					numeric(18,0),
		Fecha					datetime,
		Total					numeric(18,2),
		Id_FormaPago			numeric(11,0),
		PRIMARY KEY(Numero),
		FOREIGN KEY(Id_FormaPago) REFERENCES PMS.FORMASDEPAGO(Id_FormaPago)
	);

	

	CREATE TABLE PMS.ITEMFACTURA
	(
		Id_ItemFactura			numeric(18,0) IDENTITY(1,1) NOT NULL,
		Monto					numeric(18,2),
		Cantidad				numeric(18,0),
		Id_Factura				numeric(18,0),
		Id_Publicacion			numeric(18,0),
		PRIMARY KEY(Id_ItemFactura),
		FOREIGN KEY(Id_Factura) REFERENCES PMS.FACTURAS(Numero),
		FOREIGN KEY(Id_Publicacion) REFERENCES PMS.PUBLICACIONES(Id_Publicacion)
	);

	CREATE TABLE PMS.CALIFICACIONES
	(
		Id_Calificacion			numeric(18,0),
		Cantidad_Estrellas		numeric(18,0),
		Descripcion				nvarchar(255),
		PRIMARY KEY(Id_Calificacion)
	);

	CREATE TABLE PMS.ROLES
	(
		Id_Rol						numeric(18,0) IDENTITY(1,1) NOT NULL,
		Nombre						nvarchar(255),
		Habilitado					numeric(18,0),
		PRIMARY KEY(Id_Rol)
	);

	CREATE TABLE PMS.ROLES_USUARIOS 
	(
		Id_Rol						numeric(18,0),
		Id_Usuario					numeric(18,0),
		PRIMARY KEY(Id_Rol, Id_Usuario),
		FOREIGN KEY(Id_Rol) REFERENCES PMS.ROLES(Id_Rol),
		FOREIGN KEY(Id_Usuario) REFERENCES PMS.USUARIOS(Id_Usuario)

	);


	CREATE TABLE PMS.FUNCIONALIDADES
	(
		Id_Funcionalidad			numeric(18,0) IDENTITY(1,1) NOT NULL,
		Nombre						nvarchar(255),
		PRIMARY KEY(Id_Funcionalidad)
	);


	CREATE TABLE PMS.FUNCIONALIDES_ROLES
	(
		Id_Funcionalidad			numeric(18,0) IDENTITY(1,1) NOT NULL,
		Id_Rol						numeric(18,0),
		PRIMARY KEY(Id_Funcionalidad),
		FOREIGN KEY(Id_Rol) REFERENCES PMS.ROLES(Id_Rol)
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
	WHERE Cli_Dni not in (select Dni_Cliente from PMS.CLIENTES) AND Cli_Dni IS NOT NULL;
	
	
	INSERT INTO PMS.EMPRESAS 
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
	WHERE Publ_Empresa_Cuit IS NOT NULL 
	


	DECLARE @CantidadEmpresas numeric(18,0);
	SELECT @CantidadEmpresas = COUNT(*) FROM #TempEmpresas;
	

	--DBCC CHECKIDENT('PMS.CLIENTES', RESEED, @CantidadEmpresas);

	INSERT INTO PMS.CLIENTES
	SELECT DISTINCT 	
		   ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) + @CantidadEmpresas,
		   *
	FROM gd_esquema.Maestra
	WHERE Publ_Cli_Dni is not null
	
	

	INSERT INTO PMS.USUARIOS 
	SELECT RazonSocial 
	FROM PMS.EMPRESAS
	ORDER BY Id_Empresa;
	
	INSERT INTO PMS.USUARIOS 
	SELECT (Nombre + Apellido) 
	FROM PMS.CLIENTES
	ORDER BY Id_Cliente;

	INSERT INTO PMS.VISIBILIDADES
	SELECT	DISTINCT
			Publicacion_Visibilidad_Cod,
			Publicacion_Visibilidad_Desc,
			Publicacion_Visibilidad_Precio,		
			Publicacion_Visibilidad_Porcentaje
	FROM gd_esquema.Maestra 
	WHERE Publicacion_Visibilidad_Cod IS NOT NULL;

	INSERT INTO PMS.PUBLICACIONES
	SELECT DISTINCT				
			Publicacion_Cod,									
			Publicacion_Descripcion,		                    
			Publicacion_Stock,			                        
			Publicacion_Fecha,			                        
			Publicacion_Fecha_Venc,                             
			Publicacion_Precio,			                        
			Publicacion_Tipo,			                        
			(SELECT top 1 Id_Usuario                                  
			   FROM PMS.USUARIOS Usuarios   
			  WHERE Id_Usuario IN (SELECT Id_Cliente FROM PMS.CLIENTES WHERE Dni_Cliente = Publ_Cli_Dni)
				OR Id_Usuario IN (SELECT Id_Empresa FROM PMS.EMPRESAS WHERE Cuit_Empresa = Publ_Empresa_Cuit)),		
			Publicacion_Visibilidad_Cod
	FROM gd_esquema.Maestra WHERE Publicacion_Cod is not null;

	INSERT INTO PMS.OFERTAS	
	SELECT DISTINCT
		Oferta_Fecha,
		Oferta_Monto,
		Publicacion_Cod,
		(SELECT Id_Usuario
			   From PMS.USUARIOS
			  WHERE Id_Usuario = Cli_Dni)		
	FROM gd_esquema.Maestra WHERE Oferta_Monto IS NOT NULL;

	INSERT INTO PMS.COMPRAS
	SELECT DISTINCT
		Compra_Cantidad,			
		Compra_Fecha,			
		(SELECT Id_Oferta
		 FROM OFERTAS
		 WHERE	Publicacion_Cod = Id_Publicacion
			And	Oferta_Monto = Monto
			And	Oferta_Fecha = Fecha),	--Monto tiene que ser unico.	
		Publicacion_Cod
	FROM gd_esquema.Maestra WHERE Compra_Cantidad IS NOT NULL;

	INSERT INTO PMS.FORMASDEPAGO	
	SELECT DISTINCT
		Forma_Pago_Desc
	FROM gd_esquema.Maestra WHERE Forma_Pago_Desc IS NOT NULL;

	INSERT INTO PMS.FACTURAS
	SELECT DISTINCT			
		Factura_Nro,		
		Factura_Fecha,			
		Factura_Total,			
		(SELECT Id_FormaPago
		   FROM	FORMASDEPAGO
		  WHERE	Forma_Pago_Desc = Descripcion)	
	FROM gd_esquema.Maestra WHERE Forma_Pago_Desc IS NOT NULL;

	INSERT INTO PMS.ITEMFACTURA
	SELECT DISTINCT 
		Item_Factura_Monto,			
		Item_Factura_Cantidad,		
		Factura_Nro	
	FROM gd_esquema.Maestra WHERE Item_Factura_Monto IS NOT NULL;

	INSERT INTO PMS.CALIFICACIONES
	SELECT DISTINCT
		Calificacion_Codigo,
		Calificacion_Cant_Estrellas,
		Calificacion_Descripcion
	FROM gd_esquema.Maestra WHERE Calificacion_Codigo IS NOT NULL;

	-- Asignacion de roles
	INSERT INTO PMS.ROLES (Nombre, Habilitado) VALUES
		('Administrador',1),('Cliente',1), ('Empresa',1);

	INSERT INTO PMS.ROLES_USUARIOS 
	SELECT 2,Id_Empresa FROM PMS.EMPRESAS;

	INSERT INTO PMS.ROLES_USUARIOS
	SELECT 3, Id_Cliente FROM PMS.CLIENTES;

	
		

		




	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	--SELECT <@Param1, sysname, @p1>, <@Param2, sysname, @p2>
END
GO
