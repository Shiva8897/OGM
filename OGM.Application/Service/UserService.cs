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

        public async Task<bool> RegisterUserAsync(User user)
        {
            return await _userRepo.RegisterUserAsync(user);
        }
    }
}
