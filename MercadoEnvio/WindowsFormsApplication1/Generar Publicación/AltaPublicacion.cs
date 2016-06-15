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

namespace WindowsFormsApplication1.Generar_Publicación
{
    public partial class AltaPublicacion : Form
    {
        String tipo;
        private PublicacionesNegocio publNegocio;
       
        

        public int IdCod { get; set; }
        public int Tipo { get; set; } // compra 1  subasta 2


        public VisibilidadesNegocio visibNegocio { get; set; }


        public AltaPublicacion()
        {
            InitializeComponent();
        }

        public AltaPublicacion(PublicacionesNegocio publNegocio, int tipo)
        {
            // TODO: Complete member initialization
            this.publNegocio = publNegocio;
            this.Tipo = tipo;
        }

        private void AltaPublicacion_Load(object sender, EventArgs e)
        {
            tbxVendedor.Enabled = false;
            dtpInicio.Enabled = false;
            tbxTipo.Enabled = false;
            tbxCosto.Enabled = false;
            
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            int modo;
            if (IdCod != null) {modo = 0; }else{ modo = 1;};
              
            if (Tipo == 1) //compra
            {
                var Descripcion = this.tbxDescripcion.Text;
                var Stock = this.tbxStock.Text;
                var Fecha = this.dtpInicio.ToString();
                var FechaVencimiento = this.dptVencimiento.ToString();
                var Precio = this.tbxPrecio.Text;
                String Id_Visibilidad = null; // Falta
                String Id_Tipo = null; //Falta
                String Id_Rubro = null; //Falta
                String Id_Estado = null; //Falta
                publNegocio.ProcedurePublicacion(Tipo, modo, IdCod, 
                                                Descripcion,Stock,Fecha,
                                                FechaVencimiento,Precio,Id_Visibilidad,
                                                Id_Tipo,Id_Rubro,Id_Estado);
                                           
                
               
                
            }
            else//Subasta
            {
                //publNegocio.ProcedurePublicacion(Tipo, modo, IdCod);
                                          //pasar datos );
            }
        }
        
    }
}
