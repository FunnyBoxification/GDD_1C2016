using MercadoNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoNegocio
{
    public class Principal
    {
        SqlServerDBConnection DBConn { get; set; }

        public Principal(SqlServerDBConnection dbConnection)
        {
            DBConn = dbConnection;
        }
        public List<String> getFuncionalidades(String nombre)
        {
            var listaFuncionalidades = new List<String>();

            var dt = new DataTable();

            try
            {
                DBConn.openConnection();
                String sqlRequest = "SELECT Nombre FROM PMS.FUNCIONALIDADES WHERE Id_Funcionalidad IN ";
                sqlRequest += "(SELECT Id_Funcionalidad FROM PMS.FUNCIONALIDES_ROLES WHERE Nombre=@Nombre )";

                SqlCommand command = new SqlCommand(sqlRequest, DBConn.Connection);
                command.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = nombre;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var funcionalidad = reader["Nombre"].ToString();
                        listaFuncionalidades.Add(funcionalidad);
                    }
                }

                command.Dispose();
                DBConn.closeConnection();

                return listaFuncionalidades;

            }
            catch (Exception ex)
            {
                DBConn.closeConnection();
                throw (new Exception("Error en ObetenerRoles" + ex.Message));
            }
        }
    }
}
