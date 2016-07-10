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

namespace WindowsFormsApplication1.ABM_Visibilidad
{
    public partial class VisibilidadesForm : Form
    {

        public VisibilidadesNegocio visibNegocio { get; set; }
        public SqlServerDBConnection instance { get; set; }
        public VisibilidadesForm()
        {
            InitializeComponent();
        }

        private void limpiarbtn_Click(object sender, EventArgs e)
        {
            VisilidadesDG.Rows.Clear();
        }

        private void Buscarbtn_Click(object sender, EventArgs e)
        {
            try
            {
                
                Validaciones();
                Buscar();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void Buscar()
        {
            visibNegocio = new VisibilidadesNegocio(instance = new SqlServerDBConnection());
            VisilidadesDG.DataSource = visibNegocio.ObtenerVisibListado(txbCod.Text, txbDesc.Text, txbPorc.Text, txbPrecio.Text);
        }

        private void Validaciones()
        {
            //throw new NotImplementedException();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void Deletebutton1_Click(object sender, EventArgs e)
        {
            try
            {
                visibNegocio = new VisibilidadesNegocio(instance = new SqlServerDBConnection());

                DataGridViewRow row = this.VisilidadesDG.SelectedRows[0];
                var a = row.Cells["Id_Visibilidad"].Value;
                visibNegocio.DeleteVisib(Convert.ToInt32(VisilidadesDG.SelectedRows[0].Cells["Id_Visibilidad"].Value));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void Altabtn_Click(object sender, EventArgs e)
        {
            try
            {
                visibNegocio = new VisibilidadesNegocio(instance = new SqlServerDBConnection());

                var frm = new AltaModVisibForm(visibNegocio);
                frm.Show();
                Buscar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Modificarbtn_Click(object sender, EventArgs e)
        {
            try{
            visibNegocio = new VisibilidadesNegocio(instance = new SqlServerDBConnection());
            var IdCod = Convert.ToInt32(VisilidadesDG.SelectedRows[0].Cells["Id_Visibilidad"].Value);
            var Desc = VisilidadesDG.SelectedRows[0].Cells["Descripcion"].Value.ToString();
            var Porc = Convert.ToInt32(VisilidadesDG.SelectedRows[0].Cells["Porcentaje"].Value);
            var Precio = Convert.ToInt32(VisilidadesDG.SelectedRows[0].Cells["Precio"].Value);

            var frm = new AltaModVisibForm(visibNegocio, IdCod,Desc,Porc,Precio);
            frm.Show();
             }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Buscar();

        }

       
    }
}
