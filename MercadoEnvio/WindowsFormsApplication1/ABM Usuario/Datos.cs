using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.ABM_Visibilidad
{
    public partial class Datos : UserControl
    {
        public string Mail { get{return tbxMail.Text;} set{tbxMail.Text = value;} }     
        public string Telefono { get{return tbxTelefono.Text;} set{tbxTelefono.Text = value;} } 
        public string Direccion { get{return tbxDireccion.Text;} set{tbxDireccion.Text = value;} }
        public string Nro { get{return tbxNro.Text;} set{tbxNro.Text = value;} }   
        public string Piso { get{return tbxPiso.Text;} set{tbxPiso.Text = value;} } 
        public string Dpto { get{return tbxDpto.Text;} set{tbxDpto.Text = value;} }     
        public string Localidad { get{return tbxLocalidad.Text;} set{tbxLocalidad.Text = value;} }
        

        public Datos()
        {
            InitializeComponent();
        }
    }
}
