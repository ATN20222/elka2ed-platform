using PLatform.Models;
using PLatform.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;

namespace PLatform.Controllers
{
    [Authorize(Roles ="admin")]
    public class AdminController : Controller
    {

        private ApplicationDbContext _context;
        public AdminController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Admin
        public ActionResult Index()
        {

            return View();
        }


        public ActionResult ManageUsers()
        {
            var User = _context.Users.Include(c => c.Grade).ToList();
            foreach (var item in User)
            {
                var stdEx = _context.studentExams.Where(c=>c.ApplicationUserId==item.Id).ToList();


                foreach (var x in stdEx)
                {
                    item.points += x.Score;
                }

                
            }
            User = User.OrderBy(x=>x.points).Reverse().ToList();
            
            

            return View(User);
        }


        public ActionResult DeleteUser(string id) {

            var user = _context.Users.SingleOrDefault(x=>x.Id == id);
            _context.Users.Remove(user);
            _context.SaveChanges();

            return RedirectToAction("ManageUsers");
        }


        public ActionResult BanUser(string id)
        {
            var user = _context.Users.SingleOrDefault(c => c.Id == id);
            DateTime now = DateTime.Now;
            DateTime oneYearLater = now.AddYears(1);
            user.LockoutEndDateUtc= oneYearLater;

            _context.SaveChanges();
            TempData["banned"] = "true";
            return RedirectToAction("ManageUsers" , "Admin");
        }

        public ActionResult SelectGrade() { 
        
            var grade = _context.Grades.ToList();


            return View(grade);
        }

        [HttpPost]
        public ActionResult GetClass(int id)
        {
            var Class = _context.Class.Where(c => c.GradeId == id).ToList() ;

            List<ClassHasExamViewModel> ClassHasExamViewModel = new List<ClassHasExamViewModel>();
            foreach (var item in Class)
            {
                var ex = _context.exams.SingleOrDefault(c => c.ClassId == item.Id);

                ClassHasExamViewModel add = new ClassHasExamViewModel();
                if (ex != null)
                {
                    add.HasExam = true;
                }
                else
                {
                    add.HasExam = false;
                }


                add.Class = item;
                ClassHasExamViewModel.Add(add);
                
            }
            return Json(new { ClassHasExamViewModel });
        }


        public ActionResult AddClass(int id) {

            TempData["GradeId"] = id;


            
            return View(); 
        }


        public ActionResult EditClass(int id)
        {

            var classEdit = _context.Class.SingleOrDefault(c => c.Id == id);



            TempData["GradeId"] = classEdit.GradeId;


            return View(classEdit);
        }




        [HttpPost]
        public ActionResult SaveClass(Class newClass)
        {

            if (newClass.Id==0)
            {
                var gradeid = TempData["GradeId"];
                newClass.GradeId= (int)gradeid;
                 _context.Class.Add(newClass);


            }
            else
            {
                var c = _context.Class.SingleOrDefault(z=>z.Id==newClass.Id);

                c.Id = newClass.Id;
                c.GradeId = newClass.GradeId;
                c.Name = newClass.Name;
                c.Description = newClass.Description;
                c.VidSrc = newClass.VidSrc;
                c.Training = newClass.Training;

            }
            _context.SaveChanges();


            return RedirectToAction("SelectGrade");

        }




        public ActionResult AddExam(AddExamDataViewModel ExamData)
        {


            Exam ex = new Exam();
            ex.ClassId= ExamData.ClassId;
            ex.DurationInMinutes = ExamData.Duration;
            ex.Title= ExamData.Title;

            _context.exams.Add(ex);
            _context.SaveChanges();

            var idToPass = _context.exams.SingleOrDefault(c => c.ClassId == ex.ClassId);


            return Json(new { success = true, id = idToPass.Id });
        }




        public  ActionResult AddQuestAndAns(int id)
        {
            AddQuestsAndAnswersViewModel addQuestsAndAnswersViewModel = new AddQuestsAndAnswersViewModel{
                question = new Questions()
               
            };
            addQuestsAndAnswersViewModel.question.ExamId = id;

            TempData["examId"] = id;


            return View(addQuestsAndAnswersViewModel);
        }


        public ActionResult SaveQuests(AddQuestsAndAnswersViewModel mod)
        {
            mod.question.ExamId = (int)TempData["examId"];
            var ExamUpdate = _context.exams.SingleOrDefault(c=>c.Id== mod.question.ExamId);
            ExamUpdate.totalMark += mod.question.mark;
            _context.questions.Add(mod.question);
            _context.SaveChanges();


            //var questId = _context.questions.SingleOrDefault(x => x.Text == mod.question.Text);

            var newId = _context.Entry(mod.question).Property(m => m.Id).CurrentValue;

            var questToUpdate = _context.questions.SingleOrDefault(c => c.Id == newId);

           // Answers ansToUpdate = new Answers();



            mod.answer1.answer.QuestionsId = newId;
            mod.answer2.answer.QuestionsId = newId;
            mod.answer3.answer.QuestionsId = newId;
            mod.answer4.answer.QuestionsId = newId;



            if (mod.answer1.IsCorrect == true)
            {
                _context.answers.Add(mod.answer1.answer);
                _context.SaveChanges();

                var ansId = _context.Entry(mod.answer1.answer).Property(m => m.Id).CurrentValue;


                questToUpdate.CorrectOptionIndex = ansId;

                _context.SaveChanges();
            }
            else
            {
                _context.answers.Add(mod.answer1.answer);
                _context.SaveChanges();
            }



            if (mod.answer2.IsCorrect == true)
            {
                _context.answers.Add(mod.answer2.answer);
                _context.SaveChanges();

                var ansId = _context.Entry(mod.answer2.answer).Property(m => m.Id).CurrentValue;


                questToUpdate.CorrectOptionIndex = ansId;

                _context.SaveChanges();
            }
            else
            {
                _context.answers.Add(mod.answer2.answer);
                _context.SaveChanges();
            }




            if (mod.answer3.IsCorrect == true)
            {
                _context.answers.Add(mod.answer3.answer);
                _context.SaveChanges();

                var ansId = _context.Entry(mod.answer3.answer).Property(m => m.Id).CurrentValue;


                questToUpdate.CorrectOptionIndex = ansId;

                _context.SaveChanges();
            }
            else
            {
                _context.answers.Add(mod.answer3.answer);
                _context.SaveChanges();
            }

            if (mod.answer4.IsCorrect == true)
            {
                _context.answers.Add(mod.answer4.answer);
                _context.SaveChanges();

                var ansId = _context.Entry(mod.answer4.answer).Property(m => m.Id).CurrentValue;

                questToUpdate.CorrectOptionIndex = ansId;


                _context.SaveChanges();
            }
            else
            {
                _context.answers.Add(mod.answer4.answer);
                _context.SaveChanges();
            }





            TempData["notify"] = "true";

            return RedirectToAction("AddQuestAndAns" ,new {id= mod.question.ExamId } );

        }






        public ActionResult SetAvailable(SetAvailableClassViewModel ClassData)
        {
            var Cl = _context.Class.SingleOrDefault(c => c.Id == ClassData.ClassId);
            Cl.IsAvailable = ClassData.IsAvailable;
            _context.SaveChanges();

            return Json(new { IsAvailable = ClassData.IsAvailable });
        }







    }
}