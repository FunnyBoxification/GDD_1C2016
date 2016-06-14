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

namespace WindowsFormsApplication1.Historial_Cliente
{
    public partial class HistorialForm : Form
    {

        private int id_cliente { get; set; }
        private DataTable table { get; set; }

        public HistorialForm(int id_cliente)
        {
            InitializeComponent();
            this.id_cliente = id_cliente;
            var negocio = new HistorialCliente(SqlServerDBConnection.Instance());
            superGrid1.PageSize = 5;
            table = negocio.searchHistorialCliente(id_cliente,null,-1,-1,null,null);
            superGrid1.SetPagedDataSource(table, bindingNavigator1);
            lblCalificadas.Text = getCantidadOpsSinCalificar() + " compras sin calificar ";
            lblEstrellas.Text = negocio.getCantidadDeEstrellasDadas(id_cliente).ToString() + " estrellas dadas en total";


        }



        private int getCantidadOpsSinCalificar()
        {
            //table.Columns["Calificada"].ColumnName = "ASD";
            DataRow[] result = table.Select("Calificada  = 'No'");
            int c = 0;
            foreach (DataRow row in result)
            {
                c++;
            }
            return c;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var negocio = new HistorialCliente(SqlServerDBConnection.Instance());

            var Detalle = txtDetalle.Text;
            decimal importeDesde = numericUpDown2.Value;
            decimal importeHasta = numericUpDown1.Value;
            DateTime fechaDesde = dateTimePicker1.Value;
            DateTime fechaHasta = dateTimePicker2.Value;
            superGrid1.SetPagedDataSource(negocio.searchHistorialCliente(id_cliente,Detalle,importeHasta,importeDesde,
                                    fechaDesde.ToString("yyyy-MM-dd"), fechaHasta.ToString("yyyy-MM-dd")), bindingNavigator1);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
