using LeetCodeSolutions;
using LeetCodeSolutions.Classes;
using LeetCodeSolutions.Enums;
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

        #region Setup

        [SetUp]
        public void Setup()
        {
            questionService = new QuestionService();
        }

        #endregion Setup

        #region Exception Tests

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

        #endregion Exception Tests

        #region Easy Questions

        [Test]
        public void ExecuteQuestion_Q2331_ReturnsSuccessResult()
        {
            // Arrange
            int questionNumber = 2331;

            // Act
            IResult result = questionService.ExecuteQuestion(questionNumber);

            // Assert
            Assert.IsInstanceOf<SuccessResult>(result);
            Assert.That(result.Status, Is.EqualTo(ResultStatus.Passed));
        }

        #endregion Easy Questions
    }
}