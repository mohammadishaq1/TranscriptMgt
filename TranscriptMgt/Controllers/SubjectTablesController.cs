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
    public class SubjectTablesController : Controller
    {
        private TranscriptDbEntities db = new TranscriptDbEntities();

        // GET: SubjectTables
        public ActionResult Index()
        {
            return View(db.SubjectTables.ToList());
        }

        // GET: SubjectTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubjectTable subjectTable = db.SubjectTables.Find(id);
            if (subjectTable == null)
            {
                return HttpNotFound();
            }
            return View(subjectTable);
        }

        // GET: SubjectTables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SubjectTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SubjectID,Name,CrHrs,MidTermTotalMarks,FinalTermTotalMarks")] SubjectTable subjectTable)
        {
            if (ModelState.IsValid)
            {
                db.SubjectTables.Add(subjectTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(subjectTable);
        }

        // GET: SubjectTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubjectTable subjectTable = db.SubjectTables.Find(id);
            if (subjectTable == null)
            {
                return HttpNotFound();
            }
            return View(subjectTable);
        }

        // POST: SubjectTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SubjectID,Name,CrHrs,MidTermTotalMarks,FinalTermTotalMarks")] SubjectTable subjectTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subjectTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(subjectTable);
        }

        // GET: SubjectTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubjectTable subjectTable = db.SubjectTables.Find(id);
            if (subjectTable == null)
            {
                return HttpNotFound();
            }
            return View(subjectTable);
        }

        // POST: SubjectTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SubjectTable subjectTable = db.SubjectTables.Find(id);
            db.SubjectTables.Remove(subjectTable);
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
