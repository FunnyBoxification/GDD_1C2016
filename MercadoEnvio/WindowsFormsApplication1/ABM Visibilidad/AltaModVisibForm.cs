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
                Validar();
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

private void Validar()
{
                if (txbDesc.Text == "")
                { 
                    throw(new Exception("Debe ingresar una descripcion"));
                }
                if (txbPorc.Text == "")
                {
                    throw (new Exception("Debe ingresar una Porcentaje"));
                }
                if (txbPrecio.Text == "")
                {
                    throw (new Exception("Debe ingresar una Precio"));
                }
                try
                {
                    if (Convert.ToInt32(txbPorc.Text) >= 1 || Convert.ToInt32(txbPorc) <= 0)
                    {
                        throw (new Exception("Porcentaje debe estar entre 0 y 1"));
                    }
                }
                catch (Exception e)
                {
                    throw (new Exception("Porcentaje debe estar entre 0 y 1"));
                }
                try{    
                    if (Convert.ToInt32(txbPrecio.Text) <= 0)
                    { 
                        throw(new Exception("Precio debe ser un numero positivo"));
                    }
                }
                catch (Exception e)
                {
                    throw (new Exception("Precio debe ser un numero positivo"));
                }
}
    }
}
