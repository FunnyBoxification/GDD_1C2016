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
CREATE PROCEDURE <Procedure_Name, sysname, ProcedureName> 
	-- Add the parameters for the stored procedure here
	<@Param1, sysname, @p1> <Datatype_For_Param1, , int> = <Default_Value_For_Param1, , 0>, 
	<@Param2, sysname, @p2> <Datatype_For_Param2, , int> = <Default_Value_For_Param2, , 0>
AS
BEGIN

	CREATE TABLE EMPRESAS
	(
		Id_Empresa				numeric(11,0),
		RazonSocial				nvarchar(255),
		Cuit					nvarchar(50),
		FechaCreacion			datetime,
		Mail					nvarchar(50),
		DomCalle				nvarchar(100),
		NroCalle				numeric(18,0),
		Piso					numeric(18,0),
		Depto					nvarchar(50),
		CodigoPostal			nvarchar(50),
		PRIMARY KEY(Id_Empresa)
	)

	CREATE TABLE CLIENTES
	(
		Id_Cliente				numeric(11,0),
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
	)

	CREATE TABLE VISIBILIDADES
	(
		Id_Visibilidad			numeric(11,0),
		Descripcion				varchar(255),
		Precio					numeric(18,2),
		Porcentaje				numeric(18,2),
		PRIMARY KEY(Id_Visibilidad)
	)

	CREATE TABLE PUBLICACIONES
	(
		Id_Publicacion			numeric(18,0),
		Descripcion				nvarchar(255),
		Stock					numeric(18,0),
		Fecha					datetime,
		FechaVencimiento		datetime,
		Precio					numeric(18,2),
		Tipo					nvarchar(255),
		Id_Empresa				numeric(11,0),
		Id_Cliente				numeric(11,0),
		Id_Visibilidad			numeric(11,0),
		PRIMARY KEY(Id_Publicacion),
		FOREIGN KEY(Id_Empresa) REFERENCES EMPRESAS(Id_Empresa),
		FOREIGN KEY(Id_Cliente) REFERENCES CLIENTES(Id_Cliente),
		FOREIGN KEY(Id_Visibilidad) REFERENCES VISIBILIDADES(Id_visibilidad)
	)

	CREATE TABLE OFERTAS
	(
		Id_Oferta				numeric(18,0),
		Fecha					datetime,
		Monto					numeric(18,2),
		Id_Publicacion			numeric(18,0),
		PRIMARY KEY(Id_Oferta),
		FOREIGN KEY(Id_publicacion) REFERENCES PUBLICACIONES(Id_Publicacion)
	)
	

	CREATE TABLE COMPRAS
	(
		Id_Compras				numeric(11,0),
		Cantidad				numeric(18,0),
		Fecha					datetime,
		Id_oferta				numeric(18,0),
		Id_publicacion			numeric(18,0),
		PRIMARY KEY(Id_Compras),
		FOREIGN KEY(Id_Oferta) REFERENCES OFERTAS(Id_oferta),
		FOREIGN KEY(Id_Publicacion) REFERENCES PUBLICACIONES(Id_Publicacion),
	)

	

	CREATE TABLE FACTURAS
	(
		Id_Factura				numeric(18,0),
		Numero					numeric(18,0),
		Fecha					datetime,
		Total					numeric(18,2),
		Id_FormaPago			numeric(11,0),
		PRIMARY KEY(Id_Factura),
		FOREIGN KEY(Id_FormaPago) REFERENCES FORMASDEPAGO(Id_FormaPago)
	)

	CREATE TABLE ITEMFACTURA
	(
		Id_ItemFactura			numeric(18,0),
		Monto					numeric(18,2),
		Cantidad				numeric(18,0),
		PRIMARY KEY(Id_ItemFactura)
	)

	CREATE TABLE FORMASDEPAGO
	(
		Id_FormaPago			numeric(11,0),
		Descripcion				nvarchar(255),
		PRIMARY KEY(Id_FormaPago)
	)
	-- select empresas
	SELECT  	
		   Publ_Empresa_Razon_Social,	
		   Publ_Empresa_Cuit,
		   Publ_Empresa_Fecha_Creacion,	
		   Publ_Empresa_Mail,
		   Publ_Empresa_Dom_Calle,
		   Publ_Empresa_Nro_Calle,
		   Publ_Empresa_Piso,
		   Publ_Empresa_Depto,	
		   Publ_Empresa_Cod_Postal
	FROM gd_esquema.Maestra
	--Select empresas


	--select Clientes
	SELECT 		
		   Publ_Cli_Apeliido,	
		   Publ_Cli_Nombre,
		   Publ_Cli_Fecha_Nac,
		   Publ_Cli_Mail,			
		   Publ_Cli_Dom_Calle,		
		   Publ_Cli_Nro_Calle,		
		   Publ_Cli_Piso,			
		   Publ_Cli_Depto,			
		   Publ_Cli_Cod_Postal
	FROM gd_esquema.Maestra
	--select Clientes

	--seect Visibilidad
	SELECT	
			Publicacion_Visibilidad_Cod,
			Publicacion_Visibilidad_Desc,
			Publicacion_Visibilidad_Precio,		
			Publicacion_Visibilidad_Porcentaje
	FROM gd_esquema.Maestra
	--seect Visibilidad
	
	--seect Publicacion
	SELECT
		Publicacion_Cod,	
		Publicacion_Descripcion,
		Publicacion_Stock,	
		Publicacion_Fecha,			
		Publicacion_Fecha_Venc,
		Publicacion_Precio,			
		Publicacion_Tipo
	FROM gd_esquema.Maestra
	--select Publicacion	

	--select ofertas
	SELECT
		Ofertas_Fecha,
		Ofertas_Monto
	FROM gd_esquema.Maestra
	--select ofertas			
	SELECT 
		Item_Factura_Monto,
		Item_Facturas_Cantidad
	FROM gd_esquema.Maestra
	--select Item Facturas


	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT <@Param1, sysname, @p1>, <@Param2, sysname, @p2>
END
GO
