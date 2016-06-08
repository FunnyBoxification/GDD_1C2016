using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApplication1
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btLogin_TextChanged(object sender, EventArgs e)
        {

        }







        private void btLogin_Click(object sender, EventArgs e)
        {
            int PASSWORD_INVALID = -1;
            int USER_NOT_FOUND = -2;
            String user = txtUsuario.Text;
            //Connection.Connection.loginUser(txtUsername.Text, txtPassword.Text);

            SqlServerDBConnection instance = SqlServerDBConnection.Instance();



            int userId = instance.loginUser(user, txtPass.Text);
            Boolean habilitado = instance.estaHabilitado(txtUsuario.Text);

            if (userId >= 0)
            {
                if (!habilitado)
                {
                    MessageBox.Show("Su usuario ha sido inhabilitado");
                    return;
                }

                //TODO Limpiar intentos fallidos
                instance.limpiarIntentos(user);
                MessageBox.Show("Usuario logueado exitosamente");
                List<decimal> listRolIds = instance.getRolesIdByUserId(userId);

                if (listRolIds.Count > 1)
                {
                    //Tiene mas de un rol el usuario, se debe elegir con cual quiere loguear
                    SelectRolForm form = new SelectRolForm(listRolIds);
                    form.ShowDialog();
                }
                else
                {
                    //TODO
                    //ACCEDER A la aplicacion el unico rol que tiene el usuario
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
                instance.incrementarIntentosLogin(txtUsuario.Text);
                decimal intentos = instance.getIntentosDeLogin(txtUsuario.Text);
                MessageBox.Show("Contraseña invalida, intentos : " + intentos);

            }

        }
    }
}
