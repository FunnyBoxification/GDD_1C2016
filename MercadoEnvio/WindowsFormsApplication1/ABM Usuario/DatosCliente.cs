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
    public partial class DatosCliente : UserControl
    {
         public string Nombre { get{return tbxNombre.Text;} set{tbxNombre.Text = value;} }
         public string Apellido { get{return tbxApellido.Text;} set{tbxApellido.Text = value;} }
         public string Documento { get{return tbxDocumento.Text;} set{tbxDocumento.Text = value;} }
         public string Tipo { get{return cbxTipo.SelectedText;} set{cbxTipo.SelectedText = value;} }
         public DateTime FechaNac { get{return dtpFechaNac.Value;} set{dtpFechaNac.Value = value;} }


        public DatosCliente()
        {
            InitializeComponent();
        }

        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            //// only allow one decimal point
            //if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            //{
            //    e.Handled = true;
            //}
        }
      
    }
}
