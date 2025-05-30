using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN.INVES.CORE.Core.DTOs;
using UESAN.INVES.CORE.Core.Interfaces;

namespace UESAN.INVES.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaqChatbotController : ControllerBase
    {
        private readonly IFaqChatbotService _faqService;
        public FaqChatbotController(IFaqChatbotService faqService)
        {
            _faqService = faqService;
        }

        [HttpGet]
        public async Task<IActionResult> GetFaqs()
        {
            var faqs = await _faqService.GetAllFaqsAsync();
            return Ok(faqs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFaq(int id)
        {
            var faq = await _faqService.GetFaqByIdAsync(id);
            if (faq == null)
            {
                return NotFound();
            }
            return Ok(faq);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutFaq(int id, [FromBody] FaqChatbotUpdateDTO faqUpdateDto)
        {
            if (id != faqUpdateDto.Faqid)
            {
                return BadRequest("FAQ ID mismatch");
            }
            var updated = await _faqService.UpdateFaqAsync(faqUpdateDto);
            if (updated == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> PostFaq([FromBody] FaqChatbotCreateDTO faqCreateDto)
        {
            if (faqCreateDto == null)
            {
                return BadRequest("FAQ cannot be null");
            }
            var createdFaq = await _faqService.CreateFaqAsync(faqCreateDto);
            return CreatedAtAction(nameof(GetFaq), new { id = createdFaq.Faqid }, createdFaq);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFaq(int id)
        {
            var result = await _faqService.DeleteFaqAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
