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
    public partial class SeleccionAnioYTrimestreForm : Form
    {
        public SeleccionAnioYTrimestreForm()
        {
            InitializeComponent();
            var negocio = new ListadoEstadisticoNegocio(SqlServerDBConnection.Instance());
            comboBox1.DataSource = negocio.getAniosPublicaciones();

            var trimestres = negocio.getTrimestres();
            foreach (var trimestre in trimestres)
            {
                comboBox2.Items.Add(trimestre);
            }

            var listados = negocio.getListados();
            foreach(var listado in listados) {
                comboBox3.Items.Add(listado);
            }
        }

        private void SeleccionAnioYTrimestreForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox3.SelectedText.Equals("Vendedores con prods no vendidos"))
            {
                var form = new ListadoEstadisticoForm();
                form.Show();
            }
            else if (comboBox3.SelectedText.Equals("Clientes con mayor cantidad de productos comprados"))
            {
                var form = new ListadoClientesComprasForm();
                form.Show();
            }
            else if (comboBox3.SelectedText.Equals("Vendedores con mayor cantidad de facturas"))
            {
                var form = new ListadoVendedoresCantidadFacturas();
                form.Show();
            }
            else
            {
                var form = new ListadoVendedoresMontoFactura();
                form.Show();
            }
        }
    }
}
