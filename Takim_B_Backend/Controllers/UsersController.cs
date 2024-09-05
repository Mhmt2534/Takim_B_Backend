using Entities.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace Takim_B_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly MutluMarketDb _context;

        public UsersController(MutluMarketDb context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            if (await _context.Users.AnyAsync(u => u.Email == user.Email))
            {
                return BadRequest("Email is already in use.");
            }

            if (user.isAdmin == null)
            {
                user.isAdmin = false;
            }


            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok("User registered successfully.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == loginDto.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Password))
            {
                return Unauthorized("Invalid email or password.");
            }

            // JWT token oluşturma işlemi burada yapılabilir.

            return Ok("Login successful.");
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto forgotPasswordDto)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == forgotPasswordDto.Email);
            if (user == null)
            {
                return BadRequest("Email not found.");
            }

            // Email gönderme işlemi burada yapılabilir.

            return Ok("Password reset email sent.");
        }

        [HttpPost("check-admin")]
        public async Task<Boolean> CheckAdmin( string email)
        {
         var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == email);
            
            if (user != null && user.isAdmin == true)
            {
                return true;
            }
            return false;

        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _context.Users.ToListAsync();
            return Ok(users);
        }

    }
}
