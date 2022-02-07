using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TriviaApp.Data.Entities
{
    public class Comment
    {
        public Comment(int commentId, int userPostId, string commmentedBy, string commentContent, string imageURL)
        {
            CommentId = commentId;
            UserPostId = userPostId;
            CommmentedBy = commmentedBy;
            CommentContent = commentContent;
            ImageURL = imageURL;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommentId { get; set; }
        public int UserPostId { get; set; }
        public string CommmentedBy { get; set; }
        public string CommentContent { get; set; }
        public string ImageURL { get; set; }
    }
}
