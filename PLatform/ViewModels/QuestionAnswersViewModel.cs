using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PLatform.Models
{
    public class QuestionAnswersViewModel
    {
        //public Dictionary<Questions , IEnumerable<Answers>> MyProperty { get; set; }
        public Questions questions { get; set ; }

        public List<Answers> answers { get; set; }
    }
}