using PLatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PLatform.ViewModels
{
    public class AddQuestsAndAnswersViewModel
    {
        public Questions question { get; set; }
        public CorrectAnswerCheckViewModel answer1 { get; set; }
        public CorrectAnswerCheckViewModel answer2 { get; set; }
        public CorrectAnswerCheckViewModel answer3 { get; set; }
        public CorrectAnswerCheckViewModel answer4 { get; set; }



    }
}