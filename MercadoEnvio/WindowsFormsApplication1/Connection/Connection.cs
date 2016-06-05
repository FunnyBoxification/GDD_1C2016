using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace WindowsFormsApplication1.Connection
{
    class Connection
    {

        public static String stringConnection()
        {
            //TODO MODIFICAR STRING
            String connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=GD1C2016;User ID=gd;Password=gd2016";
            return connectionString;
        }


        public static int loginUser(string username, string password)
        {
            SqlConnection cnn;

            cnn = new SqlConnection(stringConnection());
            try
            {
                cnn.Open();

                // String sqlRequest = "SELECT PMS.getUser('" + username + "'," + password + ")";
                String sqlRequest = "SELECT PMS.getUser(@userName,@password)";

                SqlCommand command = new SqlCommand(sqlRequest, cnn);
                command.Parameters.Add("@userName", SqlDbType.VarChar).Value = username;
                //command.Parameters.Add("@password", SqlDbType.Int).Value = password;
                command.Parameters.Add("@password", SqlDbType.Int).Value = password.ToString();

                int result = (int)command.ExecuteScalar();
                cnn.Close();

                return result;



            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error con la conexion  SQL ! " + ex.Message);
                return -1;
            }
        }


    }
}
