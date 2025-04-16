using OGM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGM.Repository.Interface
{
    public interface IUserRepository
    {
        Task<RegistrationResponse> RegisterUserAsync(User user);
        Task<User> LoginUserAsync(string email, string password);

    }
}
