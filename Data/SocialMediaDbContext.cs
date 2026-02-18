using Microsoft.EntityFrameworkCore;
using SocialMedia.Models;


namespace SocialMedia.Data
{
    public class SocialMediaDbContext(DbContextOptions<SocialMediaDbContext> options) : DbContext(options)
    {
        public DbSet<Users> Users{get;set;} // represents users table
    }
}