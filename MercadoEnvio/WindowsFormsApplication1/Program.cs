using MercadoNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.ABM_Rol;
using WindowsFormsApplication1.Facturas;
using WindowsFormsApplication1.Historial_Cliente;
using WindowsFormsApplication1.Listado_Estadistico;


namespace WindowsFormsApplication1
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //terminarSubastas();
            //SqlServerDBConnection.Instance().openConnection();
            //Application.Run(new LoginForm());
            Application.Run(new LoginForm());
        }
        
        static int terminarSubastas()
        {
            string fileName = "fecha.txt";
            string path = Path.Combine(Environment.CurrentDirectory, fileName);
            string text = File.ReadAllText(path, Encoding.UTF8);
            DateTime fecha = DateTime.ParseExact(text, "yyyy-MM-dd HH:mm:ss",
                System.Globalization.CultureInfo.InvariantCulture);
            SqlServerDBConnection DBConn = SqlServerDBConnection.Instance();
            
            int result = -1;

            try
            {
                DBConn.openConnection();
                using (SqlCommand cmd = new SqlCommand("PMS.SUBASTAS_TERMIANDAS", DBConn.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = fecha;
                    var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;
                    cmd.ExecuteNonQuery();
                    int.TryParse(returnParameter.Value.ToString(), out result);
                    cmd.Dispose();
                }

                DBConn.closeConnection();
                return result;

            }
            catch (Exception ex)
            {
                DBConn.closeConnection();
                throw (new Exception("Error en Procesar Subastas" + ex.Message));
            }
        }
    }
}
