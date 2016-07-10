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

namespace WindowsFormsApplication1.Facturas
{
    public partial class FacturasVendedor : Form
    {
        public FacturasVendedor()
        {
            InitializeComponent();
            var negocio = new HistorialVendedor(SqlServerDBConnection.Instance());
            superGrid1.PageSize = 5;
            superGrid1.SetPagedDataSource(negocio.searchFacturasAVendedor(-1, null, -1, -1, null, null), bindingNavigator1);
        }

        private void FacturasVendedor_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var negocio = new HistorialVendedor(SqlServerDBConnection.Instance());
            var Id = textBox1.Text != "" ?  Int32.Parse(textBox1.Text) : -1;
            var Detalle = textBox2.Text;
            decimal importeDesde = numericUpDown2.Value;
            decimal importeHasta = numericUpDown1.Value;
            DateTime fechaDesde = dateTimePicker1.Value;
            DateTime fechaHasta = dateTimePicker2.Value;
            superGrid1.SetPagedDataSource(negocio.searchFacturasAVendedor(Id,Detalle,importeHasta,importeDesde,fechaHasta.ToString("yyyy-MM-dd"), fechaDesde.ToString("yyyy-MM-dd")),bindingNavigator1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text= null;
            numericUpDown2.Value = 0 ;
            numericUpDown1.Value = 0;

        }
    }
}
