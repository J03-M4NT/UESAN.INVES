using Microsoft.AspNetCore.Mvc;
using UESAN.INVES.CORE.Core.Entities;
using UESAN.INVES.CORE.Core.Interfaces;
using System.Threading.Tasks;

namespace UESAN.INVES.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaqChatbotController : ControllerBase
    {
        private readonly IFaqChatbotRepository _faqChatbotRepository;
        public FaqChatbotController(IFaqChatbotRepository faqChatbotRepository)
        {
            _faqChatbotRepository = faqChatbotRepository;
        }

        // GET: api/FaqChatbot
        [HttpGet]
        public async Task<IActionResult> GetFaqs()
        {
            var faqs = await _faqChatbotRepository.GetAllFAQsAsync();
            return Ok(faqs);
        }

        // GET: api/FaqChatbot/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFaq(int id)
        {
            var faq = await _faqChatbotRepository.GetFAQByIdAsync(id);
            if (faq == null)
            {
                return NotFound();
            }
            return Ok(faq);
        }

        // POST: api/FaqChatbot
        [HttpPost]
        public async Task<IActionResult> PostFaq([FromBody] FaqChatbot faq)
        {
            if (faq == null)
            {
                return BadRequest("Faq cannot be null");
            }
            var created = await _faqChatbotRepository.CreateFAQAsync(faq);
            return CreatedAtAction(nameof(GetFaq), new { id = created.Faqid }, created);
        }

        // PUT: api/FaqChatbot/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFaq(int id, [FromBody] FaqChatbot faq)
        {
            if (id != faq.Faqid)
            {
                return BadRequest("Faq ID mismatch");
            }
            var updated = await _faqChatbotRepository.UpdateFAQAsync(faq);
            if (updated == null)
            {
                return NotFound();
            }
            return Ok(updated);
        }

        // DELETE: api/FaqChatbot/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFaq(int id)
        {
            var deleted = await _faqChatbotRepository.DeleteFAQAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
