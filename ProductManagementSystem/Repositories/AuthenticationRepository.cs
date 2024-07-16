using Microsoft.EntityFrameworkCore;
using ProductManagementSystem.Data;
using ProductManagementSystem.Models;

namespace ProductManagementSystem.Repositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly ProductDBContext _context;

        public AuthenticationRepository(ProductDBContext context)
        {
            _context = context;
        }
        public async Task RegisterAsync(User user)
        {
            user.Id = 0;
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }
        public async Task<User> LoginAsync(User user)
        {
            var result=await _context.Users.SingleOrDefaultAsync(u => u.Username == user.Username);
            return result;
        }
    }
}
