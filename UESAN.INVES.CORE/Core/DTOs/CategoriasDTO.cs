namespace UESAN.INVES.CORE.Core.DTOs
{
    // DTO principal: todos los datos de la categoría
    public class CategoriasDTO
    {
        public int CategoriaId { get; set; }
        public string? NombreCategoria { get; set; }
    }

    // DTO solo con el ID (para búsquedas, eliminaciones, validaciones)
    public class CategoriasIdDTO
    {
        public int CategoriaId { get; set; }
    }

    // DTO para crear una nueva categoría
    public class CategoriasCreateDTO
    {
        public string? NombreCategoria { get; set; }
    }

    // DTO para actualizar una categoría existente
    public class CategoriasUpdateDTO
    {
        public int CategoriaId { get; set; }
        public string? NombreCategoria { get; set; }
    }

    // DTO para mostrar en listados o selectores rápidos
    public class CategoriasResumenDTO
    {
        public int CategoriaId { get; set; }
        public string? NombreCategoria { get; set; }
    }
}
