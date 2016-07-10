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
    public partial class AltaModVisibForm : Form
    {
        String tipo;
        private VisibilidadesNegocio visibNegocio1;
        public int IdCod { get; set; }
        
        
        public VisibilidadesNegocio visibNegocio { get; set; }

       

        public AltaModVisibForm(MercadoNegocio.VisibilidadesNegocio visibNegocio)
        {
            // TODO: Complete member initialization
            this.Text = "Alta";
            InitializeComponent();
            this.visibNegocio = visibNegocio;
            
        }

        public AltaModVisibForm(VisibilidadesNegocio visibNegocio1, int IdCod, string Desc, int Porc, int Precio)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.visibNegocio = visibNegocio1;
            this.Text = "Modificar Visibalidad: Codigo " + IdCod.ToString();
            this.visibNegocio1 = visibNegocio1;
            this.IdCod = IdCod;
            txbDesc.Text = Desc;
            txbPorc.Text = Porc.ToString();
            txbPrecio.Text = Precio.ToString();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                if (IdCod == null || IdCod == 0)
                {
                    visibNegocio.AltaVisibilidad(txbDesc.Text, Convert.ToDecimal(txbPorc.Text), Convert.ToDecimal(txbPorc.Text));

                }
                else
                {
                    visibNegocio.ModifVisibilidad(IdCod, txbDesc.Text, Convert.ToDecimal(txbPorc.Text), Convert.ToDecimal(txbPorc.Text));
                }
                MessageBox.Show("Se ha grabado correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
