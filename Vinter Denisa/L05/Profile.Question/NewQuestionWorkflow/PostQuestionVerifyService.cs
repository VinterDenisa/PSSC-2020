using LanguageExt.Common;
using System;
using System.Collections.Generic;
using System.Text;
using static Question.Domain.NewQuestionWorkflow.QuestionVerification;

namespace Question.Domain.NewQuestionWorkflow
{
    public class PostQuestionVerifyService
    {
        public Result<PostedQuestion> PostQuestionVerify(UnpostedQuestion question)
        {
            //verifica toate conditiile, descriere si tag-uri, inainte de a publica intrebarea

            return new PostedQuestion(question.Question, question.Tag);
        }
    }
}
