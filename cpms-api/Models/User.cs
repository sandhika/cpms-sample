using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using cpms.Api.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace cpms.Api.Models;

[Table("User")]
[Index(nameof(User.UserName), IsUnique = true)]
public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
         public string UserName { get; set; } = "";
        public string Email { get; set; } = "";
        public string Role { get; set; } = "Everyone";
        public bool IsActive { get; set; } = false;
        public string Token { get; set; } = "";        
        public string Password { get; set; } = "";
   
        public User(string userName, string email, string password, string role)
        {
            UserName = userName;
            Email = email;
            Password = password;
            Role = role;
        }
    }

    public class LoginUser
    {
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
    }

    public class RegisterUser
    {
        public string Email { get; set; } = "";
        public string UserName { get; set; } = "";
        public string Password { get; set; } = "";
        public string Role { get; set; } = "Everyone";
    }