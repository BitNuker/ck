using System;
using System.Collections.Generic;

namespace CK.EF
{
    public partial class User
    {
        public User()
        {
            Trades = new HashSet<Trade>();
        }

        public Guid UserId { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Salt { get; set; }
        public string Token { get; set; } = null!;
        public string? RefreshToken { get; set; }
        public DateTime? TokenExpiration { get; set; }
        public DateTime? RefreshTokenExpiration { get; set; }

        public virtual ICollection<Trade> Trades { get; set; }
    }
}
