﻿using Access.Primitives.Extensions.ObjectExtensions;
using Access.Primitives.IO;
using StackUnderflow.Domain.Core.Contexts.Question.CreateQuestion;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static StackUnderflow.Domain.Core.Contexts.Question.CreateQuestion.CreateQuestionResult;

namespace StackUnderflow.Domain.Core.Contexts.Question.CreateQuestion
{
    class CreateQuestionAdapter : Adapter<CreateQuestionCmd, CreateQuestionResult.ICreateQuestionResult, QuestionWriteContext, QuestionDependencies>
    {
        public override Task PostConditions(CreateQuestionCmd cmd, CreateQuestionResult.ICreateQuestionResult result, QuestionWriteContext state)
        {
            return Task.CompletedTask;
        }

        public async override Task<ICreateQuestionResult> Work(CreateQuestionCmd cmd, QuestionWriteContext state, QuestionDependencies dependencies)
        {
            var workflow = from valid in cmd.TryValidate()
                           let t = AddQuestion(state, CreateQuestionFromCmd(cmd))
                           select t;

            var result = await workflow.Match(
                Succ: r => r,
                Fail: er => new QuestionNotPosted(er.Message)
                );

            return result;
        }

        private ICreateQuestionResult AddQuestion(QuestionWriteContext state, object v)
        {
            return new QuestionPosted(new Guid("1"), "Title", "Body", "Tag");
        }

        private object CreateQuestionFromCmd(CreateQuestionCmd cmd)
        {
            return new { };
        }
    }
}
