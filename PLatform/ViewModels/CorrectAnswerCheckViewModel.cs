using PLatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PLatform.ViewModels
{
    public class CorrectAnswerCheckViewModel
    {
        public Answers answer { get; set; }

        public bool IsCorrect { get; set; }

    }
}