using LeetCodeSolutions.Enums;
using LeetCodeSolutions.Interfaces;

namespace LeetCodeSolutions.Questions.Easy
{
    public class QEasySample : IQuestion
    {
        public int QuestionNumber { get; private set; }
        public string QuestionText { get; private set; }
        public string QuestionLink { get; private set; }
        public Difficulty Difficulty { get; private set; }

        public QEasySample()
        {
            QuestionNumber = 0;
            QuestionText = "Question";
            QuestionLink = "Link";
            Difficulty = Difficulty.Easy;
        }

        public IResult Execute()
        {
            throw new NotImplementedException();
        }
    }
}