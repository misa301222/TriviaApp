using System.ComponentModel.DataAnnotations;

namespace TriviaApp.Data.Entities
{
    public class Question
    {
        public Question(int questionId, string questionName, string firstOption, string secondOption, string thirdOption, string fourthOption, string fifthOption, string sixthOption, string answer, int roomId)
        {
            QuestionId = questionId;
            QuestionName = questionName;
            FirstOption = firstOption;
            SecondOption = secondOption;
            ThirdOption = thirdOption;
            FourthOption = fourthOption;
            FifthOption = fifthOption;
            SixthOption = sixthOption;
            Answer = answer;
            RoomId = roomId;
        }

        [Key]
        public int QuestionId { get; set; }
        public string QuestionName { get; set; }
        public string FirstOption { get; set; }
        public string SecondOption { get; set; }
        public string ThirdOption { get; set; }
        public string FourthOption { get; set; }
        public string FifthOption { get; set; }
        public string SixthOption { get; set; }
        public string Answer { get; set; }
        public int RoomId { get; set; }
    }
}
