using PLatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PLatform.ViewModels
{
    public class ExamQuestionsViewModel
    {
        public Exam exam { get; set; }

        public List<QuestionAnswersViewModel> QuestionsAndAnswers { get; set; }


    }
}