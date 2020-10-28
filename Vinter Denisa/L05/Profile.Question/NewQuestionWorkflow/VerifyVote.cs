using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using static Question.Domain.NewQuestionWorkflow.NewQuestionResult;

namespace Question.Domain.NewQuestionWorkflow
{
    public class VerifyVote
    {
        public QuestionPosted VoteQuestion (QuestionPosted question, VoteEnum vote)
        {
            var allvotes = question.AllVotes;
            allvotes.Append(vote);
            return new QuestionPosted(question.QuestionId, question.Question, allvotes.Sum(v => Convert.ToInt32(v)), allvotes);
        }
    }
}
