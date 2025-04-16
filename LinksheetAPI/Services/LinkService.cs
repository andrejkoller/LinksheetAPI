using LinksheetAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LinksheetAPI.Services
{
    public class LinkService
    {
        private readonly LinksheetDbContext _context;

        public LinkService(LinksheetDbContext context) {
            _context = context;
        }

        public async Task<List<Link>> GetAllLinks()
        {
            return await _context.Links.ToListAsync();
        }

        public async Task<List<Link>> GetLinksByUserId(int userId)
        {
            return await _context.Links.Where(x => x.UserId == userId).ToListAsync();
        }
    }
}
