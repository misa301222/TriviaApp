using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TriviaApp.Data.Entities;

namespace TriviaApp.Data
{
    public class AppDbContext : IdentityDbContext<AppUser, IdentityRole, string>
    {

        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            /*
            builder.Entity<Question>().HasKey(table => new
            {
                table.Id,
                table.QuestionId
            });

            builder.Entity<Room>().HasKey(table => new
            {
                table.Id,
                table.GeneratedName
            });
            
            builder.Entity<RoomQuestion>().HasKey(table => new
            {
                table.RoomId,
                table.QuestionId
            });
            */

            builder.Entity<UserScore>().HasKey(table => new
            {
                table.UserScoreId,
                table.GeneratedName,
                table.Email
            });
        }
        
        public DbSet<Room> Room { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<UserScore> UserScore { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<TriviaApp.Data.Entities.UserProfile> UserProfile { get; set; }
    }
}
