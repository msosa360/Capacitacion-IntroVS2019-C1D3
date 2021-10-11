using System;
using System.Collections.Generic;
using System.Linq;
using Domain;

namespace Persistence
{
    public static class UsuariosRepository
    {
        private static List<Usuario> Usuarios { get; set; } = new List<Usuario>();

        public static void Add(Usuario usuario)
        {
            foreach (var item in Usuarios)
            {
                if(item.Login == usuario.Login)
                {
                    throw new Exception("El usuario ya existe");
                }
            }
            
            Usuarios.Add(usuario);
        }

        public static void Update(Usuario usuario)
        {
            if (!Usuarios.Contains(usuario))
                throw new Exception("El usuario no existe");

            Usuario usuarioExistente = Usuarios.First(x => x.Login == usuario.Login);

            usuarioExistente.Clave = usuario.Clave;
            usuarioExistente.Nombre = usuario.Nombre;
        }


        public static void Delete(Usuario usuario)
        {
            if (!Usuarios.Contains(usuario))
                throw new Exception("El usuario no existe");

            Usuarios.Remove(usuario);
        }

        public static List<Usuario> List()
        {
            return Usuarios;
        }

        public static void LoadTestData()
        {
            Usuarios.Add(new Usuario { Login = "admin", Nombre = "Administrador", Clave = "1234", FechaNacimiento = DateTime.Today });
            Usuarios.Add(new Usuario { Login = "usr1", Nombre = "Usuario 1", Clave = "1234", FechaNacimiento = DateTime.Today });
            Usuarios.Add(new Usuario { Login = "usr2", Nombre = "Usuario 2", Clave = "1234", FechaNacimiento = DateTime.Today });
        }
    }
}
