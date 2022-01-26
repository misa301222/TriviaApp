using System.ComponentModel.DataAnnotations;

namespace TriviaApp.Data.Entities
{
    public class UserScore
    {
        [Key]
        public string GeneratedName { get; set; }
        [Key]
        public int Email { get; set; }
        public int Score { get; set; }
        public int Right { get; set; }
        public int Wrong { get; set; }
    }
}
