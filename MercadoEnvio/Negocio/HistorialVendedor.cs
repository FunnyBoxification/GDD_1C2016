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
    public class HistorialVendedor
    {
        SqlServerDBConnection DBConn { get; set; }

        public HistorialVendedor(SqlServerDBConnection dbConnection)
        {
            DBConn = dbConnection;
        }

        public DataTable searchFacturasAVendedor(int Id_Vendedor, String Contenido_Detalle, decimal Importe_Max, decimal Importe_Min, string Fecha_Max, string Fecha_Min)
        {
            try
            {
                var dt = new DataTable();
                DBConn.openConnection();
                String sqlRequest;
                sqlRequest = "SELECT DISTINCT Numero, Fecha, Total FROM ";
                sqlRequest += "( SELECT item.*, factura.* FROM PMS.ITEMFACTURA item LEFT JOIN PMS.FACTURAS factura ON item.Id_Factura = factura.Numero ";
                sqlRequest += " WHERE 1=1";
                if (Id_Vendedor != -1)
                {
                    sqlRequest += " and " + Id_Vendedor + " IN (SELECT Id_Usuario FROM PMS.PUBLICACIONES WHERE Id_Publicacion = item.Id_Publicacion)";
                }
                if (Contenido_Detalle != null && Contenido_Detalle != "")
                {
                    sqlRequest += " and Descripcion LIKE '%" + Contenido_Detalle + "%'";
                }
                if (Importe_Max > 0 && Importe_Min > 0 && Importe_Max > Importe_Min)
                {
                    sqlRequest += " AND factura.Total BETWEEN " + Importe_Min + " AND " + Importe_Max;
                }
                else if (Importe_Max > 0)
                {
                    sqlRequest += " AND factura.Total <= " + Importe_Max;
                }
                else if (Importe_Min > 0)
                {
                    sqlRequest += " AND factura.Total >= " + Importe_Min;
                }
                // CHEQUEAR ESTO
                if (Fecha_Max != null && Fecha_Min != null)
                {
                    sqlRequest += " AND factura.Fecha BETWEEN CONVERT(date,'" + Fecha_Min + "') AND CONVERT(date,'" + Fecha_Max + "')";
                }
                sqlRequest += ") as Facturas";
                SqlCommand command = new SqlCommand(sqlRequest, DBConn.Connection);

                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dt);
                    command.Dispose();
                    DBConn.closeConnection();
                    return dt;
                }

            }
            catch (Exception ex)
            {
                DBConn.closeConnection();
                throw (new Exception("Error en searchFacturasAlVendedor: "  + ex.Message));
            }
        }

    }
}
