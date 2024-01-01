using LeetCodeSolutions.Classes;
using LeetCodeSolutions.Enums;
using LeetCodeSolutions.Interfaces;

namespace LeetCodeSolutions.Questions.Medium
{
    internal class Q2 : IQuestion
    {
        public int QuestionNumber { get; private set; }
        public string QuestionText { get; private set; }
        public string QuestionLink { get; private set; }
        public Difficulty Difficulty { get; private set; }

        // Definition for singly-linked list from the question.
        private class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

        public Q2()
        {
            QuestionNumber = 2;
            QuestionText = "Add Two Numbers";
            QuestionLink = "https://leetcode.com/problems/add-two-numbers/description/";
            Difficulty = Difficulty.Medium;
        }

        public IResult Execute()
        {
            IResult assertResult;
            ListNode l1 = new ListNode(2, new ListNode(4, new ListNode(3)));
            ListNode l2 = new ListNode(5, new ListNode(6, new ListNode(4)));
            ListNode result = AddTwoNumbers(l1, l2);
            ListNode expected = new ListNode(7, new ListNode(0, new ListNode(8)));
            assertResult = AssertAddTwoNumbers(result, expected);
            if (assertResult is ErrorResult) return assertResult;

            l1 = new ListNode(0);
            l2 = new ListNode(0);
            result = AddTwoNumbers(l1, l2);
            expected = new ListNode(0);
            assertResult = AssertAddTwoNumbers(result, expected);
            if (assertResult is ErrorResult) return assertResult;

            l1 = new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9)))))));
            l2 = new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9))));
            result = AddTwoNumbers(l1, l2);
            expected = new ListNode(8, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(1))))))));
            assertResult = AssertAddTwoNumbers(result, expected);
            if (assertResult is ErrorResult) return assertResult;

            l1 = new ListNode(1, new ListNode(9));
            l2 = new ListNode(4);
            result = AddTwoNumbers(l1, l2);
            expected = new ListNode(5, new ListNode(9));
            assertResult = AssertAddTwoNumbers(result, expected);
            if (assertResult is ErrorResult) return assertResult;

            l1 = new ListNode(9);
            l2 = new ListNode(1, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9))))))))));
            result = AddTwoNumbers(l1, l2);
            expected = new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(1)))))))))));
            assertResult = AssertAddTwoNumbers(result, expected);
            if (assertResult is ErrorResult) return assertResult;

            return new SuccessResult();
        }

        private IResult AssertAddTwoNumbers(ListNode result, ListNode expected)
        {
            string resultString = string.Empty;
            string expectedString = string.Empty;
            ListNode currentNode = result;
            while (currentNode != null)
            {
                resultString = $"{currentNode.val}{resultString}";
                currentNode = currentNode.next;
            }

            currentNode = expected;
            while (currentNode != null)
            {
                expectedString = $"{currentNode.val}{expectedString}";
                currentNode = currentNode.next;
            }

            if (!string.Equals(resultString, expectedString))
            {

                return new ErrorResult($"Not Same!!! Expected: {expectedString}; Actual:{resultString}");
            }

            return new SuccessResult();
        }

        private ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            int carryForward = 0;
            ListNode currentL1 = l1;
            ListNode currentL2 = l2;

            ListNode dummyHead = new ListNode(0);
            ListNode currentNode = dummyHead;

            do
            {
                currentNode.next = new ListNode(0);
                currentNode = currentNode.next;
                if (currentL1 != null)
                {
                    currentNode.val += currentL1.val;
                    currentL1 = currentL1.next;
                }
                if (currentL2 != null)
                {
                    currentNode.val += currentL2.val;
                    currentL2 = currentL2.next;
                }
                currentNode.val += carryForward;
                carryForward = currentNode.val / 10;
                currentNode.val = currentNode.val % 10;
            } while (!(currentL1 == null && currentL2 == null) || carryForward > 0);

            return dummyHead.next;
        }
    }
}

