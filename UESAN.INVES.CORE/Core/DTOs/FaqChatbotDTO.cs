using System;

namespace UESAN.INVES.CORE.Core.DTOs
{
    // DTO principal: toda la información de una FAQ
    public class FaqChatbotDTO
    {
        public int Faqid { get; set; }
        public string? PreguntaClave { get; set; }
        public string? Respuesta { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public bool? Visible { get; set; }
    }

    // DTO solo con el ID de la FAQ
    public class FaqChatbotIdDTO
    {
        public int Faqid { get; set; }
    }

    // DTO para crear una nueva FAQ
    public class FaqChatbotCreateDTO
    {
        public string? PreguntaClave { get; set; }
        public string? Respuesta { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public bool? Visible { get; set; }
    }

    // DTO para actualizar una FAQ existente
    public class FaqChatbotUpdateDTO
    {
        public int Faqid { get; set; }
        public string? PreguntaClave { get; set; }
        public string? Respuesta { get; set; }
        public bool? Visible { get; set; }
    }

    // DTO para mostrar en un listado o búsqueda rápida
    public class FaqChatbotResumenDTO
    {
        public int Faqid { get; set; }
        public string? PreguntaClave { get; set; }
        public bool? Visible { get; set; }
    }
}
