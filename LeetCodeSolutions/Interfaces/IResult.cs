using LeetCodeSolutions.Enums;

namespace LeetCodeSolutions.Interfaces
{
    public interface IResult
    {
        public ResultStatus Status { get; }
        public string Message { get; }
    }
}