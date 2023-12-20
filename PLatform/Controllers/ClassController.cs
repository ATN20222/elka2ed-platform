using Microsoft.AspNet.Identity;
using PLatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PLatform.Controllers
{

    [Authorize]
    public class ClassController : Controller
    {

        private ApplicationDbContext _context;
        public ClassController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Class
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();

            var UserData = _context.Users.SingleOrDefault(c=>c.Id== userId);

            var classes = _context.Class.Where(x=>x.GradeId == UserData.GradeId).ToList();
            
            
            
            return View(classes);
        }
    }
}