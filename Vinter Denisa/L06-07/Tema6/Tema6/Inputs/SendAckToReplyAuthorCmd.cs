using System;
using System.Collections.Generic;
using System.Text;

namespace Tema6.Inputs
{
    public class SendAckToReplyAuthorCmd
    {
        public int ReplyId { get; }
        public int QuestionId { get; }
        public string Reply { get; }
        public SendAckToReplyAuthorCmd(int replyId, int questionId, string reply)
        {
            ReplyId = replyId;
            QuestionId = questionId;
            Reply = reply;
        }
    }
}
