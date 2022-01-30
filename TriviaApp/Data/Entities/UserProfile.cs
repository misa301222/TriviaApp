using System.ComponentModel.DataAnnotations;

namespace TriviaApp.Data.Entities
{
    public class UserProfile
    {
        public UserProfile(string email, string imageURL, string coverURL, string location, string aboutMeHeader, string aboutMeDescription)
        {
            Email = email;
            ImageURL = imageURL;
            CoverURL = coverURL;
            Location = location;
            AboutMeHeader = aboutMeHeader;
            AboutMeDescription = aboutMeDescription;
        }

        [Key]
        public string Email { get; set; }
        public string ImageURL { get; set; }
        public string CoverURL { get; set; }
        public string Location { get; set; }
        public string AboutMeHeader { get; set; }
        public string AboutMeDescription { get; set; }
    }
}
