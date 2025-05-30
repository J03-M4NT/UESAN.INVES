using System;

namespace UESAN.INVES.CORE.Core.DTOs
{
    public class UsuariosDTO
    {
        public int UsuarioId { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Correo { get; set; }
        public int RolId { get; set; }
        public bool? Estado { get; set; }
        public DateTime? FechaRegistro { get; set; }
    }
}