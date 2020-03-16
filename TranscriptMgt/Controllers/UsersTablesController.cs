using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataAccess;

namespace TranscriptMgt.Controllers
{
    public class UsersTablesController : Controller
    {
        private TranscriptDbEntities db = new TranscriptDbEntities();

        // GET: UsersTables
        public ActionResult Index()
        {
            return View(db.UsersTables.ToList());
        }

        // GET: UsersTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsersTable usersTable = db.UsersTables.Find(id);
            if (usersTable == null)
            {
                return HttpNotFound();
            }
            return View(usersTable);
        }

        // GET: UsersTables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsersTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,userName,password")] UsersTable usersTable)
        {
            if (ModelState.IsValid)
            {
                db.UsersTables.Add(usersTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usersTable);
        }

        // GET: UsersTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsersTable usersTable = db.UsersTables.Find(id);
            if (usersTable == null)
            {
                return HttpNotFound();
            }
            return View(usersTable);
        }

        // POST: UsersTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,userName,password")] UsersTable usersTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usersTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usersTable);
        }

        // GET: UsersTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsersTable usersTable = db.UsersTables.Find(id);
            if (usersTable == null)
            {
                return HttpNotFound();
            }
            return View(usersTable);
        }

        // POST: UsersTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UsersTable usersTable = db.UsersTables.Find(id);
            db.UsersTables.Remove(usersTable);
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
