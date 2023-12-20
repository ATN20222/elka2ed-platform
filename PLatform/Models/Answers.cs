using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PLatform.Models
{
    public class Answers
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public Questions Questions { get; set; }
        public int  QuestionsId { get; set; }

    }
}