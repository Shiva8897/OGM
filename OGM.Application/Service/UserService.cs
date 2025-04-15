using OGM.Application.Interface;
using OGM.Domain.Entities;
using OGM.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGM.Application.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo; 
        public UserService(IUserRepository userRepo) 
        {
            _userRepo = userRepo;
        }

        public async Task<bool> RegisterUserAsync(RegisterUserDto RegisterDto)
        {
            var user = new User
            {
                FirstName = RegisterDto.FirstName,
                LastName = RegisterDto.LastName,
                Email = RegisterDto.Email,
                Password_Hash = RegisterDto.Password,
                PhoneNumber = RegisterDto.PhoneNumber,
                Gender = RegisterDto.Gender,
                CreatedAt = DateTime.Now
            };

            if (RegisterDto.ProfilePhoto is { Length: > 0 })
            {
                using var ms = new MemoryStream();
                await RegisterDto.ProfilePhoto.CopyToAsync(ms);
                user.Profile_Photo = ms.ToArray();
            }

            return await _userRepo.RegisterUserAsync(user);
        }
    }
}
