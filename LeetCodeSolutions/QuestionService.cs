using LeetCodeSolutions.Classes;
using LeetCodeSolutions.Exceptions;
using LeetCodeSolutions.Interfaces;

namespace LeetCodeSolutions
{
    public class QuestionService
    {
        private readonly IQuestionFactory _questionFactory = new QuestionFactory();

        public IResult ExecuteQuestion(int questionNumber)
        {
            try
            {
                IQuestion question = _questionFactory.GetQuestionByNumber(questionNumber);
                IResult result = question.Execute();
                if (result.Status == Enums.ResultStatus.Passed)
                {
                    var message = string.IsNullOrWhiteSpace(result.Message) ? $"Question {question.QuestionNumber}. '{question.QuestionText}' passed." : result.Message;
                    Console.WriteLine(message);
                }
                else
                {
                    Console.WriteLine($"Question {question.QuestionNumber}. '{question.QuestionText}' failed with message: {result.Message}.");
                }
                return result;
            }
            catch (QuestionNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            catch (NotImplementedException)
            {
                Console.WriteLine($"Question {questionNumber} is not implemented.");
                throw;
            }
        }
    }
}