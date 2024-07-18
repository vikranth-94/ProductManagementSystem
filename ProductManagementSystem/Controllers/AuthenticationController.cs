using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProductManagementSystem.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;
using ProductManagementSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using ProductManagementSystem.Services;
using ProductManagementSystem.Repositories;

namespace ProductManagementSystem.Controllers
{
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IAuthService _authService;
        private readonly ProductDBContext _context;

        public AuthenticationController( IConfiguration configuration,IAuthService authservice,ProductDBContext context)
        {
            _configuration = configuration;
            _authService = authservice;
            _context = context;
        }

       
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
                await _authService.RegisterAsync(user);
                return Ok(new { Message = "User registered successfully!" });
        }

        
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] User user)
        {
                var dbUser = await _authService.LoginAsync(user);
                if (dbUser == null)
                {
                    return Unauthorized();
                }
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[] { new Claim("id", dbUser.Username.ToString()) }),
                    Expires = DateTime.UtcNow.AddHours(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                    Issuer = _configuration["Jwt:Issuer"],
                    Audience = _configuration["Jwt:Audience"],
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);
                return Ok(new { Token = tokenString });

        }
    }
}