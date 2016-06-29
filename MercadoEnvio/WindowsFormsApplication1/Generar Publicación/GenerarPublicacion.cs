using MercadoNegocio;
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

namespace WindowsFormsApplication1.Generar_Publicación
{
    public partial class GenerarPublicacion : Form
    {
        public PublicacionesNegocio publNegocio { get; set; }
        public SqlServerDBConnection instance { get; set; }
        public GenerarPublicacion()
        {
            InitializeComponent();

            publNegocio = new PublicacionesNegocio(SqlServerDBConnection.Instance());
            

            foreach (DataRow row in publNegocio.getTipos().Rows)
            {
                //cbxTipo.Items.Add(trimestre[0]);
                var item = new ComboboxItem();
                item.Text = row["Descripcion"].ToString();
                item.Value = Int32.Parse(row["Id_Tipo"].ToString());

                cbxTipo.Items.Add(item);
            }

            if (UsuarioLogueado.Instance().rol == "Administrador")
            {
                btnGenerar.Enabled = false;
            }

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            tbxCod.Text = "";
            tbxDesc.Text = "";
            dataGridView1.DataSource = new DataTable(); 
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            publNegocio = new PublicacionesNegocio(instance = new SqlServerDBConnection());

            var frm = new AltaPublicacion(publNegocio, cbxTipo.SelectedIndex);
            frm.Show();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            publNegocio = new PublicacionesNegocio(SqlServerDBConnection.Instance());

            String TipoPublicacion = (cbxTipo.SelectedItem as ComboboxItem) != null ? (cbxTipo.SelectedItem as ComboboxItem).Text : null;
            String Id_Publicacion = tbxCod.Text != "" ? tbxCod.Text : null;
            String Descripcion = tbxDesc.Text != "" ? tbxDesc.Text : null;
            String userID = null;

            if (UsuarioLogueado.Instance().rol != "Adminstrador")
            {
                userID = UsuarioLogueado.Instance().userId;
            }

            dataGridView1.DataSource = publNegocio.BuscarPublicaciones(Id_Publicacion, TipoPublicacion, Descripcion,userID);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            publNegocio = new PublicacionesNegocio(instance = new SqlServerDBConnection());

            if (e.RowIndex != -1)
            {
                var idPublicacion = dataGridView1.Rows[e.RowIndex].Cells["Id_Publicacion"].Value.ToString();

                var frm = new AltaPublicacion(publNegocio, idPublicacion);
                frm.Show();
            }


        }

    }
}
