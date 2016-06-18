using Project_fbi.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_fbi.Controllers
{
    public class HomeController : Controller
    {
        private UserContext db = new UserContext();

        //[Route("{index}/{id}/{*allTheRest}")]
        [HttpGet]
        public ActionResult Autorizathion()
            {
                return View();
            }
         [HttpPost]
         public ActionResult Autorizathion(UserCollection user)
            {
                if (ModelState.IsValid)
                {
                    return View("MainView", user);
                }
                else
                    return View("FailedAuto");
            }

        [HttpGet]
        public ActionResult SignUp()
        {
             return View();
        }
        
        [HttpPost]
        public ActionResult SignUp(UserCollection user)
        {
            {
                if (ModelState.IsValid)
                {

                    if (!(db.Users.Any(o => (o.LastName == user.LastName || o.Email == user.Email || o.Phone == user.Phone))))
                    {
                        db.Users.Add(user);
                        db.SaveChanges();
                    }
                    else ViewBag.AlreadyEx = "Sorry, but that account already exists! ";
                    return View("Autorizathion");

                }
                else
                    return View("SignUp");
            }
        }

        public ActionResult MainView()
        {
            return View();
        }

        public ActionResult History()
        {
            return View();
        }

    }
}