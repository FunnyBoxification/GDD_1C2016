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
    public class RubrosNegocio
    {
        

        
        SqlServerDBConnection DBConn { get; set; }

        
        public RubrosNegocio(SqlServerDBConnection sqlServerDBConnection)
        {
            // TODO: Complete member initialization
            DBConn = sqlServerDBConnection;
        }

        public DataTable ObtenerRubroListado(string desc)
        {
            try
            {
                var dt = new DataTable();
                DBConn.openConnection();
                String sqlRequest;
                sqlRequest = "SELECT Id_Rubro, Descripcion FROM PMS.RUBROS";
                sqlRequest += " WHERE 1 = 1 ";               
                if (desc != null && desc != "") sqlRequest += " and Descripcion LIKE @Desc";            
                SqlCommand command = new SqlCommand(sqlRequest, DBConn.Connection);
                if (desc != null && desc != "") command.Parameters.Add("@Desc", SqlDbType.NVarChar).Value = "%" + desc + "%";
              
                
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dt);
                    return dt;
                }

                //SqlDataReader reader = command.ExecuteReader();

                //while (reader.Read())
                //{
                //    decimal id_Rol = reader.GetDecimal(ID_ROL_COLUMN);
                //    listRolIds.Add(id_Rol);
                //}

                //reader.Close();
                command.Dispose();
                DBConn.closeConnection();

            }
            catch (Exception ex)
            {
                DBConn.closeConnection();
                throw (new Exception("Error en ObtenerVisibilidades" + ex.Message));
            }                  

        }


        public void DeleteRubro(int IdRubro)
        {
            
            try
            {
                DBConn.openConnection();
                using (SqlCommand cmd = new SqlCommand("PMS.BAJA_RUBRO", DBConn.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Id_Rubro", SqlDbType.VarChar).Value = IdRubro;
                    cmd.ExecuteNonQuery();
                }
                DBConn.closeConnection();
            }
            catch (Exception e)
            {
                DBConn.closeConnection();
                throw (new Exception("No se pudo editar la cantidad de intentos fallidos : " + e.Message));
            
            }
        }



        public void AltaRubro(string descripcion)
        {
            try
            {
                DBConn.openConnection();
                using (SqlCommand cmd = new SqlCommand("PMS.ALTA_RUBRO", DBConn.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = descripcion;
                    cmd.ExecuteNonQuery();
                }
                DBConn.closeConnection();
            }
            catch (Exception e)
            {
                DBConn.closeConnection();
                throw (new Exception("No se pudo editar la cantidad de intentos fallidos : " + e.Message));

            }
        }

        public void ModifRubro(int IdCod, string descripcion)
        {
            try
            {
                DBConn.openConnection();
                using (SqlCommand cmd = new SqlCommand("PMS.MODIFICACION_RUBRO", DBConn.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Id_Rubro", SqlDbType.Int).Value = IdCod;
                    cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = descripcion;
                    cmd.ExecuteNonQuery();
                }
                DBConn.closeConnection();
            }
            catch (Exception e)
            {
                DBConn.closeConnection();
                throw (new Exception("No se pudo editar la cantidad de intentos fallidos : " + e.Message));

            }
        }
    }
}
