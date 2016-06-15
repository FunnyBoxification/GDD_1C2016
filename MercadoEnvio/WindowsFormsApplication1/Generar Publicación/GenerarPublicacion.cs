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

namespace WindowsFormsApplication1.Generar_Publicación
{
    public partial class GenerarPublicacion : Form
    {
        public PublicacionesNegocio publNegocio { get; set; }
        public SqlServerDBConnection instance { get; set; }
        public GenerarPublicacion()
        {
            InitializeComponent();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            tbxCod.Text = "";
            tbxDesc.Text = "";
            dgvPublicaciones.Rows.Clear();
            
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            publNegocio = new PublicacionesNegocio(instance = new SqlServerDBConnection());

            var frm = new AltaPublicacion(publNegocio, cbxTipo.SelectedIndex);
            frm.Show();
        }
    }
}
