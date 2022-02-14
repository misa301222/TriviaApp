using System.ComponentModel.DataAnnotations;

namespace TriviaApp.Data.Entities
{
    public class UserLike
    {
        public UserLike(string email, int userPostId)
        {
            Email = email;
            UserPostId = userPostId;
        }
        [Key]
        public string Email { get; set; }
        [Key]
        public int UserPostId { get; set; }
    }
}
