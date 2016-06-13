using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Linq;
using System.Data;
using MercadoEN;
using MercadoNegocio;


namespace MercadoNegocio
{
    public class HistorialCliente
    {
        SqlServerDBConnection DBConn { get; set; }

        public HistorialCliente(SqlServerDBConnection dbConnection)
        {
            DBConn = dbConnection;
        }


        public DataTable searchHistorialCliente(int Id_Cliente)
        {

            try
            {
                var dt = new DataTable();
                DBConn.openConnection();

                String sqlRequest = @"SELECT CO.Cantidad, CO.Fecha, CO.Monto, P.Descripcion AS Producto, (SELECT U.User_Nombre FROM PMS.USUARIOS U where U.Id_Usuario = P.Id_Usuario)  Vendedor,
            (SELECT CASE WHEN CO.Id_Calificacion IS NULL     THEN 'No' ELSE 'Si' END) AS Calificada
            FROM pms.CLIENTES CL JOIN PMS.COMPRAS CO ON
			CO.Id_Cliente_Comprador = CL.Id_Cliente AND
			Cl.Id_Cliente = @idCliente 
			JOIN PMS.PUBLICACIONES P ON
			P.Id_Publicacion  = CO.Id_Publicacion";
                SqlCommand sqlCommand = new SqlCommand(sqlRequest, DBConn.Connection);
                sqlCommand.Parameters.Add("@idCliente", SqlDbType.Int).Value = Id_Cliente;
                using (SqlDataAdapter da = new SqlDataAdapter(sqlCommand))
                {
                    da.Fill(dt);
                    return dt;
                }


                DBConn.closeConnection();
            }
            catch (Exception ex)
            {
                throw new Exception("Error en obtener compras del cliente" + ex.Message);
            }



        }



    }
}
