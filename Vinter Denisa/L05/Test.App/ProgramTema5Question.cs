using LanguageExt;
using Question.Domain.NewQuestionWorkflow;
using System;
using System.Collections.Generic;
using System.Text;
using static Question.Domain.NewQuestionWorkflow.QuestionVerification;

namespace Test.App
{
    class ProgramTema5Question
    {
        static void Main(string[] args)
        {
            var questionResult = UnpostedQuestion.Create("What is a .net application?", new List<string>() { "c#" });


            questionResult.Match(
                    Succ: question =>
                    {
                        VoteQuestion(question);
                        Console.WriteLine("Can vote this question!");
                        return Unit.Default;
                    },
                    Fail: ex =>
                    {
                        Console.WriteLine($"Question could not be posted. Reason: {ex.Message}");
                        return Unit.Default;
                    }
                );
            Console.ReadLine();
        }
        private static void VoteQuestion(UnpostedQuestion question)
        {
            var postedQuestionResult = new PostQuestionVerifyService().PostQuestionVerify(question);
            postedQuestionResult.Match(
                    QuestionVote =>
                    {
                        new VoteQuestionService().VoteQuestion(QuestionVote);
                        return Unit.Default;
                    },
                    ex =>
                    {
                        Console.WriteLine("Can not vote this question!");
                        return Unit.Default;
                    }
                );
        }
    }
}
