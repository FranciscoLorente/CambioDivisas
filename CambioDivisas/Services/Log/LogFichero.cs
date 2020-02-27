using System;
using System.IO;

namespace CambioDivisas.Services.Log
{
    public class LogFichero : ILog
    {
        private readonly string _path;

        public LogFichero()
        {
            _path = AppDomain.CurrentDomain.BaseDirectory + "Log";
            Directory.CreateDirectory(_path);
        }

        public void EscribirEntrada(string mensaje)
        {
            var fecha = DateTime.Now.ToString("dd/MM/yyyy");
            var hora = DateTime.Now.ToString("HH:mm:ss");

            using (var sw = new StreamWriter(_path + "/log.txt", true))
            {
                sw.WriteLine("[" + fecha + " " + hora + "] " + mensaje);
            }
        }
    }
}