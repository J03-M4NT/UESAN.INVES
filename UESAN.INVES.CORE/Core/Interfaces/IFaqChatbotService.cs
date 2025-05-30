using UESAN.INVES.CORE.Core.DTOs;

namespace UESAN.INVES.CORE.Core.Interfaces
{
    public interface IFaqChatbotService
    {
        Task<FaqChatbotDTO> CreateFaqAsync(FaqChatbotCreateDTO faqCreateDto);
        Task<bool> DeleteFaqAsync(int id);
        Task<IEnumerable<FaqChatbotDTO>> GetAllFaqsAsync();
        Task<FaqChatbotDTO?> GetFaqByIdAsync(int id);
        Task<FaqChatbotDTO?> UpdateFaqAsync(FaqChatbotUpdateDTO faqUpdateDto);
    }
}