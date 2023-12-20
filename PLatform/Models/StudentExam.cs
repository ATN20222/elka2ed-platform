using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PLatform.Models
{
    public class StudentExam
    {
        [Key]
        public int Id { get; set; }


        public int Score { get; set; }

        public bool IsSubmitted { get; set; }

        // Foreign Key to link student exams to exams
        public Exam Exam { get; set; }
        public int ExamId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public string ApplicationUserId { get; set; }

    }
}