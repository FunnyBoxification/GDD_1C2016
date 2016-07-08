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

namespace WindowsFormsApplication1.ComprarOfertar
{
    public partial class ComprarOfertarListadoForm : Form
    {
        public ComprarOfertarNegocio comprarOfertarNegocio { get; set; }
       // public SqlServerDBConnection instance { get; set; }

        public ComprarOfertarListadoForm()
        {
            InitializeComponent();
            superGrid1.PageSize = 5;
            comprarOfertarNegocio = new ComprarOfertarNegocio(SqlServerDBConnection.Instance());
        
            var rubrosDt = comprarOfertarNegocio.getRubros();
            rubrosListBox.DisplayMember = rubrosDt.Columns[1].ColumnName;
            rubrosListBox.ValueMember = rubrosDt.Columns[0].ColumnName;
            rubrosListBox.DataSource = rubrosDt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var Descripcion = textBox1.Text == "" ? null : textBox1.Text;
            var Rubros = new List<String>();
            foreach (var item in rubrosListBox.SelectedItems)
            {
                Rubros.Add(((DataRowView)item)["Id_Rubro"].ToString());
            }
            var publicacionesDt = comprarOfertarNegocio.getPublicaciones(Descripcion, Rubros);

            this.superGrid1.SetPagedDataSource(publicacionesDt,this.bindingNavigator1);
        }

        private void compraOfertaBtn_Click(object sender, EventArgs e)
        {
            if (this.superGrid1.SelectedRows.Count == 1)
            {
                var selectedRow = this.superGrid1.SelectedRows[0];
                if (Int32.Parse(selectedRow.Cells["Id_Tipo"].Value.ToString()) == 1) //Compra directa
                {
                    //Mostrar Form para que elija cantidad y si quiere envio
                    var form = new ComprarForm(selectedRow);
                    form.Show();
                }
                else //Subasta
                {
                    //Mostrar Form chiquito para que ingrese cantidad a ofertar
                    var form = new OfertarForm(selectedRow);
                    form.Show();
                }
            }

        }
    }
}
