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
using System.Data.SqlClient;

namespace WindowsFormsApplication1.ABM_Rol
{
    public partial class Alta_Rol : Form
    {
        public Alta_Rol()
        {
            InitializeComponent();

            var negocio = new LoginNegocio(SqlServerDBConnection.Instance());
            negocio.getAllFuncionalidades();
            listBox1.DisplayMember = "Nombre";
            listBox1.ValueMember = "Id_Funcionalidad";
            listBox1.DataSource = negocio.getAllFuncionalidades();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var negocio = new LoginNegocio(SqlServerDBConnection.Instance());

            negocio.insertRol();
            
            foreach (var item in listBox1.SelectedItems)
            {
                negocio.insertFuncionalidadToRol(1, (int) (item as DataRowView)["Id_Funcionalidad"] );

            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
