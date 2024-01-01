using LeetCodeSolutions.Enums;
using LeetCodeSolutions.Interfaces;

namespace LeetCodeSolutions.Classes
{
    public class SuccessResult : IResult
    {
        public ResultStatus Status { get; private set; } = ResultStatus.Passed;
        public string Message { get; private set; }

        public SuccessResult()
        {
            Message = string.Empty;
        }

        public SuccessResult(string message)
        {
            Message = message;
        }
    }
}