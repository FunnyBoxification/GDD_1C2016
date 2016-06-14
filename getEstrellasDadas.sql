CREATE FUNCTION [PMS].[getEstrellasDadas] (@idUser numeric(18,0))


returns integer

AS

BEGIN
DECLARE @cantidad integer

		set @cantidad =	(select SUM(Cantidad_Estrellas) FROM PMS.COMPRAS CO join pms.CALIFICACIONES CA on 
					CA.Id_Calificacion = CO.Id_Calificacion AND CO.Id_Cliente_Comprador = @idUser)
return @cantidad


END

