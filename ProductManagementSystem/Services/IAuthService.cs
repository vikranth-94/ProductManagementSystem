using ProductManagementSystem.Models;

namespace ProductManagementSystem.Services
{
    public interface IAuthService
    {
        Task RegisterAsync(User user);
        Task<User> LoginAsync(User user);
    }
}
