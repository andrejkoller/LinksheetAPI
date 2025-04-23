using LinksheetAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LinksheetAPI.Services
{
    public class UserService
    {
        private readonly LinksheetDbContext _context;

        public UserService(LinksheetDbContext context)
        {
            _context = context;
        }

        public User? GetUserById(int id)
        {
            return _context.Users
                .Include(u => u.Links)
                .Include(u => u.LinkSpace)
                .SingleOrDefault(u => u.Id == id);
        }

        public void UpdateUser(int id, User updatedUser)
        {
            var user = _context.Users.SingleOrDefault(x => x.Id == id) ?? throw new KeyNotFoundException($"User with ID {id} not found.");

            user.Username = updatedUser.Username;
            user.Email = updatedUser.Email;
            user.Description = updatedUser.Description;

            _context.SaveChanges();
        }
    }
}
