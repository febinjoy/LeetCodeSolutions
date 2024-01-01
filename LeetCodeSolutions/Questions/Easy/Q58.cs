
using LeetCodeSolutions.Classes;
using LeetCodeSolutions.Enums;
using LeetCodeSolutions.Interfaces;

namespace LeetCodeSolutions.Questions.Easy
{
    internal class Q58 : IQuestion
    {
        public int QuestionNumber { get; private set; }
        public string QuestionText { get; private set; }
        public string QuestionLink { get; private set; }
        public Difficulty Difficulty { get; private set; }

        public Q58()
        {
            QuestionNumber = 58;
            QuestionText = "Length of Last Word";
            QuestionLink = "https://leetcode.com/problems/length-of-last-word/description/";
            Difficulty = Difficulty.Easy;
        }

        public IResult Execute()
        {
            Dictionary<string, int> words = new Dictionary<string, int>();
            words.Add("Hello World", 5);
            words.Add("   fly me   to   the moon  ", 4);
            words.Add("luffy is still joyboy", 6);

            foreach (KeyValuePair<string, int> word in words)
            {
                var result = AssertAndVerify(word.Key, word.Value);
                if (result.Status == ResultStatus.Failed)
                    return result;
            }

            return new SuccessResult();
        }

        private IResult AssertAndVerify(string word, int expectedLength)
        {
            int length = LengthOfLastWord(word);
            if (length != expectedLength) return new ErrorResult($"Expected length: {expectedLength}; But was {length}");
            return new SuccessResult();
        }

        // Actual Solution
        private int LengthOfLastWord(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return 0;

            s = s.Trim();
            return s.Substring(s.LastIndexOf(" ") + 1).Length;
        }
    }
}

