using OGM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGM.Application.Interface
{
    public interface IUserService
    {
        Task<bool> RegisterUserAsync(User user);
    }
}
