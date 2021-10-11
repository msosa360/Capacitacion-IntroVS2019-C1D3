using System;

namespace Domain
{
    public class Usuario
    {
        public string Login { get; set; }
        public string Nombre { get; set; }
        public string Clave { get; set; }
        public DateTime FechaNacimiento { get; set; } 
        public string Email { get; set; }

        public Usuario()
        {
            FechaNacimiento = DateTime.Today;
        }

        public override string ToString()
        {
            return Login;
        }
    }
}
