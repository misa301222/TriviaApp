using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TriviaApp.Data.Entities
{
    public class UserPost
    {
        public UserPost(int userPostId, string postTarget, string postedBy, DateTime datePosted, string content, string imageURL, string backgroundColorHex, string letterColorHex, int feelingId)
        {
            UserPostId = userPostId;
            PostTarget = postTarget;
            PostedBy = postedBy;
            DatePosted = datePosted;
            Content = content;
            ImageURL = imageURL;
            BackgroundColorHex = backgroundColorHex;
            LetterColorHex = letterColorHex;
            FeelingId = feelingId;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserPostId { get; set; }
        public string PostTarget { get; set; }
        public string PostedBy { get; set; }

        public DateTime DatePosted { get; set; }
        public string Content { get; set; }
        public string ImageURL { get; set; }
        public string BackgroundColorHex { get; set; }
        public string LetterColorHex { get; set; }
        public int FeelingId { get; set; }

    }
}
