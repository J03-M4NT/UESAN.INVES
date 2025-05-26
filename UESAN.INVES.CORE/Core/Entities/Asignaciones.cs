using System;
using System.Collections.Generic;

namespace UESAN.INVES.CORE.Core.Entities;

public partial class Asignaciones
{
    public int AsignacionId { get; set; }

    public int? UsuarioId { get; set; }

    public int? PublicacionId { get; set; }

    public string? Estado { get; set; }

    public DateTime? FechaAsignacion { get; set; }

    public virtual ICollection<FormularioInvestigacion> FormularioInvestigacion { get; set; } = new List<FormularioInvestigacion>();

    public virtual Publicaciones? Publicacion { get; set; }

    public virtual Usuarios? Usuario { get; set; }
}
