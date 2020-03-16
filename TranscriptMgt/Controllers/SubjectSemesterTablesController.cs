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
    public class SubjectSemesterTablesController : Controller
    {
        private TranscriptDbEntities db = new TranscriptDbEntities();

        // GET: SubjectSemesterTables
        public ActionResult Index()
        {
            var subjectSemesterTables = db.SubjectSemesterTables.Include(s => s.ProgrammeSemestersTable).Include(s => s.SubjectTable);
            return View(subjectSemesterTables.ToList());
        }

        // GET: SubjectSemesterTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubjectSemesterTable subjectSemesterTable = db.SubjectSemesterTables.Find(id);
            if (subjectSemesterTable == null)
            {
                return HttpNotFound();
            }
            return View(subjectSemesterTable);
        }

        // GET: SubjectSemesterTables/Create
        public ActionResult Create()
        {
            ViewBag.ProgrammeSemesterID = new SelectList(db.ProgrammeSemestersTables, "ProgrammeSemesterID", "Description");
            ViewBag.SubjectID = new SelectList(db.SubjectTables, "SubjectID", "Name");
            return View();
        }

        // POST: SubjectSemesterTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SubjectSemesterID,ProgrammeSemesterID,SubjectID,Name")] SubjectSemesterTable subjectSemesterTable)
        {
            if (ModelState.IsValid)
            {
                db.SubjectSemesterTables.Add(subjectSemesterTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProgrammeSemesterID = new SelectList(db.ProgrammeSemestersTables, "ProgrammeSemesterID", "Description", subjectSemesterTable.ProgrammeSemesterID);
            ViewBag.SubjectID = new SelectList(db.SubjectTables, "SubjectID", "Name", subjectSemesterTable.SubjectID);
            return View(subjectSemesterTable);
        }

        // GET: SubjectSemesterTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubjectSemesterTable subjectSemesterTable = db.SubjectSemesterTables.Find(id);
            if (subjectSemesterTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProgrammeSemesterID = new SelectList(db.ProgrammeSemestersTables, "ProgrammeSemesterID", "Description", subjectSemesterTable.ProgrammeSemesterID);
            ViewBag.SubjectID = new SelectList(db.SubjectTables, "SubjectID", "Name", subjectSemesterTable.SubjectID);
            return View(subjectSemesterTable);
        }

        // POST: SubjectSemesterTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SubjectSemesterID,ProgrammeSemesterID,SubjectID,Name")] SubjectSemesterTable subjectSemesterTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subjectSemesterTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProgrammeSemesterID = new SelectList(db.ProgrammeSemestersTables, "ProgrammeSemesterID", "Description", subjectSemesterTable.ProgrammeSemesterID);
            ViewBag.SubjectID = new SelectList(db.SubjectTables, "SubjectID", "Name", subjectSemesterTable.SubjectID);
            return View(subjectSemesterTable);
        }

        // GET: SubjectSemesterTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubjectSemesterTable subjectSemesterTable = db.SubjectSemesterTables.Find(id);
            if (subjectSemesterTable == null)
            {
                return HttpNotFound();
            }
            return View(subjectSemesterTable);
        }

        // POST: SubjectSemesterTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SubjectSemesterTable subjectSemesterTable = db.SubjectSemesterTables.Find(id);
            db.SubjectSemesterTables.Remove(subjectSemesterTable);
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
