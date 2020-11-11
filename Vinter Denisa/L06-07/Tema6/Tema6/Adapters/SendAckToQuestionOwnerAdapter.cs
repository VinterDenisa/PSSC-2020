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
    class SendAckToQuestionOwnerAdapter : Adapter<SendAckToQuestionOwnerCmd, SendAckToQuestionOwnerResult.ISendAckToQuestionOwnerResult, QuestionWriteContext>
    {
        public override Task PostConditions(SendAckToQuestionOwnerCmd cmd, SendAckToQuestionOwnerResult.ISendAckToQuestionOwnerResult result, QuestionWriteContext state)
        {
            return Task.CompletedTask;
        }

        public override async Task<SendAckToQuestionOwnerResult.ISendAckToQuestionOwnerResult> Work(SendAckToQuestionOwnerCmd cmd, QuestionWriteContext state)
        {
            var wf = from isValid in cmd.TryValidate()
                     from ownerAck in OwnerAckResult(cmd, state)
                     select ownerAck;
            return await wf.Match(
                  Succ: owner => owner,
                  Fail: ex => new SendAckToQuestionOwnerResult.InvalidReplyReceived(ex.ToString()));
        }
        private TryAsync<SendAckToQuestionOwnerResult.ISendAckToQuestionOwnerResult> OwnerAckResult(SendAckToQuestionOwnerCmd cmd, QuestionWriteContext state)
        {

            return TryAsync<SendAckToQuestionOwnerResult.ISendAckToQuestionOwnerResult>(async () =>
            {
                return new SendAckToQuestionOwnerResult.ReplyReceived(cmd.Reply);
            });
        }
    }
}
