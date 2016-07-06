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


namespace WindowsFormsApplication1
{
    public partial class LoginForm : Form
    {
        public LoginNegocio loginNegocio { get; set; }
        public SqlServerDBConnection instance { get; set; }
        public LoginForm()
        {
            InitializeComponent();
            SqlServerDBConnection instance = new SqlServerDBConnection();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btLogin_TextChanged(object sender, EventArgs e)
        {

        }


        private void btLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtPass.Text))
            {
                MessageBox.Show("Complete los campos por favor");
                return;
            }

            int PASSWORD_INVALID = -1;
            int USER_NOT_FOUND = -2;
            String user = txtUsuario.Text;
            //Connection.Connection.loginUser(txtUsername.Text, txtPassword.Text);

            //SqlServerDBConnection instance = SqlServerDBConnection.Instance();
             
            var loginNegocio = new LoginNegocio( instance = new SqlServerDBConnection());

            int userId = loginNegocio.loginUser(user, txtPass.Text);
            Boolean habilitado = loginNegocio.estaHabilitado(txtUsuario.Text);

            if (userId >= 0)
            {
                if (!habilitado)
                {
                    MessageBox.Show("Su usuario ha sido inhabilitado");
                    return;
                }

                
                loginNegocio.limpiarIntentos(user);
                MessageBox.Show("Usuario logueado exitosamente");
                UsuarioLogueado.Instance().userId = userId.ToString();
                DataTable dt = loginNegocio.getRolesDT(userId);
                UsuarioLogueado.Instance().rol = (dt.Rows[0][0]).ToString();
                this.Hide();
                if (dt.Rows.Count > 1)
                {
                    //Tiene mas de un rol el usuario, se debe elegir con cual quiere loguear
                    SelectRolForm form = new SelectRolForm(dt, userId);
                
                    form.ShowDialog();
               
                }
                else
                {
                    //TODO
                    //ACCEDER A la aplicacion el unico rol que tiene el usuario
                    Principal.PaginaPrincipal form = new Principal.PaginaPrincipal((dt.Rows[0][0]).ToString(),userId);
                    
                    form.ShowDialog();
                }
               
             
               

            }
            //El logueo fue rechazado
            else if (userId == USER_NOT_FOUND)
            {
                MessageBox.Show("El usuario especificado no existe");
            }

            else if (userId == PASSWORD_INVALID)
            {
                if (!habilitado)
                {
                    MessageBox.Show("Su usuario ha sido inhabilitado");
                    return;
                }

                //aumentar la cantidad de intentos fallidos               
                loginNegocio.incrementarIntentosLogin(txtUsuario.Text);
                decimal intentos = loginNegocio.getIntentosDeLogin(txtUsuario.Text);
                MessageBox.Show("Contraseña invalida, intentos : " + intentos);

            }

        }
    }
}
