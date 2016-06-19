using Project_fbi.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
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
                if (ModelState.IsValid && (db.Users.Any(o => (o.Email == user.Email || o.Password == user.Password))))
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
        void CheckEx(UserCollection user)
        {
         if (db.Users.Any(o => (o.Email == user.Email)))
                  ViewBag.AlreadyEx = "Sorry, but the account with such e-mail already exists! ";
            else if (db.Users.Any(o => (o.Phone == user.Phone)))
                ViewBag.AlreadyEx = "Sorry, but the account with such phone number already exists! ";
            else ViewBag.AlreadyEx = "Sorry, but that account already exists! ";
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
                    else CheckEx(user); 
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
        [HttpGet]
        public ActionResult Decryption()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FileUpload(HttpPostedFileBase file)
        {
            if (file != null)
            {
                SteganographyEntities db = new SteganographyEntities();
                string ImageName = System.IO.Path.GetFileName(file.FileName);
                string physicalPath = Server.MapPath("~/images/" + ImageName);

                // save image in folder
                file.SaveAs(physicalPath);

                //save new record in database
               ImageCollection  newRecord = new ImageCollection();
                
                newRecord.ImageName = ImageName;
                newRecord.ID = db.ImageCollection.Count();
                newRecord.UserId = 1;
                newRecord.Data = new byte[10];
                for (int i = 0; i < 10; i++)
                    newRecord.Data[i] = (byte)(i % 2);
                db.ImageCollection.Add(newRecord);
                try
                {
                    db.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (DbEntityValidationResult item in ex.EntityValidationErrors)
                    {
                        // Get entry

                        DbEntityEntry entry = item.Entry;
                        string entityTypeName = entry.Entity.GetType().Name;

                        // Display or log error messages

                        foreach (DbValidationError subItem in item.ValidationErrors)
                        {
                            string message = string.Format("Error '{0}' occurred in {1} at {2}",
                                     subItem.ErrorMessage, entityTypeName, subItem.PropertyName);
                            Console.WriteLine(message);
                        }
                        switch (entry.State)
                        {
                            case EntityState.Added:
                                entry.State = EntityState.Detached;
                                break;
                            case EntityState.Modified:
                                entry.CurrentValues.SetValues(entry.OriginalValues);
                                entry.State = EntityState.Unchanged;
                                break;
                            case EntityState.Deleted:
                                entry.State = EntityState.Unchanged;
                                break;
                        }
                    }
                }

            }
            //return View("DownloadLink", h);
            return View();
        }

        public ActionResult Encryption()
        {
            return View();
        }

    }
}