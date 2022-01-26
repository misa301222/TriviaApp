using System.ComponentModel.DataAnnotations;

namespace TriviaApp.Data.Entities
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        [Key]
        public int QuestionId { get; set; }
        public string Option { get; set; }
        public string Answer { get; set; }
    }
}
