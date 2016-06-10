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
        public LoginNegocio loginNegocio { get; set; }
        public SqlServerDBConnection instance { get; set; }
        public SelectRolForm()
        {
            InitializeComponent();
        }


        public SelectRolForm(List<decimal> rolesIdList)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            var loginNegocio = new LoginNegocio(instance = new SqlServerDBConnection());
            foreach(decimal rolId in rolesIdList){
                Rol rol = loginNegocio.getRolById(rolId);
                rolesListBox.Items.Add(rol.nombre);
            }
            

        }
    }
}
