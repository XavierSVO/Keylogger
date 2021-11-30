using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
namespace Keylogger
{
    public class Log
    {
        public string victima_id { get; set; }
        public string log { get; set; }
    }

    public partial class Service1 : ServiceBase
    {
        private System.Timers.Timer tmProcess = null;
        private int i = 0;
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            tmProcess = new System.Timers.Timer();
            tmProcess.Interval = 1000;
            tmProcess.Elapsed += new System.Timers.ElapsedEventHandler(tmProcess_Elapsed);
            tmProcess.Enabled = true;
        }

        void tmProcess_Elapsed(object sender, System.Timers.ElapsedEventArgs e) {
            tmProcess.Enabled = false;
            ExecuteProcess();
        }
        private void ExecuteProcess() {
            i++;
            EventLog.WriteEntry("Se ejecuto el processo windows  " + i.ToString());
            tmProcess.Enabled = true;


            
        }

        protected override void OnStop()
        {
            EventLog.WriteEntry("Finalizo el servicio windows");
        }
    }
}
