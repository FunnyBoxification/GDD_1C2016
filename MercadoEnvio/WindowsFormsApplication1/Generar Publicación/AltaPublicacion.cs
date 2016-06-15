﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MercadoNegocio;
using MercadoEN;

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
            InitializeComponent();

            foreach (DataRow row in publNegocio.obtenerVisibilidades().Rows)
            {
                var item = new ComboboxItem();
                item.Text = row["Descripcion"].ToString();
                item.Value = Int32.Parse(row["Id_Visibilidad"].ToString());

                this.cbxVisibilidad.Items.Add(item);
            }

            foreach (DataRow row in publNegocio.getRubros().Rows)
            {
                var item = new ComboboxItem();
                item.Text = row["Descripcion"].ToString();
                item.Value = Int32.Parse(row["Id_Rubro"].ToString());

                this.cbxRubro.Items.Add(item);
            }

            foreach (DataRow row in publNegocio.getTipos().Rows)
            {
                var item = new ComboboxItem();
                item.Text = row["Descripcion"].ToString();
                item.Value = Int32.Parse(row["Id_Tipo"].ToString());

                this.cbxTipo.Items.Add(item);
            }

            this.publNegocio = publNegocio;
            this.Tipo = tipo;


            /**
             * ACA FIJARSE SI ES ALTA O MODIFICACION, EN EL CASO QUE SEA MODIFICACION, SETEAR 
             * LA DATA CORRESPONDIENTE DE LA PUBLICACION
             * */
        }

        private void AltaPublicacion_Load(object sender, EventArgs e)
        {
            tbxVendedor.Enabled = false;
            dtpInicio.Enabled = false;
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
                var Id_Visibilidad = (this.cbxVisibilidad.SelectedItem as ComboboxItem) != null ? (this.cbxVisibilidad.SelectedItem as ComboboxItem).Value : -1;
                Int32 Id_Tipo = (this.cbxVisibilidad.SelectedItem as ComboboxItem) != null ? (this.cbxVisibilidad.SelectedItem as ComboboxItem).Value : -1;  //Falta pasarlo a combo
                var Id_Rubro = (this.cbxRubro.SelectedItem as ComboboxItem) != null ? (this.cbxRubro.SelectedItem as ComboboxItem).Value : -1; ; //Falta
                Int32 Id_Estado = 2; //El estado 2 Es el de borrador
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
