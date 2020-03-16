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
    public class MarkSheetTablesController : Controller
    {
        private TranscriptDbEntities db = new TranscriptDbEntities();

        // GET: MarkSheetTables
        public ActionResult Index()
        {
            var markSheetTables = db.MarkSheetTables.Include(m => m.ProgrammeSemestersTable).Include(m => m.StudentTable);
            return View(markSheetTables.ToList());
        }

        // GET: MarkSheetTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MarkSheetTable markSheetTable = db.MarkSheetTables.Find(id);
            if (markSheetTable == null)
            {
                return HttpNotFound();
            }
            return View(markSheetTable);
        }

        // GET: MarkSheetTables/Create
        public ActionResult Create()
        {
            ViewBag.ProgrammeSemesterID = new SelectList(db.ProgrammeSemestersTables, "ProgrammeSemesterID", "Description");
            ViewBag.StudentID = new SelectList(db.StudentTables, "StudentID", "Name");
            return View();
        }

        // POST: MarkSheetTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MarkID,StudentID,ProgrammeSemesterID,SubjectSemesterID,ObtainMidTermMarks,ObtainFinalTermMarks")] MarkSheetTable markSheetTable)
        {
            if (ModelState.IsValid)
            {
                db.MarkSheetTables.Add(markSheetTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProgrammeSemesterID = new SelectList(db.ProgrammeSemestersTables, "ProgrammeSemesterID", "Description", markSheetTable.ProgrammeSemesterID);
            ViewBag.StudentID = new SelectList(db.StudentTables, "StudentID", "Name", markSheetTable.StudentID);
            return View(markSheetTable);
        }

        // GET: MarkSheetTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MarkSheetTable markSheetTable = db.MarkSheetTables.Find(id);
            if (markSheetTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProgrammeSemesterID = new SelectList(db.ProgrammeSemestersTables, "ProgrammeSemesterID", "Description", markSheetTable.ProgrammeSemesterID);
            ViewBag.StudentID = new SelectList(db.StudentTables, "StudentID", "Name", markSheetTable.StudentID);
            return View(markSheetTable);
        }

        // POST: MarkSheetTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MarkID,StudentID,ProgrammeSemesterID,SubjectSemesterID,ObtainMidTermMarks,ObtainFinalTermMarks")] MarkSheetTable markSheetTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(markSheetTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProgrammeSemesterID = new SelectList(db.ProgrammeSemestersTables, "ProgrammeSemesterID", "Description", markSheetTable.ProgrammeSemesterID);
            ViewBag.StudentID = new SelectList(db.StudentTables, "StudentID", "Name", markSheetTable.StudentID);
            return View(markSheetTable);
        }

        // GET: MarkSheetTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MarkSheetTable markSheetTable = db.MarkSheetTables.Find(id);
            if (markSheetTable == null)
            {
                return HttpNotFound();
            }
            return View(markSheetTable);
        }

        // POST: MarkSheetTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MarkSheetTable markSheetTable = db.MarkSheetTables.Find(id);
            db.MarkSheetTables.Remove(markSheetTable);
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
