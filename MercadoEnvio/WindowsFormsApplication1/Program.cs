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
using System.Configuration;
using System.Collections.Specialized;


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
            try
            {
                terminarSubastas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en TerminarSubastas. " + ex.Message);
                Environment.Exit(1);
            }
            //SqlServerDBConnection.Instance().openConnection();
            //Application.Run(new LoginForm());

            Application.Run(new LoginForm());

        }
        
        static int terminarSubastas()
        {
            DateTime fecha = DateTime.Parse(ConfigurationManager.AppSettings["FechaDelDia"]);
            UsuarioLogueado.Instance().fechaDeHoy = fecha;
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
                    cmd.CommandTimeout = 999999;
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
