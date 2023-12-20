using PLatform.Models;
using PLatform.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Helpers;
using Microsoft.AspNet.Identity;

namespace PLatform.Controllers
{
    [Authorize]
    public class QuizController : Controller
    {
        private ApplicationDbContext _context;
        public QuizController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Quiz

        public ActionResult Index(int Id)
        {
            var exam = _context.exams.Include(c=>c.Class).SingleOrDefault(x => x.ClassId == Id);

            var userId = User.Identity.GetUserId();

            var u = ApplicationDbContext

            var stdExam = _context.studentExams.SingleOrDefault(c => c.ExamId == exam.Id && c.ApplicationUserId == userId);

            if (stdExam != null)
            {
                TempData["message"] = "submited before";

                return RedirectToAction("Index" , "Class") ; 
            }


            ExamQuestionsViewModel ex = new ExamQuestionsViewModel();

           
            if (exam != null)
            {
                ex.exam = exam;
                var Questions = _context.questions.Include(z=>z.Exam).Where(c=>c.ExamId == exam.Id).ToList();
                if(Questions != null)
                {
                    ex.QuestionsAndAnswers = new List<QuestionAnswersViewModel>();

                    foreach (var item in Questions)
                    {
                        QuestionAnswersViewModel questionAnswers = new QuestionAnswersViewModel();
                        questionAnswers.questions = item;
                        var Ans = _context.answers.Include(z=>z.Questions).Where(c => c.QuestionsId == item.Id).ToList();

                        questionAnswers.answers = Ans;

                        ex.QuestionsAndAnswers.Add(questionAnswers);

                    }


                }

                
            }
            return View(ex);
        }



        [HttpPost]

       
        public ActionResult submitExam(List<ExamSubmitViewModel> arrayOfObjects)
        {
            var userId = User.Identity.GetUserId();

            var UserData = _context.Users.SingleOrDefault(c => c.Id == userId);



            float points = 0;

            float totalQuests = arrayOfObjects.Count;

            var x =  arrayOfObjects[0].ExId;
            var exExam = _context.exams.SingleOrDefault(c => c.Id == x);
            

            var countOfQuests = _context.questions.Where(c => c.ExamId == x).ToList();
            
            float NumOfQuestInDb= countOfQuests.Count;
            
            var Wrong = 0;

            if (totalQuests == NumOfQuestInDb)
            {
                foreach (var item in arrayOfObjects)
                {
                    var quests = _context.questions.SingleOrDefault((c => c.ExamId == item.ExId && c.Id == item.QuestId));
                    if (quests != null)
                    {
                        if (quests.CorrectOptionIndex == item.AnsId)
                        {

                            points+=quests.mark;
                            item.IsSuccess = true;

                        }
                        else
                        {
                            item.IsSuccess = false;
                            item.CorrectAns = quests.CorrectOptionIndex;
                            Wrong++;
                        }
                    }

                }

                StudentExam stdExam = new StudentExam();
                stdExam.ExamId = x;
                stdExam.ApplicationUserId = UserData.Id;
                stdExam.Score= (int)points;
                stdExam.IsSubmitted= true;
                _context.studentExams.Add(stdExam);
                _context.SaveChanges();
                TempData["arrayOfObjects"] = arrayOfObjects;
                return Json(new { success = true , message = "Data received successfully!", points = (points / exExam.totalMark ) * 100 });


            }
            else
            {
                return Json(new { success = false});
            }
            

            


        }


        public  ActionResult Result()
        {
            List<ExamSubmitViewModel> arrayOfObjects = TempData["arrayOfObjects"] as List<ExamSubmitViewModel>;

            List<QuestionAnswerSubmitViewModel> subExam = new List<QuestionAnswerSubmitViewModel>();
            foreach (var item in arrayOfObjects)
            {

                var quest = _context.questions.SingleOrDefault(c => c.Id == item.QuestId);

                QuestionAnswerSubmitViewModel qs = new QuestionAnswerSubmitViewModel();

                qs.questions = quest;

                var Ans = _context.answers.Where(c=>c.QuestionsId==item.QuestId).ToList();

                qs.answers = Ans;

                if (!item.IsSuccess)
                {
                    var Corr = _context.answers.SingleOrDefault(x => x.Id == item.CorrectAns);
                    qs.CorrectAns = Corr;
                    qs.FalseAnswer= _context.answers.SingleOrDefault(c=>c.Id== item.AnsId);
                }
                else
                {
                    var Corr = _context.answers.SingleOrDefault(x => x.Id == item.AnsId);
                    qs.CorrectAns = Corr;

                    qs.FalseAnswer = null;
                    
                }


                subExam.Add(qs);


            }




            return View(subExam);
        }


    }
}