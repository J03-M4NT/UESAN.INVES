using System;

namespace UESAN.INVES.CORE.Core.DTOs
{
    // DTO principal: contiene todos los datos del formulario
    public class FormularioInvestigacionDTO
    {
        public int FormularioId { get; set; }
        public string? Dni { get; set; }
        public string? Apellidos { get; set; }
        public string? Nombres { get; set; }
        public string? GradoAcademico { get; set; }
        public DateOnly? FechaSolicitud { get; set; }
        public string? TituloProyecto { get; set; }
    }

    // DTO solo con el ID del formulario
    public class FormularioInvestigacionIdDTO
    {
        public int FormularioId { get; set; }
    }

    // DTO para crear un nuevo formulario
    public class FormularioInvestigacionCreateDTO
    {
        public string? Dni { get; set; }
        public string? Apellidos { get; set; }
        public string? Nombres { get; set; }
        public string? GradoAcademico { get; set; }
        public DateOnly? FechaSolicitud { get; set; }
        public string? TituloProyecto { get; set; }
    }

    // DTO para actualizar un formulario existente
    public class FormularioInvestigacionUpdateDTO
    {
        public int FormularioId { get; set; }
        public string? Dni { get; set; }
        public string? Apellidos { get; set; }
        public string? Nombres { get; set; }
        public string? GradoAcademico { get; set; }
        public DateOnly? FechaSolicitud { get; set; }
        public string? TituloProyecto { get; set; }
    }

    // DTO para mostrar en un listado (sin descripción larga, por ejemplo)
    public class FormularioInvestigacionResumenDTO
    {
        public int FormularioId { get; set; }
        public string? TituloProyecto { get; set; }
        public DateOnly? FechaSolicitud { get; set; }
    }
}
