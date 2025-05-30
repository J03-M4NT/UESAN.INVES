using System;

namespace UESAN.INVES.CORE.Core.DTOs
{
    public class AsignacionesDTO
    {
        public int AsignacionId { get; set; }
        public int? UsuarioId { get; set; }
        public int? PublicacionId { get; set; }
        public string? Estado { get; set; }
        public DateTime? FechaAsignacion { get; set; }
    }
}