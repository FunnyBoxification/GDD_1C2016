using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MercadoEN;
using MercadoNegocio;

namespace WindowsFormsApplication1
{
    public partial class SelectRolForm : Form
    {

        private String rolSelected { get; set; }
        private int userId { get; set; }
        
        public SelectRolForm()
        {
            InitializeComponent();
        }


        public SelectRolForm(DataTable dt, int userId)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            dgvRoles.AutoGenerateColumns = true;
            dgvRoles.DataSource = dt;
            dgvRoles.DataMember = dt.TableName;
          

        }


    

        private void btContinuar_Click(object sender, EventArgs e)
        {

            if (dgvRoles.SelectedRows.Count != 0)
            {
                DataGridViewRow row = dgvRoles.SelectedRows[0];
                rolSelected = row.Cells[0].Value.ToString();
                Principal.PaginaPrincipal form = new Principal.PaginaPrincipal(rolSelected, userId);
                this.Hide();
                form.ShowDialog();
            }

           
        }
    }
}
