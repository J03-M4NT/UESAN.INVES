namespace UESAN.INVES.CORE.Core.DTOs
{
    // DTO principal: representaci�n completa del rol
    public class RolesDTO
    {
        public int RolId { get; set; }
        public string? NombreRol { get; set; }
    }

    // DTO solo con ID: �til para b�squedas o validaciones simples
    public class RolesIdDTO
    {
        public int RolId { get; set; }
    }

    // DTO con solo el nombre del rol: �til para listados o combos
    public class RolesNombreDTO
    {
        public string? NombreRol { get; set; }
    }

    // DTO para creaci�n de roles
    public class RolesCreateDTO
    {
        public string? NombreRol { get; set; }
    }

    // DTO para actualizaci�n de roles
    public class RolesUpdateDTO
    {
        public int RolId { get; set; }
        public string? NombreRol { get; set; }
    }
}
