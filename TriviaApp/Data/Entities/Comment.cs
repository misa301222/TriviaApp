using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TriviaApp.Data.Entities
{
    public class Comment
    {
        public Comment(int commentId, int userPostId, string commentedBy, string commentContent, string imageURL, DateTime dateComment)
        {
            CommentId = commentId;
            UserPostId = userPostId;
            CommentedBy = commentedBy;
            CommentContent = commentContent;
            ImageURL = imageURL;
            DateComment = dateComment;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommentId { get; set; }
        public int UserPostId { get; set; }
        public string CommentedBy { get; set; }
        public string CommentContent { get; set; }
        public string ImageURL { get; set; }
        public DateTime DateComment { get; set; }
    }
}
