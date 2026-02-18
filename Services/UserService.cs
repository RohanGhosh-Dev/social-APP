using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Data;
using SocialMedia.Dtos;
using SocialMedia.Models;

namespace SocialMedia.Services
{
    public class UserService(SocialMediaDbContext context)
    {
        private readonly SocialMediaDbContext _Context = context;

        public async Task<Users> RegisterUser(UserRegistrationDto userRegistrationDto)
        {
            

            //Check username and email already exists or not

            if(await _Context.Users.AnyAsync(u => u.UserName == userRegistrationDto.Username || u.Email == userRegistrationDto.Email))
             throw new System.Exception("Username or Email Already Exists");

             var user = new Users
             {
                 UserName= userRegistrationDto.Username,
                 Email = userRegistrationDto.Email,
                 PasswordHash = userRegistrationDto.Password,
                 CreatedAt = DateTime.UtcNow
             };

             // Add to the context and save changes
             _Context.Users.Add(user);
             await _Context.SaveChangesAsync();

             return user;
        }

        private static string PasswordHashed(String password)
        {
            using var hmac = new HMACSHA512(); 
            var hashedPassword = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hashedPassword);
        }
    }
}