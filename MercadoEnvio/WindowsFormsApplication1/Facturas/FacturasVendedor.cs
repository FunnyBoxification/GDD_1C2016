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

namespace WindowsFormsApplication1.Facturas
{
    public partial class FacturasVendedor : Form
    {
        public FacturasVendedor()
        {
            InitializeComponent();
            var negocio = new HistorialVendedor(SqlServerDBConnection.Instance());
            superGrid1.PageSize = 5;
            superGrid1.SetPagedDataSource(negocio.searchFacturasAVendedor(-1, null,-1,-1,-1,-1), bindingNavigator1);
        }

        private void FacturasVendedor_Load(object sender, EventArgs e)
        {

        }

        private void superGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
