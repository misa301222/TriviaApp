namespace TriviaApp.Data.Entities
{
    public class UserAnswers
    {
        public UserAnswers(int userAnswersId, string question, string answer, bool isRight, int userScoreId)
        {
            UserAnswersId = userAnswersId;
            Question = question;
            Answer = answer;
            this.isRight = isRight;
            UserScoreId = userScoreId;
        }

        public int UserAnswersId { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public Boolean isRight { get; set; }
        public int UserScoreId { get; set; }
    }
}
