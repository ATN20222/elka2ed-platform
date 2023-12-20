using PLatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PLatform.ViewModels
{
    public class QuestionAnswerSubmitViewModel
    {

        public Questions questions { get; set; }

        public List<Answers> answers { get; set; }

        public Answers CorrectAns { get; set; }
        public Answers FalseAnswer { get; set; }

    }
}