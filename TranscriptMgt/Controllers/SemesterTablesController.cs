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
    public class SemesterTablesController : Controller
    {
        private TranscriptDbEntities db = new TranscriptDbEntities();

        // GET: SemesterTables
        public ActionResult Index()
        {
            var semesterTables = db.SemesterTables.Include(s => s.SemesterTypeTable);
            return View(semesterTables.ToList());
        }

        // GET: SemesterTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SemesterTable semesterTable = db.SemesterTables.Find(id);
            if (semesterTable == null)
            {
                return HttpNotFound();
            }
            return View(semesterTable);
        }

        // GET: SemesterTables/Create
        public ActionResult Create()
        {
            ViewBag.SemesterTypeID = new SelectList(db.SemesterTypeTables, "SemesterTypeID", "Name");
            return View();
        }

        // POST: SemesterTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SemesterID,SemesterTypeID,Name,Description")] SemesterTable semesterTable)
        {
            if (ModelState.IsValid)
            {
                db.SemesterTables.Add(semesterTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SemesterTypeID = new SelectList(db.SemesterTypeTables, "SemesterTypeID", "Name", semesterTable.SemesterTypeID);
            return View(semesterTable);
        }

        // GET: SemesterTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SemesterTable semesterTable = db.SemesterTables.Find(id);
            if (semesterTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.SemesterTypeID = new SelectList(db.SemesterTypeTables, "SemesterTypeID", "Name", semesterTable.SemesterTypeID);
            return View(semesterTable);
        }

        // POST: SemesterTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SemesterID,SemesterTypeID,Name,Description")] SemesterTable semesterTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(semesterTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SemesterTypeID = new SelectList(db.SemesterTypeTables, "SemesterTypeID", "Name", semesterTable.SemesterTypeID);
            return View(semesterTable);
        }

        // GET: SemesterTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SemesterTable semesterTable = db.SemesterTables.Find(id);
            if (semesterTable == null)
            {
                return HttpNotFound();
            }
            return View(semesterTable);
        }

        // POST: SemesterTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SemesterTable semesterTable = db.SemesterTables.Find(id);
            db.SemesterTables.Remove(semesterTable);
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
