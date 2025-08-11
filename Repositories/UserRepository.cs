using Kanaklytics.API.Data;
using Kanaklytics.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Kanaklytics.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly KanaklyticsDbContext _context;
        public UserRepository(KanaklyticsDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> AddAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
