using LinksheetAPI.Models;

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
            return _context.Users.SingleOrDefault(x => x.Id == id);
        }
    }
}
