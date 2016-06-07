using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.Entities;


namespace WindowsFormsApplication1
{
    class SqlServerDBConnection
    {
        private static SqlServerDBConnection instance;

        /*@author: Fede
         * Mi instancia de SQL tiene el nombre SQLEXPRESS, en el tp SQLSERVER2012
         * 
         * */
        public const String ConnectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=GD1C2016;User ID=gd;Password=gd2016";
        public SqlConnection Connection;

        public SqlConnection openConnection()
        {
            try
            {
                Connection = new SqlConnection(ConnectionString);
                Connection.Open();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);

                Application.Exit();
            }

            return Connection;

        }

        public void closeConnection()
        {
            Connection.Close();
        }

        public static SqlServerDBConnection Instance()
        {
            if (instance != null)
            {
                return instance;
            }
            else
            {
                instance = new SqlServerDBConnection();
                return instance;
            }
        }


        public int loginUser(string username, string password)
        {


            try
            {

                String sqlRequest = "SELECT PMS.getUserV2(@userName,@password)";

                SqlCommand command = new SqlCommand(sqlRequest, Connection);
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

        public List<decimal> getRolesIdByUserId(int idUser)
        {

            int ID_ROL_COLUMN = 0;
            List<decimal> listRolIds = new List<decimal>();

            String sqlRequest = "SELECT * FROM PMS.ROLES_USUARIOS where Id_Usuario = @idUser";
            SqlCommand command = new SqlCommand(sqlRequest, Connection);
            command.Parameters.Add("@idUser", SqlDbType.Int).Value = idUser;

            try
            {
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    decimal id_Rol = reader.GetDecimal(ID_ROL_COLUMN);
                    listRolIds.Add(id_Rol);
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            command.Dispose();

            return listRolIds;

        }


        public Rol getRolById(decimal idRol)
        {
            Rol rol = new Rol();


            String sqlRequest = "SELECT * FROM PMS.ROLES where Id_Rol = @idRol";
            SqlCommand command = new SqlCommand(sqlRequest, Connection);
            command.Parameters.Add("@idRol", SqlDbType.Int).Value = idRol;

            try
            {
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    String nombre = reader.GetString(1);
                    decimal habilitado = reader.GetDecimal(2);
                    rol.nombre = nombre;
                    rol.habilitado = habilitado;
                    rol.id_rol = idRol;

                }
                reader.Close();
            }
            catch (Exception e)
            {                
                MessageBox.Show(e.Message);

            }


            command.Dispose();


            return rol;

        }


        public decimal getIntentosDeLogin(String user)
        {
            String sqlRequest = "SELECT Intentos_Login FROM PMS.USUARIOS where User_Nombre = @user";
            SqlCommand command = new SqlCommand(sqlRequest, Connection);
            command.Parameters.Add("@user", SqlDbType.VarChar).Value = user;

            try
            {
                decimal intentos = (decimal)command.ExecuteScalar();
                return intentos;
            }
            catch (Exception e) {
                return -1;
            }

        }


        public void incrementarIntentosLogin(String user)
        {
            String sqlRequest = "EXEC PMS.AumentarIntentosFallidos @userName =  @user";
            SqlCommand command = new SqlCommand(sqlRequest, Connection);
            command.Parameters.Add("@user", SqlDbType.VarChar).Value = user;

            try
            {
                command.ExecuteScalar();
            }
            catch (Exception e)
            {
                Console.WriteLine("No se pudo editar la cantidad de intentos fallidos : " + e.Message);
            }
        }


    }
}

