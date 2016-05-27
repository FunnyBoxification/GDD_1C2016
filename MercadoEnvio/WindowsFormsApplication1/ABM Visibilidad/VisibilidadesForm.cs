using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.ABM_Visibilidad
{
    public partial class VisibilidadesForm : Form
    {
        public VisibilidadesForm()
        {
            InitializeComponent();
        }

        private void limpiarbtn_Click(object sender, EventArgs e)
        {
            VisilidadesDG.Rows.Clear();
        }

        private void Buscarbtn_Click(object sender, EventArgs e)
        {

        }
    }
}
