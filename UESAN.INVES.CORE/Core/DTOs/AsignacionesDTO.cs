using System;

namespace UESAN.INVES.CORE.Core.DTOs
{
    // DTO principal: contiene toda la informaci�n de la asignaci�n
    public class AsignacionesDTO
    {
        public int AsignacionId { get; set; }
        public int? UsuarioId { get; set; }
        public int? PublicacionId { get; set; }
        public string? Estado { get; set; }
        public DateTime? FechaAsignacion { get; set; }
    }

    // DTO solo con el ID (para buscar o eliminar)
    public class AsignacionesIdDTO
    {
        public int AsignacionId { get; set; }
    }

    // DTO para crear una nueva asignaci�n
    public class AsignacionesCreateDTO
    {
        public int? UsuarioId { get; set; }
        public int? PublicacionId { get; set; }
        public string? Estado { get; set; }
        public DateTime? FechaAsignacion { get; set; }
    }

    // DTO para actualizar el estado de una asignaci�n
    public class AsignacionesUpdateDTO
    {
        public int AsignacionId { get; set; }
        public string? Estado { get; set; }
        public DateTime? FechaAsignacion { get; set; }
    }

    // DTO para mostrar informaci�n combinada en listados (opcional)
    public class AsignacionesDetalleDTO
    {
        public int AsignacionId { get; set; }
        public string? NombreUsuario { get; set; }
        public string? TituloPublicacion { get; set; }
        public string? Estado { get; set; }
        public DateTime? FechaAsignacion { get; set; }
    }
}
