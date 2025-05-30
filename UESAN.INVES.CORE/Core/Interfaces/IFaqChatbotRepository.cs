using UESAN.INVES.CORE.Core.Entities;

namespace UESAN.INVES.CORE.Core.Interfaces
{
    public interface IFaqChatbotRepository
    {
        Task<FaqChatbot> CreateFAQAsync(FaqChatbot faq);
        Task<bool> DeleteFAQAsync(int id);
        IEnumerable<FaqChatbot> GetAllFAQs();
        Task<List<FaqChatbot>> GetAllFAQsAsync();
        Task<FaqChatbot?> GetFAQByIdAsync(int id);
        Task<FaqChatbot?> UpdateFAQAsync(FaqChatbot faq);
    }
}