using System;

namespace UESAN.INVES.CORE.Core.DTOs
{
    // DTO principal (respuesta completa)
    public class UsuariosDTO
    {
        public int UsuarioId { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Correo { get; set; }
        public int RolId { get; set; }
        public bool? Estado { get; set; }
        public DateTime? FechaRegistro { get; set; }
    }

    // DTO solo con ID (para búsquedas o eliminaciones)
    public class UsuariosIdDTO
    {
        public int UsuarioId { get; set; }
    }

    // DTO para mostrar nombre completo y correo (ej. en listados)
    public class UsuariosInfoDTO
    {
        public int UsuarioId { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Correo { get; set; }
    }

    // DTO para mostrar datos con rol
    public class UsuariosConRolDTO
    {
        public int UsuarioId { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Correo { get; set; }
        public string? RolNombre { get; set; } // Suponiendo que haces join con Roles
    }

    // DTO para creación de usuario
    public class UsuariosCreateDTO
    {
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Correo { get; set; }
        public int RolId { get; set; }
    }

    // DTO para actualización de usuario
    public class UsuariosUpdateDTO
    {
        public int UsuarioId { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Correo { get; set; }
        public int RolId { get; set; }
        public bool? Estado { get; set; }
    }
}
