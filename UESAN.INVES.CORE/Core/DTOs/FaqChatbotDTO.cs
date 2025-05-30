using System;

namespace UESAN.INVES.CORE.Core.DTOs
{
    public class FaqChatbotDTO
    {
        public int Faqid { get; set; }
        public string? PreguntaClave { get; set; }
        public string? Respuesta { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public bool? Visible { get; set; }
    }
}