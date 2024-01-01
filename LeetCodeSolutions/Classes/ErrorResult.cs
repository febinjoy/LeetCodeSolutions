using LeetCodeSolutions.Enums;
using LeetCodeSolutions.Interfaces;

namespace LeetCodeSolutions.Classes
{
    public class ErrorResult : IResult
    {
        public ResultStatus Status { get; private set; } = ResultStatus.Failed;
        public string Message { get; private set; }

        public ErrorResult(string message)
        {
            Message = message;
        }
    }
}