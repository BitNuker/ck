﻿using System.ComponentModel.DataAnnotations;

namespace CK.Entities
{
    public class User
    {
        public User()
        {

        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        public DateTime Created { get; set; }

        public DateTime? Modified { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        public string Salt { get; set; }

        [Required]
        public string Token { get; set; }

        public string RefreshToken { get; set; }

        public DateTime? TokenExpiration { get; set; }

        public DateTime? RefreshTokenExpiration { get; set; }



    }
}
