using Kanaklytics.API.Models;
using System.Threading.Tasks;

namespace Kanaklytics.API.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByUsernameAsync(string username);
        Task<User> GetByEmailAsync(string email);
        Task<User> AddAsync(User user);
    }
}
