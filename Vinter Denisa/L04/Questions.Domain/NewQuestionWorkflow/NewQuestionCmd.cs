using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Questions.Domain.NewQuestionWorkflow
{
    public struct NewQuestionCmd
    {
        [Required]
        public string UserName { get; private set; }
        public string Title { get; private set; }
        public string Description { get; set; }
        [Required]
        public string DomainTag { get; private set; }

        public NewQuestionCmd(string userName, string title, string description, string domainTag)
        {
            UserName = userName;
            Title = title;
            Description = description;
            DomainTag = domainTag;
        }
    }
}
