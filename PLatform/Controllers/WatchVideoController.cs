using Microsoft.AspNet.Identity;
using PLatform.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PLatform.Controllers
{
    //[Authorize]
    public class WatchVideoController : Controller
    {
        private ApplicationDbContext _context;
        public WatchVideoController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: WatchVideo
        public ActionResult Index(int id)
        {
            var userId = User.Identity.GetUserId();


            var UserData = _context.Users.Include(c => c.Grade).SingleOrDefault(c => c.Id == userId);



            var Class = _context.Class.Where(x => x.GradeId ==UserData.GradeId ).OrderBy(c=>c.Id).ToList();

            if (id != Class.Count-1) {
                var next = id + 1;
                TempData["index"] = next;
            }
            

            
            return View(Class[id]);
        }
    }
}