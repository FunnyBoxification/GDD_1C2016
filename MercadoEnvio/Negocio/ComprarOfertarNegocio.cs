using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Linq;
using System.Data;
using MercadoEN;

namespace MercadoNegocio
{
    public class ComprarOfertarNegocio
    {
        SqlServerDBConnection DBConn { get; set; }

        public ComprarOfertarNegocio(SqlServerDBConnection dbConnection)
        {
            DBConn = dbConnection;
        }

        public DataTable getRubros()
        {
            try
            {
                var dt = new DataTable();
                DBConn.openConnection();
                String sqlRequest;
                sqlRequest = "SELECT * FROM PMS.RUBROS";

                SqlCommand command = new SqlCommand(sqlRequest, DBConn.Connection);

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
                throw (new Exception("Error en la Busqueda de publicaciones: " + ex.Message));
            }
        }

        public void Comprar(String userid, String idPublicacion, int cantidad)
        {
            try
            {
                var proc = "PMS.ALTA_COMPRAS";

                DBConn.openConnection();
                using (SqlCommand cmd = new SqlCommand(proc, DBConn.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = UsuarioLogueado.Instance().fechaDeHoy;
                    cmd.Parameters.Add("@Cantidad", SqlDbType.Int).Value = cantidad;
                    cmd.Parameters.Add("@Id_Publicacion", SqlDbType.Int).Value = Int32.Parse(idPublicacion);
                    cmd.Parameters.Add("@Id_Cliente_Comprador", SqlDbType.Int).Value = Int32.Parse(userid);
                    var returnParameter = cmd.Parameters.Add("@id", SqlDbType.Int);
                    //returnParameter.Value = 0;
                    returnParameter.Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();
                }

                DBConn.closeConnection();
            }
            catch (Exception e)
            {
                DBConn.closeConnection();
                throw (new Exception("No se pudo crear la compra: " + e.Message));

            }
        }

        public void Ofertar(String userid, String idPublicacion, int monto)
        {
            try
            {
                var proc = "PMS.ALTA_OFERTAS";

                DBConn.openConnection();
                using (SqlCommand cmd = new SqlCommand(proc, DBConn.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = UsuarioLogueado.Instance().fechaDeHoy;
                    cmd.Parameters.Add("@Monto", SqlDbType.Int).Value = monto;
                    cmd.Parameters.Add("@Id_Publicacion", SqlDbType.Int).Value = Int32.Parse(idPublicacion);
                    cmd.Parameters.Add("@Id_Cliente", SqlDbType.Int).Value = Int32.Parse(userid);
                    var returnParameter = cmd.Parameters.Add("@id", SqlDbType.Int);
                    //returnParameter.Value = 0;
                    returnParameter.Direction = ParameterDirection.Output;
                   

                    cmd.ExecuteNonQuery();
                }

                DBConn.closeConnection();
            }
            catch (Exception e)
            {
                DBConn.closeConnection();
                throw (new Exception("No se pudo crear la oferta: " + e.Message));

            }
        }

        public DataTable getPublicaciones(String Descripcion, List<String> Rubros)
        {
            try
            {
                var dt = new DataTable();
                DBConn.openConnection();
                String sqlRequest;
                sqlRequest = "SELECT * FROM PMS.PUBLICACIONES WHERE Id_Estado = 1 AND Id_Usuario <> "+UsuarioLogueado.Instance().userId;
                if (Descripcion != null)
                {
                    sqlRequest += " AND DESCRIPCION LIKE '%" + Descripcion + "%'";
                }
                if (Rubros.Count > 0)
                {
                    sqlRequest += " AND Id_Rubro IN (0";
                    foreach(var rubro in Rubros) {
                        sqlRequest += "," + rubro;
                    }
                    sqlRequest += ")";
                }
                sqlRequest += " ORDER BY Id_Visibilidad ASC";

                SqlCommand command = new SqlCommand(sqlRequest, DBConn.Connection);

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
                throw (new Exception("Error en la Busqueda de publicaciones: " + ex.Message));
            }
        }

        

    }
}
