BEGIN TRAN TRANSACCION_INICIAL;

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE SCHEMA PMS;
GO

CREATE PROCEDURE PMS.CreacionTabla
AS
BEGIN

		CREATE TABLE PMS.USUARIOS 
	(
		Id_Usuario				numeric(18,0) IDENTITY(1,1) NOT NULL,
		User_Nombre				nvarchar(255),
		User_Password			binary(32),
		FechaCreacion			datetime,
		Habilitado					numeric(18,0) DEFAULT 1,
		Intentos_login			numeric(18,0) DEFAULT 0,
		Primera_Vez				numeric(18,0),
		Reputacion				numeric(18,0)		
		PRIMARY KEY(Id_Usuario)
	);

		CREATE TABLE PMS.RUBROS
	(
		Id_Rubro						numeric(18,0) IDENTITY(1,1) NOT NULL,
		Descripcion						nvarchar(255),
		PRIMARY KEY(Id_Rubro)	
	);
	
	CREATE TABLE PMS.EMPRESAS
	(	
		Id_Empresa				numeric(18,0) NOT NULL,
		Cuit_Empresa			nvarchar(50) UNIQUE,	
		RazonSocial				nvarchar(255),	
		Mail					nvarchar(50),
		DomCalle				nvarchar(100),
		NroCalle				numeric(18,0),
		Piso					numeric(18,0),
		Depto					nvarchar(50),
		CodigoPostal			nvarchar(50),
		Ciudad					nvarchar(50),
		NombreContacto			nvarchar(50),
		Telefono				nvarchar(50),
		Id_Rubro				numeric(18,0),
		PRIMARY KEY(Id_Empresa),
		FOREIGN KEY(Id_Rubro) REFERENCES PMS.RUBROS(Id_Rubro),

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
		Tipo_Doc				nvarchar(50),
		Telefono				nvarchar(50),
		PRIMARY KEY(Id_Cliente)
	);

	CREATE TABLE PMS.VISIBILIDADES
	(
		Id_Visibilidad			numeric(18,0),
		Descripcion				nvarchar(255),
		Precio					numeric(18,2),
		Porcentaje				numeric(18,2),
		Habilitado				numeric(18,0) DEFAULT 1,
		CostoEnvio				numeric(18,0) DEFAULT 5,
		PRIMARY KEY(Id_Visibilidad)
	);
	
	CREATE TABLE PMS.TIPO_PUBLICACION
	(
		Id_Tipo						numeric(18,0) IDENTITY(1,1) NOT NULL,
		Descripcion					nvarchar(255),
		PRIMARY KEY(Id_Tipo)
	);
	
		CREATE TABLE PMS.PUBLICACION_ESTADOS
	(
		Id_Estado				numeric(18,0) IDENTITY(1,1) NOT NULL,
		Descripcion				nvarchar(255),
		PRIMARY KEY(Id_Estado)					
	);


	CREATE TABLE PMS.PUBLICACIONES
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
		AceptaPreguntas			numeric(18,0) DEFAULT 0,
		PRIMARY KEY(Id_Publicacion),
		FOREIGN KEY(Id_Visibilidad) REFERENCES PMS.VISIBILIDADES(Id_visibilidad),
		FOREIGN KEY(Id_Usuario) 	REFERENCES PMS.USUARIOS(Id_Usuario),
		FOREIGN KEY(Id_Rubro) 		REFERENCES PMS.RUBROS(Id_Rubro),
		FOREIGN KEY(Id_Tipo) 		REFERENCES PMS.TIPO_PUBLICACION(Id_Tipo),
		FOREIGN KEY(Id_Estado) 		REFERENCES PMS.PUBLICACION_ESTADOS(Id_Estado),
		
	);

	CREATE TABLE PMS.CALIFICACIONES
	(
		Id_Calificacion			numeric(18,0),
		Cantidad_Estrellas		numeric(18,0),
		Descripcion				nvarchar(255),
		PRIMARY KEY(Id_Calificacion)
	);

	CREATE TABLE PMS.COMPRAS
	(
		Id_Compra				numeric(18,0) IDENTITY(1,1) NOT NULL,
		Cantidad				numeric(18,0),
		Monto					numeric(18,2),
		Fecha					datetime,
		Id_Cliente_Comprador	numeric(18,0),
		Id_Publicacion			numeric(18,0),
		Id_Calificacion			numeric(18,0),
		PRIMARY KEY(Id_Compra),
		FOREIGN KEY(Id_Cliente_Comprador) REFERENCES PMS.CLIENTES(Id_Cliente),
		FOREIGN KEY(Id_Publicacion) REFERENCES PMS.PUBLICACIONES(Id_Publicacion),
		FOREIGN KEY(Id_Calificacion) REFERENCES PMS.CALIFICACIONES(Id_Calificacion),
	);


	CREATE TABLE PMS.OFERTAS
	(
		Id_Oferta				numeric(18,0) IDENTITY(1,1) NOT NULL,
		Fecha					datetime,
		Monto					numeric(18,2),
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
		Descripcion				nvarchar(255),
		Id_Factura				numeric(18,0),
		Id_Publicacion			numeric(18,0),
		PRIMARY KEY(Id_ItemFactura),
		FOREIGN KEY(Id_Factura) REFERENCES PMS.FACTURAS(Numero),
		FOREIGN KEY(Id_Publicacion) REFERENCES PMS.PUBLICACIONES(Id_Publicacion)
	);

	CREATE TABLE PMS.ROLES
	(
		Id_Rol						numeric(18,0) IDENTITY(1,1) NOT NULL,
		Nombre						nvarchar(255),
		Habilitado					numeric(18,0) DEFAULT 1,
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
		Id_Funcionalidad			numeric(18,0),
		Id_Rol						numeric(18,0),
		PRIMARY KEY(Id_Funcionalidad,Id_Rol),
		FOREIGN KEY(Id_Rol) REFERENCES PMS.ROLES(Id_Rol),
		FOREIGN KEY(Id_Funcionalidad) REFERENCES PMS.FUNCIONALIDADES(Id_Funcionalidad)
	);
	
		INSERT INTO PMS.RUBROS
	SELECT DISTINCT
			Publicacion_Rubro_Descripcion
	FROM gd_esquema.Maestra 
	WHERE Publicacion_Rubro_Descripcion IS NOT NULL;
	
	SELECT DISTINCT			
		   Publ_Empresa_Cuit,
		   Publ_Empresa_Razon_Social,
		   Publ_Empresa_Mail,
		   Publ_Empresa_Dom_Calle,
		   Publ_Empresa_Nro_Calle,
		   Publ_Empresa_Piso,
		   Publ_Empresa_Depto,	
		   Publ_Empresa_Cod_Postal,
		   null as Ciudad,
		   null as NombreContacto,
		   null as Telefono,
		   (select top 1 Id_Rubro from PMS.RUBROS r,gd_esquema.Maestra m  where r.Descripcion=m.Publicacion_Rubro_Descripcion) as Id_Rubro
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
		   Publ_Cli_Cod_Postal,
		   'DNI' AS Tipo_Doc,
		   NULL as Telefono
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
		   Cli_Cod_Postal,
		   'DNI',
		   NULL
	FROM gd_esquema.Maestra
	WHERE Cli_Dni not in (select Cli_Dni from #TempClientes) AND Cli_Dni IS NOT NULL;
	

	INSERT INTO PMS.EMPRESAS 
	SELECT
		   ROW_NUMBER() OVER (ORDER BY (SELECT NULL)),
		   Publ_Empresa_Cuit,
		   Publ_Empresa_Razon_Social,
		   Publ_Empresa_Mail,
		   Publ_Empresa_Dom_Calle,
		   Publ_Empresa_Nro_Calle,
		   Publ_Empresa_Piso,
		   Publ_Empresa_Depto,
		   Publ_Empresa_Cod_Postal,
		   Ciudad,
		   NombreContacto,
		   Telefono,
		   Id_Rubro
	FROM #TempEmpresas
	WHERE Publ_Empresa_Cuit IS NOT NULL;
	


	DECLARE @CantidadEmpresas numeric(18,0);
	SELECT @CantidadEmpresas = COUNT(*) FROM #TempEmpresas;
	

	--DBCC CHECKIDENT('PMS.CLIENTES', RESEED, @CantidadEmpresas);

	INSERT INTO PMS.CLIENTES
	SELECT DISTINCT 	
		   ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) + @CantidadEmpresas,
		   *
	FROM #TempClientes
	WHERE Publ_Cli_Dni is not null;
	
	

	INSERT INTO PMS.USUARIOS (User_Nombre, Habilitado, User_Password,FechaCreacion)
	SELECT RazonSocial, 1, HASHBYTES('SHA2_256','1234'),
	(select TOP 1 Publ_Empresa_Fecha_Creacion 
	   from gd_esquema.Maestra
	  where Publ_Empresa_Cuit = Cuit_Empresa
		and Publ_Empresa_Fecha_Creacion is not null )
	FROM PMS.EMPRESAS
	ORDER BY Id_Empresa;
	
	INSERT INTO PMS.USUARIOS (User_Nombre, Habilitado, User_Password, FechaCreacion)
	SELECT (Nombre + Apellido), 1 , HASHBYTES('SHA2_256','1234'),
	(select MIN(Publicacion_Fecha)
	   from gd_esquema.Maestra)
	FROM PMS.CLIENTES
	ORDER BY Id_Cliente;

	INSERT INTO PMS.VISIBILIDADES
	SELECT	DISTINCT
			Publicacion_Visibilidad_Cod,
			Publicacion_Visibilidad_Desc,
			Publicacion_Visibilidad_Precio,		
			Publicacion_Visibilidad_Porcentaje,
			1, 5
	FROM gd_esquema.Maestra 
	WHERE Publicacion_Visibilidad_Cod IS NOT NULL;

	UPDATE PMS.VISIBILIDADES SET CostoEnvio = 0 WHERE Descripcion='Gratis';

	INSERT INTO PMS.TIPO_PUBLICACION
	SELECT DISTINCT
		Publicacion_Tipo
	FROM gd_esquema.Maestra 
	WHERE Publicacion_Tipo IS NOT NULL;
	
	
	INSERT INTO PMS.PUBLICACION_ESTADOS
	SELECT DISTINCT
			Publicacion_Estado
	FROM gd_esquema.Maestra 
	WHERE Publicacion_Estado IS NOT NULL;	

	INSERT INTO PMS.PUBLICACIONES
	SELECT DISTINCT				
			Publicacion_Cod,									
			Publicacion_Descripcion,		                    
			Publicacion_Stock,			                        
			Publicacion_Fecha,			                        
			Publicacion_Fecha_Venc,                             
			Publicacion_Precio,			                        			                        
			(SELECT top 1 Id_Usuario                                  
			   FROM PMS.USUARIOS Usuarios   
			  WHERE Id_Usuario IN (SELECT Id_Cliente FROM PMS.CLIENTES WHERE Dni_Cliente = Publ_Cli_Dni)
				OR Id_Usuario IN (SELECT Id_Empresa FROM PMS.EMPRESAS WHERE Cuit_Empresa = Publ_Empresa_Cuit)),		
			Publicacion_Visibilidad_Cod,
			(SELECT top 1 t.Id_Tipo
			   FROM PMS.TIPO_PUBLICACION t
			  WHERE t.Descripcion = Publicacion_Tipo
			    AND Publicacion_Cod = Publicacion_Cod),
			(SELECT top 1 r.Id_Rubro
			   FROM PMS.RUBROS r
			  WHERE r.Descripcion = Publicacion_Rubro_Descripcion
			    AND Publicacion_Cod = Publicacion_Cod),
			(SELECT top 1 e.Id_Estado
			   FROM PMS.PUBLICACION_ESTADOS e
			  WHERE e.Descripcion = Publicacion_Estado
			    AND Publicacion_Cod = Publicacion_Cod),
				0	
	FROM gd_esquema.Maestra WHERE Publicacion_Cod is not null;

	INSERT INTO PMS.OFERTAS	
	SELECT DISTINCT
		Oferta_Fecha,
		Oferta_Monto,
		Publicacion_Cod,
		(SELECT Id_Cliente
			   From PMS.CLIENTES
			  WHERE Dni_Cliente = Cli_Dni)		
	FROM gd_esquema.Maestra WHERE Oferta_Monto IS NOT NULL;

	INSERT INTO PMS.CALIFICACIONES
	SELECT DISTINCT
		Calificacion_Codigo,
		Calificacion_Cant_Estrellas,
		Calificacion_Descripcion
	FROM gd_esquema.Maestra WHERE Calificacion_Codigo IS NOT NULL;

	INSERT INTO PMS.COMPRAS
	SELECT DISTINCT
		Compra_Cantidad,
		Publicacion_Precio,			
		Compra_Fecha,			
		(SELECT Id_Cliente FROM PMS.CLIENTES cliente WHERE Cli_Dni = cliente.Dni_Cliente),	--Monto tiene que ser unico.	
		Publicacion_Cod,
		Calificacion_Codigo
	FROM gd_esquema.Maestra WHERE Compra_Cantidad IS NOT NULL AND Calificacion_Codigo is not null;

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
		   FROM	PMS.FORMASDEPAGO
		  WHERE	Forma_Pago_Desc = Descripcion)	
	FROM gd_esquema.Maestra WHERE Forma_Pago_Desc IS NOT NULL;

	INSERT INTO PMS.ITEMFACTURA
	SELECT DISTINCT 
		Item_Factura_Monto,			
		Item_Factura_Cantidad,
		CASE WHEN (Item_Factura_Monto = Publicacion_Precio * Publicacion_Visibilidad_Porcentaje) THEN 'Comision por venta'
			 ELSE 'Comision por publicacion' END,		
		Factura_Nro,
		Publicacion_Cod	
	FROM gd_esquema.Maestra WHERE Item_Factura_Monto IS NOT NULL;

	-- Asignacion de roles
	INSERT INTO PMS.ROLES (Nombre, Habilitado) VALUES
		('Administrador',1),('Cliente',1), ('Empresa',1);

	INSERT INTO PMS.ROLES_USUARIOS 
	SELECT 3,Id_Empresa FROM PMS.EMPRESAS;

	INSERT INTO PMS.ROLES_USUARIOS
	SELECT 2, Id_Cliente FROM PMS.CLIENTES;

	INSERT INTO PMS.USUARIOS (User_Nombre,User_Password,Habilitado) VALUES ('Admin',HASHBYTES('SHA2_256','1234'),1);
	INSERT INTO PMS.ROLES_USUARIOS (Id_Rol, Id_Usuario) SELECT 1, (SELECT TOP 1 Id_Usuario FROM PMS.USUARIOS WHERE User_Nombre='Admin');

	INSERT INTO PMS.FUNCIONALIDADES (Nombre) VALUES ('ConsultaRol'),
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

	INSERT INTO PMS.FUNCIONALIDES_ROLES (Id_Funcionalidad,Id_Rol) 
	SELECT Id_Funcionalidad,1 
	FROM PMS.FUNCIONALIDADES
	WHERE Nombre NOT LIKE '%Publicacion' 
		AND Nombre NOT LIKE '%CompraOferta' 
		AND Nombre NOT LIKE '%Calificar' 
		AND Nombre NOT LIKE '%HistorialCliente';

	INSERT INTO PMS.FUNCIONALIDES_ROLES (Id_Funcionalidad,Id_Rol)
	SELECT Id_Funcionalidad,2
	FROM PMS.FUNCIONALIDADES
	WHERE Nombre NOT LIKE '%Rol'
		AND Nombre NOT LIKE '%Rubro'
		AND Nombre NOT LIKE 'ListadoEstadistico'
		AND Nombre NOT LIKE '%Visibilidad'
		AND Nombre NOT LIKE '%Usuario';

	INSERT INTO PMS.FUNCIONALIDES_ROLES (Id_Funcionalidad,Id_Rol)
	SELECT Id_Funcionalidad, 3
	FROM PMS.FUNCIONALIDADES 
	WHERE Nombre LIKE '%Publicar' OR Nombre LIKE 'FacturasVendedor';
	
	INSERT INTO PMS.PUBLICACION_ESTADOS
(Descripcion)
select
'Borrador'
union all
select
'Pausada'
union all
select
'Finalizada';

update PMS.PUBLICACION_ESTADOS
SET
Descripcion='Activa'
where Id_Estado=1;

update PMS.PUBLICACIONES 
set Id_Estado= 4
where Id_Publicacion in (select f.Id_Publicacion from PMS.ITEMFACTURA f where Descripcion = 'Comision por venta')
--and Id_Tipo = 2

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	END
	GO

	IF not EXISTS (SELECT * FROM sys.types WHERE is_user_defined = 1 AND name = 'pms.Funcionalidades')
	CREATE TYPE pms.Funcionalidades
	AS TABLE
	(
		funcionalidad_id INT
	);
	GO

			EXEC PMS.CreacionTabla;
			GO
	

	CREATE FUNCTION [PMS].[getEstrellasDadas] (@idUser numeric(18,0))
	returns integer
	AS

		BEGIN
		DECLARE @cantidad integer

				set @cantidad =	(select SUM(Cantidad_Estrellas) FROM PMS.COMPRAS CO join pms.CALIFICACIONES CA on 
							CA.Id_Calificacion = CO.Id_Calificacion AND CO.Id_Cliente_Comprador = @idUser)
		return @cantidad


		END
		GO

CREATE  PROCEDURE pms.upd_Rol
       @id numeric,
	   @nombre nvarchar(255),
	   @func_del pms.Funcionalidades READONLY,
	   @func_add pms.Funcionalidades READONLY
	   
		
                    
AS 
BEGIN 
     SET NOCOUNT ON 

UPDATE [pms].[ROLES]
   SET nombre = @nombre
 WHERE Id_Rol = @id;
 

 DELETE FROM [pms].[FUNCIONALIDES_ROLES]
      WHERE (Id_Funcionalidad in (select * from @func_del));

DECLARE @id_func INT
DECLARE db_cursor CURSOR FOR  
SELECT * 
FROM @func_add 

OPEN db_cursor   
FETCH NEXT FROM db_cursor INTO @id_func   

WHILE @@FETCH_STATUS = 0
BEGIN

 INSERT INTO [pms].[FUNCIONALIDES_ROLES]
           ([Id_Rol],Id_Funcionalidad)
     VALUES
           (@id,@id_func);
FETCH NEXT FROM db_cursor INTO @id_func
END

END 
GO

CREATE PROCEDURE pms.insert_Ro
       @nombre nvarchar(255)
                    
AS 
BEGIN 
     SET NOCOUNT ON 

     INSERT INTO [pms].[ROLES]
          ( 
            nombre, 
			habilitado		
          ) 
     VALUES 
          ( 
            @nombre,
			1)
			
END 
GO
CREATE  PROCEDURE pms.del_Rol
       @id numeric 
                    
AS 
BEGIN 
     SET NOCOUNT ON 

UPDATE [pms].[ROLES]
   SET [Habilitado] = 0
 WHERE Id_Rol = @id;
 
 DELETE FROM [pms].[ROLES_USUARIOS]
      where Id_Rol=@id;


END
GO

CREATE  PROCEDURE PMS.MODIFICACION_ROLES
       @id numeric,
	   @nombre nvarchar(255),
	   @func_add PMS.Funcionalidades READONLY
	   
		
                    
AS 
BEGIN 
     SET NOCOUNT ON 

UPDATE [PMS].[ROLES]
   SET nombre = @nombre
 WHERE Id_Rol = @id;
 

 DELETE FROM [PMS].[FUNCIONALIDES_ROLES]
      WHERE (Id_Rol=@id);

DECLARE @id_func INT
DECLARE db_cursor CURSOR FOR  
SELECT * 
FROM @func_add 

OPEN db_cursor   
FETCH NEXT FROM db_cursor INTO @id_func   

WHILE @@FETCH_STATUS = 0
BEGIN

 INSERT INTO [PMS].[FUNCIONALIDES_ROLES]
           ([Id_Rol],Id_Funcionalidad)
     VALUES
           (@id,@id_func);
FETCH NEXT FROM db_cursor INTO @id_func
END

END 
GO

CREATE PROCEDURE PMS.ALTA_ROL
       @nombre nvarchar(255),
	   @id numeric(18,0) OUTPUT
                    
AS 
BEGIN 
     SET NOCOUNT ON 

     INSERT INTO [PMS].[ROLES]
          ( 
            nombre, 
			habilitado		
          ) 
     VALUES 
          ( 
            @nombre,
			1)
	set @id=(SELECT MAX(Id_Rol) from PMS.ROLES)	
END 
GO
CREATE  PROCEDURE PMS.BAJA_ROL
       @id numeric 
                    
AS 
BEGIN 
     SET NOCOUNT ON 

UPDATE [PMS].[ROLES]
   SET [Habilitado] = 0
 WHERE Id_Rol = @id;
 
 DELETE FROM [PMS].[ROLES_USUARIOS]
      where Id_Rol=@id;


END
GO

CREATE  PROCEDURE PMS.HABILITAR_ROL
       @id numeric 
                    
AS 
BEGIN 
     SET NOCOUNT ON 

UPDATE [PMS].[ROLES]
   SET [Habilitado] = 1
 WHERE Id_Rol = @id;
 
 DELETE FROM [PMS].[ROLES_USUARIOS]
      where Id_Rol=@id;


END
GO

CREATE PROCEDURE PMS.ALTA_USER
			@User_Nombre nvarchar(255)
			,@User_Password binary(32)
			,@Habilitado numeric(18,0)
           ,@Intentos_login numeric(18,0)
           ,@Primera_Vez numeric(18,0)
           ,@Reputacion numeric(18,0)
		   ,@id numeric(18,0) output
	   
                    
AS 
BEGIN 
     SET NOCOUNT ON 

INSERT INTO [PMS].[USUARIOS]
           ([User_Nombre]
           ,[User_Password]
           ,[Habilitado]
           ,[Intentos_login]
           ,[Primera_Vez]
           ,[Reputacion])
     VALUES
           (@User_Nombre
           ,HASHBYTES('SHA2_256',@User_Password)
           ,@Habilitado
           ,@Intentos_login
           ,@Primera_Vez
           ,@Reputacion)
SET @id= (SELECT max(Id_Usuario) from PMS.USUARIOS)
end
go

CREATE PROCEDURE PMS.ALTA_CLIENTE
			@Id_Cliente numeric(18,0)
           ,@Dni_Cliente numeric(18,0)
           ,@Apellido nvarchar(255)
           ,@Nombre nvarchar(255)
           ,@FechaNacimiento datetime
           ,@Mail nvarchar(255)
           ,@DomCalle nvarchar(255)
           ,@NroCalle numeric(18,0)
           ,@Piso numeric(18,0)
           ,@Depto nvarchar(50)
           ,@Cod_Postal nvarchar(50)
as begin
INSERT INTO [PMS].[CLIENTES]
           ([Id_Cliente]
           ,[Dni_Cliente]
           ,[Apellido]
           ,[Nombre]
           ,[FechaNacimiento]
           ,[Mail]
           ,[DomCalle]
           ,[NroCalle]
           ,[Piso]
           ,[Depto]
           ,[Cod_Postal])
     VALUES
           (@Id_Cliente
           ,@Dni_Cliente
           ,@Apellido
           ,@Nombre
           ,@FechaNacimiento
           ,@Mail
           ,@DomCalle
           ,@NroCalle
           ,@Piso
           ,@Depto
           ,@Cod_Postal)
end
go

create procedure PMS.ALTA_EMPRESA
			@Id_Empresa numeric(18,0)
           ,@Cuit_Empresa nvarchar(50)
           ,@RazonSocial nvarchar(255)
           ,@Mail nvarchar(50)
           ,@DomCalle nvarchar(100)
           ,@NroCalle numeric(18,0)
           ,@Piso numeric(18,0)
           ,@Depto nvarchar(50)
           ,@CodigoPostal nvarchar(50)
as 
begin
	INSERT INTO [PMS].[EMPRESAS]
			   ([Id_Empresa]
			   ,[Cuit_Empresa]
			   ,[RazonSocial]
			   ,[Mail]
			   ,[DomCalle]
			   ,[NroCalle]
			   ,[Piso]
			   ,[Depto]
			   ,[CodigoPostal]) 
	VALUES
			   (@Id_Empresa
			   ,@Cuit_Empresa
			   ,@RazonSocial
			   ,@Mail
			   ,@DomCalle
			   ,@NroCalle
			   ,@Piso
			   ,@Depto
			   ,@CodigoPostal);
	end
go

create procedure PMS.ALTA_USUARIO_CLIENTE
			@User_Nombre nvarchar(255)
		   ,@User_Password nvarchar(255)
           ,@Dni_Cliente numeric(18,0)
		   ,@Tipo_Dni nvarchar(50)
           ,@Apellido nvarchar(255)
           ,@Nombre nvarchar(255)
           ,@FechaNacimiento datetime
           ,@Mail nvarchar(255)
           ,@DomCalle nvarchar(255)
           ,@NroCalle numeric(18,0)
           ,@Piso numeric(18,0)
           ,@Depto nvarchar(50)
           ,@CodigoPostal nvarchar(50)
		   ,@Telefono nvarchar(50)
		   --,@Localidad nvarchar(50)
		   ,@FechaCreacion datetime
		   ,@id numeric(18,0) output
as begin
IF EXISTS (select * from PMS.USUARIOS u  WHERE @User_Nombre = u.User_Nombre)
 BEGIN
    RAISERROR ('Duplicate UserName', 16, 1)
 END
 IF EXISTS (select * from PMS.CLIENTES c  WHERE @Dni_Cliente = c.Dni_Cliente)
 BEGIN
    RAISERROR ('Duplicate RazonSocial', 16, 1)
 END
 IF EXISTS (select * from PMS.CLIENTES c  WHERE @Mail = c.Mail)
 BEGIN
    RAISERROR ('Duplicate Mail', 16, 1)
 END

INSERT INTO [PMS].[USUARIOS]
           ([User_Nombre]
           ,[User_Password]
		   ,[FechaCreacion]
           ,[Habilitado]
           ,[Intentos_login]
           ,[Primera_Vez]
           ,[Reputacion])
     VALUES
           (@User_Nombre
           ,HASHBYTES('SHA2_256',@User_Password)
		   ,@FechaCreacion
           ,1
           ,0
           ,1
           ,null)


set @id=(select Id_usuario from PMS.USUARIOS where User_Nombre=@User_Nombre);
INSERT INTO [PMS].[CLIENTES]      
           ([Id_Cliente]			
           ,[Dni_Cliente]            
           ,[Apellido]               
           ,[Nombre]                 
           ,[FechaNacimiento]        
           ,[Mail]                   
           ,[DomCalle]               
           ,[NroCalle]               
           ,[Piso]                   
           ,[Depto]                  
           ,[Cod_Postal]
		   ,[Tipo_Doc]
		   ,[Telefono])              
     VALUES                          
           (@id                      
           ,@Dni_Cliente
           ,@Apellido
           ,@Nombre
           ,@FechaNacimiento
           ,@Mail
           ,@DomCalle
           ,@NroCalle
           ,@Piso
           ,@Depto
           ,@CodigoPostal
		   ,@Tipo_Dni
		   ,@Telefono)
end
go

create procedure PMS.ALTA_USUARIO_EMPRESA
			@User_Nombre nvarchar(255)
			,@User_Password nvarchar(255)
           ,@Cuit_Empresa nvarchar(50)
           ,@RazonSocial nvarchar(255)
           ,@FechaCreacion datetime
           ,@Mail nvarchar(50)
           ,@DomCalle nvarchar(100)
           ,@NroCalle numeric(18,0)
           ,@Piso numeric(18,0)
           ,@Depto nvarchar(50)
           ,@CodigoPostal nvarchar(50)
		   ,@Telefono nvarchar(50)
		   ,@Contacto nvarchar(50)
		   --,@Localidad nvarchar(50)
		   ,@Ciudad nvarchar(50)
		   ,@Rubro nvarchar(50)
		   ,@Id numeric(18,0) output
as begin

declare @Id_Rubro1 numeric(18,0)

IF EXISTS (select * from PMS.USUARIOS u  WHERE @User_Nombre = u.User_Nombre)
 BEGIN
    RAISERROR ('Duplicate UserName', 16, 1)
 END
 IF EXISTS (select * from PMS.EMPRESAS e  WHERE @RazonSocial = e.RazonSocial)
 BEGIN
    RAISERROR ('Duplicate RazonSocial', 16, 1)
 END
 IF EXISTS (select * from PMS.EMPRESAS e  WHERE @Cuit_Empresa = e.Cuit_Empresa)
 BEGIN
    RAISERROR ('Duplicate Cuit', 16, 1)
 END
 IF EXISTS (select * from PMS.EMPRESAS e  WHERE @Mail = e.Mail)
 BEGIN
    RAISERROR ('Duplicate Mail', 16, 1)
 END


INSERT INTO [PMS].[USUARIOS]					
           ([User_Nombre]				    	
           ,[User_Password]                 	
		   ,[FechaCreacion]
           ,[Habilitado]                    	
           ,[Intentos_login]                	
           ,[Primera_Vez]                   	
           ,[Reputacion])                   	
     VALUES                                 	
           (@User_Nombre
           ,HASHBYTES('SHA2_256',@User_Password)
		   ,GETDATE()
           ,1
           ,0
           ,1
           ,null)

set @id=(select Id_usuario from PMS.USUARIOS where User_Nombre=@User_Nombre);
DECLARE @Id_Rubro numeric(18,0);
set @Id_Rubro1=(select Id_Rubro from PMS.RUBROS where Descripcion = @Rubro);

INSERT INTO [PMS].[EMPRESAS]		
           ([Id_Empresa]           
           ,[Cuit_Empresa]         
           ,[RazonSocial]          
           ,[Mail]                 
           ,[DomCalle]             
           ,[NroCalle]             
           ,[Piso]                 
           ,[Depto]                
           ,[CodigoPostal]
		   ,[NombreContacto]
		   ,[Ciudad]
		   ,[Telefono]
		   ,[Id_Rubro]				   
		   )         			
     VALUES	                        	
           (@id                     
           ,@Cuit_Empresa           
           ,@RazonSocial
           ,@FechaCreacion
           ,@Mail
           ,@DomCalle
           ,@NroCalle
           ,@Piso
           ,@Depto
           ,@CodigoPostal
		   ,@Contacto
		   ,@Telefono
		   ,@Id_Rubro)
end
go

create procedure PMS.MODIFICACION_USUARIO_CLIENTE
			@Id_Usuario numeric(18,0)
		   ,@User_Nombre nvarchar(255)
		   ,@User_Password nvarchar(255)
           ,@Dni_Cliente numeric(18,0)
		   ,@Tipo_Dni nvarchar(50)
           ,@Apellido nvarchar(255)
           ,@Nombre nvarchar(255)
           ,@FechaNacimiento datetime
           ,@Mail nvarchar(255)
           ,@DomCalle nvarchar(255)
           ,@NroCalle numeric(18,0)
           ,@Piso numeric(18,0)
           ,@Depto nvarchar(50)
           ,@CodigoPostal nvarchar(50)
		   ,@Telefono nvarchar(50)
		   --,@Localidad nvarchar(50)
		   --,@FechaCreacion datetime
		   --,@id numeric(18,0) 
as begin
IF not EXISTS (select * from PMS.USUARIOS u  WHERE @Id_Usuario = u.Id_Usuario)
 BEGIN
    RAISERROR ('NO Existe usuario', 16, 1)
 END
 IF EXISTS (select * from PMS.CLIENTES c  WHERE @Dni_Cliente = c.Dni_Cliente)
 BEGIN
    RAISERROR ('Duplicate RazonSocial', 16, 1)
 END
 IF EXISTS (select * from PMS.CLIENTES c  WHERE @Mail = c.Mail)
 BEGIN
    RAISERROR ('Duplicate Mail', 16, 1)
 END


IF @User_Password IS NOT NULL
BEGIN UPDATE [PMS].[USUARIOS]
SET			[User_password] = HASHBYTES('SHA2_256',@User_Password)	
WHERE [User_Nombre] = @Id_Usuario

END

UPDATE [PMS].[CLIENTES]      
Set                   
           [Dni_Cliente]     =  @Dni_Cliente     
           ,[Apellido]        =  @Apellido     
           ,[Nombre]          =  @Nombre     
           ,[FechaNacimiento] =  @FechaNacimiento     
           ,[Mail]            =  @Mail     
           ,[DomCalle]        =  @DomCalle     
           ,[NroCalle]        =  @NroCalle     
           ,[Piso]            =  @Piso     
           ,[Depto]           =  @Depto     
           ,[Cod_Postal]	  =  @CodigoPostal
		   ,[Tipo_Doc]		  =  @Tipo_Dni
		   ,[Telefono]        =  @Telefono    
where [Id_Cliente]		=	@Id_Usuario  
   
end
go

create procedure PMS.MODIFICACION_USUARIO_EMPRESA
			@Id_Usuario numeric(18,0)
			,@User_Nombre nvarchar(255)
			,@User_Password nvarchar(255)
           ,@Cuit_Empresa nvarchar(50)
           ,@RazonSocial nvarchar(255)
           ,@FechaCreacion datetime
           ,@Mail nvarchar(50)
           ,@DomCalle nvarchar(100)
           ,@NroCalle numeric(18,0)
           ,@Piso numeric(18,0)
           ,@Depto nvarchar(50)
           ,@CodigoPostal nvarchar(50)
		   ,@Telefono nvarchar(50)
		   ,@Contacto nvarchar(50)
		   --,@Localidad nvarchar(50)
		   ,@Ciudad nvarchar(50)
		   ,@Rubro nvarchar(50)
		   --,@Id numeric(18,0)
as begin

declare @Id_Rubro1 numeric(18,0)

IF not EXISTS (select * from PMS.USUARIOS u  WHERE @Id_Usuario = u.Id_Usuario)
 BEGIN
    RAISERROR ('No user', 16, 1)
 END
 IF EXISTS (select * from PMS.EMPRESAS e  WHERE @RazonSocial = e.RazonSocial and @Id_Usuario <> e.Id_empresa)
 BEGIN
    RAISERROR ('Duplicate RazonSocial', 16, 1)
 END
 IF EXISTS (select * from PMS.EMPRESAS e  WHERE @Cuit_Empresa = e.Cuit_Empresa and @Id_Usuario <> e.Id_empresa)
 BEGIN
    RAISERROR ('Duplicate Cuit', 16, 1)
 END
 IF EXISTS (select * from PMS.EMPRESAS e  WHERE @Mail = e.Mail and @Id_Usuario <> e.Id_empresa)
 BEGIN
    RAISERROR ('Duplicate Mail', 16, 1)
 END


IF @User_Password IS NOT NULL
BEGIN UPDATE [PMS].[USUARIOS]
SET			[User_password] = HASHBYTES('SHA2_256',@User_Password)   	
WHERE [User_Nombre] = @Id_Usuario

END



DECLARE @Id_Rubro numeric(18,0);
set @Id_Rubro1=(select Id_Rubro from PMS.RUBROS where Descripcion = @Rubro);

UPDATE [PMS].[EMPRESAS]		
SET			[Cuit_Empresa]  = @Cuit_Empresa        
           ,[RazonSocial]   = @RazonSocial      
           ,[Mail]          = @FechaCreacion      
           ,[DomCalle]      = @Mail      
           ,[NroCalle]      = @DomCalle      
           ,[Piso]          = @NroCalle      
           ,[Depto]         = @Piso      
           ,[CodigoPostal]	= @Depto
		   ,[NombreContacto]= @CodigoPostal
		   ,[Ciudad]		= @Contacto
		   ,[Telefono]		= @Telefono
		   ,[Id_Rubro]	=	@Id_Rubro
where [Id_Empresa]      =     @Id_Usuario 		   
		          			
   
end
go

CREATE PROCEDURE PMS.MODIFICACION_PUBLICACION
			@Id_Publicacion numeric(18,0)
		   ,@Descripcion nvarchar(255)
           ,@Stock numeric(18,0)
           ,@Fecha datetime
           ,@FechaVencimiento datetime
           ,@Precio numeric(18,2)
           ,@Id_Usuario numeric(18,0)
           ,@Id_Visibilidad numeric(18,0)
           ,@Id_Tipo numeric(18,0)
           ,@Id_Rubro numeric(18,0)
           ,@Id_Estado numeric(18,0)
		   ,@AceptaPreguntas numeric(18,0)
	   
                    
AS 
BEGIN 
     SET NOCOUNT ON 

UPDATE PMS.PUBLICACIONES SET 
      [Descripcion] = @Descripcion
      ,[Stock] = @Stock
      ,[Fecha] = @Fecha
      ,[FechaVencimiento] = @FechaVencimiento
      ,[Precio] = @Precio
      ,[Id_Usuario] = @Id_Usuario
      ,[Id_Visibilidad] = @Id_Visibilidad
      ,[Id_Tipo] = @Id_Tipo
      ,[Id_Rubro] = @Id_Rubro
      ,[Id_Estado] = @Id_Estado
	  ,[AceptaPreguntas] = @AceptaPreguntas
WHERE [Id_Publicacion] = @Id_Publicacion
END
GO

CREATE PROCEDURE PMS.ALTA_PUBLICACION
       @Descripcion nvarchar(255)
           ,@Stock numeric(18,0)
           ,@Fecha datetime
           ,@FechaVencimiento datetime
           ,@Precio numeric(18,2)
           ,@Id_Usuario numeric(18,0)
           ,@Id_Visibilidad numeric(18,0)
           ,@Id_Tipo numeric(18,0)
           ,@Id_Rubro numeric(18,0)
           ,@Id_Estado numeric(18,0)
		   ,@AceptaPreguntas numeric(18,0)
	   
                    
AS 
BEGIN 
     SET NOCOUNT ON 

INSERT INTO PMS.PUBLICACIONES
           ([Id_Publicacion]
      ,[Descripcion]
      ,[Stock]
      ,[Fecha]
      ,[FechaVencimiento]
      ,[Precio]
      ,[Id_Usuario]
      ,[Id_Visibilidad]
      ,[Id_Tipo]
      ,[Id_Rubro]
      ,[Id_Estado])
     VALUES
           ((select max(Id_Publicacion)from PUBLICACIONES)+1
			,@Descripcion 
			,@Stock 
			,@Fecha 
			,@FechaVencimiento 
			,@Precio 
			,@Id_Usuario 
			,@Id_Visibilidad 
			,@Id_Tipo 
			,@Id_Rubro 
			,@Id_Estado)
END
GO

CREATE PROCEDURE PMS.ALTA_COMPRAS
			@Cantidad numeric(18,0)
           ,@Fecha datetime
           ,@Id_Cliente_Comprador numeric(18,0)
           ,@Id_Publicacion numeric(18,0)
		   ,@id numeric(18,0) output
AS BEGIN
if (select top 1 Stock from PMS.PUBLICACIONES where Id_Publicacion=@Id_Publicacion) < @Cantidad
begin
;throw 50999,'cantidad a comprar mayor a stock',1;
end
else if @Id_Cliente_Comprador=(select Id_Usuario from PMS.PUBLICACIONES where Id_Publicacion=@Id_Publicacion)
begin
; throw 50999,'comprador no puede ser el vendedor',1;
end
--else if (select count(Id_Compra) from PMS.COMPRAS where Id_Cliente_Comprador=@Id_Cliente_Comprador and Id_Calificacion is null) > 2
--begin
--; throw 50999,'3 compras sin calificar',1;
--end
else
begin
INSERT INTO PMS.COMPRAS
           (Cantidad
           ,Monto
           ,Fecha
           ,Id_Cliente_Comprador
           ,Id_Publicacion)
     VALUES
           (@Cantidad
           ,(select Precio from PUBLICACIONES where Id_Publicacion=@Id_Publicacion)*@Cantidad
           ,@Fecha
           ,@Id_Cliente_Comprador
           ,@Id_Publicacion);
update PUBLICACIONES set Stock=Stock-@Cantidad where Id_Publicacion=@Id_Publicacion;
if (SELECT Stock from PUBLICACIONES WHERE Id_Publicacion=@Id_Publicacion ) = 0
begin
update PUBLICACIONES SET Id_Estado = 4 WHERE Id_Publicacion=@Id_Publicacion
end
set @id=(select max(Id_Compra)from PMS.COMPRAS)
end
end
GO


CREATE PROCEDURE PMS.ALTA_RUBRO
		@Descripcion nvarchar(30)

AS BEGIN

INSERT INTO PMS.RUBROS
           (Descripcion)
     VALUES
           (@Descripcion
           )

end
GO

create procedure PMS.ALTA_OFERTAS
			@Fecha datetime
           ,@Monto numeric(18,2)
           ,@Id_Publicacion numeric(18,0)
           ,@Id_Cliente numeric(18,0)
		   ,@id numeric(18,0) output
as begin
if @monto<(select max(monto)from OFERTAS where Id_Publicacion=@Id_Publicacion)
begin
; throw 50999,'monto menor',1;
end
else if @Id_Cliente=(select Id_usuario from PUBLICACIONES where Id_Publicacion=@Id_Publicacion)
begin
; throw 50999,'comprador no puede ser el vendedor',1;
end
--else if 2>(select count(Id_Compra) from PMS.COMPRAS where Id_Cliente_Comprador=@Id_Cliente and Id_Calificacion is null)
--begin
--; throw 50999,'3 compras sin calificar',1;
--end
else
begin
INSERT INTO [PMS].[OFERTAS]
           ([Fecha]
           ,[Monto]
           ,[Id_Publicacion]
           ,[Id_Cliente])
     VALUES
           (@Fecha
           ,@Monto
           ,@Id_Publicacion
           ,@Id_Cliente)

UPDATE PMS.Publicaciones SET Precio = @Monto WHERE Id_Publicacion = @Id_Publicacion
end
end
set @id=(select max(Id_Oferta) from PMS.OFERTAS)
GO

create procedure PMS.ALTA_FACTURA
		@Numero numeric(18,0)
        ,@Fecha datetime
        ,@Total numeric(18,2)
        ,@Id_FormaPago numeric(11,0)
		,@Monto numeric(18,2)
        ,@Cantidad numeric(18,0)
        ,@Id_Publicacion numeric(18,0)
		,@Descripcion nvarchar(255)
as
begin 

INSERT INTO PMS.FACTURAS
           (numero
           ,Fecha
           ,Total
           ,Id_FormaPago)
     VALUES
           (@Numero
           ,@Fecha
           ,@Total
           ,@Id_FormaPago );

INSERT INTO [PMS].[ITEMFACTURA]
           ([Monto]
           ,[Cantidad]
           ,[Id_Factura]
           ,[Id_Publicacion]
		   ,Descripcion)
     VALUES
           (@Monto
           ,@Cantidad
           ,@Numero
           ,@Id_Publicacion
		   ,@Descripcion);
END
GO

CREATE TRIGGER PMS.MODIFICACION_USUARIO_REPUTACION
ON PMS.CALIFICACIONES
AFTER INSERT
AS
BEGIN
DECLARE @ID_USER numeric (18,0)
SET @ID_USER = (select Id_Usuario from PMS.PUBLICACIONES where Id_Publicacion= (select Id_Publicacion from COMPRAS where Id_Calificacion=(select Id_Calificacion from inserted)))
DECLARE @REPUTACION numeric (18,0)
SET @REPUTACION =((select Cantidad_Estrellas from inserted)+ (select Reputacion from PMS.USUARIOS where Id_Usuario=@ID_USER))/(select count(Id_Calificacion) from PMS.CALIFICACIONES where Id_Calificacion IN (select Id_Calificacion from COMPRAS where Id_Publicacion IN (select Id_Publicacion FROM PMS.PUBLICACIONES where Id_Usuario = @ID_USER)))
UPDATE USUARIOS
set Reputacion=@REPUTACION
where Id_Usuario=@ID_USER
END
GO

CREATE PROCEDURE [PMS].[ALTA_CALIFICACION]
		@Id_Compra numeric(18,0)
        ,@Cantidad_Estrellas numeric(18,0)
        ,@Descripcion nvarchar(255)
		,@ID_CALIFICACION numeric(18,0) output
AS
BEGIN

set @ID_CALIFICACION=((select max(Id_Calificacion) from PMS.CALIFICACIONES) +1)
INSERT INTO [PMS].[CALIFICACIONES]
           ([Id_Calificacion]
           ,[Cantidad_Estrellas]
           ,[Descripcion])
     VALUES
           (@ID_CALIFICACION
           ,@Cantidad_Estrellas
           ,@Descripcion)

UPDATE [PMS].[COMPRAS]
   SET [Id_Calificacion] = @Id_Calificacion
 WHERE Id_Compra=@Id_Compra


END
GO

CREATE PROCEDURE PMS.BORRAR_FUNCIONALIDADES_ROL
	@Id_Rol numeric(18,0)
AS
BEGIN
	DELETE FROM PMS.FUNCIONALIDES_ROLES WHERE Id_Rol = @Id_Rol
END
GO

CREATE PROCEDURE PMS.insertFuncionalidad
	@Id_Rol numeric(18,0), @Id_Funcionalidad numeric(18,0)
AS BEGIN
	INSERT INTO PMS.FUNCIONALIDES_ROLES (Id_Rol, Id_Funcionalidad) VALUES (@Id_Rol, @Id_Funcionalidad)
END 
GO

CREATE PROCEDURE PMS.SUBASTAS_TERMIANDAS
		@Fecha datetime
AS
BEGIN
DECLARE @ID_CLIENTE numeric (18,0)
DECLARE @ID_PUBLICACION numeric(18,0)
DECLARE @MONTO numeric(18,2)
DECLARE @Id_Compra numeric(18,0)

DECLARE db_cursor CURSOR FOR  
select p.Id_Publicacion,o.Monto,o.Id_Cliente 
	from PMS.PUBLICACIONES p 
	LEFT JOIN PMS.OFERTAS o ON p.Id_Publicacion=o.Id_Publicacion
	where p.Id_Tipo=2 AND p.FechaVencimiento<@Fecha AND p.Id_Estado = 1
	AND o.Monto IN (SELECT TOP 1 MAX(Monto) FROM PMS.OFERTAS WHERE Id_Publicacion = p.Id_Publicacion)
OPEN db_cursor   
FETCH NEXT FROM db_cursor INTO @ID_PUBLICACION,@MONTO,@ID_CLIENTE

WHILE @@FETCH_STATUS = 0
BEGIN
EXECUTE PMS.ALTA_COMPRAS 1,@Fecha,@ID_CLIENTE,@ID_PUBLICACION,@Id_Compra output
update PMS.PUBLICACIONES
set Id_Estado=4
where Id_Publicacion=@ID_PUBLICACION;
FETCH NEXT FROM db_cursor INTO @ID_PUBLICACION,@MONTO,@ID_CLIENTE
END
END
GO

CREATE TRIGGER PMS.ALTA_FACTURA_PUBLICACION
ON PMS.PUBLICACIONES
AFTER INSERT
AS
BEGIN
DECLARE @NUMERO numeric(18,0)
SET @NUMERO =(select max(Numero)from FACTURAS)+1
DECLARE @FECHA datetime,@ID numeric(18,0)
select @FECHA=Fecha,@ID=Id_Publicacion from inserted;
DECLARE @TOTAL numeric(18,0)
select @TOTAL=Precio from VISIBILIDADES WHERE Id_Visibilidad=(select Id_Visibilidad from PMS.PUBLICACIONES where Id_Publicacion = (select Id_Publicacion from inserted))
EXEC PMS.ALTA_FACTURA @NUMERO,@FECHA,@TOTAL,1,@TOTAL,1,@ID,'Comision por Publicacion'
END
GO

CREATE TRIGGER ALTA_FACTURA_VENTA
ON PMS.COMPRAS
AFTER INSERT
AS
BEGIN 
DECLARE @NUMERO numeric(18,0)
SET @NUMERO =(select max(Numero)from FACTURAS)+1
DECLARE @PORCENTAJE numeric(18,0)
DECLARE @ENVIO numeric(18,0)
select @PORCENTAJE= Porcentaje,@ENVIO=isnull(CostoEnvio,0) from VISIBILIDADES WHERE Id_Visibilidad=(select Id_Visibilidad from PUBLICACIONES where Id_Publicacion = (select Id_Publicacion from inserted))
DECLARE @FECHA datetime,@TOTAL numeric(18,0),@MONTO numeric(18,0),@CANTIDAD numeric(18,0),@ID numeric(18,0)
select @FECHA=Fecha,@TOTAL=Monto*@PORCENTAJE+@ENVIO,@MONTO=Monto,@CANTIDAD=Cantidad,@ID=Id_Publicacion from inserted;
SET @TOTAL = @TOTAL * @CANTIDAD;
SET @MONTO = @MONTO * @PORCENTAJE;
EXEC PMS.ALTA_FACTURA @NUMERO ,@FECHA,@TOTAL,1,@MONTO,@CANTIDAD,@ID,'Comision por venta'
END
GO


	--************************FUNCIONES/STORED PROCEDURES/TRIGGERS*****************************************
CREATE FUNCTION [PMS].[getUser] (@userName nvarchar(255), @password varchar(255))
returns integer
AS
BEGIN
DECLARE @resultExistence integer
DECLARE @resultLogin integer

	SET @resultExistence = (SELECT  USUARIOS.Id_Usuario FROM Pms.USUARIOS where User_Nombre like @userName)
	

	if @resultExistence >= 0 
	BEGIN
	SET @resultLogin = ( SELECT USUARIOS.Id_Usuario FROM Pms.USUARIOS where User_Password = HASHBYTES('SHA2_256',@password) AND User_Nombre like @userName);
	if @resultLogin IS NULL 
	SET @resultLogin = -1
	END
	else if @resultExistence IS NULL
	SET @resultLogin = -2;

	return @resultLogin

END
GO
	-- /GETUSER


	--AumentarIntentos
	CREATE PROCEDURE [PMS].[AumentarIntentosFallidos] @userName nvarchar(255)

AS
BEGIN

DECLARE @intentosActuales integer

SET @intentosActuales = (SELECT Intentos_Login FROM PMS.USUARIOS WHERE User_Nombre like @userName) 


UPDATE PMS.USUARIOS SET Intentos_Login = (@intentosActuales + 1) WHERE User_nombre like @userName
END 
GO

--/AumentarIntentos


--LimpiarIntentos
CREATE PROCEDURE PMS.LimpiarIntentos @userName varchar(255)

AS

BEGIN
UPDATE PMS.USUARIOS SET Intentos_login = 0 WHERE User_Nombre LIKE @userName

END
GO
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
GO

CREATE PROCEDURE PMS.ALTA_VISIBILIDAD
			@Descripcion nvarchar(255)
			,@porcentaje numeric(18,2)
			,@precio numeric(18,2)
                              
AS 
BEGIN 

DECLARE @id integer
     SET NOCOUNT ON 

SET @id = (SELECT top 1 Id_Visibilidad FROM PMS.VISIBILIDADES order by  Id_Visibilidad desc) 

INSERT INTO [PMS].[VISIBILIDADES]
           ([Id_Visibilidad]
		   ,[Descripcion]
           ,[Porcentaje]
           ,[Precio]
           ,[Habilitado])           
     VALUES
           (@id +1
		   ,@Descripcion
           ,@porcentaje
           ,@precio
		   ,1)
end
go

CREATE PROCEDURE PMS.MODIFICACION_VISIBILIDAD
			 @Id_Visibilidad numeric(18,0)
			,@Descripcion nvarchar(255)
			,@porcentaje numeric(18,2)
			,@precio numeric(18,2)
                              
AS 
BEGIN 
     SET NOCOUNT ON 

UPDATE [PMS].[VISIBILIDADES]
Set          [Descripcion] = @Descripcion
           ,[Porcentaje] = @porcentaje
           ,[Precio] = @precio
 where [Id_Visibilidad] = @Id_Visibilidad
    
end
go

CREATE PROCEDURE PMS.BAJA_VISIBILIDAD
			 @Id_Visibilidad numeric(18,0)
                              
AS 
BEGIN 
     SET NOCOUNT ON 

UPDATE [PMS].[VISIBILIDADES]
Set          [Habilitado] = 0
 where [Id_Visibilidad] = @Id_Visibilidad
    
end
go

COMMIT TRAN TRANSACCION_INICIAL;
GO
