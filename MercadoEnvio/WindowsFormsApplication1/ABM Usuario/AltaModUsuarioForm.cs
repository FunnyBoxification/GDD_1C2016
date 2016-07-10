using MercadoNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.ABM_Visibilidad;
using System.Configuration;
using System.Collections.Specialized;

namespace WindowsFormsApplication1.ABM_Usuario
{
    public partial class AltaModUsuarioForm : Form
    {

        String tipo;
        private UsuariosNegocio UsuNegocio;
        int modo;
        public string rubro { get; set; }
        private UsuariosNegocio usuNegocio;

        public int IdCod { get; set; }
        public int Tipo { get; set; }
        
        
        public VisibilidadesNegocio visibNegocio { get; set; }

       

        public AltaModUsuarioForm(MercadoNegocio.UsuariosNegocio usuNegocio, int tipo)
        {
            // TODO: Complete member initialization
            IdCod = 0;
            this.Text = "Alta";
            InitializeComponent();
            this.UsuNegocio = usuNegocio;
            Tipo = tipo;
            if (Tipo == 1)
            {
                
                cargarRubros();
            }
        }

        

        public AltaModUsuarioForm(UsuariosNegocio usuNegocio,int tipo, string idCod, string userNamer, string RazonSocialNombre, 
                            string cuitApellido, string contactoDto,  string rubroTipo, string ciudadFechaNac, string mail, string telefono,
                            string direccion, string nro, string piso, string dpto,  string CodPostal)
        {
            InitializeComponent();
            this.UsuNegocio = usuNegocio;
           
            Tipo = tipo;
            if (Tipo == 1)
            {
                this.Text = "Modificar Empresa: Codigo " + IdCod.ToString();
                cargarRubros();
            }
            else
            {
                this.Text = "Modificar Cliente: Codigo " + IdCod.ToString();
            }
            // TODO: Complete member initialization
            this.txbUsername.Text = userNamer;
            this.usuNegocio = usuNegocio;
           // this.txbPassw.Text = Password;
            CargarDatosPropios(tipo,RazonSocialNombre, cuitApellido, contactoDto, rubroTipo, ciudadFechaNac);
            this.datos1.Mail = mail;
            this.datos1.Telefono = telefono;
            this.datos1.Direccion = direccion;
            this.datos1.Nro = nro;
            this.datos1.Piso = piso;
            this.datos1.Dpto = dpto;
            this.datos1.Localidad = CodPostal;
            this.IdCod = Convert.ToInt32(idCod);
        }

        private void cargarRubros()
        {
            var dt = UsuNegocio.ObtenerRubros();
            this.datosEmpresa1.dtRubros = dt;
        }

        private void CargarDatosPropios(int tipo, string RazonSocialNombre, string cuitApellido, string contactoDto, string rubroTipo, string ciudadFechaNac)
        {
            if (tipo == 1)
            {
                this.datosEmpresa1.RazonSocial = RazonSocialNombre;
                this.datosEmpresa1.Cuit = cuitApellido;
                this.datosEmpresa1.Contacto = contactoDto;

                rubro = rubroTipo;
                this.datosEmpresa1.Ciudad = ciudadFechaNac;
            }
            else
            {
                this.datosCliente1.Nombre = RazonSocialNombre;
                this.datosCliente1.Apellido = cuitApellido;
                this.datosCliente1.Documento = contactoDto;
                this.datosCliente1.Tipo = rubroTipo;
                this.datosCliente1.FechaNac = Convert.ToDateTime(ciudadFechaNac);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (IdCod != null) { modo = 0; } else { modo = 1; };

                if (Tipo == 0)
                {
                    UsuNegocio.ProcedureCliente(Tipo, modo, IdCod,
                                           txbUsername.Text,
                                           txbPassw.Text,
                                           datosCliente1.Nombre,
                                           datosCliente1.Apellido,
                                           datosCliente1.Documento,
                                           datosCliente1.Tipo,
                                           datosCliente1.FechaNac.ToString(),
                                           datos1.Mail,
                                           datos1.Telefono,
                                           datos1.Direccion,
                                           datos1.Nro,
                                           datos1.Piso,
                                           datos1.Dpto,
                                           datos1.Localidad,
                                           DateTime.Parse(ConfigurationManager.AppSettings["FechaDelDia"]));



                }
                else
                {
                    UsuNegocio.ProcedureCliente(Tipo, modo, IdCod,
                                             txbUsername.Text,
                                             txbPassw.Text,
                                               datosEmpresa1.RazonSocial,
                                               datosEmpresa1.Cuit,
                                               datosEmpresa1.Contacto,
                                               datosEmpresa1.Rubro,
                                               datosEmpresa1.Ciudad,
                                               datos1.Mail,
                                               datos1.Telefono,
                                               datos1.Direccion,
                                               datos1.Nro,
                                               datos1.Piso,
                                               datos1.Dpto,
                                               datos1.Localidad,
                                               DateTime.Parse(ConfigurationManager.AppSettings["FechaDelDia"]));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AltaModUsuarioForm_Load(object sender, EventArgs e)
        {
            if (Tipo == 0)
            {
                datosEmpresa1.Visible = false;
                this.Text = "Alta Cliente";
            }
            else
            {
                this.Text = "Alta Empresa";
                datosCliente1.Visible = false;
                this.datosEmpresa1.Rubro = rubro;
                this.datosEmpresa1.Location = new System.Drawing.Point(this.datosEmpresa1.Location.X , this.datosEmpresa1.Location.Y-25);
                this.datosEmpresa1.Height = this.datosEmpresa1.Height + 15;
            }

            if (IdCod != null)
            {
                txbUsername.Enabled = false;
            }
        }

        
    }
}
