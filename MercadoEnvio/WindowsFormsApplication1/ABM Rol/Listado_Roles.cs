using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MercadoNegocio;

namespace WindowsFormsApplication1.ABM_Rol
{
    public partial class Listado_Roles : Form
    {
        public Listado_Roles()
        {
            InitializeComponent();
            var negocio = new RolesNegocio(SqlServerDBConnection.Instance());
            //negocio.searchRoles(null,-1);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = negocio.searchRoles(null, -1);
            SqlServerDBConnection.Instance().closeConnection();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Listado_Roles_Load(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            var negocio = new RolesNegocio(SqlServerDBConnection.Instance());
            var Nombre = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Nombre"].Value);
            var Habilitado = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Habilitado"].Value);
            var Id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Id_Rol"].Value);
            var funcionalidades = negocio.getFuncionalidadesDeRol(Id);

            var popupform = new Modificacion_Rol(Id,Nombre,Habilitado,funcionalidades);
            popupform.Show(); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var form = new ABM_Rol.Alta_Rol();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var negocio = new RolesNegocio(SqlServerDBConnection.Instance());
            var nombre = textBox1.Text != "" ? textBox1.Text : null;
            int Habilitado = comboBox1.SelectedIndex;
            dataGridView1.DataSource = negocio.searchRoles(nombre, Habilitado);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            comboBox1.SelectionLength = 0;
            var negocio = new RolesNegocio(SqlServerDBConnection.Instance());
            dataGridView1.DataSource = negocio.searchRoles(null, -1);

        }

    }
}
