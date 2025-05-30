using System;

namespace UESAN.INVES.CORE.Core.DTOs
{
    // DTO principal: contiene todos los datos del formulario
    public class FormularioInvestigacionDTO
    {
        public int FormularioId { get; set; }
        public string? Titulo { get; set; }
        public string? Descripcion { get; set; }
        public DateTime? FechaCreacion { get; set; }
    }

    // DTO solo con el ID del formulario
    public class FormularioInvestigacionIdDTO
    {
        public int FormularioId { get; set; }
    }

    // DTO para crear un nuevo formulario
    public class FormularioInvestigacionCreateDTO
    {
        public string? Titulo { get; set; }
        public string? Descripcion { get; set; }
        public DateTime? FechaCreacion { get; set; }
    }

    // DTO para actualizar un formulario existente
    public class FormularioInvestigacionUpdateDTO
    {
        public int FormularioId { get; set; }
        public string? Titulo { get; set; }
        public string? Descripcion { get; set; }
        public DateTime? FechaCreacion { get; set; }
    }

    // DTO para mostrar en un listado (sin descripción larga, por ejemplo)
    public class FormularioInvestigacionResumenDTO
    {
        public int FormularioId { get; set; }
        public string? Titulo { get; set; }
        public DateTime? FechaCreacion { get; set; }
    }
}
