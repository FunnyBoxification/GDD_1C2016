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

	CREATE TABLE FORMASDEPAGO
	(
		Id_FormaPago			numeric(11,0),
		Descripcion				nvarchar(255),
		PRIMARY KEY(Id_FormaPago)
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
		Id_Factura				numeric(18,0),
		PRIMARY KEY(Id_ItemFactura),
		FOREIGN KEY(Id_Factura) REFERENCES FACTURAS(Id_Factura)
	)

	INSERT INTO EMPRESAS 
	SELECT  DISTINCT	
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

	INSERT INTO CLIENTES
	SELECT  DISTINCT	
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

	INSERT INTO VISIBILIDADES
	SELECT	DISTINCT
			Publicacion_Visibilidad_Cod,
			Publicacion_Visibilidad_Desc,
			Publicacion_Visibilidad_Precio,		
			Publicacion_Visibilidad_Porcentaje
	FROM gd_esquema.Maestra

	INSERT INTO FORMASDEPAGO
	SELECT DISTINCT
		
	FROM gd_esquema.Maestra

	-- Create a temporary table, note the IDENTITY
	-- column that will be used to loop through
	-- the rows of this table
	CREATE TABLE #MaestraTemporal (--meter todas las fucking columnaas
		RowID							int IDENTITY(1, 1), 
		--empresa
		--Empresa_Id_Empresa				numeric(11,0),
		Empresa_RazonSocial				nvarchar(255),
		Empresa_Cuit					nvarchar(50),
		Empresa_FechaCreacion			datetime,
		Empresa_Mail					nvarchar(50),
		Empresa_DomCalle				nvarchar(100),
		Empresa_NroCalle				numeric(18,0),
		Empresa_Piso					numeric(18,0),
		Empresa_Depto					nvarchar(50),
		Empresa_CodigoPostal			nvarchar(50),
		--clientes
		--Cliente_Id_Cliente				numeric(11,0),
		Cliente_Apellido				nvarchar(255),
		Cliente_Nombre					nvarchar(255),
		Cliente_FechaNacimiento			datetime,
		Cliente_Mail					nvarchar(255),
		Cliente_DomCalle				nvarchar(255),
		Cliente_NroCalle				numeric(18,0),
		Cliente_Piso					numeric(18,0),
		Cliente_Depto					nvarchar(50),
		Cliente_Cod_Postal				nvarchar(50),
		--visibilidades
		--Visibilidades_Id_Visibilidad	numeric(11,0),
		Visibilidades_Descripcion		varchar(255),
		Visibilidades_Precio			numeric(18,2),
		Visibilidades_Porcentaje		numeric(18,2),
		--Publicaciones
		--Publicaciones_Id_Publicacion	numeric(18,0),
		Publicaciones_Descripcion		nvarchar(255),
		Publicaciones_Stock				numeric(18,0),
		Publicaciones_Fecha				datetime,
		Publicaciones_FechaVencimiento	datetime,
		Publicaciones_Precio			numeric(18,2),
		Publicaciones_Tipo				nvarchar(255),
		Publicaciones_Id_Empresa		numeric(11,0),
		Publicaciones_Id_Cliente		numeric(11,0),
		Publicaciones_Id_Visibilidad	numeric(11,0),
		--Ofertas
		--Ofertas_Id_Oferta				numeric(18,0),
		Ofertas_Fecha					datetime,
		Ofertas_Monto					numeric(18,2),
		Ofertas_Id_Publicacion			numeric(18,0),
		--Compras
		--Compras_Id_Compras				numeric(11,0),
		Compras_Cantidad				numeric(18,0),
		Compras_Fecha					datetime,
		Compras_Id_oferta				numeric(18,0),
		Compras_Id_publicacion			numeric(18,0),
		--Fromas de pago
		Formas_Descripcion				nvarchar(255),
		--Factura
		--Factura_Id_Factura				numeric(18,0),
		Factura_Numero					numeric(18,0),
		Factura_Fecha					datetime,
		Factura_Total					numeric(18,2),
		--Factura_Id_FormaPago			numeric(11,0),
		--ItemFacturas
		ItemFacturas_Id_ItemFactura		numeric(18,0),
		ItemFacturas_Monto				numeric(18,2),
		ItemFacturas_Cantidad			numeric(18,0),
		--ItemFacturas_Id_Factura			numeric(18,0),

	)
	DECLARE @NumberRecords int, @RowCount int
	DECLARE 
	--empresa
	--Empresa_Id_Empresa				numeric(11,0),
	@Empresa_RazonSocial				nvarchar(255),
	@Empresa_Cuit					nvarchar(50),
	@Empresa_FechaCreacion			datetime,
	@Empresa_Mail					nvarchar(50),
	@Empresa_DomCalle				nvarchar(100),
	@Empresa_NroCalle				numeric(18,0),
	@Empresa_Piso					numeric(18,0),
	@Empresa_Depto					nvarchar(50),
	@Empresa_CodigoPostal			nvarchar(50),
	--clientes
	--Cliente_Id_Cliente				numeric(11,0),
	@Cliente_Apellido				nvarchar(255),
	@Cliente_Nombre					nvarchar(255),
	@Cliente_FechaNacimiento			datetime,
	@Cliente_Mail					nvarchar(255),
	@Cliente_DomCalle				nvarchar(255),
	@Cliente_NroCalle				numeric(18,0),
	@Cliente_Piso					numeric(18,0),
	@Cliente_Depto					nvarchar(50),
	@Cliente_Cod_Postal				nvarchar(50),
	--visibilidades
	--Visibilidades_Id_Visibilidad	numeric(11,0),
	@Visibilidades_Descripcion		varchar(255),
	@Visibilidades_Precio			numeric(18,2),
	@Visibilidades_Porcentaje		numeric(18,2),
	--Publicaciones
	--Publicaciones_Id_Publicacion	numeric(18,0),
	@Publicaciones_Descripcion		nvarchar(255),
	@Publicaciones_Stock				numeric(18,0),
	@Publicaciones_Fecha				datetime,
	@Publicaciones_FechaVencimiento	datetime,
	@Publicaciones_Precio			numeric(18,2),
	@Publicaciones_Tipo				nvarchar(255),
	@Publicaciones_Id_Empresa		numeric(11,0),
	@Publicaciones_Id_Cliente		numeric(11,0),
	@Publicaciones_Id_Visibilidad	numeric(11,0),
	--Ofertas
	--Ofertas_Id_Oferta				numeric(18,0),
	@Ofertas_Fecha					datetime,
	@Ofertas_Monto					numeric(18,2),
	@Ofertas_Id_Publicacion			numeric(18,0),
	--Compras
	--Compras_Id_Compras				numeric(11,0),
	@Compras_Cantidad				numeric(18,0),
	@Compras_Fecha					datetime,
	@Compras_Id_oferta				numeric(18,0),
	@Compras_Id_publicacion			numeric(18,0),
	--Fromas de pago
	@Formas_Descripcion				nvarchar(255),
	--Factura
	--Factura_Id_Factura				numeric(18,0),
	@Factura_Numero					numeric(18,0),
	@Factura_Fecha					datetime,
	@Factura_Total					numeric(18,2),
	--Factura_Id_FormaPago			numeric(11,0),
	--ItemFacturas
	@ItemFacturas_Id_ItemFactura		numeric(18,0),
	@ItemFacturas_Monto				numeric(18,2),
	@ItemFacturas_Cantidad			numeric(18,0)
	--ItemFacturas_Id_Factura			numeric(18,0),
	
	-- Insert the resultset we want to loop through
	-- into the temporary table
	SELECT * INTO #MaestraTemporal
	FROM gd_esquema.Maestra
	
	
	-- Get the number of records in the temporary table
	SET @NumberRecords = @@ROWCOUNT
	SET @RowCount = 1
	
	-- loop through all records in the temporary table
	-- using the WHILE loop construct
	WHILE @RowCount <= @NumberRecords
	BEGIN
	 SELECT 
	    @Publicaciones_Cod				= mt.Publicacion_Cod,	
		@Publicaciones_Descripcion		= mt.Publicaciones_Descripcion,		
		@Publicaciones_Stock			= mt.Publicaciones_Stock,				
		@Publicaciones_Fecha			= mt.Publicaciones_Fecha,				
		@Publicaciones_FechaVencimiento	= mt.Publicaciones_FechaVencimiento,	
		@Publicaciones_Precio			= mt.Publicaciones_Precio,			
		@Publicaciones_Tipo				= mt.Publicaciones_Tipo,				
		@Publicaciones_Id_Empresa		= mt.Publ_Empresa_Cuit,		
	    @Publicaciones_Id_Cliente		= mt.Publ_Cli_Dni		
		--@Publicaciones_Id_Visibilidad	=  gd_esquema.Maestra.Publicaciones_Id_Visibilidad	
	 FROM #MaestraTemporal mt
	 WHERE RowID = @RowCount

	 -- Aca va el insert con los values de arriba.


	
		

	
	 EXEC MyStoredProc @CustomerID, @FirstName, @LastName
	
	 SET @RowCount = @RowCount + 1
	END
	
	-- drop the temporary table
	DROP TABLE #ActiveCustomer


	
	-- select empresas
	SELECT  DISTINCT	
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
	SELECT DISTINCT 		
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
	SELECT	DISTINCT
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
	
	--SLECT item facturas		
	SELECT 
		Item_Factura_Monto,
		Item_Facturas_Cantidad
	FROM gd_esquema.Maestra
	--select Item Facturas

	--select formas de pago

	--select formas de pago



	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT <@Param1, sysname, @p1>, <@Param2, sysname, @p2>
END
GO
