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

namespace WindowsFormsApplication1.Principal
{
    public partial class PaginaPrincipal : Form
    {
        public List<String> ListaFuncionalidades;

        public String rol;
        public String passValue
        {
            get{return rol;}
            set { rol = value; }
        }

        public PaginaPrincipal()
        {
            InitializeComponent();
            var negocio = new MercadoNegocio.Principal(SqlServerDBConnection.Instance());
            ListaFuncionalidades = negocio.getFuncionalidades(rol);
            if (ListaFuncionalidades.Any(p => p.ToLower().Contains("rol"))){
                ABMRol.Visible = true;
            }
            if (ListaFuncionalidades.Any(p => p.ToLower().Contains("usuario")))
            {
                ABMUser.Visible = true;
            }
            if (ListaFuncionalidades.Any(p => p.ToLower().Contains("visibilidad")))
            {
                ABMVisibilidad.Visible = true;
            }
            if (ListaFuncionalidades.Any(p => p.ToLower().Contains("rubro")))
            {
                ABMRubro.Visible = true;
            }
            if (ListaFuncionalidades.Any(p => p.ToLower().Contains("factura")))
            {
                Facturas.Visible = true;
            }
            if (ListaFuncionalidades.Any(p => p.ToLower().Contains("compra")))
            {
                ComprarOfertar.Visible = true;
            }
            if (ListaFuncionalidades.Any(p => p.ToLower().Contains("publica")))
            {
                ABMPublicacion.Visible = true;
            }
            if (ListaFuncionalidades.Any(p => p.ToLower().Contains("historial")))
            {
                Historial.Visible = true;
            }
            if (ListaFuncionalidades.Any(p => p.ToLower().Contains("lsitado")))
            {
                Listado.Visible = true;
            }
            if (ListaFuncionalidades.Any(p => p.ToLower().Contains("calificar")))
            {
                Calificar.Visible = true;
            }

        }

        private void ABMRol_Click(object sender, EventArgs e)
        {
            WindowsFormsApplication1.ABM_Rol.Listado_Roles FormRol = new WindowsFormsApplication1.ABM_Rol.Listado_Roles();
            FormRol.Show();
        }

        private void ABMUser_Click(object sender, EventArgs e)
        {
            WindowsFormsApplication1.ABM_Rol.Listado_Roles FormRol = new WindowsFormsApplication1.ABM_Rol.Listado_Roles();
            FormRol.Show();
        }

        private void ABMRubro_Click(object sender, EventArgs e)
        {
            WindowsFormsApplication1.ABM_Rol.Listado_Roles FormRol = new WindowsFormsApplication1.ABM_Rol.Listado_Roles();
            FormRol.Show();
        }

        private void ABMVisibilidad_Click(object sender, EventArgs e)
        {
            WindowsFormsApplication1.ABM_Rol.Listado_Roles FormRol = new WindowsFormsApplication1.ABM_Rol.Listado_Roles();
            FormRol.Show();
        }

        private void ABMPublicacion_Click(object sender, EventArgs e)
        {
            WindowsFormsApplication1.ABM_Rol.Listado_Roles FormRol = new WindowsFormsApplication1.ABM_Rol.Listado_Roles();
            FormRol.Show();
        }

        private void ComprarOfertar_Click(object sender, EventArgs e)
        {
            WindowsFormsApplication1.ABM_Rol.Listado_Roles FormRol = new WindowsFormsApplication1.ABM_Rol.Listado_Roles();
            FormRol.Show();
        }

        private void Calificar_Click(object sender, EventArgs e)
        {
            WindowsFormsApplication1.ABM_Rol.Listado_Roles FormRol = new WindowsFormsApplication1.ABM_Rol.Listado_Roles();
            FormRol.Show();
        }

        private void Historial_Click(object sender, EventArgs e)
        {
            WindowsFormsApplication1.ABM_Rol.Listado_Roles FormRol = new WindowsFormsApplication1.ABM_Rol.Listado_Roles();
            FormRol.Show();
        }

        private void Listado_Click(object sender, EventArgs e)
        {
            WindowsFormsApplication1.ABM_Rol.Listado_Roles FormRol = new WindowsFormsApplication1.ABM_Rol.Listado_Roles();
            FormRol.Show();
        }

        private void Facturas_Click(object sender, EventArgs e)
        {
            WindowsFormsApplication1.ABM_Rol.Listado_Roles FormRol = new WindowsFormsApplication1.ABM_Rol.Listado_Roles();
            FormRol.Show();
        }
    }
}
