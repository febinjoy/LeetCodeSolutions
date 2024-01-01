namespace LeetCodeSolutions.Exceptions
{
    public class DuplicateQuestionException : Exception
    {
        public DuplicateQuestionException(int questionNumber) : base($"Question {questionNumber} is found more than once.") { }
    }
}