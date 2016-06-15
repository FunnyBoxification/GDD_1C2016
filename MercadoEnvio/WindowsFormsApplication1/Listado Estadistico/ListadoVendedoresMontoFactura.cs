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

namespace WindowsFormsApplication1.Listado_Estadistico
{
    public partial class ListadoVendedoresMontoFactura : Form
    {
        public String anio;
        public String trimestre;

        public ListadoVendedoresMontoFactura(String anio, String trimestre)
        {
            InitializeComponent();
            this.anio = anio;
            this.trimestre = trimestre;

            var negocio = new ListadoEstadisticoNegocio(SqlServerDBConnection.Instance());
            this.dataGridView1.DataSource = negocio.getTop5VendedoresConMontoFacturado(anio, trimestre);
        }

    }
}
