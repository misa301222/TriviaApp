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

            builder.Entity<UserLike>().HasKey(table => new
            {
                table.Email,
                table.UserPostId,
            });
        }
        
        public DbSet<Room> Room { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<UserScore> UserScore { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<UserProfile> UserProfile { get; set; }
        public DbSet<UserAnswers> UserAnswers { get; set; }
        public DbSet<TriviaApp.Data.Entities.UserPost> UserPost { get; set; }
        public DbSet<TriviaApp.Data.Entities.Comment> Comment { get; set; }
        public DbSet<TriviaApp.Data.Entities.Feeling> Feeling { get; set; }
        public DbSet<TriviaApp.Data.Entities.UserLike> UserLike { get; set; }
        public DbSet<TriviaApp.Data.Entities.Activity> Activity { get; set; }
    }
}
