using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Question.Domain.NewQuestionWorkflow.QuestionVerification;

namespace Question.Domain.NewQuestionWorkflow
{
    public class VoteQuestionService
    {
        public Task VoteQuestion(PostedQuestion question)
        {
            //ensure that the vote is registered for that question
            return Task.CompletedTask;
        }
    }
}
