using CSharp.Choices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tema6.Outputs
{
    [AsChoice]
    public static partial class SendAckToReplyAuthorResult
    {
        public interface ISendAckToReplyAuthorResult { };
        public class ReplyPublished : ISendAckToReplyAuthorResult
        {
            public string ConfirmationMessage { get; }
            public ReplyPublished(string confirmationMessage)
            {
                ConfirmationMessage = confirmationMessage;
            }
        }
        public class InvalidReplyPublished : ISendAckToReplyAuthorResult
        {
            public string ErrorMessage { get; }
            public InvalidReplyPublished(string errorMessage)
            {
                ErrorMessage = errorMessage;
            }
        }
    }
}
