using LinksheetAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LinksheetAPI.Services
{
    public class LinkSpaceService
    {
        private readonly LinksheetDbContext _context;

        public LinkSpaceService(LinksheetDbContext context)
        {
            _context = context;
        }

        public async Task<List<LinkSpace>> GetAllLinkSpaces()
        {
            return await _context.LinkSpaces.ToListAsync();
        }

        public async Task<LinkSpace> GetLinkSpaceById(int id)
        {
            var linkSpace = await _context.LinkSpaces.FindAsync(id);

            return linkSpace ?? throw new KeyNotFoundException($"LinkSpace with ID {id} not found.");
        }

        public async Task<LinkSpace> GetLinkSpaceByUserId(int userId)
        {
            var linkSpace = await _context.LinkSpaces.SingleOrDefaultAsync(x => x.UserId == userId);

            if (linkSpace == null)
            {
                linkSpace = new LinkSpace
                {
                    UserId = userId,
                    LinkPageBackgroundColor = "rgb(255,255,255)",
                    LinkButtonColor = "rgb(0,0,0)",
                    LinkButtonFontColor = "rgb(0,0,0)",
                    LinkPageFontColor = "rgb(0,0,0)",
                    LinkBorderRadius = LinkSpace.LinkBorderRadiusType.NotRounded,
                    LinkBorderStyle = LinkSpace.LinkBorderStyleType.Solid,
                };

                _context.LinkSpaces.Add(linkSpace);
                await _context.SaveChangesAsync();
            }

            return linkSpace ?? throw new KeyNotFoundException($"LinkSpace with User ID {userId} not found.");
        }

        public async Task<LinkSpace> PostLinkSpace(LinkSpace linkSpace)
        {
            ArgumentNullException.ThrowIfNull(linkSpace);
            var linkSpaceModel = new LinkSpace
            {
                Description = linkSpace.Description,
                LinkPageBackgroundColor = linkSpace.LinkPageBackgroundColor,
                LinkButtonColor = linkSpace.LinkButtonColor,
                LinkButtonFontColor = linkSpace.LinkButtonFontColor,
                LinkPageFontColor = linkSpace.LinkPageFontColor,
                LinkBorderRadius = linkSpace.LinkBorderRadius,
                LinkBorderStyle = linkSpace.LinkBorderStyle,
                UserId = linkSpace.UserId
            };

            try
            {
                await _context.LinkSpaces.AddAsync(linkSpaceModel);
                await _context.SaveChangesAsync();
                return linkSpaceModel;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("An error occurred while saving the LinkSpace.", ex);
            }
        }

        public async Task<LinkSpace> UpdateLinkSpace(int id, LinkSpace updatedLinkSpace)
        {
            var linkSpace = await _context.LinkSpaces.FindAsync(id) ?? throw new KeyNotFoundException($"LinkSpace with ID {id} not found.");

            linkSpace.Description = updatedLinkSpace.Description;
            linkSpace.LinkPageBackgroundColor = updatedLinkSpace.LinkPageBackgroundColor;
            linkSpace.LinkButtonColor = updatedLinkSpace.LinkButtonColor;
            linkSpace.LinkButtonFontColor = updatedLinkSpace.LinkButtonFontColor;
            linkSpace.LinkPageFontColor = updatedLinkSpace.LinkPageFontColor;
            linkSpace.LinkBorderRadius = updatedLinkSpace.LinkBorderRadius;
            linkSpace.LinkBorderStyle = updatedLinkSpace.LinkBorderStyle;

            try
            {
                _context.LinkSpaces.Update(linkSpace);
                await _context.SaveChangesAsync();
                return linkSpace;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("An error occurred while updating the LinkSpace.", ex);
            }
        }
    }
}
