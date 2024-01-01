using LeetCodeSolutions.Classes;
using LeetCodeSolutions.Exceptions;
using LeetCodeSolutions.Interfaces;

namespace LeetCodeSolutions
{
    class Program
    {
        private static readonly IQuestionFactory _questionFactory = new QuestionFactory();

        static void Main(string[] args)
        {
            // Easy
            ExecuteQuestion(2331);
            ExecuteQuestion(58);
            ExecuteQuestion(26);
            ExecuteQuestion(9);
            ExecuteQuestion(35);
            ExecuteQuestion(2974);

            //Medium
            ExecuteQuestion(2);

            // Hard

        }

        private static void ExecuteQuestion(int questionNumber)
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
            }
            catch (QuestionNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (NotImplementedException)
            {
                Console.WriteLine($"Question {questionNumber} is not implemented.");
            }
        }
    }
}

