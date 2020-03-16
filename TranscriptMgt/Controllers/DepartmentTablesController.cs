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
    public class DepartmentTablesController : Controller
    {
        private TranscriptDbEntities db = new TranscriptDbEntities();

        // GET: DepartmentTables
        public ActionResult Index()
        {
            return View(db.DepartmentTables.ToList());
        }

        // GET: DepartmentTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartmentTable departmentTable = db.DepartmentTables.Find(id);
            if (departmentTable == null)
            {
                return HttpNotFound();
            }
            return View(departmentTable);
        }

        // GET: DepartmentTables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DepartmentID,Name,Establish_Date,Description")] DepartmentTable departmentTable)
        {
            if (ModelState.IsValid)
            {
                db.DepartmentTables.Add(departmentTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(departmentTable);
        }

        // GET: DepartmentTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartmentTable departmentTable = db.DepartmentTables.Find(id);
            if (departmentTable == null)
            {
                return HttpNotFound();
            }
            return View(departmentTable);
        }

        // POST: DepartmentTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DepartmentID,Name,Establish_Date,Description")] DepartmentTable departmentTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(departmentTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(departmentTable);
        }

        // GET: DepartmentTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartmentTable departmentTable = db.DepartmentTables.Find(id);
            if (departmentTable == null)
            {
                return HttpNotFound();
            }
            return View(departmentTable);
        }

        // POST: DepartmentTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DepartmentTable departmentTable = db.DepartmentTables.Find(id);
            db.DepartmentTables.Remove(departmentTable);
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
