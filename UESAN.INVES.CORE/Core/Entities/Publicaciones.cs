using System;
using System.Collections.Generic;
namespace UESAN.INVES.CORE.Core.Entities;

public partial class Publicaciones
{
    public int PublicacionId { get; set; }

    public string? Issn { get; set; }

    public string? Issn2 { get; set; }

    public string? Issn3 { get; set; }

    public string? Nombre { get; set; }

    public int? CategoriaId { get; set; }

    public decimal? Puntaje { get; set; }

    public decimal? IncentivoUsd { get; set; }

    public DateOnly? FechaPublicacion { get; set; }

    public string? Estado { get; set; }

    public virtual ICollection<Asignaciones> Asignaciones { get; set; } = new List<Asignaciones>();

    public virtual Categorias? Categoria { get; set; }

    public virtual ICollection<PublicacionesGuardadas> PublicacionesGuardadas { get; set; } = new List<PublicacionesGuardadas>();
}
