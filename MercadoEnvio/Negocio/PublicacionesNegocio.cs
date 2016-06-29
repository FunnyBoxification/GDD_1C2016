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
    public class PublicacionesNegocio
    {
        SqlServerDBConnection DBConn { get; set; }

        public PublicacionesNegocio(SqlServerDBConnection dbConnection)
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
                sqlRequest = "SELECT Id_Rubro, Descripcion FROM PMS.RUBROS";

                SqlCommand command = new SqlCommand(sqlRequest, DBConn.Connection);


                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dt);
                }

                command.Dispose();
                DBConn.closeConnection();
                return dt;

            }
            catch (Exception ex)
            {
                DBConn.closeConnection();
                throw (new Exception("Error en GetRubros" + ex.Message));
            }
        }

        public DataTable getTipos()
        {
            var dt = new DataTable();

            try
            {

                DBConn.openConnection();
                String sqlRequest;
                sqlRequest = "SELECT Id_Tipo, Descripcion FROM PMS.TIPO_PUBLICACION";

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
                throw (new Exception("Error en searchFacturasAlVendedor: " + ex.Message));
            }
        }

        public DataTable obtenerVisibilidades()
        {
            try
            {
                var dt = new DataTable();
                DBConn.openConnection();
                String sqlRequest;
                sqlRequest = "SELECT Id_Visibilidad, Descripcion FROM PMS.VISIBILIDADES ";

                SqlCommand command = new SqlCommand(sqlRequest, DBConn.Connection);


                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dt);
                }

                command.Dispose();
                DBConn.closeConnection();
                return dt;

            }
            catch (Exception ex)
            {
                DBConn.closeConnection();
                throw (new Exception("Error en ObtenerVisibilidades" + ex.Message));
            }

        }


        public DataTable BuscarPublicacionSeleccionada(String Idpubli)
        {
            try
            {
                var dt = new DataTable();
                DBConn.openConnection();
                String sqlRequest;
                sqlRequest = "SELECT * FROM PMS.PUBLICACIONES WHERE Id_Publicacion = " + Idpubli;
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
                throw (new Exception("Error en la Busqueda de empresas" + ex.Message));
            }
        }

       

        public DataTable BuscarPublicaciones(String Idpubli, String tipo, String descripcion,String userid)
        {
            try
            {
                var dt = new DataTable();
                DBConn.openConnection();
                String sqlRequest;
                sqlRequest = "SELECT p.Id_Publicacion, p.Id_Tipo, p.Descripcion, p.Stock  , p.Fecha  ,p.FechaVencimiento  ,   p.Precio  , ";
                sqlRequest += " (SELECT u.User_Nombre FROM PMS.USUARIOS u  WHERE u.Id_Usuario = p.Id_Usuario) as Vendedor, ";
                sqlRequest += " (SELECT v.Descripcion FROM PMS.VISIBILIDADES v WHERE v.Id_Visibilidad = p.Id_Visibilidad) as Visibilidad, ";
                sqlRequest += " (SELECT t.Descripcion FROM PMS.TIPO_PUBLICACION t WHERE t.Id_Tipo = p.Id_Tipo) as Tipo , ";
                sqlRequest += " (SELECT r.Descripcion FROM PMS.RUBROS r WHERE r.Id_Rubro = p.Id_Rubro) as Rubro, ";
                sqlRequest += " (SELECT e.Descripcion FROM PMS.PUBLICACION_ESTADOS e WHERE e.Id_Estado = p.Id_Estado) As Estado ";   
                sqlRequest += "FROM PMS.PUBLICACIONES p  ";
                sqlRequest += "WHERE 1=1 ";
                if (userid != null)
                {
                    sqlRequest += "AND p.Id_Usuario <> " + userid+" ";
                }
                if (tipo != null)
                {
                    sqlRequest += "AND p.Id_Tipo = (SELECT t.Id_Tipo FROM PMS.TIPO_PUBLICACION t WHERE t.Descripcion = '" + tipo+"' ) ";
                }
                if (Idpubli != null && Idpubli != "") sqlRequest += " and p.Id_Publicacion = " + Idpubli + " ";
                
                if (descripcion != null && descripcion != "") sqlRequest += " and p.Descripcion = '"+descripcion+"'";
                SqlCommand command = new SqlCommand(sqlRequest, DBConn.Connection);
                
                /*if (tipo != null)  command.Parameters.Add("@tipo", SqlDbType.NVarChar).Value = tipo;
                if (Idpubli != null && Idpubli != "") command.Parameters.Add("@idpubli", SqlDbType.Int).Value = Convert.ToInt32(Idpubli);
                if (descripcion != null && descripcion != "") command.Parameters.Add(" @descripcion", SqlDbType.NVarChar).Value = descripcion;*/
               
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
                throw (new Exception("Error en la Busqueda de empresas" + ex.Message));
            }
        }

       

        public void ProcedurePublicacion(int tipo, 
            int modo, 
            int IdCod,
            String Descripcion,
            String Stock,
            String Fecha,
            String FechaVencimiento,
            String Precio,
            int Id_Visibilidad,
            int Id_Tipo,
            int Id_Rubro,
            int Id_Estado)
        {
            try
            {
                var proc = "PMS.";
                if(modo == 0)
                {
                    proc += "ALTA_PUBLICACION";
                }else
                {
                    proc += "MODIFICACION_PUBLICACION";
                }
                
                DBConn.openConnection();
                using (SqlCommand cmd = new SqlCommand(proc, DBConn.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Id_Usuario", SqlDbType.Int).Value = IdCod;
                    cmd.Parameters.Add("@Descripcion", SqlDbType.NVarChar).Value = Descripcion;
                    cmd.Parameters.Add("@Stock", SqlDbType.Int).Value = Stock;
                    cmd.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = Fecha;
                    cmd.Parameters.Add("@FechaVencimiento", SqlDbType.DateTime).Value = FechaVencimiento;
                    cmd.Parameters.Add("@Precio", SqlDbType.Int).Value = Precio;
                    cmd.Parameters.Add("@Id_Visibilidad", SqlDbType.Int).Value = Id_Visibilidad;
                    cmd.Parameters.Add("@Id_Tipo", SqlDbType.Int).Value = Id_Tipo;
                    cmd.Parameters.Add("@Id_Rubro", SqlDbType.Int).Value = Id_Rubro;
                    cmd.Parameters.Add("@Id_Estado", SqlDbType.Int).Value = Id_Estado;

                    cmd.ExecuteNonQuery();
                }
                DBConn.closeConnection();
            }
            catch (Exception e)
            {
                DBConn.closeConnection();
                throw (new Exception("No se pudo crear o modificar la publicacion: " + e.Message));

            }
        }
    }
}
