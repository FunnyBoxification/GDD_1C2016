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

namespace WindowsFormsApplication1.ABM_Rubro
{
    public partial class Listado_Rubros : Form
    {
        public RubrosNegocio rubroNegocio { get; set; }
        public SqlServerDBConnection instance { get; set; }
        public Listado_Rubros()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
        
            
            try
            {
                //rubroNegocio = new RubrosNegocio(instance = new SqlServerDBConnection());
                //var IdCod = Convert.ToInt32(VisilidadesDG.SelectedRows[0].Cells["Id_Visibilidad"].Value);
                //var Desc = VisilidadesDG.SelectedRows[0].Cells["Descripcion"].Value.ToString();
                //var Porc = Convert.ToInt32(VisilidadesDG.SelectedRows[0].Cells["Porcentaje"].Value);
                //var Precio = Convert.ToInt32(VisilidadesDG.SelectedRows[0].Cells["Precio"].Value);

                var frm = new Altas_Rubros(rubroNegocio);
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Debe seleccionar la visibilidad del seleccionador a la izquierda. " + ex.Message);
            }
            Buscar();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dgvRubros.Rows.Clear();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            rubroNegocio = new RubrosNegocio(instance = new SqlServerDBConnection());
            dgvRubros.DataSource = rubroNegocio.ObtenerRubroListado(txbDescripcion.Text);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                rubroNegocio = new RubrosNegocio(instance = new SqlServerDBConnection());

                DataGridViewRow row = this.dgvRubros.SelectedRows[0];
                var a = row.Cells["Id_Visibilidad"].Value;
                rubroNegocio.DeleteRubro(Convert.ToInt32(dgvRubros.SelectedRows[0].Cells["Id_Rubro"].Value));
                Buscar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Debe seleccionar la visibilidad del seleccionador a la izquierda. " + ex.Message);
            }
            
        }
    }
}
