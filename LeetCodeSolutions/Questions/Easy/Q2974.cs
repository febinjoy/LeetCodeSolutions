using LeetCodeSolutions.Classes;
using LeetCodeSolutions.Enums;
using LeetCodeSolutions.Interfaces;

namespace LeetCodeSolutions.Questions.Easy
{
    internal class Q2974 : IQuestion
    {
        public int QuestionNumber { get; private set; }
        public string QuestionText { get; private set; }
        public string QuestionLink { get; private set; }
        public Difficulty Difficulty { get; private set; }

        public Q2974()
        {
            QuestionNumber = 2974;
            QuestionText = "Minimum Number Game";
            QuestionLink = "https://leetcode.com/problems/minimum-number-game/description/";
            Difficulty = Difficulty.Easy;
        }

        public IResult Execute()
        {
            int[] nums = new int[] { 5, 4, 2, 3 };
            int[] expectedNums = new int[] { 3, 2, 5, 4 };
            int[] result = NumberGame(nums);

            for (int i = 0; i < nums.Length; i++)
            {
                if (expectedNums[i] != result[i])
                {
                    return new ErrorResult($"Expected number: {expectedNums[i]}; But was {result[i]}");
                }
            }

            nums = new int[] { 2, 5 };
            expectedNums = new int[] { 5, 2 };
            result = NumberGame(nums);

            for (int i = 0; i < nums.Length; i++)
            {
                if (expectedNums[i] != result[i])
                {
                    return new ErrorResult($"Expected number: {expectedNums[i]}; But was {result[i]}");
                }
            }

            return new SuccessResult();
        }

        public int[] NumberGame(int[] nums)
        {
            int[] sortedArray = nums.OrderBy(i => i).ToArray();
            var result = new int[nums.Length];

            for (int i = 0; i < nums.Length; i = i + 2)
            {
                result[i] = sortedArray[i + 1];
                result[i + 1] = sortedArray[i];
            }

            return result;
        }

    }
}

