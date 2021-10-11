using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        [HttpPost("login")]
        public string Login([FromQuery] string usuario, [FromQuery] string clave)
        {
            Logger.Logger.LogInfo($"Intento de Acceso {usuario}");

            // busco el usuario en el repositorio
            var usr = Persistence.UsuariosRepository.Get(usuario);
            if (usr == null)
                return "Usuario o Clave inválidos";

            // verifico que la clave coincida
            if(usr.Clave != clave)
                return "Usuario o Clave inválidos";

            return "OK";
        }
    }
}
