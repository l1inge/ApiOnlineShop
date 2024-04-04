using System;
using System.Collections.Generic;

namespace ApiOnlineShop.Models
{
    public partial class User
    {
     
        public int UserId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? MiddleName { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int? RoleId { get; set; }
        public string? FcmToken { get; set; }

        public virtual Role? Role { get; set; }
    }
}
