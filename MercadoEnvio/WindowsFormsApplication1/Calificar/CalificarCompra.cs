using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MercadoEN;
using MercadoNegocio;

namespace WindowsFormsApplication1.Calificar
{
    public partial class CalificarCompra : Form
    {
        Calificar calificar;
        int compraId;
        public CalificarCompra(int compraId, Calificar calificarForm)
        {
            InitializeComponent();
            this.compraId = compraId;
            this.calificar = calificarForm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int outParse;
            if (Int32.TryParse(txtEstrellas.Text, out outParse) && Int32.Parse(txtEstrellas.Text) > 0 && Int32.Parse(txtEstrellas.Text) <= 5)
            {
                Calificacion calNegocio = new Calificacion(SqlServerDBConnection.instance);
                String resultado = calNegocio.calificarCompra(compraId, txtComentario.Text, Int32.Parse(txtEstrellas.Text));
                MessageBox.Show("Compra calificada exitosamente");
                this.Close();
                calificar.Close();
                Calificar newCalificar = new Calificar();
                newCalificar.Show();

            }
            else
            {
                MessageBox.Show("Debe insertar un valor numerico en el campo de estrellas entre 1 y 5");
            }     
        }
    }
}
