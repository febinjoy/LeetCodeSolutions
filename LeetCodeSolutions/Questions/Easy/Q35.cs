using LeetCodeSolutions.Classes;
using LeetCodeSolutions.Enums;
using LeetCodeSolutions.Interfaces;

namespace LeetCodeSolutions.Questions.Easy
{
    internal class Q35 : IQuestion
    {
        public int QuestionNumber { get; private set; }
        public string QuestionText { get; private set; }
        public string QuestionLink { get; private set; }
        public Difficulty Difficulty { get; private set; }

        public Q35()
        {
            QuestionNumber = 35;
            QuestionText = "Search Insert Position";
            QuestionLink = "https://leetcode.com/problems/search-insert-position/";
            Difficulty = Difficulty.Easy;
        }

        public IResult Execute()
        {
            int[] nums = new int[] { 1, 3, 5, 6 };
            int target = 5;
            int expectedValue = 2;
            int result = SearchInsert(nums, target);
            if (result != expectedValue) return new ErrorResult($"Expected position: {expectedValue}, Actual was {result}");

            target = 2;
            expectedValue = 1;
            result = SearchInsert(nums, target);
            if (result != expectedValue) return new ErrorResult($"Expected position: {expectedValue}, Actual was {result}");

            target = 7;
            expectedValue = 4;
            result = SearchInsert(nums, target);
            if (result != expectedValue) return new ErrorResult($"Expected position: {expectedValue}, Actual was {result}");

            return new SuccessResult();
        }

        public int SearchInsert(int[] nums, int target)
        {
            if (nums.Contains(target)) return Array.IndexOf(nums, target);

            return nums.Where(num => num < target).Count();
        }
    }
}

