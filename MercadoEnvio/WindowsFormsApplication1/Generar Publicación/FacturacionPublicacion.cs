using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MercadoNegocio;

namespace WindowsFormsApplication1.Generar_Publicación
{
    public partial class FacturacionPublicacion : Form
    {
        private PublicacionesNegocio publNegocio;

        public FacturacionPublicacion(int idPublicacion)
        {
            publNegocio = new PublicacionesNegocio(SqlServerDBConnection.Instance());
            InitializeComponent();
            var dt = publNegocio.facturacionPublicacion(idPublicacion);
            this.dataGridView1.DataSource = dt;
        }
    }
}
