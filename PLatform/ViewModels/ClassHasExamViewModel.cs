using PLatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PLatform.ViewModels
{
    public class ClassHasExamViewModel
    {
        public Class Class { get; set; }

        public bool HasExam { get; set; }
    }
}