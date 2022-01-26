using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TriviaApp.Data.Entities
{
    public class Room
    {
        [Key]
        public int Id { get; set; }
        [Key]
        public string GeneratedName { get; set; }

        public Question QuestionForeignKey { get; set; }
    }
}
