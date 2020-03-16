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
    public class SemesterTypeTablesController : Controller
    {
        private TranscriptDbEntities db = new TranscriptDbEntities();

        // GET: SemesterTypeTables
        public ActionResult Index()
        {
            return View(db.SemesterTypeTables.ToList());
        }

        // GET: SemesterTypeTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SemesterTypeTable semesterTypeTable = db.SemesterTypeTables.Find(id);
            if (semesterTypeTable == null)
            {
                return HttpNotFound();
            }
            return View(semesterTypeTable);
        }

        // GET: SemesterTypeTables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SemesterTypeTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SemesterTypeID,Name,Description")] SemesterTypeTable semesterTypeTable)
        {
            if (ModelState.IsValid)
            {
                db.SemesterTypeTables.Add(semesterTypeTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(semesterTypeTable);
        }

        // GET: SemesterTypeTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SemesterTypeTable semesterTypeTable = db.SemesterTypeTables.Find(id);
            if (semesterTypeTable == null)
            {
                return HttpNotFound();
            }
            return View(semesterTypeTable);
        }

        // POST: SemesterTypeTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SemesterTypeID,Name,Description")] SemesterTypeTable semesterTypeTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(semesterTypeTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(semesterTypeTable);
        }

        // GET: SemesterTypeTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SemesterTypeTable semesterTypeTable = db.SemesterTypeTables.Find(id);
            if (semesterTypeTable == null)
            {
                return HttpNotFound();
            }
            return View(semesterTypeTable);
        }

        // POST: SemesterTypeTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SemesterTypeTable semesterTypeTable = db.SemesterTypeTables.Find(id);
            db.SemesterTypeTables.Remove(semesterTypeTable);
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
