using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TriviaApp.Data.Entities
{
    public class UserScore
    {
        public UserScore(int userScoreId, string generatedName, string email, int correct, int wrong, double score, DateTime dateSent)
        {
            UserScoreId = userScoreId;
            GeneratedName = generatedName;
            Email = email;
            Correct = correct;
            Wrong = wrong;
            Score = score;
            DateSent = dateSent;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserScoreId { get; set; }
        [Key]
        public string GeneratedName { get; set; }
        [Key]
        public string Email { get; set; }
        public int Correct { get; set; }
        public int Wrong { get; set; }
        public double Score { get; set; }
        public DateTime DateSent { get; set; }
    }
}
