namespace UESAN.INVES.CORE.Core.DTOs
{
    // DTO principal: todos los datos de la categor�a
    public class CategoriasDTO
    {
        public int CategoriaId { get; set; }
        public string? NombreCategoria { get; set; }
    }

    // DTO solo con el ID (para b�squedas, eliminaciones, validaciones)
    public class CategoriasIdDTO
    {
        public int CategoriaId { get; set; }
    }

    // DTO para crear una nueva categor�a
    public class CategoriasCreateDTO
    {
        public string? NombreCategoria { get; set; }
    }

    // DTO para actualizar una categor�a existente
    public class CategoriasUpdateDTO
    {
        public int CategoriaId { get; set; }
        public string? NombreCategoria { get; set; }
    }

    // DTO para mostrar en listados o selectores r�pidos
    public class CategoriasResumenDTO
    {
        public int CategoriaId { get; set; }
        public string? NombreCategoria { get; set; }
    }
}
