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

namespace WindowsFormsApplication1.ABM_Rol
{
    public partial class Modificacion_Rol : Form
    {
        public Int32 idRol;

        public Modificacion_Rol(Int32 id, String nombre,Int32 habilitado,List<String> funcionalidades)
        {
            InitializeComponent();

            idRol = id;

            this.textBox1.Text = nombre;

            var negocio = new RolesNegocio(SqlServerDBConnection.Instance());

            dataGridView1.DataSource = negocio.getAllFuncionalidades();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (funcionalidades.Contains(Convert.ToString(row.Cells["Nombre"])))
                    ((DataGridViewCheckBoxCell)row.Cells[0]).Value = true;
            }

            checkBox1.Checked = habilitado == 1 ? true : false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var negocio = new RolesNegocio(SqlServerDBConnection.Instance());
            var nombre = textBox1.Text;
            List<int> idsFuncionalidades = new List<int>();
            if (dataGridView1.SelectedRows.Count > 0)
            {
                negocio.deleteAllFuncionalidadesDeRol(idRol);
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    var id = Convert.ToInt32(row.Cells["Id_Funcionalidad"].Value);
                    negocio.insertFuncionalidadToRol(idRol, id);
                }
            }

            if (!checkBox1.Checked)
            {
                negocio.bajaRol(idRol);
            }
            else
            {
                negocio.habilitarRol(idRol);
            }
            this.Hide();

        }

    }
}
