namespace UESAN.INVES.CORE.Core.DTOs
{
    // DTO principal: representación completa del rol
    public class RolesDTO
    {
        public int RolId { get; set; }
        public string? NombreRol { get; set; }
    }

    // DTO solo con ID: útil para búsquedas o validaciones simples
    public class RolesIdDTO
    {
        public int RolId { get; set; }
    }

    // DTO con solo el nombre del rol: útil para listados o combos
    public class RolesNombreDTO
    {
        public string? NombreRol { get; set; }
    }

    // DTO para creación de roles
    public class RolesCreateDTO
    {
        public string? NombreRol { get; set; }
    }

    // DTO para actualización de roles
    public class RolesUpdateDTO
    {
        public int RolId { get; set; }
        public string? NombreRol { get; set; }
    }
}
