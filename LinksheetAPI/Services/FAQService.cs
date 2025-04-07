using LinksheetAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LinksheetAPI.Services
{
    public class FAQService
    {
        public readonly LinksheetDbContext _context;

        public FAQService(LinksheetDbContext context)
        {
            _context = context;
        }

        public async Task<List<FAQ>> GetAllFAQsAsync()
        {
            return await _context.FAQs.ToListAsync();
        }
    }
}
