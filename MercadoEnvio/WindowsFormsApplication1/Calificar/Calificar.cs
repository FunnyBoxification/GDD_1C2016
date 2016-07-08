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
            this.user = UserSingleton.Instance.getUser();
            if (user == null)
            {
                MessageBox.Show("No se pudo recuperar el usuario");
                return;
            }
            ;
            Calificacion calificacionNegocio =  new Calificacion(SqlServerDBConnection.instance);

            dgvPendientes.DataSource = calificacionNegocio.GetComprasSinCalificar(user.userId);

            
            
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
    }
}
