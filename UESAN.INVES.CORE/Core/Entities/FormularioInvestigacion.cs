using System;
using System.Collections.Generic;

namespace UESAN.INVES.CORE.Core.Entities;

public partial class FormularioInvestigacion
{
    public int FormularioId { get; set; }

    public int? AsignacionId { get; set; }

    public string? CodigoProy { get; set; }

    public string? Dni { get; set; }

    public string? Apellidos { get; set; }

    public string? Nombres { get; set; }

    public string? GradoAcademico { get; set; }

    public DateOnly? FechaSolicitud { get; set; }

    public string? PosgradoPregrado { get; set; }

    public string? RegimenDedicacion { get; set; }

    public string? CategoriaRenacyt { get; set; }

    public string? TituloProyecto { get; set; }

    public string? NombrePublicacion { get; set; }

    public string? EditorialUniversidad { get; set; }

    public string? Pais { get; set; }

    public string? IssnIsbn { get; set; }

    public decimal? MontoApc { get; set; }

    public string? LineaInvestigacion { get; set; }

    public virtual Asignaciones? Asignacion { get; set; }
}
