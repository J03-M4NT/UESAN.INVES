using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.INVES.CORE.Core.Entities;
using UESAN.INVES.CORE.Core.Interfaces;
using UESAN.INVES.CORE.Infrastructure.Data;

namespace UESAN.INVES.CORE.Infrastructure.Repositories
{
    public class FAQ_ChatbotRepository : IFAQ_ChatbotRepository
    {
        private readonly VdiIntranetContext _context;
        public FAQ_ChatbotRepository(VdiIntranetContext context)
        {
            _context = context;
        }

        //Get all faqs
        public IEnumerable<FaqChatbot> GetAllFAQs()
        {
            var faqs = _context.FaqChatbot.ToList();
            return faqs;
        }

        //Get all faqs async
        public async Task<List<FaqChatbot>> GetAllFAQsAsync()
        {
            return await _context.FaqChatbot.ToListAsync();
        }

        //Get faq by id async
        public async Task<FaqChatbot?> GetFAQByIdAsync(int id)
        {
            var faq = await _context.FaqChatbot.FirstOrDefaultAsync(f => f.Faqid == id);
            return faq;
        }
        //Create faq async
        public async Task<FaqChatbot> CreateFAQAsync(FaqChatbot faq)
        {
            _context.FaqChatbot.Add(faq);
            await _context.SaveChangesAsync();
            return faq;
        }
        //Delete faq async
        public async Task<bool> DeleteFAQAsync(int id)
        {
            var faq = await _context.FaqChatbot.FindAsync(id);
            if (faq == null)
            {
                return false;
            }
            _context.FaqChatbot.Remove(faq);
            await _context.SaveChangesAsync();
            return true;
        }
        //Update faq async
        public async Task<bool> UpdateFAQAsync(FaqChatbot faq)
        {
            var existingFaq = await _context.FaqChatbot.FindAsync(faq.Faqid);
            if (existingFaq == null)
            {
                return false;
            }
            existingFaq.PreguntaClave = faq.PreguntaClave;
            existingFaq.Respuesta = faq.Respuesta;
            existingFaq.FechaCreacion = faq.FechaCreacion;
            existingFaq.Visible = faq.Visible;
            _context.FaqChatbot.Update(existingFaq);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
