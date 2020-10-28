using CSharp.Choices;
using System;
using System.Collections.Generic;
using System.Text;
using LanguageExt.Common;

namespace Question.Domain.NewQuestionWorkflow
{
    [AsChoice]
    public static partial class QuestionVerification
    {
        public interface IQuestionVerification { }
        public class UnpostedQuestion : IQuestionVerification
        {
            public string Question { get; private set; }
            public List<string> Tag { get; private set; }

            private UnpostedQuestion(string question, List<string> tag)
            {
                Question = question;
                Tag = tag;
            }

            public static Result<UnpostedQuestion> Create(string question, List<string> tag)
            {
                if (IsQuestionValid(question))
                {
                    if (IsTagValid(tag))
                    {
                        return new UnpostedQuestion(question, tag);
                    }
                    else
                    {
                        return new Result<UnpostedQuestion>(new InvalidQuestionExceptionTag(tag));
                    }
                }
                else
                {
                    return new Result<UnpostedQuestion>(new InvalidQuestionExceptionCharacters(question));
                }
            }

            private static bool IsQuestionValid(string question)
            {
                if (question.Length < 1000)
                {
                    return true;
                }
                return false;
            }
            private static bool IsTagValid(List<string> tag)
            {
                if (tag.Count >= 1 && tag.Count <= 3)
                {
                    return true;
                }
                return false;
            }
        }
        public class PostedQuestion : IQuestionVerification
        {
            public string Question { get; private set; }
            public List<string> Tag { get; private set; }

            internal PostedQuestion(string question, List<string> tag)
            {
                Question = question;
                Tag = tag;
            }
        }
    }
}
