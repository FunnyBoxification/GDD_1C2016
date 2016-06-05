using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.Entities;

namespace WindowsFormsApplication1
{
    public partial class SelectRolForm : Form
    {
        public SelectRolForm()
        {
            InitializeComponent();
        }


        public SelectRolForm(List<decimal> rolesIdList)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            foreach(decimal rolId in rolesIdList){
                Rol rol =SqlServerDBConnection.Instance().getRolById(rolId);
                rolesListBox.Items.Add(rol.nombre);
            }
            

        }
    }
}
