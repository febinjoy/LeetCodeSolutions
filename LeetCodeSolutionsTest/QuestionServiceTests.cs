using LeetCodeSolutions;
using LeetCodeSolutions.Exceptions;

namespace LeetCodeSolutionsTest
{
    public class QuestionServiceTests
    {
        private QuestionService questionService;

        [SetUp]
        public void Setup()
        {
            questionService = new QuestionService();
        }

        [Test]
        public void ExecuteQuestion_UnknownQuestionNumber_ThrowsQuestionNotFoundException()
        {
            // Arrange + Act + Assert
            Assert.Throws<QuestionNotFoundException>(() => questionService.ExecuteQuestion(99999999));
        }
    }
}