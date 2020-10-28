using CSharp.Choices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Question.Domain.NewQuestionWorkflow
{
    [AsChoice]
    public static partial class NewQuestionResult
    {
        public interface INewQuestionResult { }

        public class QuestionPosted : INewQuestionResult
        {
            public Guid QuestionId { get; private set; }
            public string Question { get; private set; }
            public int VoteCount { get; private set; }
            public IReadOnlyCollection<VoteEnum> AllVotes { get; private set; }

            public QuestionPosted(Guid questionId, string question, int voteCount, IReadOnlyCollection<VoteEnum> allVotes)
            {
                QuestionId = questionId;
                Question = question;
                VoteCount = voteCount;
                AllVotes = allVotes;
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
