using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGM.Domain.Entities
{
    public class User
    {
        public int UserID { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public string? Password_Hash { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Gender { get; set; }

        public byte[]? Profile_Photo { get; set; }

        public bool IsPhoneVerified { get; set; } = false;

        public bool IsEmailVerified { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
