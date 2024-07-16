using Microsoft.AspNetCore.Authentication;
using ProductManagementSystem.Data;
using ProductManagementSystem.Models;
using ProductManagementSystem.Repositories;

namespace ProductManagementSystem.Services
{
    public class AuthService: IAuthService
    {
        private readonly ProductDBContext _context;
        private readonly IAuthenticationRepository _authenticationRepo;

        public AuthService(ProductDBContext context, IAuthenticationRepository authRepo)
        {
            _context = context;
            _authenticationRepo = authRepo;
        }
        public async Task RegisterAsync(User user)
        {
            await _authenticationRepo.RegisterAsync(user);
           
        }
        public async Task<User> LoginAsync(User user)
        {
            return await _authenticationRepo.LoginAsync(user);
        }
    }
}
