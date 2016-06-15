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

namespace WindowsFormsApplication1.ABM_Usuario
{
    public partial class Listado_Usuarios : Form
    {
        public UsuariosNegocio usuNegocio { get; set; }
        public SqlServerDBConnection instance { get; set; }
        public Listado_Usuarios()
        {
            InitializeComponent();
        }

        private void Listado_Usuarios_Load(object sender, EventArgs e)
        {
            cbxTipo.Items.Add("Clientes");
            cbxTipo.Items.Add("Empresas");            
            cbxTipo.SelectedIndex = 0;

        }

        private void cbxTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxTipo.SelectedIndex == 1)
            {
                
                labelapell.Visible = false;
                txbApellido.Visible = false;
                txbNomRaz.Width = 230;
                txbNomRaz.Location = new System.Drawing.Point(268, 20);
                RefrescarCampos();
                labelDniCuit.Text = "CUIT";
                labelNombre.Text = "Razon Social";

            }
            else
            {
                txbNomRaz.Text = null;
                labelapell.Visible = true;
                txbApellido.Visible = true;
                txbNomRaz.Location = new System.Drawing.Point(238, 20);
                txbNomRaz.Width = 100;
                labelNombre.Text = "Nombre";
                labelDniCuit.Text = "DNI";
                RefrescarCampos();
            }
        }

        private void RefrescarCampos()
        {
            txbNomRaz.Text = "";
            txbApellido.Text = "";
            txbEmail.Text = "";
            txbDniCuit.Text = "";
            dgvUsuarios.Rows.Clear();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            RefrescarCampos();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                usuNegocio = new UsuariosNegocio(instance = new SqlServerDBConnection());
                if (cbxTipo.SelectedIndex == 1)
                {
                    dgvUsuarios.DataSource = usuNegocio.BuscarEmpresas(txbNomRaz.Text, txbDniCuit.Text, txbEmail.Text);
                }
                else
                {
                    int dni;
                    if(txbDniCuit.Text == ""){ dni = 0;}else{dni = Convert.ToInt32(txbDniCuit.Text);}
                    dgvUsuarios.DataSource = usuNegocio.BuscarClientes(txbNomRaz.Text, txbApellido.Text, dni, txbEmail.Text);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
              
        }


        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbxTipo.SelectedIndex == 0)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                    (e.KeyChar != '.'))
                {
                    e.Handled = true;
                }

                // only allow one decimal point
                //if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                //{
                //    e.Handled = true;
                //}
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            usuNegocio = new UsuariosNegocio(instance = new SqlServerDBConnection());
            var frm = new AltaModUsuarioForm(usuNegocio, cbxTipo.SelectedIndex);
            frm.Show();
            
        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            usuNegocio = new UsuariosNegocio(instance = new SqlServerDBConnection());
            if (cbxTipo.SelectedIndex == 1) //Empresa
            {
                var frm = new AltaModUsuarioForm(usuNegocio, cbxTipo.SelectedIndex,
                                                  Convert.ToString(dgvUsuarios.SelectedRows[0].Cells["Id_Usuario"].Value),                                                   
                                                  Convert.ToString(dgvUsuarios.SelectedRows[0].Cells["UserName"].Value), 
                                                  Convert.ToString(dgvUsuarios.SelectedRows[0].Cells["Passwod"].Value),
                                                  Convert.ToString(dgvUsuarios.SelectedRows[0].Cells["RazonSocial"].Value),
                                                  Convert.ToString(dgvUsuarios.SelectedRows[0].Cells["CUIT"].Value),
                                                  Convert.ToString(dgvUsuarios.SelectedRows[0].Cells["Coontacto"].Value),
                                                  Convert.ToString(dgvUsuarios.SelectedRows[0].Cells["Rubro"].Value),
                                                  Convert.ToString(dgvUsuarios.SelectedRows[0].Cells["Ciudad"].Value),
                                                  Convert.ToString(dgvUsuarios.SelectedRows[0].Cells["Mail"].Value),
                                                  Convert.ToString(dgvUsuarios.SelectedRows[0].Cells["Telefono"].Value),
                                                  Convert.ToString(dgvUsuarios.SelectedRows[0].Cells["Direccion"].Value),
                                                  Convert.ToString(dgvUsuarios.SelectedRows[0].Cells["Nro"].Value),
                                                  Convert.ToString(dgvUsuarios.SelectedRows[0].Cells["Piso"].Value),
                                                  Convert.ToString(dgvUsuarios.SelectedRows[0].Cells["Dpto"].Value),
                                                  Convert.ToString(dgvUsuarios.SelectedRows[0].Cells["Localidad"].Value));
                frm.Show();
            }
            else
            {
                var frm = new AltaModUsuarioForm(usuNegocio, cbxTipo.SelectedIndex,
                                                  Convert.ToString(dgvUsuarios.SelectedRows[0].Cells["Id_Usuario"].Value),       
                                                  Convert.ToString(dgvUsuarios.SelectedRows[0].Cells["UserName"].Value),
                                                  Convert.ToString(dgvUsuarios.SelectedRows[0].Cells["Passwod"].Value),
                                                  Convert.ToString(dgvUsuarios.SelectedRows[0].Cells["Nombre"].Value),
                                                  Convert.ToString(dgvUsuarios.SelectedRows[0].Cells["Apellido"].Value),
                                                  Convert.ToString(dgvUsuarios.SelectedRows[0].Cells["Documento"].Value),
                                                  Convert.ToString(dgvUsuarios.SelectedRows[0].Cells["Tipo"].Value),
                                                  Convert.ToString(dgvUsuarios.SelectedRows[0].Cells["FechaNac"].Value),
                                                  Convert.ToString(dgvUsuarios.SelectedRows[0].Cells["Mail"].Value),
                                                  Convert.ToString(dgvUsuarios.SelectedRows[0].Cells["Telefono"].Value),
                                                  Convert.ToString(dgvUsuarios.SelectedRows[0].Cells["Direccion"].Value),
                                                  Convert.ToString(dgvUsuarios.SelectedRows[0].Cells["Nro"].Value),
                                                  Convert.ToString(dgvUsuarios.SelectedRows[0].Cells["Piso"].Value),
                                                  Convert.ToString(dgvUsuarios.SelectedRows[0].Cells["Dpto"].Value),
                                                  Convert.ToString(dgvUsuarios.SelectedRows[0].Cells["Localidad"].Value));
                frm.Show();
            }
        }


    }
}
