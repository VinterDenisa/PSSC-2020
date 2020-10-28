using System;
using System.Collections.Generic;
using System.Text;

namespace Question.Domain.NewQuestionWorkflow
{
    [Serializable]
    public class InvalidQuestionExceptionTag : Exception
    {
        public InvalidQuestionExceptionTag()
        {
        }

        public InvalidQuestionExceptionTag(List<string> tag) : base($"The value \"Tag\" is "+ tag.Count +" and it must be at least 1 and no more than 3!")
        {
        }

    }
}
