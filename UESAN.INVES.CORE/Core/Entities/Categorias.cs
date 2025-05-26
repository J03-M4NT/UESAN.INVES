using System;
using System.Collections.Generic;
using UESAN.INVES.CORE.Core.Entities;

namespace UESAN.INVES.CORE.Infrastructure.Data;

public partial class Categorias
{
    public int CategoriaId { get; set; }

    public string NombreCategoria { get; set; } = null!;

    public virtual ICollection<Publicaciones> Publicaciones { get; set; } = new List<Publicaciones>();
}
