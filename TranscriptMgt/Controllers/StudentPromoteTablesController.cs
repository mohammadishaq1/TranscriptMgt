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
    public class StudentPromoteTablesController : Controller
    {
        private TranscriptDbEntities db = new TranscriptDbEntities();

        // GET: StudentPromoteTables
        public ActionResult Index()
        {
            var studentPromoteTables = db.StudentPromoteTables.Include(s => s.ProgrammeSemestersTable).Include(s => s.StudentTable);
            return View(studentPromoteTables.ToList());
        }

        // GET: StudentPromoteTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentPromoteTable studentPromoteTable = db.StudentPromoteTables.Find(id);
            if (studentPromoteTable == null)
            {
                return HttpNotFound();
            }
            return View(studentPromoteTable);
        }

        // GET: StudentPromoteTables/Create
        public ActionResult Create()
        {
            ViewBag.ProgrammeSemesterID = new SelectList(db.ProgrammeSemestersTables, "ProgrammeSemesterID", "Description","0");
            ViewBag.ProgrammeSemesterPromoteID = new SelectList(db.ProgrammeSemestersTables, "ProgrammeSemesterID", "Description", "0");
            ViewBag.StudentID = new SelectList(db.StudentTables, "StudentID", "Name", "0");
            return View();
        }

        public ActionResult PromoteStudent()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetSession()
        {
            List<SessionMV> list = new List<SessionMV>();
            var session = db.SessionTables.ToList();
            foreach (var item in session)
            {
                list.Add(new SessionMV { Name = item.Name, SessionID = item.SessionID });
            }
            return Json(new { data = list }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetDepartment()
        {
            List<DepartmentMV> list = new List<DepartmentMV>();
            var departments = db.DepartmentTables.ToList();
            foreach (var item in departments)
            {
                list.Add(new DepartmentMV { Name = item.Name, DepartmentID = item.DepartmentID });
            }
            return Json(new { data = list }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetProgram(int? id)
        {
            List<ProgrammeMV> list = new List<ProgrammeMV>();
            var programs = db.ProgrammeTables.Where(p=>p.ProgrammeID ==id).ToList();
            foreach (var item in programs)
            {
                list.Add(new ProgrammeMV { Name = item.Name, ProgrammeID = item.ProgrammeID });
            }
            return Json(new { data = list }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult GetSemesters(int? id)
        {
            List<ProgrammeSemesterMV> list = new List<ProgrammeSemesterMV>();
            var semesters = db.ProgrammeSemestersTables.Where(p => p.ProgrammeID == id).ToList();
            foreach (var item in semesters)
            {
                list.Add(new ProgrammeSemesterMV { Description = item.Description, ProgrammeSemesterID = item.ProgrammeSemesterID });
            }
            return Json(new { data = list }, JsonRequestBehavior.AllowGet);
        }
        // POST: StudentPromoteTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentPromoteID,StudentID,ProgrammeSemesterID,IsActive")] StudentPromoteTable studentPromoteTable)
        {
            if (ModelState.IsValid)
            {
                db.StudentPromoteTables.Add(studentPromoteTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProgrammeSemesterID = new SelectList(db.ProgrammeSemestersTables, "ProgrammeSemesterID", "Description", studentPromoteTable.ProgrammeSemesterID);
            ViewBag.StudentID = new SelectList(db.StudentTables, "StudentID", "Name", studentPromoteTable.StudentID);
            return View(studentPromoteTable);
        }

        // GET: StudentPromoteTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentPromoteTable studentPromoteTable = db.StudentPromoteTables.Find(id);
            if (studentPromoteTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProgrammeSemesterID = new SelectList(db.ProgrammeSemestersTables, "ProgrammeSemesterID", "Description", studentPromoteTable.ProgrammeSemesterID);
            ViewBag.StudentID = new SelectList(db.StudentTables, "StudentID", "Name", studentPromoteTable.StudentID);
            return View(studentPromoteTable);
        }

        // POST: StudentPromoteTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentPromoteID,StudentID,ProgrammeSemesterID,IsActive")] StudentPromoteTable studentPromoteTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentPromoteTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProgrammeSemesterID = new SelectList(db.ProgrammeSemestersTables, "ProgrammeSemesterID", "Description", studentPromoteTable.ProgrammeSemesterID);
            ViewBag.StudentID = new SelectList(db.StudentTables, "StudentID", "Name", studentPromoteTable.StudentID);
            return View(studentPromoteTable);
        }

        // GET: StudentPromoteTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentPromoteTable studentPromoteTable = db.StudentPromoteTables.Find(id);
            if (studentPromoteTable == null)
            {
                return HttpNotFound();
            }
            return View(studentPromoteTable);
        }

        // POST: StudentPromoteTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentPromoteTable studentPromoteTable = db.StudentPromoteTables.Find(id);
            db.StudentPromoteTables.Remove(studentPromoteTable);
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
