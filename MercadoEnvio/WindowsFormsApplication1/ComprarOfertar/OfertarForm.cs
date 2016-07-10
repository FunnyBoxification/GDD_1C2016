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

namespace WindowsFormsApplication1.ComprarOfertar
{
    public partial class OfertarForm : Form
    {
        public DataGridViewRow selRow { get; set; }

        public OfertarForm(DataGridViewRow selectedRow)
        {
            InitializeComponent();
            this.selRow = selectedRow;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int parsedValue;
            if (!int.TryParse(textBox1.Text, out parsedValue))
            {
                MessageBox.Show("Debes ingresar numeros");
                return;
            }
            else if (parsedValue <= Int32.Parse(selRow.Cells["Precio"].Value.ToString()))
            {
                MessageBox.Show("La oferta debe superar el precio actual");
                return;
            }
            else
            {
                var comprarOfertarNegocio = new ComprarOfertarNegocio(SqlServerDBConnection.Instance());
                comprarOfertarNegocio.Ofertar(UsuarioLogueado.Instance().userId, selRow.Cells["Codigo"].Value.ToString(), parsedValue);
                this.Close();
            }
        }
    }
}
