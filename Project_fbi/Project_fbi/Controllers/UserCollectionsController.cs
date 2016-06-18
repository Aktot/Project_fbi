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
    public class UserCollectionsController : Controller
    {
        private UserContext db = new UserContext();

        // GET: UserCollections
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        // GET: UserCollections/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserCollection userCollection = db.Users.Find(id);
            if (userCollection == null)
            {
                return HttpNotFound();
            }
            return View(userCollection);
        }

        // GET: UserCollections/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserCollections/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName,Email,Phone,Password")] UserCollection userCollection)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(userCollection);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userCollection);
        }

        // GET: UserCollections/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserCollection userCollection = db.Users.Find(id);
            if (userCollection == null)
            {
                return HttpNotFound();
            }
            return View(userCollection);
        }

        // POST: UserCollections/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName,Email,Phone,Password")] UserCollection userCollection)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userCollection).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userCollection);
        }

        // GET: UserCollections/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserCollection userCollection = db.Users.Find(id);
            if (userCollection == null)
            {
                return HttpNotFound();
            }
            return View(userCollection);
        }

        // POST: UserCollections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserCollection userCollection = db.Users.Find(id);
            db.Users.Remove(userCollection);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
