using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WindowsFormsApplication1
{
    class SqlServerDBConnection
    {
        private static SqlServerDBConnection instance;
        public const String ConnectionString = "Data Source=localhost\\SQLSERVER2012;Initial Catalog=GD1C2016;User ID=gd;Password=gd2016";
        public SqlConnection Connection;

        public SqlConnection openConnection() {
            Connection = new SqlConnection(ConnectionString);
            Connection.Open();
            return Connection;
        }

        public void closeConnection() {
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
