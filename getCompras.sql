SELECT CO.Cantidad, CO.Fecha, CO.Monto, P.Descripcion AS Producto, (SELECT U.User_Nombre FROM PMS.USUARIOS U where U.Id_Usuario = P.Id_Usuario)  Vendedor,
(SELECT CASE WHEN CO.Id_Calificacion IS NULL 
	THEN 'No' ELSE 'Si' END 
) AS Calificada
FROM pms.CLIENTES CL JOIN PMS.COMPRAS CO ON
			CO.Id_Cliente_Comprador = CL.Id_Cliente AND
			Cl.Id_Cliente = 97 
			JOIN PMS.PUBLICACIONES P ON
			P.Id_Publicacion  = CO.Id_Publicacion



-- Trae la descripcion de la publicacion dada y el nombre del vendedor
SELECT P.Descripcion, (SELECT U.User_Nombre FROM PMS.USUARIOS U where U.Id_Usuario = P.Id_Usuario) AS Vendedor FROM PMS.PUBLICACIONES P where Id_Publicacion = 27492