using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoNegocio
{
    public class Calificacion
    {
         SqlServerDBConnection DBConn { get; set; }

        public Calificacion(SqlServerDBConnection dbConnection)
        {
            DBConn = dbConnection;
        }
        public DataTable GetComprasSinCalificar(int id )
        {

            var dt = new DataTable();

            try
            {
                DBConn.openConnection();
                String sqlRequest = "select c.Id_Compra As Codigo, c.Monto,c.Cantidad,p.Descripcion,c.Fecha,p.Precio,r.Descripcion from PMS.COMPRAS c JOIN PMS.PUBLICACIONES p ON c.Id_Publicacion = p.Id_Publicacion join PMS.RUBROS r on p.Id_Rubro = r.Id_Rubro   where c.Id_Cliente_Comprador = @id and c.Id_Calificacion is null";

                SqlCommand command = new SqlCommand(sqlRequest, DBConn.Connection);
                command.Parameters.Add("@id", SqlDbType.Int).Value = id;

                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dt);
                    command.Dispose();
                    DBConn.closeConnection();
                    return dt;
                }
            }
            catch (Exception ex)
            {
                DBConn.closeConnection();
                throw (new Exception("Error en Compras" + ex.Message));
            }
        }

        public String calificarCompra(int compraId, String comentario, int estrellas)
        {
            try
            {
                DBConn.openConnection();
                String sqlRequest = "EXEC PMS.ALTA_CALIFICACION @Id_Compra = @compraId, @Cantidad_Estrellas = @estrellas, @Descripcion = @comentario, @ID_CALIFICACION = @calificacionId";

                SqlCommand command = new SqlCommand(sqlRequest, DBConn.Connection);
                command.Parameters.Add("@compraId", SqlDbType.Int).Value = compraId;
                command.Parameters.Add("@estrellas", SqlDbType.Int).Value = estrellas;
                command.Parameters.Add("@comentario", SqlDbType.Text).Value = comentario;

                SqlParameter output = new SqlParameter("@calificacionId", SqlDbType.Int);
                output.Direction = ParameterDirection.Output;
                command.Parameters.Add(output);

                command.ExecuteNonQuery();
                DBConn.closeConnection();
                return output.Value.ToString();
            }
            catch (Exception ex)
            {
                DBConn.closeConnection();
                throw (new Exception("Error al calificar la compra " + ex.Message));
            }
        }

        public DataTable getInfoCompras(int id)
        {

            var dt = new DataTable();

            try
            {
                DBConn.openConnection();
                String sqlRequest = "select count(co.Id_Calificacion)as compras, count(case ca.Cantidad_Estrellas when 1 then 1 else null end) as unaEstrella, count(case ca.Cantidad_Estrellas when 2 then 1 else null end) as dosEstrellas, count(case ca.Cantidad_Estrellas when 3 then 1 else null end) as tresEstrellas, count(case ca.Cantidad_Estrellas when 4 then 1 else null end) as cuatroEstrellas, count(case ca.Cantidad_Estrellas when 5 then 1 else null end) as cincoEstrellas FROM PMS.COMPRAS co left join PMS.CALIFICACIONES ca on co.Id_Calificacion=ca.Id_Calificacion where co.Id_Cliente_Comprador=@id";

                SqlCommand command = new SqlCommand(sqlRequest, DBConn.Connection);
                command.Parameters.Add("@id", SqlDbType.Int).Value = id;

                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dt);
                    command.Dispose();
                    DBConn.closeConnection();
                    return dt;
                }
            }
            catch (Exception ex)
            {
                DBConn.closeConnection();
                throw (new Exception("Error en Compras" + ex.Message));
            }
        }

        public int insertarCalificacion(int Id_Compra, int Cantidad_Estrellas, String Descripcion)
        {
            
            var dt = new DataTable();
            int Id_Calificacion;
            try
            {
                DBConn.openConnection();
                
                using (SqlCommand cmd = new SqlCommand("PMS.ALTA_CALIFICACION", DBConn.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("Id_Compra", Id_Compra);
                    cmd.Parameters.AddWithValue("Cantidad_Estrellas", Cantidad_Estrellas);
                    cmd.Parameters.AddWithValue("Descripcion", Descripcion);
                    SqlParameter Id = new SqlParameter("ID_CALIFICACION", SqlDbType.Int);
                    Id.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(Id);
                    cmd.ExecuteNonQuery();
                    Id_Calificacion = (int)Id.Value;
                    cmd.Dispose();
                }

                DBConn.closeConnection();
                return Id_Calificacion;

            }
            catch (Exception ex)
            {
                DBConn.closeConnection();
                throw (new Exception("Error en ObetenerRoles" + ex.Message));
            }
        }


        public int getCantidadDeCompras(int userId)
        {
            try
            {
                DBConn.openConnection();
                String sqlRequest = "SELECT COUNT(*) FROM PMS.Compras where Id_Cliente_Comprador =  @idCliente;";

                SqlCommand command = new SqlCommand(sqlRequest, DBConn.Connection);
                command.Parameters.Add("@idCliente", SqlDbType.Int).Value = userId;

               

                int result = (int)command.ExecuteScalar();
                DBConn.closeConnection();
                return result;

            }
            catch (Exception ex)
            {
                DBConn.closeConnection();               
                throw new Exception("Error al obtener cantidad de compras : " + ex.Message);

            }
        }



        public int getCantidadDeSubastasConXEstrellas(int clienteId, int cant)
        {
            try
            {
                DBConn.openConnection();
                String sqlRequest = "SELECT COUNT(CA.Id_Calificacion) " +
             " FROM PMS.CALIFICACIONES CA JOIN PMS.COMPRAS  CO on CO.Id_Calificacion = CA.Id_Calificacion" +
                " and CO.Id_Cliente_Comprador = @clienteId AND ca.Cantidad_Estrellas = @cantEstrellas " +
                "		JOIN PMS.PUBLICACIONES PU ON PU.Id_Publicacion  = CO.Id_Publicacion" +
          " join PMS.TIPO_PUBLICACION TP ON TP.Id_Tipo = PU.Id_Tipo and TP.Descripcion like 'Subasta'";

                SqlCommand command = new SqlCommand(sqlRequest, DBConn.Connection);
                command.Parameters.Add("@clienteId", SqlDbType.Int).Value = clienteId;
                command.Parameters.Add("@cantEstrellas", SqlDbType.Int).Value = cant;



                int result = (int)command.ExecuteScalar();
                DBConn.closeConnection();
                return result;

            }
            catch (Exception ex)
            {
                DBConn.closeConnection();
                throw new Exception("Error al obtener cantidad de compras : " + ex.Message);

            }
        }


        public int getCantidadDeSubastasCalificadas(int clienteId)
        {
            try
            {
                DBConn.openConnection();
                String sqlRequest = "select COUNT(c.Id_Compra) from " +
                " PMS.COMPRAS c JOIN PMS.PUBLICACIONES p ON c.Id_Publicacion = p.Id_Publicacion join PMS.RUBROS r on p.Id_Rubro = r.Id_Rubro" +
            " JOIN PMS.TIPO_PUBLICACION TP ON TP.Id_Tipo = P.Id_Tipo AND TP.Descripcion LIKE 'Subasta'" +
              "   where c.Id_Cliente_Comprador = @clienteId and c.Id_Calificacion is not null";

                SqlCommand command = new SqlCommand(sqlRequest, DBConn.Connection);
                command.Parameters.Add("@clienteId", SqlDbType.Int).Value = clienteId;




                int result = (int)command.ExecuteScalar();
                DBConn.closeConnection();
                return result;

            }
            catch (Exception ex)
            {
                DBConn.closeConnection();
                throw new Exception("Error al obtener cantidad de subastas : " + ex.Message);

            }
        }

        public int getCantidadDeSubastasSinCalificar(int clienteId)
        {
            try
            {
                DBConn.openConnection();
                String sqlRequest = "select COUNT(c.Id_Compra) from " +
                " PMS.COMPRAS c JOIN PMS.PUBLICACIONES p ON c.Id_Publicacion = p.Id_Publicacion join PMS.RUBROS r on p.Id_Rubro = r.Id_Rubro" +
            " JOIN PMS.TIPO_PUBLICACION TP ON TP.Id_Tipo = P.Id_Tipo AND TP.Descripcion LIKE 'Subasta'" +
              "   where c.Id_Cliente_Comprador = @clienteId and c.Id_Calificacion is null";

                SqlCommand command = new SqlCommand(sqlRequest, DBConn.Connection);
                command.Parameters.Add("@clienteId", SqlDbType.Int).Value = clienteId;




                int result = (int)command.ExecuteScalar();
                DBConn.closeConnection();
                return result;

            }
            catch (Exception ex)
            {
                DBConn.closeConnection();
                throw new Exception("Error al obtener cantidad de subastas : " + ex.Message);

            }
        }


        public int getCantidadDeComprasSinCalificar(int clienteId)
        {
            try
            {
                DBConn.openConnection();
                String sqlRequest =  "select COUNT(c.Id_Compra) from " + 
                " PMS.COMPRAS c JOIN PMS.PUBLICACIONES p ON c.Id_Publicacion = p.Id_Publicacion join PMS.RUBROS r on p.Id_Rubro = r.Id_Rubro" +
            " JOIN PMS.TIPO_PUBLICACION TP ON TP.Id_Tipo = P.Id_Tipo AND TP.Descripcion LIKE 'Compra Inmediata'" + 
              "   where c.Id_Cliente_Comprador = @clienteId and c.Id_Calificacion is null";

                SqlCommand command = new SqlCommand(sqlRequest, DBConn.Connection);
                command.Parameters.Add("@clienteId", SqlDbType.Int).Value = clienteId;
                



                int result = (int)command.ExecuteScalar();
                DBConn.closeConnection();
                return result;

            }
            catch (Exception ex)
            {
                DBConn.closeConnection();
                throw new Exception("Error al obtener cantidad de compras : " + ex.Message);

            }
        }


        public int getCantidadDeComprasConXEstrellas(int clienteId, int cant)
        {
            try
            {
                DBConn.openConnection();
                String sqlRequest = "SELECT COUNT(CA.Id_Calificacion) " + 
             " FROM PMS.CALIFICACIONES CA JOIN PMS.COMPRAS  CO on CO.Id_Calificacion = CA.Id_Calificacion"+
		        " and CO.Id_Cliente_Comprador = @clienteId AND ca.Cantidad_Estrellas = @cantEstrellas "+
                "		JOIN PMS.PUBLICACIONES PU ON PU.Id_Publicacion  = CO.Id_Publicacion" + 
		  " join PMS.TIPO_PUBLICACION TP ON TP.Id_Tipo = PU.Id_Tipo and TP.Descripcion like 'Compra Inmediata'";

                SqlCommand command = new SqlCommand(sqlRequest, DBConn.Connection);
                command.Parameters.Add("@clienteId", SqlDbType.Int).Value = clienteId;
                command.Parameters.Add("@cantEstrellas", SqlDbType.Int).Value = cant;



                int result = (int)command.ExecuteScalar();
                DBConn.closeConnection();
                return result;

            }
            catch (Exception ex)
            {
                DBConn.closeConnection();
                throw new Exception("Error al obtener cantidad de compras : " + ex.Message);

            }
        }


        public DataTable getUltimasCincoCalificaciones(int clienteId)
        {
            var dt = new DataTable();

            try
            {
                DBConn.openConnection();
                String sqlRequest = "SELECT TOP 5 CA.Cantidad_Estrellas As Estrellas, CA.Descripcion" +
                 " FROM PMS.COMPRAS CO JOIN PMS.CALIFICACIONES CA on CO.Id_Calificacion = CA.Id_Calificacion" +
                " JOIN PMS.CLIENTES CL ON CL.Id_Cliente = @clienteId AND CO.Id_Cliente_Comprador = @clienteId";

                SqlCommand command = new SqlCommand(sqlRequest, DBConn.Connection);
                command.Parameters.Add("@clienteId", SqlDbType.Int).Value = clienteId;

                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dt);
                    command.Dispose();
                    DBConn.closeConnection();
                    return dt;
                }
            }
            catch (Exception ex)
            {
                DBConn.closeConnection();
                throw (new Exception("Error en Calificaciones" + ex.Message));
            }
        }


        public int getSumaDeEstrellasObtenidas(int userId)
        {
            try
            {
                DBConn.openConnection();
                String sqlRequest = "select SUM(Ca.Cantidad_Estrellas) from pms.USUARIOS U join pms.PUBLICACIONES P on U.Id_Usuario =  P.Id_Usuario "+
                    " AND U.Id_Usuario = @userId "+
                    " JOIN pms.COMPRAS CO  on CO.Id_Publicacion = P.Id_Publicacion JOIN pms.CALIFICACIONES CA on CA.Id_Calificacion = CO.Id_Calificacion";

                SqlCommand command = new SqlCommand(sqlRequest, DBConn.Connection);
                command.Parameters.Add("@userId", SqlDbType.Int).Value = userId;             



                int result = (int)command.ExecuteScalar();
                DBConn.closeConnection();
                return result;

            }
            catch (Exception ex)
            {
                DBConn.closeConnection();
                throw new Exception("Error suma de estrellas : " + ex.Message);

            }
        }


        public int getCantidadDeCalificacionesObtenidas(int userId)
        {
            try
            {
                DBConn.openConnection();
                String sqlRequest = "select COUNT(Ca.Id_Calificacion) from pms.USUARIOS U join pms.PUBLICACIONES P on U.Id_Usuario =  P.Id_Usuario AND U.Id_Usuario = @userId"+ 
            " JOIN pms.COMPRAS CO on CO.Id_Publicacion = P.Id_Publicacion JOIN pms.CALIFICACIONES CA on CA.Id_Calificacion = CO.Id_Calificacion";

                SqlCommand command = new SqlCommand(sqlRequest, DBConn.Connection);
                command.Parameters.Add("@userId", SqlDbType.Int).Value = userId;



                int result = (int)command.ExecuteScalar();
                DBConn.closeConnection();
                return result;

            }
            catch (Exception ex)
            {
                DBConn.closeConnection();
                throw new Exception("Error suma de estrellas : " + ex.Message);

            }

        }
    
    
    }
}
