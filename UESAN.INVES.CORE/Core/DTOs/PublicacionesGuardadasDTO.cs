using System;

namespace UESAN.INVES.CORE.Core.DTOs
{
    // DTO principal: contiene todos los datos
    public class PublicacionesGuardadasDTO
    {
        public int Id { get; set; }
        public int? UsuarioId { get; set; }
        public int? PublicacionId { get; set; }
        public DateTime? FechaGuardado { get; set; }
    }

    // DTO solo con el Id (útil para eliminar, buscar, etc.)
    public class PublicacionesGuardadasIdDTO
    {
        public int Id { get; set; }
    }

    // DTO para crear una nueva publicación guardada
    public class PublicacionesGuardadasCreateDTO
    {
        public int? UsuarioId { get; set; }
        public int? PublicacionId { get; set; }
        public DateTime? FechaGuardado { get; set; }
    }

    // DTO para actualizar una publicación guardada
    public class PublicacionesGuardadasUpdateDTO
    {
        public int Id { get; set; }
        public int? UsuarioId { get; set; }
        public int? PublicacionId { get; set; }
        public DateTime? FechaGuardado { get; set; }
    }

    // DTO para mostrar información del usuario y la publicación (opcional)
    public class PublicacionesGuardadasDetalleDTO
    {
        public int Id { get; set; }
        public string? UsuarioNombre { get; set; }
        public string? TituloPublicacion { get; set; }
        public DateTime? FechaGuardado { get; set; }
    }
}
