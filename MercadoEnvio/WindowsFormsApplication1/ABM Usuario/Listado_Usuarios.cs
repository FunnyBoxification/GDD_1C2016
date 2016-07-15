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
        string RazonSocial = "", cuit = "", contacto = "", rubro = "", ciudad = "", nombre = "",
                    apellido = "", documento = "", tipo = "", fechanac = "", codusu ="", username ="";
string mail = "";
 string telefono = "";
 string Direccion ="";
 string nro = "";
 string piso = "";
 string dpto = "";
 string CodPost = "";

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
            try
            {
                txbNomRaz.Text = "";
                txbApellido.Text = "";
                txbEmail.Text = "";
                txbDniCuit.Text = "";
                dgvUsuarios.DataSource = null;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            RefrescarCampos();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
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
                    if (txbDniCuit.Text == "") { dni = 0; } else { dni = Convert.ToInt32(txbDniCuit.Text); }
                    dgvUsuarios.DataSource = usuNegocio.BuscarClientes(txbNomRaz.Text, txbApellido.Text, dni, txbEmail.Text);
                }

                dgvUsuarios.Columns[0].Width = 60;
                dgvUsuarios.Columns[0].HeaderText = "Hab";

                foreach (DataGridViewRow row in dgvUsuarios.Rows)
                {
                    if (Convert.ToDecimal(row.Cells[0].Value) == 1)
                    {
                        row.Cells[0].Style.BackColor = Color.Green;
                    }
                    else
                    {
                        row.Cells[0].Style.BackColor = Color.Red;
                    }
                }

            }
            catch (Exception ex)
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
            Buscar();
            
        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                usuNegocio = new UsuariosNegocio(instance = new SqlServerDBConnection());
                codusu = Convert.ToString(dgvUsuarios.Rows[e.RowIndex].Cells["Código Usuario"].Value);
                username = Convert.ToString(dgvUsuarios.Rows[e.RowIndex].Cells["Nombre Usuario"].Value);
                //var = Convert.ToString(dgvUsuarios.Rows[e.RowIndex].Cells["Passwod"].Value),.
                
                if (cbxTipo.SelectedIndex == 1) //Empresa
                {
                    RazonSocial = Convert.ToString(dgvUsuarios.Rows[e.RowIndex].Cells["Razon Social"].Value);
                    cuit = Convert.ToString(dgvUsuarios.Rows[e.RowIndex].Cells["CUIT"].Value);
                    contacto = Convert.ToString(dgvUsuarios.Rows[e.RowIndex].Cells["Contacto"].Value);
                    rubro = Convert.ToString(dgvUsuarios.Rows[e.RowIndex].Cells["Rubro"].Value);
                    ciudad = Convert.ToString(dgvUsuarios.Rows[e.RowIndex].Cells["Ciudad"].Value);
                }
                else
                {
                    nombre = Convert.ToString(dgvUsuarios.Rows[e.RowIndex].Cells["Nombre"].Value);
                    apellido = Convert.ToString(dgvUsuarios.Rows[e.RowIndex].Cells["Apellido"].Value);
                    documento = Convert.ToString(dgvUsuarios.Rows[e.RowIndex].Cells["Documento"].Value);
                    tipo = Convert.ToString(dgvUsuarios.Rows[e.RowIndex].Cells["Tipo Doc"].Value);
                    fechanac = Convert.ToString(dgvUsuarios.Rows[e.RowIndex].Cells["Fecha Nacimiento"].Value);
                }
                mail = Convert.ToString(dgvUsuarios.Rows[e.RowIndex].Cells["Mail"].Value);
                telefono = Convert.ToString(dgvUsuarios.Rows[e.RowIndex].Cells["Telefono"].Value);
                Direccion = Convert.ToString(dgvUsuarios.Rows[e.RowIndex].Cells["Calle"].Value);
                nro = Convert.ToString(dgvUsuarios.Rows[e.RowIndex].Cells["Nro"].Value);
                piso = Convert.ToString(dgvUsuarios.Rows[e.RowIndex].Cells["Piso"].Value);
                dpto = Convert.ToString(dgvUsuarios.Rows[e.RowIndex].Cells["Depto"].Value);
                CodPost = Convert.ToString(dgvUsuarios.Rows[e.RowIndex].Cells["Cod Postal"].Value);
                if (cbxTipo.SelectedIndex == 1) //Empresa
                {
                    var frm = new AltaModUsuarioForm(usuNegocio, cbxTipo.SelectedIndex,
                                                      codusu,
                                                      username,                    // r = Convert),
                                                      RazonSocial,
                                                      cuit,
                                                      contacto,
                                                      rubro,
                                                      ciudad,
                                                      mail,
                                                      telefono,
                                                      Direccion,
                                                      nro,
                                                      piso,
                                                      dpto,
                                                      CodPost);
                    frm.Show();
                }
                else
                {
                    var frm = new AltaModUsuarioForm(usuNegocio, cbxTipo.SelectedIndex,
                                                      codusu,
                                                      username,
                                                      nombre,
                                                      apellido,
                                                      documento,
                                                      tipo,
                                                      fechanac,
                                                      mail,
                                                      telefono,
                                                      Direccion,
                                                      nro,
                                                      piso,
                                                      dpto,
                                                      CodPost);
                    frm.Show(); ;
                    //frm.Show();
                    Buscar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en llamado a alta mod" + ex.Message);
            }
        }

        private void btnHabilitar_Click(object sender, EventArgs e)
        {
            try{

                usuNegocio = new UsuariosNegocio(instance = new SqlServerDBConnection());
                
                    usuNegocio.HabDeshabUsuario(Convert.ToString(dgvUsuarios.SelectedRows[0].Cells["Código Usuario"].Value), Convert.ToString(dgvUsuarios.SelectedRows[0].Cells["Habilitado"].Value));
                
                if (Convert.ToString(dgvUsuarios.SelectedRows[0].Cells["Habilitado"].Value) == "1"){
                    MessageBox.Show("Se ha deshabilitado el usuario");
                }else{
                    MessageBox.Show("Se ha habilitado el usuario");
                }
                Buscar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Debe seleccionar desde el seleccionador al a izquierda" +ex.Message);
            }
        }


    }
}
