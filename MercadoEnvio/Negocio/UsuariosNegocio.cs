using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Linq;
using System.Data;
using MercadoEN;
using System.Configuration;
using System.Collections.Specialized;

namespace MercadoNegocio
{
    public class UsuariosNegocio
    {
        SqlServerDBConnection DBConn { get; set; }

        public UsuariosNegocio(SqlServerDBConnection dbConnection)
        {
            DBConn = dbConnection;
        }
       

        public DataTable BuscarEmpresas(string razonSocial, string cuit, string email)
        {
            try
            {
                var dt = new DataTable();
                DBConn.openConnection();
                String sqlRequest;                                                                                                                 // Id_Empresa			
                sqlRequest = "SELECT  u.Habilitado, u.Id_Usuario as \"Código Usuario\", u.User_Nombre as \"Nombre Usuario\", ";                   // Cuit_Empresa		
                sqlRequest += "e.RAzonSocial as \"Razon Social\", e.Cuit_Empresa as \"CUIT\", e.Mail, e.DomCalle as \"Calle\", ";              // RazonSocial			
                sqlRequest += "e.NroCalle as \"Nro\", e.Piso, e.Depto, ";                                                                                // Mail				
                sqlRequest += "e.CodigoPostal as \"Cod Postal\", e.Ciudad ,  e.Telefono, e.NombreContacto as \"Contacto\", ";                                                     // DomCalle			
                sqlRequest += "(select r.Descripcion FROM PMS.RUBROS r where r.Id_Rubro = e.Id_Rubro) as \"Rubro\" , u.FechaCreacion as \"Fecha Creación\" ";                              // NroCalle			
                sqlRequest += " FROM PMS.USUARIOS u, PMS.EMPRESAS e";                                                                              // Piso				
                sqlRequest += " WHERE u.Id_Usuario = e.Id_Empresa ";                                                                               // Depto				
                if (razonSocial != null && razonSocial != "") sqlRequest += " and e.RazonSocial = @razonSocial";                                   // CodigoPostal		
                if (cuit != null && cuit != "") sqlRequest += " and e.Cuit_Empresa = @cuit";                                                       // Ciudad				
                if (email != null && email != "") sqlRequest += " and e.Mail = @email";                                                            // NombreContacto		
                SqlCommand command = new SqlCommand(sqlRequest, DBConn.Connection);                                                                // Telefono			
                if (razonSocial != null && razonSocial != "") command.Parameters.Add("@razonSocial", SqlDbType.NVarChar).Value = razonSocial;      // Id_Rubro			
                if (cuit != null && cuit != "") command.Parameters.Add("@cuit", SqlDbType.NVarChar).Value = cuit;
                if (email != null && email != "") command.Parameters.Add("@email", SqlDbType.NVarChar).Value = email;
               
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
                throw (new Exception("Error en la Busqueda de empresas: " + ex.Message));
            }
        }

        public DataTable BuscarClientes(string nombre, string apellido, int dni, string email)
        {
            try
            {
                var dt = new DataTable();
                DBConn.openConnection();
                String sqlRequest;
                sqlRequest = "SELECT u.Habilitado, u.Id_Usuario as \"Código Usuario\", u.User_Nombre as \"Nombre Usuario\", c.Nombre , c.Apellido, c.Tipo_Doc as \"Tipo Doc\" , ";//Id_Cliente		
                sqlRequest += " c.Dni_Cliente as \"Documento\", c.FechaNacimiento as \"Fecha Nacimiento\", c.Mail, c.DomCalle as \"Calle\","; //Dni_Cliente		
                sqlRequest += " c.NroCalle as \"Nro\", c.Piso, c.Depto, c.Cod_Postal as \"Cod Postal\", c.Telefono, u.FechaCreacion as \"Fecha Creación\"";  //Apellido		
                sqlRequest += " FROM PMS.USUARIOS u, PMS.Clientes c";                                                                               //Nombre			
                sqlRequest += " WHERE u.Id_Usuario = c.Id_Cliente ";                                                                                //FechaNacimiento	
                if (nombre != null && nombre != "") sqlRequest += " and c.Nombre = @nombre";                                                        //Mail			
                if (apellido != null && apellido != "") sqlRequest += " and c.Apellido = @apellido";                                                //DomCalle		
                if (dni != null && dni != 0) sqlRequest += " and c.Dni_Cliente = @dni";                                                             //NroCalle		
                if (email != null && email != "") sqlRequest += " and c.Mail = @email";                                                             //Piso			
                SqlCommand command = new SqlCommand(sqlRequest, DBConn.Connection);                                                                 //Depto			
                if (nombre != null && nombre != "") command.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = nombre;                           //Cod_Postal		
                if (apellido != null && apellido != "") command.Parameters.Add("@apellido", SqlDbType.NVarChar).Value = apellido;                   //Tipo_Doc		
                if (dni != null && dni != 0) command.Parameters.Add("@dni", SqlDbType.Int).Value = dni;                                        //Telefono		
                if (email != null && email != "") command.Parameters.Add("@email", SqlDbType.NVarChar).Value = email;

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
                throw (new Exception("Error en la busqueda de clientes" + ex.Message));
            }
        }

        public void ProcedureCliente(int tipo, int modo, int IdCod, string username, string password, string nombreRazon, string ApellidCui,
                                string Doccto,string tiporub, string fechaCiud, string mail, string telef, string direcc,
                                string nro, string piso, string dpto, string local, DateTime fechacreac)
        {
            try
            {
                
                var proc = "PMS.";
                if(modo == 0)
                {
                    proc += "ALTA_USUARIO_";
                }else
                {
                    proc += "MODIFICACION_USUARIO_";
                }
                if(tipo == 0)
                {
                    proc += "CLIENTE";
                }else
                {
                    proc += "EMPRESA";
                }
                DBConn.openConnection();
                using (SqlCommand cmd = new SqlCommand(proc, DBConn.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (modo == 1)
                    {
                        cmd.Parameters.Add("@Id_Usuario", SqlDbType.Int).Value = IdCod;
                    }
                    else
                    {
                        cmd.Parameters.Add("@FechaCreacion", SqlDbType.DateTime).Value = fechacreac;
                    }
                    cmd.Parameters.Add("@User_nombre", SqlDbType.VarChar).Value = username;
                    cmd.Parameters.Add("@User_Password", SqlDbType.VarChar).Value = password;
                    if(tipo == 0)
                    {                //Cliente    
                    cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = nombreRazon;
                    cmd.Parameters.Add("@Apellido", SqlDbType.VarChar).Value = ApellidCui;
                    cmd.Parameters.Add("@Dni_Cliente", SqlDbType.VarChar).Value = Doccto;
                    cmd.Parameters.Add("@Tipo_Dni", SqlDbType.VarChar).Value = tiporub;
                    cmd.Parameters.Add("@FechaNacimiento", SqlDbType.DateTime).Value = Convert.ToDateTime(fechaCiud);
                    }else
                    { //empresa
                    cmd.Parameters.Add("@RazonSocial", SqlDbType.VarChar).Value = nombreRazon;
                    cmd.Parameters.Add("@Cuit_Empresa", SqlDbType.VarChar).Value = ApellidCui;
                    cmd.Parameters.Add("@Contacto", SqlDbType.VarChar).Value = Doccto;
                    cmd.Parameters.Add("@Rubro", SqlDbType.VarChar).Value = tiporub;
                    cmd.Parameters.Add("@Ciudad", SqlDbType.VarChar).Value = fechaCiud;
                    }
                    cmd.Parameters.Add("@Mail", SqlDbType.VarChar).Value = mail;
                    cmd.Parameters.Add("@Telefono", SqlDbType.VarChar).Value = telef;
                    cmd.Parameters.Add("@DomCalle", SqlDbType.VarChar).Value =direcc;
                    cmd.Parameters.Add("@NroCalle", SqlDbType.Int).Value = Convert.ToInt32(nro);
                    cmd.Parameters.Add("@Piso", SqlDbType.Int).Value = Convert.ToInt32(piso);
                    cmd.Parameters.Add("@Depto", SqlDbType.VarChar).Value = dpto;
                    cmd.Parameters.Add("@CodigoPostal", SqlDbType.VarChar).Value = local;
                    //cmd.Parameters.Add("¨@Localidad", SqlDbType.VarChar).Value = local;
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
        public static object DbNullIfNull(object obj)
        {
            return obj != null ? obj : DBNull.Value;
        }
       

    }
    
     
}
