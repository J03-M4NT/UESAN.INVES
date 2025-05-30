using System;

namespace UESAN.INVES.CORE.Core.DTOs
{
    public class FormularioInvestigacionDTO
    {
        public int FormularioId { get; set; }
        public string? Titulo { get; set; }
        public string? Descripcion { get; set; }
        public DateTime? FechaCreacion { get; set; }
    }
}