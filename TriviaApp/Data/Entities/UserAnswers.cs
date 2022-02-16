using System.ComponentModel.DataAnnotations;

namespace TriviaApp.Data.Entities
{
    public class UserAnswers
    {
        public UserAnswers(int userAnswersId, string question, string answer, bool isRight, int userScoreId, string firstOption, string secondOption, string thirdOption, string fourthOption, string fifthOption, string sixthOption, string rightAnswer)
        {
            UserAnswersId = userAnswersId;
            Question = question;
            Answer = answer;
            IsRight = isRight;
            UserScoreId = userScoreId;
            FirstOption = firstOption;
            SecondOption = secondOption;
            ThirdOption = thirdOption;
            FourthOption = fourthOption;
            FifthOption = fifthOption;
            SixthOption = sixthOption;
            RightAnswer = rightAnswer;
        }

        [Key]
        public int UserAnswersId { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public bool IsRight { get; set; }
        public int UserScoreId { get; set; }
        public string FirstOption { get; set; }
        public string SecondOption { get; set; }
        public string ThirdOption { get; set; }
        public string FourthOption { get; set; }
        public string FifthOption { get; set; }
        public string SixthOption { get; set; }
        public string RightAnswer { get; set; }
    }
}
