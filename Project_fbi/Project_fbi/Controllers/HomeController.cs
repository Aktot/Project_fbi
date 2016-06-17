using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_fbi.Controllers
{
    public class HomeController : Controller
    {
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