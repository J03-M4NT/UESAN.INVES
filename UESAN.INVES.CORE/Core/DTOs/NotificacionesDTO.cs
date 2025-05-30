using System;

namespace UESAN.INVES.CORE.Core.DTOs
{
    // DTO principal: toda la informaci�n de la notificaci�n
    public class NotificacionesDTO
    {
        public int NotificacionId { get; set; }
        public int? UsuarioId { get; set; }
        public string? Mensaje { get; set; }
        public DateTime? FechaEnvio { get; set; }
        public bool? Leido { get; set; }
    }

    // DTO solo con el ID (�til para buscar o eliminar)
    public class NotificacionesIdDTO
    {
        public int NotificacionId { get; set; }
    }

    // DTO para crear una notificaci�n nueva
    public class NotificacionesCreateDTO
    {
        public int? UsuarioId { get; set; }
        public string? Mensaje { get; set; }
        public DateTime? FechaEnvio { get; set; }
    }

    // DTO para actualizar estado de lectura u otros campos
    public class NotificacionesUpdateDTO
    {
        public int NotificacionId { get; set; }
        public bool? Leido { get; set; }
    }

    // DTO para mostrar resumen en listados (sin cuerpo completo del mensaje)
    public class NotificacionesResumenDTO
    {
        public int NotificacionId { get; set; }
        public DateTime? FechaEnvio { get; set; }
        public bool? Leido { get; set; }
    }

    // DTO para mostrar con datos del usuario (si se desea enriquecer)
    public class NotificacionesDetalleDTO
    {
        public int NotificacionId { get; set; }
        public string? UsuarioNombre { get; set; }
        public string? Mensaje { get; set; }
        public DateTime? FechaEnvio { get; set; }
        public bool? Leido { get; set; }
    }
}
