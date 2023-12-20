using Microsoft.AspNet.Identity;
using PLatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using PLatform.ViewModels;

namespace PLatform.Controllers
{
    [Authorize]
    public class MyProfileController : Controller
    {
        private ApplicationDbContext _context;
        public MyProfileController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: MyProfile
        public ActionResult Index()
        {

            var userId = User.Identity.GetUserId();


            var UserData = _context.Users.Include(c=>c.Grade).SingleOrDefault(c => c.Id == userId);
            

            ChangePasswordProfileViewModel obj= new ChangePasswordProfileViewModel();

            obj.applicationUser = UserData;

            return View(obj);
        }



        //public ActionResult Index(ChangePasswordViewModel o)
        //{
        //    var userId = User.Identity.GetUserId();


        //    var UserData = _context.Users.Include(c => c.Grade).SingleOrDefault(c => c.Id == userId);


        //    ChangePasswordProfileViewModel obj = new ChangePasswordProfileViewModel();

        //    obj.applicationUser = UserData;
        //    obj.changePasswordViewModel = o;

        //    return View(obj);
        //}

    }
}