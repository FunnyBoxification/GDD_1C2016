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
        
        public SelectRolForm()
        {
            InitializeComponent();
        }


        public SelectRolForm(DataTable dt)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            dgvRoles.AutoGenerateColumns = true;
            dgvRoles.DataSource = dt;
            dgvRoles.DataMember = dt.TableName;
          

        }
    }
}
