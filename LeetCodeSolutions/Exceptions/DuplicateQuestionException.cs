namespace LeetCodeSolutions.Exceptions
{
    public class DuplicateQuestionException(int questionNumber)
        : Exception($"Question {questionNumber} is found more than once.");
}