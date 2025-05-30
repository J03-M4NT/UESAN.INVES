﻿using System;
using System.Collections.Generic;

namespace UESAN.INVES.CORE.Core.Entities;

public partial class Usuarios
{
    public int UsuarioId { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string Correo { get; set; } = null!;

    public string Contraseña { get; set; } = null!;

    public int RolId { get; set; }

    public bool? Estado { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<Accesos> Accesos { get; set; } = new List<Accesos>();

    public virtual ICollection<Asignaciones> Asignaciones { get; set; } = new List<Asignaciones>();

    public virtual ICollection<Notificaciones> Notificaciones { get; set; } = new List<Notificaciones>();

    public virtual ICollection<PublicacionesGuardadas> PublicacionesGuardadas { get; set; } = new List<PublicacionesGuardadas>();

    public virtual Roles Rol { get; set; } = null!;
}
