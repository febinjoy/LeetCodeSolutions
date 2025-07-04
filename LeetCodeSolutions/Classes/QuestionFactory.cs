using System.Reflection;
using LeetCodeSolutions.Exceptions;
using LeetCodeSolutions.Interfaces;

namespace LeetCodeSolutions.Classes
{
    public class QuestionFactory : IQuestionFactory
    {
        readonly Dictionary<int, IQuestion> _questions;
        public QuestionFactory()
        {
            _questions = new Dictionary<int, IQuestion>();

            // Load all classes that implement IQuestion to the Dictionary
            var instances = from t in Assembly.GetExecutingAssembly().GetTypes()
                            where t.GetInterfaces().Contains(typeof(IQuestion))
                                     && t.GetConstructor(Type.EmptyTypes) != null
                            select Activator.CreateInstance(t) as IQuestion;


            // TODO: Use LINQ and improve this.
            foreach (var question in instances)
            {
                if (!_questions.TryAdd(question.QuestionNumber, question))
                    throw new DuplicateQuestionException(question.QuestionNumber);
            }
        }

        public IQuestion GetQuestionByNumber(int number)
        {
            if (_questions.TryGetValue(number, out var byNumber) == false) throw new QuestionNotFoundException(number);

            return byNumber;
        }
    }
}