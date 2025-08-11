using Kanaklytics.API.DTOs;
using System.Threading.Tasks;

namespace Kanaklytics.API.Services
{
    public interface IUserService
    {
        Task<UserDto> RegisterAsync(RegisterDto dto);
        Task<UserDto> LoginAsync(LoginDto dto);
        Task<bool> LogoutAsync(string username);
    }
}
