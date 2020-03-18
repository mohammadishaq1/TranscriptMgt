using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataAccess;
using TranscriptMgt.Models;

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

        public List<SemesterSubjectMV> GetSemesterSubject()
        {
            var list = new List<SemesterSubjectMV>();
            var subj = db.SubjectSemesterTables.ToList();
            foreach (var item in subj)
            {
                list.Add(new SemesterSubjectMV { SubjectSemesterID = item.SubjectSemesterID, Name = item.SubjectTable.Name });
            }
            return list;
        }

        // GET: MarkSheetTables/Create
        public ActionResult Create()
        {
            ViewBag.ProgrammeSemesterID = new SelectList(db.ProgrammeSemestersTables, "ProgrammeSemesterID", "Description","0");
            ViewBag.StudentID = new SelectList(db.StudentTables, "StudentID", "Name", "0");
            ViewBag.SubjectSemesterID = new SelectList(GetSemesterSubject(), "SubjectSemesterID", "Name", "0");
            return View();
        }

        // POST: MarkSheetTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MarkSheetTable markSheetTable)
        {
            if (ModelState.IsValid)
            {
                db.MarkSheetTables.Add(markSheetTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProgrammeSemesterID = new SelectList(db.ProgrammeSemestersTables, "ProgrammeSemesterID", "Description", markSheetTable.ProgrammeSemesterID);
            ViewBag.StudentID = new SelectList(db.StudentTables, "StudentID", "Name", markSheetTable.StudentID);
            ViewBag.StudentID = new SelectList(GetSemesterSubject(), "SubjectSemesterID", "Name", markSheetTable.SubjectSemesterID);
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
            ViewBag.StudentID = new SelectList(GetSemesterSubject(), "SubjectSemesterID", "Name", markSheetTable.SubjectSemesterID);
            return View(markSheetTable);
        }

        // POST: MarkSheetTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MarkSheetTable markSheetTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(markSheetTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProgrammeSemesterID = new SelectList(db.ProgrammeSemestersTables, "ProgrammeSemesterID", "Description", markSheetTable.ProgrammeSemesterID);
            ViewBag.StudentID = new SelectList(db.StudentTables, "StudentID", "Name", markSheetTable.StudentID);
            ViewBag.StudentID = new SelectList(GetSemesterSubject(), "SubjectSemesterID", "Name", markSheetTable.SubjectSemesterID);
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
