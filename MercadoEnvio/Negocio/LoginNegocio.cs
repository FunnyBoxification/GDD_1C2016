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
    public class LoginNegocio
    {
        SqlServerDBConnection DBConn { get; set; }

        public LoginNegocio(SqlServerDBConnection dbConnection)
        {
            DBConn = dbConnection;
        }



        public int loginUser(string username, string password)
        {


            try
            {

                String sqlRequest = "SELECT PMS.getUser(@userName,@password)";

                SqlCommand command = new SqlCommand(sqlRequest, DBConn.Connection);
                command.Parameters.Add("@userName", SqlDbType.VarChar).Value = username;

                command.Parameters.Add("@password", SqlDbType.Int).Value = password.ToString();
                int result = (int)command.ExecuteScalar();

                return result;

            }
            catch (Exception ex)
            {
                //System.Windows.Forms.MessageBox.Show("Error con la conexion  SQL ! " + ex.Message);
                return -1;
            }
        }

        public DataTable getRolesDT(int idUser)
        {

            //int ID_ROL_COLUMN = 0;
            //List<decimal> listRolIds = new List<decimal>();
            var dt = new DataTable();

            try
            {
            String sqlRequest = "SELECT Descripcion FROM PMS.ROLES_USUARIOS where Id_Usuario = @idUser";
            SqlCommand command = new SqlCommand(sqlRequest, DBConn.Connection);
            command.Parameters.Add("@idUser", SqlDbType.Int).Value = idUser;
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

            }
            catch (Exception ex)
            {
                throw (new Exception("Error en ObetenerRoles" + ex.Message));
            }                  

        }



        public void limpiarIntentos(String user)
        {
            String sqlRequest = "EXEC PMS.LimpiarIntentos @userName = @user";
            SqlCommand command = new SqlCommand(sqlRequest, DBConn.Connection);
            command.Parameters.Add("@user", SqlDbType.VarChar).Value = user;

            command.ExecuteScalar();
        }

        //public Rol getRolById(decimal idRol)
        //{
        //    MercadoEN.Rol rol = new Rol();


        //    String sqlRequest = "SELECT * FROM PMS.ROLES where Id_Rol = @idRol";
        //    SqlCommand command = new SqlCommand(sqlRequest, DBConn.Connection);
        //    command.Parameters.Add("@idRol", SqlDbType.Int).Value = idRol;

        //    try
        //    {
        //        SqlDataReader reader = command.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            String nombre = reader.GetString(1);
        //            decimal habilitado = reader.GetDecimal(2);
        //            rol.nombre = nombre;
        //            rol.habilitado = habilitado;
        //            rol.id_rol = idRol;

        //        }
        //        reader.Close();
        //    }
        //    catch (Exception e)
        //    {
        //        throw (new Exception("Error en ObetenerRoles" + e.Message));

        //    }


        //    command.Dispose();


        //    return rol;

        //}


        public decimal getIntentosDeLogin(String user)
        {
            String sqlRequest = "SELECT Intentos_Login FROM PMS.USUARIOS where User_Nombre = @user";
            SqlCommand command = new SqlCommand(sqlRequest, DBConn.Connection);
            command.Parameters.Add("@user", SqlDbType.VarChar).Value = user;

            try
            {
                decimal intentos = (decimal)command.ExecuteScalar();
                return intentos;
            }
            catch (Exception e)
            {
                return -1;
            }

        }


        public Boolean estaHabilitado(String user)
        {
            String sqlRequest = "SELECT Habilitado FROM PMS.USUARIOS where User_Nombre = @user";
            SqlCommand command = new SqlCommand(sqlRequest, DBConn.Connection);
            command.Parameters.Add("@user", SqlDbType.VarChar).Value = user;

            try
            {
                decimal habilitado = (decimal)command.ExecuteScalar();
                if (habilitado == 1) return true;
                else return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public void incrementarIntentosLogin(String user)
        {
            //String sqlRequest = "EXEC PMS.AumentarIntentosFallidos @userName =  @user";
            //SqlCommand command = new SqlCommand(sqlRequest, DBConn.Connection);
            //command.Parameters.Add("@user", SqlDbType.VarChar).Value = user;
            try
            {
                using (SqlCommand cmd = new SqlCommand("PMS.AumentarIntentosFallidos", DBConn.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }            
                
            }
            catch (Exception e)
            {
                throw (new Exception("No se pudo editar la cantidad de intentos fallidos : " + e.Message));
            }
        }




    }
}
