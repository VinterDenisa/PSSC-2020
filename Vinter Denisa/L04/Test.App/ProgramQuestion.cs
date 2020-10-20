using Questions.Domain.NewQuestionWorkflow;
using System;
using System.Collections.Generic;
using System.Text;
using static Questions.Domain.NewQuestionWorkflow.NewQuestionResult;

namespace Test.App
{
    class ProgramQuestion
    {
        static void Main(string[] args)
        {
            var cmd = new NewQuestionCmd("Numele user-ului", "Titlu", "Descrierea intrebarii", "Domeniul din care este intrebarea / tag-ul");
            var result = NewQuestion(cmd);

            result.Match(
                    ProcessQuestionPosted,
                    ProcessQuestionNotPosted,
                    ProcessInvalidQuestion
                );

            Console.ReadLine();
        }

        private static INewQuestionResult ProcessInvalidQuestion(QuestionValidationFailed validationErrors)
        {
            Console.WriteLine("Question validation failed: ");
            foreach (var error in validationErrors.ValidationErrors)
            {
                Console.WriteLine(error);
            }
            return validationErrors;
        }

        private static INewQuestionResult ProcessQuestionNotPosted(QuestionNotPosted questionNotPostedResult)
        {
            Console.WriteLine($"Question not posted: {questionNotPostedResult.Reason}");
            return questionNotPostedResult;
        }

        private static INewQuestionResult ProcessQuestionPosted(QuestionPosted question)
        {
            Console.WriteLine($"Profile {question.QuestionId}");
            return question;
        }

        public static INewQuestionResult NewQuestion(NewQuestionCmd newQuestionCommand)
        {
            if (string.IsNullOrWhiteSpace(newQuestionCommand.Title))
            {
                var errors = new List<string>() { "Please provide a title" };
                return new QuestionValidationFailed(errors);
            }
            if (string.IsNullOrWhiteSpace(newQuestionCommand.Description))
            {
                var errors = new List<string>() { "Please provide a description for the question" };
                return new QuestionValidationFailed(errors);
            }
            if (string.IsNullOrWhiteSpace(newQuestionCommand.DomainTag))
            {
                var errors = new List<string>() { "Please provide a domain/tag for the question" };
                return new QuestionValidationFailed(errors);
            }

            if (new Random().Next(10) > 1)
            {
                return new QuestionNotPosted("ML validation failed");
            }

            var questionId = Guid.NewGuid();
            var result = new QuestionPosted(questionId, newQuestionCommand.UserName);

            //execute logic
            return result;
        }
    }
}
