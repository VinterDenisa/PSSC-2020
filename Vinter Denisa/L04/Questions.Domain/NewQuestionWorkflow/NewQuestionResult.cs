using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharp.Choices;

namespace Questions.Domain.NewQuestionWorkflow
{
    [AsChoice]
    public static partial class NewQuestionResult
    {
        public interface INewQuestionResult { }
        public class QuestionPosted : INewQuestionResult
        {
            public Guid QuestionId { get; private set; }
            public string User { get; private set; }

            public QuestionPosted(Guid questionId, string user)
            {
                QuestionId = questionId;
                User = user;
            }
        }
        public class QuestionNotPosted : INewQuestionResult
        {
            public string Reason { get; set; }

            public QuestionNotPosted(string reason)
            {
                Reason = reason;
            }
        }
        public class QuestionValidationFailed : INewQuestionResult
        {
            public IEnumerable<string> ValidationErrors { get; private set; }

            public QuestionValidationFailed(IEnumerable<string> errors)
            {
                ValidationErrors = errors.AsEnumerable();
            }
        }
    }
}
