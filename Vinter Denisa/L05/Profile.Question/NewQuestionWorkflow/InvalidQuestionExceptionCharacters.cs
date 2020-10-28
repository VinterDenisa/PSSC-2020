using System;
using System.Collections.Generic;
using System.Text;

namespace Question.Domain.NewQuestionWorkflow
{
    [Serializable]
    public class InvalidQuestionExceptionCharacters : Exception
    {
        public InvalidQuestionExceptionCharacters()
        {
        }

        public InvalidQuestionExceptionCharacters(string characters) : base($"The value \"Description\" can not have more than 1000 characters!")
        {
        }

    }
}
