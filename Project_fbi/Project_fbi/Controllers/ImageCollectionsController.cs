using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project_fbi;
using Project_fbi.DAL;

namespace Project_fbi.Controllers
{
    public class ImageCollectionsController : Controller
    {
        private UserContext db = new UserContext();
        public ActionResult Decryption()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View(db.Images.ToList());
        }
    }
}
