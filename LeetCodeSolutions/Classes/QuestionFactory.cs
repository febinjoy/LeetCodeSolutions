using System.Reflection;
using LeetCodeSolutions.Exceptions;
using LeetCodeSolutions.Interfaces;

namespace LeetCodeSolutions.Classes
{
    public class QuestionFactory : IQuestionFactory
    {
        Dictionary<int, IQuestion> questions;
        public QuestionFactory()
        {
            questions = new Dictionary<int, IQuestion>();

            // Load all classes that implement IQuestion to the Dictionary
            var instances = from t in Assembly.GetExecutingAssembly().GetTypes()
                            where t.GetInterfaces().Contains(typeof(IQuestion))
                                     && t.GetConstructor(Type.EmptyTypes) != null
                            select Activator.CreateInstance(t) as IQuestion;


            // TODO: Use LINQ and improve this.
            foreach (var question in instances)
            {
                if (questions.ContainsKey(question.QuestionNumber))
                    throw new DuplicateQuestionException(question.QuestionNumber);

                questions.Add(question.QuestionNumber, question);
            }
        }

        public IQuestion GetQuestionByNumber(int number)
        {
            if (questions.ContainsKey(number) == false) throw new QuestionNotFoundException(number);

            return questions[number];
        }
    }
}