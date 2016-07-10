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
    public partial class ListadoEstadisticoForm : Form
    {
        //TODO: se debe tirar la query en funcion de la visibilidad seleccionada

        public String anio;
        public String trimestre;

        public ListadoEstadisticoForm(String anio, String trimestre)
        {
            InitializeComponent();

            this.anio = anio;
            this.trimestre = trimestre;

            var negocio = new ListadoEstadisticoNegocio(SqlServerDBConnection.Instance());

            foreach (DataRow row in negocio.obtenerVisibilidades().Rows)
            {
                var item = new ComboboxItem();
                item.Text = row["Descripcion"].ToString();
                item.Value = Int32.Parse(row["Id_Visibilidad"].ToString());

                comboBox1.Items.Add(item);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var visibilidad = (this.comboBox1.SelectedItem as ComboboxItem) != null ? (this.comboBox1.SelectedItem as ComboboxItem).Value : -1;

            var negocio = new ListadoEstadisticoNegocio(SqlServerDBConnection.Instance());

            dataGridView1.DataSource = negocio.getTop5VendedoresConArticulosNoVendidos(anio, trimestre, visibilidad);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedItem = null;
            dataGridView1.DataSource = new DataTable();
        }
    }
}
