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
using MercadoEN;

namespace WindowsFormsApplication1.Generar_Publicación
{
    public partial class AltaPublicacion : Form
    {
        String tipo;
        private PublicacionesNegocio publNegocio;
       
        

        public int IdCod { get; set; }
        public int Tipo { get; set; } // compra 1  subasta 2
        public int Modo { get; set; } // alta 0  mod 1
        public int idPublicacion { get; set; }


        public VisibilidadesNegocio visibNegocio { get; set; }


        public AltaPublicacion()
        {
            InitializeComponent();
        }

        //En caso de modificacion
        public AltaPublicacion(PublicacionesNegocio publNegocio, String idPublicacion)
        {
            InitializeComponent();

            //Busco la info de la publicacion
            DataTable publicacionDt = publNegocio.BuscarPublicacionSeleccionada(idPublicacion);
            this.idPublicacion = Int32.Parse(publicacionDt.Rows[0]["Id_Publicacion"].ToString());
            if (publicacionDt.Rows[0]["Id_Estado"].ToString() == "3" || publicacionDt.Rows[0]["Id_Estado"].ToString() == "4")
            {
                this.cbxRubro.Enabled = false;
                this.cbxTipo.Enabled = false;
                this.cbxVisibilidad.Enabled = false;
                this.chbPreguntas.Enabled = false;
                this.dtpInicio.Enabled = false;
                this.dptVencimiento.Enabled = false;
                this.tbxCosto.Enabled = false;
                this.tbxDescripcion.Enabled = false;
                this.tbxPrecio.Enabled = false;
                this.tbxStock.Enabled = false;
                this.tbxVendedor.Enabled = false;
                if (publicacionDt.Rows[0]["Id_Estado"].ToString() == "4")
                {
                    this.cbxEstado.Enabled = false;
                }

            }

            foreach (DataRow row in publNegocio.obtenerVisibilidades().Rows)
            {
                var item = new ComboboxItem();
                item.Text = row["Descripcion"].ToString();
                item.Value = Int32.Parse(row["Id_Visibilidad"].ToString());

                this.cbxVisibilidad.Items.Add(item);
            }

            foreach (DataRow row in publNegocio.getEstados(idPublicacion).Rows)
            {
                var item = new ComboboxItem();
                item.Text = row["Descripcion"].ToString();
                item.Value = Int32.Parse(row["Id_Estado"].ToString());

                this.cbxEstado.Items.Add(item);
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
            //this.Tipo = tipo;

            tbxDescripcion.Text = publicacionDt.Rows[0]["Descripcion"].ToString();
            tbxCosto.Text = publicacionDt.Rows[0]["Precio"].ToString();
            tbxPrecio.Text = publicacionDt.Rows[0]["Precio"].ToString();
            tbxStock.Text = publicacionDt.Rows[0]["Stock"].ToString();
            if(UsuarioLogueado.Instance().rol == "Cliente" || UsuarioLogueado.Instance().rol == "Empresa") 
            {
                tbxVendedor.Enabled = false;
                //tbxVendedor.Text = UsuarioLogueado.Instance().userId;
            }
            tbxVendedor.Text = publicacionDt.Rows[0]["Id_Usuario"].ToString();
            dtpInicio.Value = DateTime.Parse(publicacionDt.Rows[0]["Fecha"].ToString());
            dptVencimiento.Value = DateTime.Parse(publicacionDt.Rows[0]["FechaVencimiento"].ToString());

            int a = 0;
            foreach (DataRow row in publNegocio.obtenerVisibilidades().Rows)
            {
                if (Int32.Parse(row["Id_Visibilidad"].ToString()).Equals(Int32.Parse(publicacionDt.Rows[0]["Id_Visibilidad"].ToString())))
                {
                    cbxVisibilidad.SelectedIndex = a;
                }
                a++;
            }

            a = 0;
            foreach (DataRow row in publNegocio.getRubros().Rows)
            {
                if (Int32.Parse(row["Id_Rubro"].ToString()).Equals(Int32.Parse(publicacionDt.Rows[0]["Id_Rubro"].ToString())))
                {
                    cbxRubro.SelectedIndex = a;
                }
                a++;
            }

            a = 0;
            foreach (DataRow row in publNegocio.getEstados(idPublicacion).Rows)
            {
                if (Int32.Parse(row["Id_Estado"].ToString()).Equals(Int32.Parse(publicacionDt.Rows[0]["Id_Estado"].ToString())))
                {
                    cbxEstado.SelectedIndex = a;
                }
                a++;
            }


            cbxTipo.SelectedIndex = Int32.Parse(publicacionDt.Rows[0]["Id_Tipo"].ToString());
            a = 0;
            foreach (DataRow row in publNegocio.getTipos().Rows)
            {
                if (Int32.Parse(row["Id_Tipo"].ToString()).Equals(Int32.Parse(publicacionDt.Rows[0]["Id_Tipo"].ToString())))
                {
                    cbxTipo.SelectedIndex = a;
                }
                a++;
            }

            chbPreguntas.Checked = Int32.Parse(publicacionDt.Rows[0]["AceptaPreguntas"].ToString()) == 1;
            this.Modo = 0;
        }

        public AltaPublicacion(PublicacionesNegocio publNegocio, int tipo)
        {
            // TODO: Complete member initialization
            InitializeComponent();

            cbxEstado.Enabled = false;

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

            foreach (DataRow row in publNegocio.getEstados(null).Rows)
            {
                var item = new ComboboxItem();
                item.Text = row["Descripcion"].ToString();
                item.Value = Int32.Parse(row["Id_Estado"].ToString());

                this.cbxEstado.Items.Add(item);
            }

            foreach (DataRow row in publNegocio.getTipos().Rows)
            {
                var item = new ComboboxItem();
                item.Text = row["Descripcion"].ToString();
                item.Value = Int32.Parse(row["Id_Tipo"].ToString());

                this.cbxTipo.Items.Add(item);
            }

            if (UsuarioLogueado.Instance().rol == "Cliente" || UsuarioLogueado.Instance().rol == "Empresa")
            {
                tbxVendedor.Enabled = false;
                tbxVendedor.Text = UsuarioLogueado.Instance().userId;
            }

            this.publNegocio = publNegocio;
            this.Tipo = tipo;
            this.Modo = 1;

        }

        private void AltaPublicacion_Load(object sender, EventArgs e)
        {
            tbxVendedor.Enabled = false;
            dtpInicio.Enabled = false;
            tbxCosto.Enabled = false;
            
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
                var idPublicacion = this.Modo == 0 ? this.idPublicacion : -1;
                var Descripcion = this.tbxDescripcion.Text;
                var Stock = this.tbxStock.Text;
                var Fecha = this.dtpInicio.Value;
                var FechaVencimiento = this.dptVencimiento.Value;
                if (DateTime.Compare(Fecha, FechaVencimiento) >= 0)
                {
                    MessageBox.Show("La fecha de finalizacion debe ser posterior a la fecha de publicacion");
                    return;
                }
                var Precio = this.tbxPrecio.Text;
                int a;
                if (!Int32.TryParse(Precio,out a))
                {
                    MessageBox.Show("El precio debe ser un numero");
                    return;
                }
                var idUsuario = Int32.Parse(tbxVendedor.Text);
                var Id_Visibilidad = (this.cbxVisibilidad.SelectedItem as ComboboxItem) != null ? (this.cbxVisibilidad.SelectedItem as ComboboxItem).Value : -1;
                Int32 Id_Tipo = (this.cbxTipo.SelectedItem as ComboboxItem) != null ? (this.cbxTipo.SelectedItem as ComboboxItem).Value : -1;  //Falta pasarlo a combo
                var Id_Rubro = (this.cbxRubro.SelectedItem as ComboboxItem) != null ? (this.cbxRubro.SelectedItem as ComboboxItem).Value : -1; //Falta
                var AceptaPreguntas = this.chbPreguntas.Checked;
                Int32 Id_Estado = (this.cbxEstado.SelectedItem as ComboboxItem) != null ? (this.cbxEstado.SelectedItem as ComboboxItem).Value : -1; ; //El estado 2 Es el de borrador
                publNegocio.ProcedurePublicacion(idPublicacion, Tipo, this.Modo, idUsuario, 
                                                Descripcion,Stock,Fecha,
                                                FechaVencimiento,Precio,Id_Visibilidad,
                                                Id_Tipo,Id_Rubro,Id_Estado,AceptaPreguntas);
                if (Id_Estado == 4)
                {
                    //PopUp de facturacion
                    var formm = new FacturacionPublicacion(idPublicacion);
                    this.Hide();
                    formm.Show();
                }
               
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
    }
}
