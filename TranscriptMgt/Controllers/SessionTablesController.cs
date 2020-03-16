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
    public class SessionTablesController : Controller
    {
        private TranscriptDbEntities db = new TranscriptDbEntities();

        // GET: SessionTables
        public ActionResult Index()
        {
            return View(db.SessionTables.ToList());
        }

        // GET: SessionTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SessionTable sessionTable = db.SessionTables.Find(id);
            if (sessionTable == null)
            {
                return HttpNotFound();
            }
            return View(sessionTable);
        }

        // GET: SessionTables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SessionTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SessionID,Name,Start_Date,End_Date,Description")] SessionTable sessionTable)
        {
            if (ModelState.IsValid)
            {
                db.SessionTables.Add(sessionTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sessionTable);
        }

        // GET: SessionTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SessionTable sessionTable = db.SessionTables.Find(id);
            if (sessionTable == null)
            {
                return HttpNotFound();
            }
            return View(sessionTable);
        }

        // POST: SessionTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SessionID,Name,Start_Date,End_Date,Description")] SessionTable sessionTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sessionTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sessionTable);
        }

        // GET: SessionTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SessionTable sessionTable = db.SessionTables.Find(id);
            if (sessionTable == null)
            {
                return HttpNotFound();
            }
            return View(sessionTable);
        }

        // POST: SessionTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SessionTable sessionTable = db.SessionTables.Find(id);
            db.SessionTables.Remove(sessionTable);
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
