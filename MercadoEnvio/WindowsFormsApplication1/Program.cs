﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.ABM_Rol;
using WindowsFormsApplication1.Facturas;
using WindowsFormsApplication1.Historial_Cliente;
using WindowsFormsApplication1.Listado_Estadistico;


namespace WindowsFormsApplication1
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //SqlServerDBConnection.Instance().openConnection();
            Application.Run(new Listado_Estadistico.SeleccionAnioYTrimestreForm());
        }
    }
}
