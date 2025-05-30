using System;

namespace UESAN.INVES.CORE.Core.DTOs
{
    public class PublicacionesGuardadasDTO
    {
        public int Id { get; set; }
        public int? UsuarioId { get; set; }
        public int? PublicacionId { get; set; }
        public DateTime? FechaGuardado { get; set; }
    }
}