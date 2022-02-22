namespace TriviaApp.Data.Entities
{
    public class AnimalConfig
    {
        public AnimalConfig(int animalConfigId, string email, string animal)
        {
            AnimalConfigId = animalConfigId;
            Email = email;
            Animal = animal;
        }

        public int AnimalConfigId { get; set; }
        public string Email { get; set; }
        public string Animal { get; set; }
    }
}
