using LinksheetAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LinksheetAPI.Services
{
    public class LinkService
    {
        private readonly LinksheetDbContext _context;

        public LinkService(LinksheetDbContext context)
        {
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

        public async void PostLink(Link link)
        {
            ArgumentNullException.ThrowIfNull(link);

            var linkModel = new Link
            {
                Title = link.Title,
                Url = link.Url,
                Description = link.Description,
                IsActive = link.IsActive = true,
                UserId = link.UserId
            };

            try
            {
                await _context.Links.AddAsync(linkModel);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("An error occurred while saving the link.", ex);
            }
        }

        public async Task<bool> DeleteLink(int id)
        {
            var link = await _context.Links.SingleOrDefaultAsync(x => x.Id == id) ?? throw new KeyNotFoundException($"Link with ID {id} not found.");

            _context.Links.Remove(link);
            _context.SaveChanges();

            return true;
        }

        public void UpdateLink(int id, Link updatedLink)
        {
            var link = _context.Links.SingleOrDefault(x => x.Id == id) ?? throw new KeyNotFoundException($"Link with ID {id} not found.");

            link.Title = updatedLink.Title;
            link.Url = updatedLink.Url;
            link.Description = updatedLink.Description;
            link.IsActive = updatedLink.IsActive;

            _context.SaveChanges();
        }
    }
}
