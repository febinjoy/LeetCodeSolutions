using LeetCodeSolutions.Enums;
using LeetCodeSolutions.Interfaces;

namespace LeetCodeSolutions.Classes
{
    public class ErrorResult(string message) : IResult
    {
        public ResultStatus Status { get; private set; } = ResultStatus.Failed;
        public string Message { get; private set; } = message;
    }
}