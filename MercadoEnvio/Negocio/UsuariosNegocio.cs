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
    public class UsuariosNegocio
    {
        SqlServerDBConnection DBConn { get; set; }

        public UsuariosNegocio(SqlServerDBConnection dbConnection)
        {
            DBConn = dbConnection;
        }
       


        public void DeleteVisib(int IdVisib)
        {

            try
            {
                DBConn.openConnection();
                using (SqlCommand cmd = new SqlCommand("PMS.BAJA_VISIBILIDAD", DBConn.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@user", SqlDbType.VarChar).Value = IdVisib;
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



        public void AltaVisibilidad(string descripcion, Decimal porcentaje, Decimal precio)
        {
            try
            {
                DBConn.openConnection();
                using (SqlCommand cmd = new SqlCommand("PMS.ALTA_VISIBILIDAD", DBConn.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = descripcion;
                    cmd.Parameters.Add("@porcentaje", SqlDbType.Decimal).Value = porcentaje;
                    cmd.Parameters.Add("@precio", SqlDbType.Decimal).Value = precio;
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

        public void ModifVisibilidad(int IdCod, string descripcion, decimal porcentaje, decimal precio)
        {
            try
            {
                DBConn.openConnection();
                using (SqlCommand cmd = new SqlCommand("PMS.MODIFICACION_VISIBILIDAD", DBConn.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Id_Visibilidad", SqlDbType.VarChar).Value = descripcion;
                    cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = descripcion;
                    cmd.Parameters.Add("@porcentaje", SqlDbType.Decimal).Value = porcentaje;
                    cmd.Parameters.Add("@precio", SqlDbType.Decimal).Value = precio;
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


        public DataTable BuscarEmpresas(string razonSocial, string cuit, string email)
        {
            try
            {
                var dt = new DataTable();
                DBConn.openConnection();
                String sqlRequest;
                sqlRequest = "SELECT  u.Id_Usuarios, u.User_Nombre, u.User_Password, e.RAzonSocial, e.Cuit_Empresa, e.Mail, e.DomCalle, e.NroCalle, e.Piso, ";
                sqlRequest += "e.CodigoPostal, e.Telefono, e.Contacto, ";
                sqlRequest += "(select r.Descripcion FROM PMS.RUBROS where r.Id_Rubro = e.Id_Rubro), c.FechaCreacion,  u.Habilitado";
                sqlRequest += " FROM PMS.USUARIOS u, PMS.EMPRESAS e";
                sqlRequest += "WHERE u.Id_Usuario = e.Id_Empresa ";
                if (razonSocial != null || razonSocial != "") sqlRequest += " and e.RazonSocial = @razonSocial";
                if (cuit != null || cuit != "") sqlRequest += " and e.Cuit_Empresa = @cuit";
                if (email != null || email != "") sqlRequest += " and e.Mail = @email";
                SqlCommand command = new SqlCommand(sqlRequest, DBConn.Connection);
                if (razonSocial != null || razonSocial != "") command.Parameters.Add("@razonSocial", SqlDbType.NVarChar).Value = razonSocial;
                if (cuit != null || cuit != "") command.Parameters.Add("@cuit", SqlDbType.NVarChar).Value = cuit;
                if (email != null || email != "") command.Parameters.Add(" @email", SqlDbType.NVarChar).Value = email;
               
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

        public DataTable BuscarClientes(string nombre, string apellido, int dni, string email)
        {
            try
            {
                var dt = new DataTable();
                DBConn.openConnection();
                String sqlRequest;
                sqlRequest = "SELECT u.Id_Usuarios, u.User_Nombre, u.User_Password, c.Nombre, c.Apellido, c.Dni_Cliente, c.FechaNacimiento, c.Mail, c.DomCalle, c.NroCalle, c.Piso, c.CodigoPostal, c.Telefono, c.FechaCreacion, u.Habilitado";
                sqlRequest += " FROM PMS.USUARIOS u, PMS.Clientes c";
                sqlRequest += "WHERE u.Id_Usuarios = c.Id_Cliente ";
                if (nombre != null || nombre != "") sqlRequest += " and c.Nombre = @nombre";
                if (apellido != null || apellido != "") sqlRequest += " and c.Apellido = @apellido";
                if (dni != null || dni != 0) sqlRequest += " and c.Dni_Cliente = @dni";
                if (email != null || email != "") sqlRequest += " and c.Mail = @email";
                SqlCommand command = new SqlCommand(sqlRequest, DBConn.Connection);
                if (nombre != null || nombre != "") command.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = nombre;
                if (apellido != null || apellido != "") command.Parameters.Add("@apellido", SqlDbType.NVarChar).Value = apellido;
                if (dni != null || dni != 0) command.Parameters.Add("@apellido", SqlDbType.Int).Value = dni;
                if (email != null || email != "") command.Parameters.Add(" @email", SqlDbType.NVarChar).Value = email;

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
                                string nro, string piso, string dpto, string local)
        {
            try
            {
                var proc = "PMS.";
                if(modo == 0)
                {
                    proc += "ALTA_";
                }else
                {
                    proc += "MODIICACION_";
                }
                if(tipo == 0)
                {
                    proc += "CLIENTE";
                }else
                {
                    proc += "MODIICACION_";
                }
                DBConn.openConnection();
                using (SqlCommand cmd = new SqlCommand(proc, DBConn.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Id_Usuario", SqlDbType.Int).Value = IdCod;
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
                    {
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
