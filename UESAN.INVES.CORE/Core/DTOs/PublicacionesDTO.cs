using System;

namespace UESAN.INVES.CORE.Core.DTOs
{
    // DTO principal: contiene todos los datos de la publicaci�n
    public class PublicacionesDTO
    {
        public int PublicacionId { get; set; }
        public string? Titulo { get; set; }
        public string? NombreCategoria { get; set; }
        public decimal? IncentivoUSD { get; set; }
        public DateTime? FechaPublicacion { get; set; }
    }

    /*
    public class PublicacionesDTO
    {
        public int PublicacionId { get; set; }
        public string? Titulo { get; set; }
        public string? Contenido { get; set; }
        public DateTime? FechaPublicacion { get; set; }
    }
    */

    // DTO solo con el ID: �til para eliminar, buscar, etc.
    public class PublicacionesIdDTO
    {
        public int PublicacionId { get; set; }
    }

    // DTO para crear una nueva publicaci�n
    public class PublicacionesCreateDTO
    {
        public string? Titulo { get; set; }
        public string? Contenido { get; set; }
        public DateTime? FechaPublicacion { get; set; }
    }

    // DTO para actualizar una publicaci�n existente
    public class PublicacionesUpdateDTO
    {
        public int PublicacionId { get; set; }
        public string? Titulo { get; set; }
        public string? Contenido { get; set; }
        public DateTime? FechaPublicacion { get; set; }
    }

    // DTO para mostrar resumen de publicaciones (ej. listado)
    public class PublicacionesResumenDTO
    {
        public int PublicacionId { get; set; }
        public string? Titulo { get; set; }
        public DateTime? FechaPublicacion { get; set; }
    }
}
