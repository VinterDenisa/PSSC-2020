using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Question.Domain.NewQuestionWorkflow
{
    public struct NewQuestionCmd
    {
        [Required]
        public string Title { get; private set; }
        [Required]
        [StringLength(100, MinimumLength = 3,
        ErrorMessage = "Description should have minimum 3 characters and a maximum of 100 characters")]
        [DataType(DataType.Text)]
        public string Description { get; private set; }
        [Required]
        public string TagsQuestion { get; private set; }

        public NewQuestionCmd(string title, string description, string tagQuestion)
        {
            Title = title;
            Description = description;
            TagsQuestion = tagQuestion;
        }
    }
}
