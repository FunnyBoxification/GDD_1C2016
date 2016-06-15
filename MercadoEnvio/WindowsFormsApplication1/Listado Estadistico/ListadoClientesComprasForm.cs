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
using MercadoEN;

namespace WindowsFormsApplication1.Listado_Estadistico
{
    public partial class ListadoClientesComprasForm : Form
    {
        public String anio;
        public String trimestre;

        public ListadoClientesComprasForm(String anio, String trimestre)
        {
            InitializeComponent();
            this.anio = anio;
            this.trimestre = trimestre;

            var negocio = new ListadoEstadisticoNegocio(SqlServerDBConnection.Instance());

            foreach (DataRow row in negocio.getRubros().Rows)
            {
                var item = new ComboboxItem();
                item.Text = row["Descripcion"].ToString();
                item.Value = Int32.Parse(row["Id_Rubro"].ToString());

                comboBox1.Items.Add(item);
            }

        }

        private void ListadoClientesComprasForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var negocio = new ListadoEstadisticoNegocio(SqlServerDBConnection.Instance());
            var rubro = (this.comboBox1.SelectedItem as ComboboxItem) != null ? (this.comboBox1.SelectedItem as ComboboxItem).Value : -1;
            this.dataGridView1.DataSource = negocio.getTop5ClientesConArticulosComprados(anio, trimestre, rubro);
        }
    }
}
