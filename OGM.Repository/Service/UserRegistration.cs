using Microsoft.EntityFrameworkCore;
using OGM.Repository.Interface;
using OGM.Domain.Entities;
using OGM.Infra.sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGM.Repository.Service
{
    public class UserRegistration : IUserRegistration
    {
        private readonly PlayCricketDbContext _context;

        public UserRegistration(PlayCricketDbContext context)
        {
            _context = context;
        }

        public async Task<bool> RegisterUserAsync(User user)
        {
            try
            {
                var emailExists = await _context.Users.AnyAsync(u => u.Email == user.Email);
                if (emailExists)
                {
                    return false;
                }
                //Hash
                user.Password_Hash = BCrypt.Net.BCrypt.HashPassword(user.Password_Hash);

                //Save
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during user registration: {ex.Message}");
                return false;
            }
        }

        public bool VerifyPassword(string plainPassword, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(plainPassword, hashedPassword);
        }
    }
}
