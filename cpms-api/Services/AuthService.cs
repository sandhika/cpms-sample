using cpms.Api.Models;
using cpms.Api.Models.DTO;
using Microsoft.EntityFrameworkCore;

using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BCrypt.Net;

namespace cpms.Api.Services;

public interface IAuthService
    {
        public Task<User> Login(string email, string password);
        public Task<User> Register(User user);

        public Task<User> GetByName(string name);
    }




    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IConfiguration _configuration;
        public AuthService(ApplicationDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public async Task<User> Login(string email, string password)
        {
            User? user =  _dbContext.Users.Where(x => x.Email.Equals(email)).FirstOrDefault();

            if (user == null || BCrypt.Net.BCrypt.Verify(password, user.Password) == false)
            {
                return null; //returning null intentionally to show that login was unsuccessful
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JWT:SecretKey"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.GivenName, user.Email),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                IssuedAt = DateTime.UtcNow,
                Issuer = _configuration["JWT:Issuer"],
                Audience = _configuration["JWT:Audience"],
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
            user.IsActive = true;

            return user;
        }

        public async Task<User> Register(User user)
        {
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
            
            return user;
        }

         public async Task<User> GetByName(string name)
        {

            return  _dbContext.Users.Where(x => x.UserName.Equals(name)).FirstOrDefault();
        }
    }