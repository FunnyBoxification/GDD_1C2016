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

namespace WindowsFormsApplication1.ABM_Rubro
{
    public partial class Altas_Rubros : Form
    {
        String tipo;
        private RubrosNegocio rubroNegocio1;
        public int IdCod { get; set; }
        
        
        public RubrosNegocio rubroNegocio { get; set; }



        public Altas_Rubros(MercadoNegocio.RubrosNegocio rubroNegocio)
        {
            // TODO: Complete member initialization
            this.Text = "Alta";
            InitializeComponent();
            this.rubroNegocio = rubroNegocio;
            
        }
      

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Validar();
               
                rubroNegocio.AltaRubro(txbDescripcion.Text);

                MessageBox.Show("Se ha grabado correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Validar()
        {
            if (txbDescripcion.Text == "")
            {
                throw new Exception("Debe ingresar una descrpicion");
            }
        }
    }
}
