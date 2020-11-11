using CSharp.Choices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tema6.Outputs
{
    [AsChoice]
    public static partial class SendAckToQuestionOwnerResult
    {
        public interface ISendAckToQuestionOwnerResult { }
        public class ReplyReceived : ISendAckToQuestionOwnerResult
        {
            public string Reply { get; }
            public ReplyReceived(string reply)
            {
                Reply = reply;
            }
        }
        public class InvalidReplyReceived : ISendAckToQuestionOwnerResult
        {
            public string ErrorMessage { get; }
            public InvalidReplyReceived(string errorMessage)
            {
                ErrorMessage = errorMessage;
            }
        }
    }
}
