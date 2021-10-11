using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    public class LogInfo
    {
        public LogInfo()
        {
            Fecha = DateTime.Now;
        }

        public string Texto { get; set; }
        public DateTime Fecha { get; set; }
    }
}
