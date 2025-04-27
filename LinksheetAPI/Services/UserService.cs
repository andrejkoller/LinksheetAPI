using LinksheetAPI.DTOs;
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

        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users
                .Include(u => u.Links)
                .Include(u => u.LinkSpace)
                .ToListAsync();
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

            try
            {
                _context.Users.Update(user);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("An error occurred while updating the user.", ex);
            }
        }
    }
}
