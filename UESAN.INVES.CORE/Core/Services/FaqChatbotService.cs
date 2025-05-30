using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.INVES.CORE.Core.DTOs;
using UESAN.INVES.CORE.Core.Entities;
using UESAN.INVES.CORE.Core.Interfaces;

namespace UESAN.INVES.CORE.Core.Services
{
    public class FaqChatbotService : IFaqChatbotService
    {
        private readonly IFaqChatbotRepository _faqChatbotRepository;

        public FaqChatbotService(IFaqChatbotRepository faqChatbotRepository)
        {
            _faqChatbotRepository = faqChatbotRepository;
        }

        public async Task<IEnumerable<FaqChatbotDTO>> GetAllFaqsAsync()
        {
            var faqs = await _faqChatbotRepository.GetAllFAQsAsync();
            return faqs.Select(f => new FaqChatbotDTO
            {
                Faqid = f.Faqid,
                PreguntaClave = f.PreguntaClave,
                Respuesta = f.Respuesta,
                FechaCreacion = f.FechaCreacion,
                Visible = f.Visible
            });
        }

        public async Task<FaqChatbotDTO?> GetFaqByIdAsync(int id)
        {
            var faq = await _faqChatbotRepository.GetFAQByIdAsync(id);
            if (faq == null) return null;

            return new FaqChatbotDTO
            {
                Faqid = faq.Faqid,
                PreguntaClave = faq.PreguntaClave,
                Respuesta = faq.Respuesta,
                FechaCreacion = faq.FechaCreacion,
                Visible = faq.Visible
            };
        }

        public async Task<FaqChatbotDTO> CreateFaqAsync(FaqChatbotCreateDTO faqCreateDto)
        {
            var faq = new FaqChatbot
            {
                PreguntaClave = faqCreateDto.PreguntaClave,
                Respuesta = faqCreateDto.Respuesta,
                FechaCreacion = faqCreateDto.FechaCreacion ?? DateTime.Now,
                Visible = faqCreateDto.Visible ?? true
            };

            var createdFaq = await _faqChatbotRepository.CreateFAQAsync(faq);

            return new FaqChatbotDTO
            {
                Faqid = createdFaq.Faqid,
                PreguntaClave = createdFaq.PreguntaClave,
                Respuesta = createdFaq.Respuesta,
                FechaCreacion = createdFaq.FechaCreacion,
                Visible = createdFaq.Visible
            };
        }

        public async Task<FaqChatbotDTO?> UpdateFaqAsync(FaqChatbotUpdateDTO faqUpdateDto)
        {
            var faq = new FaqChatbot
            {
                Faqid = faqUpdateDto.Faqid,
                PreguntaClave = faqUpdateDto.PreguntaClave,
                Respuesta = faqUpdateDto.Respuesta,
                Visible = faqUpdateDto.Visible
            };

            var updatedFaq = await _faqChatbotRepository.UpdateFAQAsync(faq);
            if (updatedFaq == null) return null;

            return new FaqChatbotDTO
            {
                Faqid = updatedFaq.Faqid,
                PreguntaClave = updatedFaq.PreguntaClave,
                Respuesta = updatedFaq.Respuesta,
                FechaCreacion = updatedFaq.FechaCreacion,
                Visible = updatedFaq.Visible
            };
        }

        public async Task<bool> DeleteFaqAsync(int id)
        {
            return await _faqChatbotRepository.DeleteFAQAsync(id);

        }



    }
}
