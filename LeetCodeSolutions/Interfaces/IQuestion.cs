using LeetCodeSolutions.Enums;

namespace LeetCodeSolutions.Interfaces
{
    public interface IQuestion
    {
        public int QuestionNumber { get; }
        public string QuestionText { get; }
        public string QuestionLink { get; }
        public Difficulty Difficulty { get; }

        public IResult Execute();
    }
}