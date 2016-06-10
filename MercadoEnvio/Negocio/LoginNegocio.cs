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
                DBConn.openConnection();
                int result = (int)command.ExecuteScalar();
                DBConn.closeConnection();
                return result;

            }
            catch (Exception ex)
            {
                DBConn.closeConnection();
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
             DBConn.openConnection();
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
            DBConn.closeConnection();

            }
            catch (Exception ex)
            {
                DBConn.closeConnection();
                throw (new Exception("Error en ObetenerRoles" + ex.Message));
            }                  

        }

        public int insertRol()
        {
            return 1;
        }

        public void insertFuncionalidadToRol(int idRol, int idFuncionalidad)
        {
            //int ID_ROL_COLUMN = 0;
            //List<decimal> listRolIds = new List<decimal>();
            var dt = new DataTable();

            try
            {
                DBConn.openConnection();
                /*String sqlRequest = "INSERT INTO PMS.FUNCIONALIDES_ROLES(Id_Rol, Id_Funcionalidad) VALUES (@Id_Rol, @Id_Funcionalidad)";
                SqlCommand command = new SqlCommand(sqlRequest, DBConn.Connection);
                command.Parameters.Add("@Id_Rol", SqlDbType.Int).Value = idRol;
                command.Parameters.Add("@Id_Funcionalidad", SqlDbType.Int).Value = idFuncionalidad;*/
                using (SqlCommand cmd = new SqlCommand("PMS.insertFuncionalidad", DBConn.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("Id_Rol", idRol);
                    cmd.Parameters.AddWithValue("Id_Funcionalidad", idFuncionalidad);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                
                DBConn.closeConnection();

            }
            catch (Exception ex)
            {
                DBConn.closeConnection();
                throw (new Exception("Error en ObetenerRoles" + ex.Message));
            }
        }

        public DataTable getAllFuncionalidades()
        {

            //int ID_ROL_COLUMN = 0;
            //List<decimal> listRolIds = new List<decimal>();
            var dt = new DataTable();

            try
            {
                DBConn.openConnection();
                String sqlRequest = "SELECT * FROM PMS.FUNCIONALIDADES WHERE Id_Funcionalidad IS NOT NULL";
                SqlCommand command = new SqlCommand(sqlRequest, DBConn.Connection);
                //command.Parameters.Add("@idUser", SqlDbType.Int).Value = idUser;
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dt);
                    return dt;
                }
                command.Dispose();
                DBConn.closeConnection();

            }
            catch (Exception ex)
            {
                DBConn.closeConnection();
                throw (new Exception("Error en ObetenerRoles" + ex.Message));
            }

        }



        public void limpiarIntentos(String user)
        {
            String sqlRequest = "EXEC PMS.LimpiarIntentos @userName = @user";
            SqlCommand command = new SqlCommand(sqlRequest, DBConn.Connection);
            command.Parameters.Add("@user", SqlDbType.VarChar).Value = user;
            DBConn.openConnection();
            command.ExecuteScalar();
            DBConn.closeConnection();
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
                DBConn.openConnection();
                decimal intentos = (decimal)command.ExecuteScalar();
                return intentos;
                DBConn.closeConnection();
            }
            catch (Exception e)
            {
                DBConn.closeConnection();
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
                DBConn.openConnection();
                decimal habilitado = (decimal)command.ExecuteScalar();
                if (habilitado == 1) return true;
                else return false;
                DBConn.closeConnection();
            }
            catch (Exception e)
            {
                DBConn.closeConnection();
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
                DBConn.openConnection();
                using (SqlCommand cmd = new SqlCommand("PMS.AumentarIntentosFallidos", DBConn.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
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
