using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace MercadoNegocio
{
    public class SqlServerDBConnection
    {
        public static SqlServerDBConnection instance;

        /*@author: Fede
         * Mi instancia de SQL tiene el nombre SQLEXPRESS, en el tp SQLSERVER2012
         * 
         * */
        public const String ConnectionString = "Data Source=PABLO-NT\\SQLSERVER2012;Initial Catalog=GD1C2016;User ID=gd;Password=gd2016";
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
                throw(new Exception("Error en Connection" + e.Message));
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


    }
}
