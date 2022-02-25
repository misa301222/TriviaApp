namespace TriviaApp.Data.Entities
{
    public class Activity
    {
        public Activity(int activityId, string email, string activityDescription, string category, DateTime dateActivity)
        {
            ActivityId = activityId;
            Email = email;
            ActivityDescription = activityDescription;
            Category = category;
            DateActivity = dateActivity;
        }
        public int ActivityId { get; set; }
        public string Email { get; set; }
        public string ActivityDescription { get; set; }
        public string Category { get; set; }
        public DateTime DateActivity { get; set; }
    }
}
