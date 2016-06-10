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
            SqlServerDBConnection.Instance().openConnection();
            String select = "SELECT * FROM PMS.ROLES WHERE Id_Rol IS NOT NULL";
            SqlCommand command = new SqlCommand(select, SqlServerDBConnection.Instance().Connection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(select, SqlServerDBConnection.ConnectionString);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];
            SqlServerDBConnection.Instance().closeConnection();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Listado_Roles_Load(object sender, EventArgs e)
        {

            SqlServerDBConnection.Instance().openConnection();
            String select = "SELECT * FROM PMS.ROLES";
            SqlCommand command = new SqlCommand(select, SqlServerDBConnection.Instance().Connection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(select, SqlServerDBConnection.ConnectionString);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];
            SqlServerDBConnection.Instance().closeConnection();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

      /*  private void Form1_Load(object sender, EventArgs e)
        {
            String select = "SELECT * FROM PMS.ROLES";
            SqlCommand command = new SqlCommand(select, SqlServerDBConnection.Instance().Connection);
            this.dataGridView1;            
        }*/

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var form = new ABM_Rol.Alta_Rol();
            form.Show();
        }
    }
}
