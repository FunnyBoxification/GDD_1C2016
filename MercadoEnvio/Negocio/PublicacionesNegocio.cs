using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Linq;
using System.Data;
using MercadoEN;

namespace MercadoNegocio
{
    public class PublicacionesNegocio
    {
        SqlServerDBConnection DBConn { get; set; }

        public PublicacionesNegocio(SqlServerDBConnection dbConnection)
        {
            DBConn = dbConnection;
        }
       

        public DataTable BuscarPublicaciones(string Idpubli, string tipo, string descripcion)
        {
            try
            {
                var dt = new DataTable();
                DBConn.openConnection();
                String sqlRequest;
                sqlRequest = "SELECT p.Id_Publicacion, p.Descripcion, p.Stock  , p.Fecha  ,p.FechaVencimiento  ,   p.Precio  , ";
                sqlRequest += " (SELECT u.User_Nombre FROM PMS.USUARIOS u  WHERE u.Id_Usuario = p.Id_Usuario) as Vendedor, ";
                sqlRequest += " (SELECT v.Descripcion FROM PMS.VISIBILIDADES v WHERE v.Id_Visibilidad = p.Id_Visibilidad) as Visibilidad, ";
                sqlRequest += " (SELECT t.Descripcion FROM PMS.TIPO_PUBLICACION t WHERE t.Id_Tipo = p.Id_Tipo) as Tipo , ";
                sqlRequest += " (SELECT r.Descripcion FROM PMS.RUBROS r WHERE r.Id_Rubro = r.Id_Rubro) as Rubro, ";
                sqlRequest += " (SELECT e.Descripcion FROM PMS.PUBLICACION_ESTADOS e WHERE e.Id_Estado = e.Id_Estado) As Estado ";   
                sqlRequest += "FROM PMS.PUBLICACIONES p  ";
                sqlRequest += "WHERE  p.Id_Tipo = (SELECT t.Id_Tipo FROM PMS.TIPO_PUBLICACION t WHERE t.Descripcion = @tipo) ";
                if (Idpubli != null || Idpubli != "") sqlRequest += " and p.Id_Publicacion = @idpubli";
                if (descripcion != null || descripcion != "") sqlRequest += " and p.Descripcion = @descripcion";
                SqlCommand command = new SqlCommand(sqlRequest, DBConn.Connection);
                command.Parameters.Add("@tipo", SqlDbType.NVarChar).Value = tipo;
                if (Idpubli != null || Idpubli != "") command.Parameters.Add("@idpubli", SqlDbType.Int).Value = Convert.ToInt32(Idpubli);
                if (descripcion != null || descripcion != "") command.Parameters.Add(" @email", SqlDbType.NVarChar).Value = descripcion;
               
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dt);
                    return dt;
                }


                command.Dispose();
                DBConn.closeConnection();

            }
            catch (Exception ex)
            {
                DBConn.closeConnection();
                throw (new Exception("Error en la Busqueda de empresas" + ex.Message));
            }
        }

       

        public void ProcedurePublicacion(int tipo, int modo, int IdCod )//poner parametros)
        {
            try
            {
                var proc = "PMS.";
                if(modo == 0)
                {
                    proc += "ALTA_PUBLICACION";
                }else
                {
                    proc += "MODIFICACION_PUBLICACION";
                }
                
                DBConn.openConnection();
                using (SqlCommand cmd = new SqlCommand(proc, DBConn.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure; // aca van todos los parametros. Tipo de publi (compra subasta es uno de ellos
                    if (modo == 1)
                    {
                        cmd.Parameters.Add("@Id_Usuario", SqlDbType.Int).Value = IdCod;
                    }
                    cmd.Parameters.Add("@Username", SqlDbType.VarChar).Value = username;
                    cmd.Parameters.Add("¨@Password", SqlDbType.VarChar).Value = password;
                    if(tipo == 0)
                    {                //Cliente    
                    cmd.Parameters.Add("@Nombre", SqlDbType.Int).Value = nombreRazon;
                    cmd.Parameters.Add("@Apellido", SqlDbType.VarChar).Value = ApellidCui;
                    cmd.Parameters.Add("¨@Documento", SqlDbType.VarChar).Value = Doccto;
                    cmd.Parameters.Add("@TipoDocumento", SqlDbType.VarChar).Value = tiporub;
                    cmd.Parameters.Add("¨@FechaNac", SqlDbType.VarChar).Value = fechaCiud;
                    }else
                    { //empresa
                    cmd.Parameters.Add("@RazonSocial", SqlDbType.Int).Value = nombreRazon;
                    cmd.Parameters.Add("@Cuit_Empresa", SqlDbType.VarChar).Value = ApellidCui;
                    cmd.Parameters.Add("¨@Contacto", SqlDbType.VarChar).Value = Doccto;
                    cmd.Parameters.Add("@Rubro", SqlDbType.VarChar).Value = tiporub;
                    cmd.Parameters.Add("¨@Ciudad", SqlDbType.VarChar).Value = fechaCiud;
                    }
                    cmd.Parameters.Add("@Mail", SqlDbType.Int).Value = mail;
                    cmd.Parameters.Add("@Telefono", SqlDbType.VarChar).Value = telef;
                    cmd.Parameters.Add("¨@Direccion", SqlDbType.VarChar).Value = direcc;
                    cmd.Parameters.Add("@Nro", SqlDbType.VarChar).Value = nro;
                    cmd.Parameters.Add("¨@Piso", SqlDbType.VarChar).Value = piso;
                    cmd.Parameters.Add("@Departamento", SqlDbType.VarChar).Value = dpto;
                    cmd.Parameters.Add("¨@Localidad", SqlDbType.VarChar).Value = local;
                    cmd.ExecuteNonQuery();
                }
                DBConn.closeConnection();
            }
            catch (Exception e)
            {
                DBConn.closeConnection();
                throw (new Exception("No se pudo editar la cantidad de intentos fallidos : " + e.Message));

            }
        }
    }
}
