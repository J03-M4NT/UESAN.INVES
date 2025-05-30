using System;

namespace UESAN.INVES.CORE.Core.DTOs
{
    public class PublicacionesDTO
    {
        public int PublicacionId { get; set; }
        public string? Titulo { get; set; }
        public string? Contenido { get; set; }
        public DateTime? FechaPublicacion { get; set; }
    }
}