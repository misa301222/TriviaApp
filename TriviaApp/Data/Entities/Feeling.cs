using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TriviaApp.Data.Entities
{
    public class Feeling
    {
        public Feeling(int feelingId, string feelingDescription, string feelingImageURL)
        {
            FeelingId = feelingId;
            FeelingDescription = feelingDescription;
            FeelingImageURL = feelingImageURL;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FeelingId { get; set; }
        public string FeelingDescription { get; set; }
        public string FeelingImageURL { get; set; }
    }
}
