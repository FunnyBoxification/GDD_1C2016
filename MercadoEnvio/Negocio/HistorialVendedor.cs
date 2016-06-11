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

        public DataTable searchFacturasAVendedor(int Id_Vendedor, String Contenido_Detalle, int Importe_Max, int Importe_Min, int Fecha_Max, int Fecha_Min)
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
                if (Contenido_Detalle != null)
                {
                    sqlRequest += " and Descripcion LIKE %" + Contenido_Detalle + "%";
                }
                if (Importe_Max != -1 && Importe_Min != -1)
                {
                    sqlRequest += " AND factura.Monto BETWEEN " + Importe_Min + " AND " + Importe_Max;
                }
                else if (Importe_Max != -1)
                {
                    sqlRequest += " AND factura.Monto <= " + Importe_Max;
                }
                else if (Importe_Min != -1)
                {
                    sqlRequest += " AND factura.Monto >= " + Importe_Min;
                }
                // CHEQUEAR ESTO
                if (Fecha_Max != -1 && Fecha_Min != -1)
                {
                    sqlRequest += " AND factura.Fecha BETWEEN " + Fecha_Min + " AND " + Fecha_Max;
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
