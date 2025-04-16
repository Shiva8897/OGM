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

        public async Task<RegistrationResponse> RegisterUserAsync(RegisterUserDto user)
        {
            var RegisterDto = new User
            {
                FirstName = user.Firstname,
                LastName = user.Lastname,
                Email = user.Email,
                Password_Hash = user.Password,
                PhoneNumber = user.PhoneNumber,
                DateOfBirth = user.DateOfBirth,
                Country = user.Country,
                City = user.City,
            };

            if(user.Profile_photo != null)
            {
                using (var ms = new MemoryStream())
                {
                    await user.Profile_photo.CopyToAsync(ms);
                    RegisterDto.Profile_Photo = ms.ToArray();
                }
            }

            return await _userRepo.RegisterUserAsync(RegisterDto);
        }

        public async Task<User> LoginUserAsync(string email, string password)
        {
            return await _userRepo.LoginUserAsync(email, password);
        }

    }
}
