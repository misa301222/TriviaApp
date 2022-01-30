using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TriviaApp.Data.Entities
{
    public class Room
    {
        public Room(int roomId, string generatedName, string createdBy, DateTime dateCreated)
        {
            RoomId = roomId;
            GeneratedName = generatedName;
            CreatedBy = createdBy;
            DateCreated = dateCreated;
        }

        [Key]
        public int RoomId { get; set; }
        public string GeneratedName { get; set; }
        public string CreatedBy { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime DateCreated { get; set; }
    }
}
