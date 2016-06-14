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

        public int getCantidadDeEstrellasDadas(int idUser)
        {
            String sqlRequest = "select pms.getEstrellasDadas (@idUser)";

            try
            {
                SqlCommand sqlCommand = new SqlCommand(sqlRequest, DBConn.Connection);
                sqlCommand.Parameters.Add("@idUser", SqlDbType.Int).Value = idUser;


                int cantidad = (int)sqlCommand.ExecuteScalar();
                return cantidad;
            }
            catch (Exception e)
            {
                throw new Exception("Error al obtener la cantidad de estrellas dadas por el usuario: " + e.Message);
            }
         


        }


        public DataTable searchHistorialCliente(int Id_Cliente, String detalle, decimal importe_Max, decimal importe_Min, string fechaDesde, string fechaHasta)
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
            sqlRequest += " WHERE 1=1";


                if (detalle != null && detalle != "")
                {
                    sqlRequest += "and P.Descripcion LIKE '%" + detalle + "%'";
                }

                if (importe_Max > 0 && importe_Min >= 0 && importe_Max > importe_Min)
                {
                    sqlRequest += " AND CO.Monto BETWEEN " + importe_Min + " AND " + importe_Max;
                }

                if (fechaDesde != null && fechaHasta != null)
                {
                    sqlRequest += " AND CO.Fecha BETWEEN CONVERT(date,'" + fechaDesde + "') AND CONVERT(date,'" + fechaHasta + "')";
                }

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
