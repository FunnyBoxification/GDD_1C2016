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
    public partial class ComprarForm : Form
    {
        public DataGridViewRow selRow { get; set; }

        public ComprarForm(DataGridViewRow selectedRow)
        {
            InitializeComponent();
            this.selRow = selectedRow;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int parsedValue;
            if (!int.TryParse(textBox2.Text, out parsedValue))
            {
                MessageBox.Show("Debes ingresar numeros");
                return;
            }
            else if (parsedValue > Int32.Parse(selRow.Cells["Stock"].Value.ToString()))
            {
                MessageBox.Show("No puedes comprar esta cantidad de productos");
                return;
            }
            else
            {
                var comprarOfertarNegocio = new ComprarOfertarNegocio(SqlServerDBConnection.Instance());
                comprarOfertarNegocio.Comprar(UsuarioLogueado.Instance().userId, selRow.Cells["Id_Publicacion"].Value.ToString(), parsedValue);
                this.Close();
            }
        }
    }
}
