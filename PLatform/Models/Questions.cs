using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PLatform.Models
{
    public class Questions
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        // Store the options for multiple-choice questions
        public ICollection<string> Options { get; set; }

        // Store the index of the correct option (e.g., 0 for the first option, 1 for the second, and so on)
        public int CorrectOptionIndex { get; set; }

        public int mark { get; set; }

        // Foreign Key to link questions to exams
        public Exam Exam { get; set; }
        public int ExamId { get; set; }

    }
}