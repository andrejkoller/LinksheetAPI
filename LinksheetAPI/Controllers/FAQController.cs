using LinksheetAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LinksheetAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FAQController : Controller
    {
        private readonly FAQService _faqService;

        public FAQController(FAQService faqService)
        {
            _faqService = faqService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var faqs = await _faqService.GetAllFAQsAsync();
            return faqs == null ? NotFound() : Ok(faqs);
        }
    }
}
