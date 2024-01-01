namespace LeetCodeSolutions.Exceptions
{
    public class QuestionNotFoundException : Exception
    {
        public QuestionNotFoundException(int questionNumber) : base($"Question {questionNumber} not found.") { }
    }
}