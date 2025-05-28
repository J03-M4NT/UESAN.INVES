using System;
using System.Collections.Generic;

namespace UESAN.INVES.CORE.Core.Entities;

public partial class Accesos
{
    public int AccesoId { get; set; }

    public int? UsuarioId { get; set; }

    public DateTime? FechaHoraAcceso { get; set; }

    public virtual Usuarios? Usuario { get; set; }
}
