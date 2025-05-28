using System;
using System.Collections.Generic;

namespace UESAN.INVES.CORE.Core.Entities;

public partial class PublicacionesGuardadas
{
    public int Id { get; set; }

    public int? UsuarioId { get; set; }

    public int? PublicacionId { get; set; }

    public DateTime? FechaGuardado { get; set; }

    public virtual Publicaciones? Publicacion { get; set; }

    public virtual Usuarios? Usuario { get; set; }
}
