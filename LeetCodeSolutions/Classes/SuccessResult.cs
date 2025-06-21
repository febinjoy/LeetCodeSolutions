using LeetCodeSolutions.Enums;
using LeetCodeSolutions.Interfaces;

namespace LeetCodeSolutions.Classes
{
    public class SuccessResult(string message) : IResult
    {
        public ResultStatus Status { get; private set; } = ResultStatus.Passed;
        public string Message { get; private set; } = message;

        public SuccessResult() : this(string.Empty)
        {
        }
    }
}