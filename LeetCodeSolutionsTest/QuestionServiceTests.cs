using LeetCodeSolutions;
using LeetCodeSolutions.Exceptions;
using LeetCodeSolutions.Interfaces;
using LeetCodeSolutions.Questions.Easy;
using NSubstitute;
using NSubstitute.ExceptionExtensions;

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
            // Arrange
            int questionNumber = 99999999;

            // Act + Assert
            Assert.Throws<QuestionNotFoundException>(() => questionService.ExecuteQuestion(questionNumber));
        }

        [Test]
        public void ExecuteQuestion_NotImplementedQuestion_ThrowsNotImplementedException()
        {
            // Arrange
            int questionNumber = 0;
            var mockQuestionFactory = Substitute.For<IQuestionFactory>();
            var mockQuestion = Substitute.For<IQuestion>();

            mockQuestionFactory.GetQuestionByNumber(questionNumber).Returns(new QEasySample());
            mockQuestion.Execute().Throws(new NotImplementedException());

            // Act + Assert
            Assert.Throws<NotImplementedException>(() => questionService.ExecuteQuestion(questionNumber));
        }
    }
}