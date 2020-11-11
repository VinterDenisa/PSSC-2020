using Access.Primitives.IO;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tema6.Inputs;
using Tema6.Outputs;
using Access.Primitives.Extensions.ObjectExtensions;
using static LanguageExt.Prelude;

namespace Tema6.Adapters
{
    class SendAckToReplyAuthorAdapter : Adapter<SendAckToReplyAuthorCmd, SendAckToReplyAuthorResult.ISendAckToReplyAuthorResult, QuestionWriteContext>
    {
        public override Task PostConditions(SendAckToReplyAuthorCmd cmd, SendAckToReplyAuthorResult.ISendAckToReplyAuthorResult result, QuestionWriteContext state)
        {
            return Task.CompletedTask;
        }

        public override async Task< SendAckToReplyAuthorResult.ISendAckToReplyAuthorResult> Work(SendAckToReplyAuthorCmd cmd, QuestionWriteContext state)
        {
            var wf = from isValid in cmd.TryValidate()
                     from ackSentToReplyAuthor in AckSentToReplyAuthor(cmd, state)
                     select ackSentToReplyAuthor;
            return await wf.Match(
                  Succ: ReplyAuthor => ReplyAuthor,
                  Fail: ex => new SendAckToReplyAuthorResult.InvalidReplyPublished(ex.ToString()));
        }
        private TryAsync<SendAckToReplyAuthorResult.ISendAckToReplyAuthorResult> AckSentToReplyAuthor(SendAckToReplyAuthorCmd cmd, QuestionWriteContext state)
        {

            return TryAsync<SendAckToReplyAuthorResult.ISendAckToReplyAuthorResult>(async () =>
            {
                return new SendAckToReplyAuthorResult.ReplyPublished(cmd.Reply);
            });
        }
    }
}
