using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PLatform.Models
{
    public class Exam
    {
        public int Id { get; set; }

        public string Title { get; set; }


        public int DurationInMinutes { get; set; }

        public int totalMark { get; set; }

        // Foreign Key to link exams to lectures
        public Class Class { get; set; }
        public int ClassId { get; set; }

        // Navigation property to store exam questions
        public ICollection<Questions> Questions { get; set; }
    }
}