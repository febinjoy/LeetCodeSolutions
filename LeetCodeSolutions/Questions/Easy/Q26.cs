
using LeetCodeSolutions.Classes;
using LeetCodeSolutions.Enums;
using LeetCodeSolutions.Interfaces;

namespace LeetCodeSolutions.Questions.Easy
{
    internal class Q26 : IQuestion
    {
        public int QuestionNumber { get; private set; }
        public string QuestionText { get; private set; }
        public string QuestionLink { get; private set; }
        public Difficulty Difficulty { get; private set; }

        public Q26()
        {
            QuestionNumber = 26;
            QuestionText = "Remove Duplicates from Sorted Array";
            QuestionLink = "https://leetcode.com/problems/remove-duplicates-from-sorted-array/description/";
            Difficulty = Difficulty.Easy;
        }

        public IResult Execute()
        {
            int[] nums = new int[] { 1, 1, 2 };// Input array
            int[] expectedNums = new int[] { 1, 2 }; // The expected answer with correct length

            int count = RemoveDuplicates(nums); // Calls your implementation

            if (count != 2)
            {
                return new ErrorResult($"Expected 2, Actual {count}");
            }

            nums = new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };// Input array
            expectedNums = new int[] { 0, 1, 2, 3, 4 }; // The expected answer with correct length

            count = RemoveDuplicates(nums); // Calls your implementation

            if (count != 5)
            {
                return new ErrorResult($"Expected 5, Actual {count}");
            }

            return new SuccessResult();
        }

        // Actual Solution
        public int RemoveDuplicates(int[] nums)
        {
            var uniqueList = nums.Select(n => n).Distinct().ToArray();

            for (int i = 0; i < nums.Length; i++)
            {
                if (i < uniqueList.Count())
                {
                    nums[i] = uniqueList[i];
                }
                else
                {
                    nums[i] = 0;
                }
            }
            return uniqueList.Count();
        }
    }
}

