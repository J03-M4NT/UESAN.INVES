using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESAN.INVES.CORE.Core.DTOs
{
    public class SignInDTO
    {
        public string Correo { get; set; }
        public string Contraseña { get; set; }

    }

    public class SignInResponseDTO
    {
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }

        public int RolId { get; set; }
        public string NombreRol { get; set; }
        public bool Estado { get; set; }

        public string Token { get; set; }


    }


}
