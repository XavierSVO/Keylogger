using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Keylogger
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        static void Main()
        {
            //Activar servicio de windows
            //Crear el objeto del servicio base
            /* ServiceBase[] ServicesToRun;
             ServicesToRun = new ServiceBase[]
             {
                 new Service1()
             };
            //Ejecutar el servicio
             ServiceBase.Run(ServicesToRun);
            */
            //Habiliar el windows forms para hacer pruebas sin ejecutar el servicio
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmService());
        }
    }
}
