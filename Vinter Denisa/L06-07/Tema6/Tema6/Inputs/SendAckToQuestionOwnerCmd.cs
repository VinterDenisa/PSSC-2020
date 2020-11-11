using System;
using System.Collections.Generic;
using System.Text;

namespace Tema6.Inputs
{
    public class SendAckToQuestionOwnerCmd
    {
        public int AuthorId { get; }
        public int QuestionId { get; }
        public string Reply { get; }
        public SendAckToQuestionOwnerCmd(int authorId, int questionId, string reply)
        {
            AuthorId = authorId;
            QuestionId = questionId;
            Reply = reply;
        }
    }
}
