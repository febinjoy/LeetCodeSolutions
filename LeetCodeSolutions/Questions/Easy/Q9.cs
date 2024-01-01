
using LeetCodeSolutions.Classes;
using LeetCodeSolutions.Enums;
using LeetCodeSolutions.Interfaces;

namespace LeetCodeSolutions.Questions.Easy
{
    internal class Q9 : IQuestion
    {
        public int QuestionNumber { get; private set; }
        public string QuestionText { get; private set; }
        public string QuestionLink { get; private set; }
        public Difficulty Difficulty { get; private set; }

        public Q9()
        {
            QuestionNumber = 9;
            QuestionText = "Palindrome Number";
            QuestionLink = "https://leetcode.com/problems/palindrome-number/description/";
            Difficulty = Difficulty.Easy;
        }

        public IResult Execute()
        {
            int number = 121;
            bool expected = true;
            if (IsPalindrome(number) != expected) return new ErrorResult($"Expected {number} check to return {expected}, Actual was {!expected}");

            number = -121;
            expected = false;
            if (IsPalindrome(number) != expected) return new ErrorResult($"Expected {number} check to return {expected}, Actual was {!expected}");

            number = 10;
            expected = false;
            if (IsPalindrome(number) != expected) return new ErrorResult($"Expected {number} check to return {expected}, Actual was {!expected}");

            return new SuccessResult();
        }

        public bool IsPalindrome(int x)
        {
            if (x < 0) return false;

            int forward = x;
            int reverse = 0;
            while (forward != 0)
            {
                reverse = (reverse * 10) + forward % 10;
                forward /= 10;
            }
            return (reverse == x);
        }
    }
}

