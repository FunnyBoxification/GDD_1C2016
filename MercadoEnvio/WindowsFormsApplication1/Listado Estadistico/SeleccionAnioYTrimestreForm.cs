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
            /*var form = new ListadoEstadisticoForm();
            form.Show();*/
        }
    }
}
