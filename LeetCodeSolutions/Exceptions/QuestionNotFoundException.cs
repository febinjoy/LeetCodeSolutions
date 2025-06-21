namespace LeetCodeSolutions.Exceptions
{
    public class QuestionNotFoundException(int questionNumber) : Exception($"Question {questionNumber} not found.");
}