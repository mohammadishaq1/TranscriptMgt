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
    public class ProgrammeSemestersTablesController : Controller
    {
        private TranscriptDbEntities db = new TranscriptDbEntities();

        // GET: ProgrammeSemestersTables
        public ActionResult Index()
        {
            var programmeSemestersTables = db.ProgrammeSemestersTables.Include(p => p.ProgrammeTable).Include(p => p.SemesterTable);
            return View(programmeSemestersTables.ToList());
        }

        // GET: ProgrammeSemestersTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProgrammeSemestersTable programmeSemestersTable = db.ProgrammeSemestersTables.Find(id);
            if (programmeSemestersTable == null)
            {
                return HttpNotFound();
            }
            return View(programmeSemestersTable);
        }

        // GET: ProgrammeSemestersTables/Create
        public ActionResult Create()
        {
            ViewBag.ProgrammeID = new SelectList(db.ProgrammeTables, "ProgrammeID", "Name");
            ViewBag.SemesterID = new SelectList(db.SemesterTables, "SemesterID", "Name");
            return View();
        }

        // POST: ProgrammeSemestersTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProgrammeSemesterID,SemesterID,ProgrammeID,Description")] ProgrammeSemestersTable programmeSemestersTable)
        {
            if (ModelState.IsValid)
            {
                db.ProgrammeSemestersTables.Add(programmeSemestersTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProgrammeID = new SelectList(db.ProgrammeTables, "ProgrammeID", "Name", programmeSemestersTable.ProgrammeID);
            ViewBag.SemesterID = new SelectList(db.SemesterTables, "SemesterID", "Name", programmeSemestersTable.SemesterID);
            return View(programmeSemestersTable);
        }

        // GET: ProgrammeSemestersTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProgrammeSemestersTable programmeSemestersTable = db.ProgrammeSemestersTables.Find(id);
            if (programmeSemestersTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProgrammeID = new SelectList(db.ProgrammeTables, "ProgrammeID", "Name", programmeSemestersTable.ProgrammeID);
            ViewBag.SemesterID = new SelectList(db.SemesterTables, "SemesterID", "Name", programmeSemestersTable.SemesterID);
            return View(programmeSemestersTable);
        }

        // POST: ProgrammeSemestersTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProgrammeSemesterID,SemesterID,ProgrammeID,Description")] ProgrammeSemestersTable programmeSemestersTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(programmeSemestersTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProgrammeID = new SelectList(db.ProgrammeTables, "ProgrammeID", "Name", programmeSemestersTable.ProgrammeID);
            ViewBag.SemesterID = new SelectList(db.SemesterTables, "SemesterID", "Name", programmeSemestersTable.SemesterID);
            return View(programmeSemestersTable);
        }

        // GET: ProgrammeSemestersTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProgrammeSemestersTable programmeSemestersTable = db.ProgrammeSemestersTables.Find(id);
            if (programmeSemestersTable == null)
            {
                return HttpNotFound();
            }
            return View(programmeSemestersTable);
        }

        // POST: ProgrammeSemestersTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProgrammeSemestersTable programmeSemestersTable = db.ProgrammeSemestersTables.Find(id);
            db.ProgrammeSemestersTables.Remove(programmeSemestersTable);
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
