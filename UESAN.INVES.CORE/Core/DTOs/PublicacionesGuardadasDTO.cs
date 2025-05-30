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

    // DTO solo con el Id (�til para eliminar, buscar, etc.)
    public class PublicacionesGuardadasIdDTO
    {
        public int Id { get; set; }
    }

    // DTO para crear una nueva publicaci�n guardada
    public class PublicacionesGuardadasCreateDTO
    {
        public int? UsuarioId { get; set; }
        public int? PublicacionId { get; set; }
        public DateTime? FechaGuardado { get; set; }
    }

    // DTO para actualizar una publicaci�n guardada
    public class PublicacionesGuardadasUpdateDTO
    {
        public int Id { get; set; }
        public int? UsuarioId { get; set; }
        public int? PublicacionId { get; set; }
        public DateTime? FechaGuardado { get; set; }
    }

    // DTO para mostrar informaci�n del usuario y la publicaci�n (opcional)
    public class PublicacionesGuardadasDetalleDTO
    {
        public int Id { get; set; }
        public string? UsuarioNombre { get; set; }
        public string? TituloPublicacion { get; set; }
        public DateTime? FechaGuardado { get; set; }
    }
}
