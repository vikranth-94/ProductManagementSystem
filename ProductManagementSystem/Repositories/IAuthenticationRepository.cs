using ProductManagementSystem.Models;

namespace ProductManagementSystem.Repositories
{
    public interface IAuthenticationRepository
    {
        Task RegisterAsync(User user);
        Task<User> LoginAsync(User user);
    }
}
