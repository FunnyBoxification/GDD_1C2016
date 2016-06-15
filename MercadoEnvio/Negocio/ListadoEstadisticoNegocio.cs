using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using MercadoEN;
using MercadoNegocio;

namespace MercadoNegocio
{
    public class ListadoEstadisticoNegocio
    {
        SqlServerDBConnection DBConn { get; set; }

        public ListadoEstadisticoNegocio(SqlServerDBConnection dbConnection)
        {
            DBConn = dbConnection;
        }

        public DataTable getAniosPublicaciones()
        {
            var dt = new DataTable();

            try
            {

                DBConn.openConnection();
                String sqlRequest;
                sqlRequest = "SELECT DISTINCT DATEPART(yyyy,Fecha) FROM PMS.PUBLICACIONES";

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
                throw (new Exception("Error en searchFacturasAlVendedor: " + ex.Message));
            }
        }

        public List<String> getTrimestres()
        {
            var lista =  new List<String>();

            lista.Add("Ene-Mar");
            lista.Add("Abr-Jun");
            lista.Add("Jul-Sep");
            lista.Add("Oct-Dic");

            return lista;
        }

        public List<String> getListados()
        {
            var listados = new List<String>();

            listados.Add("Vendedores con prods no vendidos");
            listados.Add("Clientes con mayor cantidad de productos comprados");
            listados.Add("Vendedores con mayor cantidad de facturas");
            listados.Add("Vendedores con mayor monto facturado");
            return listados;

        }

        public String getInicioTrimestre(String anio, String trimestre)
        {
            if (trimestre.Equals("Ene-Mar", StringComparison.Ordinal))
            {
                return "01/01/" + anio;
            }
            else if (trimestre.Equals("Abr-Jun", StringComparison.Ordinal))
            {
                return "01/04/" + anio;
            }
            else if (trimestre.Equals("Jul-Sep", StringComparison.Ordinal))
            {
                return "01/07/" + anio;
            }
            else
            {
                return "01/10/" + anio;
            }
        }

        public String getFinTrimestre(String anio, String trimestre)
        {
            if (trimestre.Equals("Ene-Mar", StringComparison.Ordinal))
            {
                return "31/03/" + anio;
            }
            else if (trimestre.Equals("Abr-Jun", StringComparison.Ordinal))
            {
                return "30/06/" + anio;
            }
            else if (trimestre.Equals("Jul-Sep", StringComparison.Ordinal))
            {
                return "30/09/" + anio;
            }
            else
            {
                return "31/12/" + anio;
            }
        }

        public DataTable getRubros()
        {
            try
            {
                var dt = new DataTable();
                DBConn.openConnection();
                String sqlRequest;
                sqlRequest = "SELECT Id_Rubro, Descripcion FROM PMS.RUBROS";

                SqlCommand command = new SqlCommand(sqlRequest, DBConn.Connection);


                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dt);
                }

                command.Dispose();
                DBConn.closeConnection();
                return dt;

            }
            catch (Exception ex)
            {
                DBConn.closeConnection();
                throw (new Exception("Error en GetRubros" + ex.Message));
            }  
        }

        public DataTable obtenerVisibilidades()
        {
            try
            {
                var dt = new DataTable();
                DBConn.openConnection();
                String sqlRequest;
                sqlRequest = "SELECT Id_Visibilidad, Descripcion FROM PMS.VISIBILIDADES ";

                SqlCommand command = new SqlCommand(sqlRequest, DBConn.Connection);


                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dt);
                }

                command.Dispose();
                DBConn.closeConnection();
                return dt;

            }
            catch (Exception ex)
            {
                DBConn.closeConnection();
                throw (new Exception("Error en ObtenerVisibilidades" + ex.Message));
            }                  

        }

        public DataTable getTop5VendedoresConArticulosNoVendidos(String anio, String trimestre, int idVisibilidad)
        {
            var dt = new DataTable();
            var inicioTrimestre = this.getInicioTrimestre(anio,trimestre) ;
            var finTrimestre = this.getFinTrimestre(anio,trimestre);

            try
            {

                DBConn.openConnection();
                String sqlRequest;
                sqlRequest = "SELECT TOP 5 Id_Usuario, DATEPART(mm,Fecha) as \"Mes\", Id_Visibilidad, MAX(Stock) as Max_Stock  FROM PMS.Publicaciones WHERE 1=1 ";
                if (idVisibilidad != -1) 
                {
                    sqlRequest += "AND Id_Visibilidad = @IdVisibilidad ";
                }
                sqlRequest += "AND Fecha BETWEEN CONVERT(date,@InicioTrimestre) AND CONVERT(date,@FinTrimestre) ";
                sqlRequest += "GROUP BY Id_Usuario, DATEPART(mm,Fecha), Id_Visibilidad ORDER BY MAX(Stock), DATEPART(mm,Fecha), Id_Visibilidad";

                SqlCommand command = new SqlCommand(sqlRequest, DBConn.Connection);
                command.Parameters.Add("@IdVisibilidad", SqlDbType.Int).Value = idVisibilidad;
                command.Parameters.Add("@InicioTrimestre", SqlDbType.NVarChar).Value = inicioTrimestre;
                command.Parameters.Add("@FinTrimestre", SqlDbType.NVarChar).Value = finTrimestre;

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
                throw (new Exception("Error en getTop5VendedoresConArticulosNoVendidos: " + ex.Message));
            }
        }

        public DataTable getTop5ClientesConArticulosComprados(String anio, String trimestre, int idRubro)
        {
            var dt = new DataTable();
            var inicioTrimestre = this.getInicioTrimestre(anio, trimestre);
            var finTrimestre = this.getFinTrimestre(anio, trimestre);

            try
            {

                DBConn.openConnection();
                String sqlRequest;
                sqlRequest = "SELECT TOP 5 compras.Id_Cliente_Comprador as \"Id Cliente \", COUNT(compras.Id_Compra) as \"Cantidad de Compras \" FROM PMS.COMPRAS compras ";
                sqlRequest += "LEFT JOIN PMS.PUBLICACIONES publicaciones ON publicaciones.Id_Publicacion = compras.Id_Publicacion ";
                sqlRequest += "WHERE 1=1 AND";
                if (idRubro != -1)
                {
                    sqlRequest += " publicaciones.Id_Rubro = @IdRubro ";
                }
                sqlRequest += "AND compras.Fecha BETWEEN CONVERT(date,@InicioTrimestre) AND CONVERT(date,@FinTrimestre) ";
                sqlRequest += " GROUP BY compras.Id_Cliente_Comprador ORDER BY COUNT(compras.Id_Compra)";

                SqlCommand command = new SqlCommand(sqlRequest, DBConn.Connection);
                command.Parameters.Add("@IdRubro", SqlDbType.Int).Value = idRubro;
                command.Parameters.Add("@InicioTrimestre", SqlDbType.NVarChar).Value = inicioTrimestre;
                command.Parameters.Add("@FinTrimestre", SqlDbType.NVarChar).Value = finTrimestre;

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
                throw (new Exception("Error en getTop5VendedoresConArticulosNoVendidos: " + ex.Message));
            }
        }

        public DataTable getTop5VendedoresConFacturas(String anio, String trimestre)
        {
            var dt = new DataTable();
            var inicioTrimestre = this.getInicioTrimestre(anio, trimestre);
            var finTrimestre = this.getFinTrimestre(anio, trimestre);

            try
            {

                DBConn.openConnection();
                String sqlRequest;
                sqlRequest = "SELECT TOP 5 COUNT(item.Id_ItemFactura), publicacion.Id_Usuario FROM PMS.ITEMFACTURA item ";
                sqlRequest += "LEFT JOIN PMS.PUBLICACIONES publicacion ON item.Id_Publicacion = publicacion.Id_Publicacion ";
                sqlRequest += "WHERE Fecha BETWEEN CONVERT(date,@InicioTrimestre) AND CONVERT(date,@FinTrimestre) ";
                sqlRequest += "GROUP BY publicacion.Id_Usuario ORDER BY COUNT(item.Id_ItemFactura)";

                SqlCommand command = new SqlCommand(sqlRequest, DBConn.Connection);
                command.Parameters.Add("@InicioTrimestre", SqlDbType.NVarChar).Value = inicioTrimestre;
                command.Parameters.Add("@FinTrimestre", SqlDbType.NVarChar).Value = finTrimestre;

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
                throw (new Exception("Error en getTop5VendedoresConArticulosNoVendidos: " + ex.Message));
            }

        }

        public DataTable getTop5VendedoresConMontoFacturado(String anio, String trimestre)
        {
            var dt = new DataTable();
            var inicioTrimestre = this.getInicioTrimestre(anio, trimestre);
            var finTrimestre = this.getFinTrimestre(anio, trimestre);

            try
            {

                DBConn.openConnection();
                String sqlRequest;
                sqlRequest = "SELECT TOP 5 SUM(item.Monto), publicacion.Id_Usuario FROM PMS.ITEMFACTURA item ";
                sqlRequest += "LEFT JOIN PMS.PUBLICACIONES publicacion ON item.Id_Publicacion = publicacion.Id_Publicacion ";
                sqlRequest += "WHERE Fecha BETWEEN CONVERT(date,@InicioTrimestre) AND CONVERT(date,@FinTrimestre) ";
                sqlRequest += "GROUP BY publicacion.Id_Usuario ORDER BY SUM(item.Monto)";

                SqlCommand command = new SqlCommand(sqlRequest, DBConn.Connection);
                command.Parameters.Add("@InicioTrimestre", SqlDbType.NVarChar).Value = inicioTrimestre;
                command.Parameters.Add("@FinTrimestre", SqlDbType.NVarChar).Value = finTrimestre;

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
                throw (new Exception("Error en getTop5VendedoresConArticulosNoVendidos: " + ex.Message));
            }
        }
    }
}
