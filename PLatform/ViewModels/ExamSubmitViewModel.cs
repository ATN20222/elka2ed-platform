using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PLatform.ViewModels
{
    public class ExamSubmitViewModel
    {
        public int ExId { get; set; }
        public int QuestId { get; set; }
        public int AnsId { get; set; }

        public bool IsSuccess { get; set; }

        public int CorrectAns { get; set; }
    }
}