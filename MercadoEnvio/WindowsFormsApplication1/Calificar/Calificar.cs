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
    public partial class Calificar : Form
    {
        User user;
        public Calificar()
        {
            InitializeComponent();
            dgvPendientes.MultiSelect = false;
            
            this.user = UserSingleton.Instance.getUser();
            if (user == null)
            {
                MessageBox.Show("No se pudo recuperar el usuario");
                return;
            }
            ;
            Calificacion calificacionNegocio =  new Calificacion(SqlServerDBConnection.instance);

            int cantComprasRealizadas = 0;
            int cantComprasSinCalificar = 0;
            var dtComprasSinCalificar = new DataTable();

            dtComprasSinCalificar = calificacionNegocio.GetComprasSinCalificar(user.userId);
            cantComprasSinCalificar = dtComprasSinCalificar.Rows.Count;
            dgvPendientes.DataSource = dtComprasSinCalificar;

            cantComprasRealizadas = calificacionNegocio.getCantidadDeCompras(user.userId);
            lblComprasRealizadas.Text =  cantComprasRealizadas.ToString() + "  "  + "compra/s realizada/s";

            dgvUltimasCinco.DataSource = calificacionNegocio.getUltimasCincoCalificaciones(user.userId);


            lblCompras1.Text = calificacionNegocio.getCantidadDeComprasConXEstrellas(user.userId, 1).ToString();
            lblCompras2.Text = calificacionNegocio.getCantidadDeComprasConXEstrellas(user.userId, 2).ToString();
            lblCompras3.Text = calificacionNegocio.getCantidadDeComprasConXEstrellas(user.userId, 3).ToString();
            lblCompras4.Text = calificacionNegocio.getCantidadDeComprasConXEstrellas(user.userId, 4).ToString();
            lblCompras5.Text = calificacionNegocio.getCantidadDeComprasConXEstrellas(user.userId, 5).ToString();


            lblSubastas1.Text = calificacionNegocio.getCantidadDeSubastasConXEstrellas(user.userId, 1).ToString();
            lblSubastas2.Text = calificacionNegocio.getCantidadDeSubastasConXEstrellas(user.userId, 2).ToString();
            lblSubastas3.Text = calificacionNegocio.getCantidadDeSubastasConXEstrellas(user.userId, 3).ToString();
            lblSubastas4.Text = calificacionNegocio.getCantidadDeSubastasConXEstrellas(user.userId, 4).ToString();
            lblSubastas5.Text = calificacionNegocio.getCantidadDeSubastasConXEstrellas(user.userId, 5).ToString();


            lblComprasCalificadas.Text = (cantComprasRealizadas - cantComprasSinCalificar).ToString();

            lblCantSubastasSinCalificar.Text = calificacionNegocio.getCantidadDeSubastasCalificadas(user.userId).ToString();

           


            
        }


        private void dgvPendientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show("click");
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter_1(object sender, EventArgs e)
        {

        }

        private void btCalificarPendiente_Click(object sender, EventArgs e)
        {
            if (dgvPendientes.SelectedRows.Count != 0)
            {
                DataGridViewRow row = dgvPendientes.SelectedRows[0];
                String compra_id = row.Cells[0].Value.ToString();               
               CalificarCompra form =  new CalificarCompra(Int32.Parse(compra_id),this);
               form.Show();
            }
          

        }
    }
}
