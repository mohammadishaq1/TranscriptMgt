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
    public class ProgrammeTablesController : Controller
    {
        private TranscriptDbEntities db = new TranscriptDbEntities();

        // GET: ProgrammeTables
        public ActionResult Index()
        {
            var programmeTables = db.ProgrammeTables.Include(p => p.DepartmentTable);
            return View(programmeTables.ToList());
        }

        // GET: ProgrammeTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProgrammeTable programmeTable = db.ProgrammeTables.Find(id);
            if (programmeTable == null)
            {
                return HttpNotFound();
            }
            return View(programmeTable);
        }

        // GET: ProgrammeTables/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentID = new SelectList(db.DepartmentTables, "DepartmentID", "Name");
            return View();
        }

        // POST: ProgrammeTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProgrammeID,DepartmentID,Name,Description")] ProgrammeTable programmeTable)
        {
            if (ModelState.IsValid)
            {
                db.ProgrammeTables.Add(programmeTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentID = new SelectList(db.DepartmentTables, "DepartmentID", "Name", programmeTable.DepartmentID);
            return View(programmeTable);
        }

        // GET: ProgrammeTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProgrammeTable programmeTable = db.ProgrammeTables.Find(id);
            if (programmeTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentID = new SelectList(db.DepartmentTables, "DepartmentID", "Name", programmeTable.DepartmentID);
            return View(programmeTable);
        }

        // POST: ProgrammeTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProgrammeID,DepartmentID,Name,Description")] ProgrammeTable programmeTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(programmeTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentID = new SelectList(db.DepartmentTables, "DepartmentID", "Name", programmeTable.DepartmentID);
            return View(programmeTable);
        }

        // GET: ProgrammeTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProgrammeTable programmeTable = db.ProgrammeTables.Find(id);
            if (programmeTable == null)
            {
                return HttpNotFound();
            }
            return View(programmeTable);
        }

        // POST: ProgrammeTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProgrammeTable programmeTable = db.ProgrammeTables.Find(id);
            db.ProgrammeTables.Remove(programmeTable);
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
