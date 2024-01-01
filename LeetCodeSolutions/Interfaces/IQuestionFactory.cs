namespace LeetCodeSolutions.Interfaces
{
    public interface IQuestionFactory
    {
        public IQuestion GetQuestionByNumber(int number);
    }
}