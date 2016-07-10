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
    public class VisibilidadesNegocio
    {
        

        
        SqlServerDBConnection DBConn { get; set; }

        
        public VisibilidadesNegocio(SqlServerDBConnection sqlServerDBConnection)
        {
            // TODO: Complete member initialization
            DBConn = sqlServerDBConnection;
        }

        public DataTable ObtenerVisibListado(double codigo, string desc, double porc, double precio)
        {
            try
            {
                var dt = new DataTable();
                DBConn.openConnection();
                String sqlRequest;
                sqlRequest = "SELECT Id_Visibilidad, Descripcion, Porcentaje, Precio FROM PMS.VISIBILIDADES";
                sqlRequest += "WHERE 1 = 1 ";
                if (codigo != null) sqlRequest += " and Id_Visibilidad LIKE  @idVisib";
                if (desc != null) sqlRequest += " and Descripcion LIKE @Desc";
                if (porc != null) sqlRequest += " and Porcentaje LIKE  @Porc";
                if (precio != null) sqlRequest += " and Precio LIKE @Precio";
                SqlCommand command = new SqlCommand(sqlRequest, DBConn.Connection);
                if (codigo != null) command.Parameters.Add("@idVisib", SqlDbType.Int).Value = "%" + codigo + "%";
                if (desc != null) command.Parameters.Add("@Desc", SqlDbType.Int).Value = "%" + desc + "%";
                if (porc != null) command.Parameters.Add(" @Porc", SqlDbType.Int).Value = "%" + porc + "%";
                if (precio != null) command.Parameters.Add("@Precio", SqlDbType.Int).Value = "%" + precio + "%";
                
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


        public void DeleteVisib(int IdVisib)
        {
            
            try
            {
                DBConn.openConnection();
                using (SqlCommand cmd = new SqlCommand("PMS.BAJA_VISIBILIDAD", DBConn.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@user", SqlDbType.VarChar).Value = IdVisib;
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



        public void AltaVisibilidad(string descripcion, Decimal porcentaje, Decimal precio)
        {
            try
            {
                DBConn.openConnection();
                using (SqlCommand cmd = new SqlCommand("PMS.ALTA_VISIBILIDAD", DBConn.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = descripcion;
                    cmd.Parameters.Add("@porcentaje", SqlDbType.Decimal).Value = porcentaje;
                    cmd.Parameters.Add("@precio", SqlDbType.Decimal).Value = precio;
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

        public void ModifVisibilidad(int IdCod, string descripcion, decimal porcentaje, decimal precio)
        {
            try
            {
                DBConn.openConnection();
                using (SqlCommand cmd = new SqlCommand("PMS.MODIFICACION_VISIBILIDAD", DBConn.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Id_Visibilidad", SqlDbType.VarChar).Value = descripcion;
                    cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = descripcion;
                    cmd.Parameters.Add("@porcentaje", SqlDbType.Decimal).Value = porcentaje;
                    cmd.Parameters.Add("@precio", SqlDbType.Decimal).Value = precio;
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
