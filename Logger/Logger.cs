using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;

namespace Logger
{
    public class Logger
    {
        static Logger()
        {
            FileName = ConfigurationManager.AppSettings["fileName"];
        }

        private static readonly string FileName;

        public static void LogInfo(string texto)
        {
            var info = new LogInfo { Texto = texto };

            var file = File.AppendText(FileName);
            file.WriteLine($"{info.Fecha:g} - {info.Texto}");
            file.Close();
            file.Dispose();
        }
    }
}
