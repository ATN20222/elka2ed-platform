using Microsoft.AspNet.Identity;
using PLatform.Models;
using PLatform.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PLatform.Controllers
{
    [Authorize]
    public class RankController : Controller
    {
        private ApplicationDbContext _context;
        public RankController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Rank
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();

            var UserData = _context.Users.SingleOrDefault(c => c.Id == userId);

            var StudentInGrade = _context.Users.Where(c => c.GradeId == UserData.GradeId).ToList();

            List<StudentRankViewModel> studentRankViewModel = new List<StudentRankViewModel>();

            foreach (var item in StudentInGrade)
            {
                StudentRankViewModel std= new StudentRankViewModel();
                std.UserName = item.UserName;

                

                var stdEx = _context.studentExams.Where(x => x.ApplicationUserId == item.Id).ToList();

                foreach (var inSide in stdEx)
                {
                    std.Points += inSide.Score;

                }



                studentRankViewModel.Add(std);

            }

            TempData["userId"]= UserData.UserName;



            return View(studentRankViewModel);
        }
    }
}