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
