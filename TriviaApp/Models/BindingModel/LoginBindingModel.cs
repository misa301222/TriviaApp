using System.ComponentModel.DataAnnotations;

namespace TriviaApp.Models.BindingModel
{
    public class LoginBindingModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
