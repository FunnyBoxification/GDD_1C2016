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

namespace WindowsFormsApplication1.Listado_Estadistico
{
    public partial class ListadoEstadisticoForm : Form
    {
        //TODO: se debe tirar la query en funcion de la visibilidad seleccionada

        public ListadoEstadisticoForm()
        {
            InitializeComponent();

            var negocio = new ListadoEstadisticoNegocio(SqlServerDBConnection.Instance());

            //Cargo las visibilidades
            comboBox1.DataSource = negocio.obtenerVisibilidades();
        }
    }
}
