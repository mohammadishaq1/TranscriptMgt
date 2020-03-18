using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataAccess;

namespace TranscriptMgt.Controllers
{
    public class StudentTablesController : Controller
    {
        private TranscriptDbEntities db = new TranscriptDbEntities();

        // GET: StudentTables
        public ActionResult Index()
        {
            var studentTables = db.StudentTables.Include(s => s.DepartmentTable).Include(s => s.ProgrammeTable).Include(s => s.SessionTable);
            return View(studentTables.ToList());
        }

        // GET: StudentTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentTable studentTable = db.StudentTables.Find(id);
            if (studentTable == null)
            {
                return HttpNotFound();
            }
            return View(studentTable);
        }

        // GET: StudentTables/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentID = new SelectList(db.DepartmentTables, "DepartmentID", "Name");
            ViewBag.ProgrammeID = new SelectList(db.ProgrammeTables, "ProgrammeID", "Name");
            ViewBag.SessionID = new SelectList(db.SessionTables, "SessionID", "Name");
            return View();
        }

        // POST: StudentTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentTable studentTable)
        {

            if (ModelState.IsValid)
            {
                if (studentTable.LogoFile != null)
                {
                    var folder = "~/Content/StudentPhoto";
                    var extension = Path.GetExtension(studentTable.LogoFile.FileName);
                    var file = string.Format("{0}", studentTable.StudentID);
                    var response = FileHelpers.UploadPhoto(studentTable.LogoFile, folder, file);
                    if (response)
                    {
                        var pic = string.Format("{0}/{1}{2}", folder, file, extension);
                        studentTable.Photo = pic;

                    }
                }
                db.StudentTables.Add(studentTable);
                db.SaveChanges();
               
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentID = new SelectList(db.DepartmentTables, "DepartmentID", "Name", studentTable.DepartmentID);
            ViewBag.ProgrammeID = new SelectList(db.ProgrammeTables, "ProgrammeID", "Name", studentTable.ProgrammeID);
            ViewBag.SessionID = new SelectList(db.SessionTables, "SessionID", "Name", studentTable.SessionID);
            return View(studentTable);
        }

        // GET: StudentTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentTable studentTable = db.StudentTables.Find(id);
            if (studentTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentID = new SelectList(db.DepartmentTables, "DepartmentID", "Name", studentTable.DepartmentID);
            ViewBag.ProgrammeID = new SelectList(db.ProgrammeTables, "ProgrammeID", "Name", studentTable.ProgrammeID);
            ViewBag.SessionID = new SelectList(db.SessionTables, "SessionID", "Name", studentTable.SessionID);
            return View(studentTable);
        }

        // POST: StudentTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StudentTable studentTable)
        {
            if (ModelState.IsValid)
            {
                if (studentTable.LogoFile != null)
                {
                    var folder = "~/Content/StudentPhoto";
                    var extension = Path.GetExtension(studentTable.LogoFile.FileName);
                    var file = string.Format("{0}", studentTable.StudentID);
                    var response = FileHelpers.UploadPhoto(studentTable.LogoFile, folder, file);
                    if (response)
                    {
                        var pic = string.Format("{0}/{1}{2}", folder, file,extension);
                        studentTable.Photo = pic;
                       
                    }
                }
                db.Entry(studentTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentID = new SelectList(db.DepartmentTables, "DepartmentID", "Name", studentTable.DepartmentID);
            ViewBag.ProgrammeID = new SelectList(db.ProgrammeTables, "ProgrammeID", "Name", studentTable.ProgrammeID);
            ViewBag.SessionID = new SelectList(db.SessionTables, "SessionID", "Name", studentTable.SessionID);
            return View(studentTable);
        }

        // GET: StudentTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentTable studentTable = db.StudentTables.Find(id);
            if (studentTable == null)
            {
                return HttpNotFound();
            }
            return View(studentTable);
        }

        // POST: StudentTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentTable studentTable = db.StudentTables.Find(id);
            db.StudentTables.Remove(studentTable);
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
