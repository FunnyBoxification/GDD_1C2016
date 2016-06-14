using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoNegocio
{
    class Calificacion
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
                String sqlRequest = "select c.Monto,c.Cantidad,p.Descripcion,c.Fecha,p.Precio,r.Descripcion from PMS.COMPRAS c JOIN PMS.PUBLICACIONES p ON c.Id_Publicacion = p.Id_Publicacion join PMS.RUBROS r on p.Id_Rubro = r.Id_Rubro where c.Id_Cliente_Comprador = @id and c.Id_Calificacion is null";

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
    }
}
