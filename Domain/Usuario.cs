using System;

namespace Domain
{
    public class Usuario
    {
        public string Login { get; set; }
        public string Nombre { get; set; }
        public string Clave { get; set; }

        public override string ToString()
        {
            return Login;
        }
    }
}
