using LeetCodeSolutions.Classes;
using LeetCodeSolutions.Enums;
using LeetCodeSolutions.Interfaces;

namespace LeetCodeSolutions.Questions.Easy
{
    internal class Q2331 : IQuestion
    {
        public int QuestionNumber { get; private set; }
        public string QuestionText { get; private set; }
        public string QuestionLink { get; private set; }
        public Difficulty Difficulty { get; private set; }

        private class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        public Q2331()
        {
            QuestionNumber = 2331;
            QuestionText = "Evaluate Boolean Binary Tree";
            QuestionLink = "https://leetcode.com/problems/evaluate-boolean-binary-tree/";
            Difficulty = Difficulty.Easy;
        }

        public IResult Execute()
        {
            TreeNode node = new TreeNode(2, new TreeNode(1), new TreeNode(3, new TreeNode(0), new TreeNode(1)));
            bool output = EvaluateTree(node);
            if (output == true)
                return new SuccessResult();
            else
                return new ErrorResult("Expected True. But was False.");
        }

        // Actual Solution
        private bool EvaluateTree(TreeNode root)
        {
            if (root.val == 3)
                return EvaluateTree(root.left) && EvaluateTree(root.right);
            else if (root.val == 2)
                return EvaluateTree(root.left) || EvaluateTree(root.right);
            else if (root.val == 0)
                return false;
            return true;
        }
    }
}

