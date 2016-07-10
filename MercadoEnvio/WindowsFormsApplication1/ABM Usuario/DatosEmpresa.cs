using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.ABM_Usuario
{
    public partial class DatosEmpresa : UserControl
    {
         public string RazonSocial { get{return tbxRazonSocial.Text;} set{tbxRazonSocial.Text = value;} }
         public string Cuit { get{return tbxCuit.Text;} set{tbxCuit.Text = value;} }
         public string Contacto { get{return tbxContacto.Text;} set{tbxContacto.Text = value;} }
         public string Rubro { get{return  cbxRubro.Text;} set{cbxRubro.SelectedText = value;} }
         public string Ciudad { get{return tbxCiudad.Text;} set{tbxCiudad.Text = value;} }
         public DataTable dtRubros { get ;  set;  }
        
        public DatosEmpresa()
        {
            InitializeComponent();
           
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void DatosEmpresa_Load(object sender, EventArgs e)
        {
            cbxRubro.DataSource = dtRubros.DefaultView;
            cbxRubro.DisplayMember = "Descripcion";

            cbxRubro.BindingContext = this.BindingContext;
        }
        

    }
}
