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

            //Connection.Connection.loginUser(txtUsername.Text, txtPassword.Text);

            SqlServerDBConnection instance = SqlServerDBConnection.Instance();

            int userId = instance.loginUser(txtUsuario.Text, txtPass.Text);
            if (userId >= 0)
            {
                //TODO Limpiar intentos fallidos

                MessageBox.Show("Usuario logueado exitosamente");
               List<decimal> listRolIds= instance.getRolesIdByUserId(userId);

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
            else if (userId < 0) MessageBox.Show("Usuario invalido");
        }
    }
}
