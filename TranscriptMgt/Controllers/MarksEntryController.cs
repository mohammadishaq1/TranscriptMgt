using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TranscriptMgt.Models;

namespace TranscriptMgt.Controllers
{
    public class MarksEntryController : Controller
    {
        private TranscriptDbEntities db = new TranscriptDbEntities();

        public ActionResult MarkSheet()
        {
            return View(new List<MarksheetMV>());
        }
       
       

        [HttpPost]
        public ActionResult MarkSheet(int SessionID, int DepartmentID, int ProgrammeID, int CurrentSemesterID)
        {
            if (SessionID == 0 || DepartmentID == 0 || ProgrammeID == 0 || CurrentSemesterID == 0)
            {
                Session["Message"] = "Please fill fields";
                return View(new List<MarksheetMV>());
            }


            List<MarksheetMV> list = new List<MarksheetMV>();
            var studentlist = db.StudentPromoteTables.Where(p => p.ProgrammeSemesterID == CurrentSemesterID && p.IsActive == true).ToList();
            foreach (var item in studentlist)
            {
                var stu = new MarksheetMV();
                var student = db.StudentTables.Find(item.StudentID);
                stu.StudentID = item.StudentID;
                stu.StudentName = student.Name;
                stu.Reg_No = student.Reg_No;
                stu.ProgrammeSemesterID = item.ProgrammeSemesterID;
                stu.Enroll_No = student.Enroll_No;
                stu.ObtainFinalTermMarks = 0;
                stu.ObtainMidTermMarks = 0;
                list.Add(stu);
            }
            Session["CurrentSemesterID"] = CurrentSemesterID;
            return View(list);
        }

        [HttpPost]
        public ActionResult MarkSheetSubmit(FormCollection collection)
        {
            List<int> studentids = new List<int>();
            string[] keys = collection.AllKeys;
            string ssubjectid = collection["SubjectID"];
            if(ssubjectid == "0")
            {
                Session["Message"] = "Please select subject";
                return View(new List<MarksheetMV>());
            }
            int SubjectID = int.Parse(ssubjectid);
            int ProgrammeSemesterID = db.SubjectSemesterTables.Find(SubjectID).ProgrammeSemesterID;
            string[] studentidlist = collection.GetValues("item.StudentID");
            string[] midtermmarks = collection.GetValues("midtermmarks");
            string[] finaltermmarks = collection.GetValues("finaltermmarks");
            List<MarkSheetTable> markslist = new List<MarkSheetTable>();
            for (int i = 0; i < studentidlist.Length; i++)
            {
                var stdmarks = new MarkSheetTable();
                stdmarks.StudentID = Convert.ToInt32(studentidlist[i]);
                stdmarks.ObtainMidTermMarks = Convert.ToInt32(midtermmarks[i]);
                stdmarks.ObtainFinalTermMarks = Convert.ToInt32(finaltermmarks[i]);
                stdmarks.SubjectSemesterID = SubjectID;
                stdmarks.ProgrammeSemesterID = ProgrammeSemesterID;
            }
            foreach (MarkSheetTable item in markslist)
            {
                db.MarkSheetTables.Add(item);
                db.SaveChanges();
            }
            return View(new List<MarksheetMV>());
        }



        [HttpGet]
        public ActionResult GetSemesterSubject(int? id)
        {
            int sid = 0;
            if (id == null)
            {

                int.TryParse(Convert.ToString(Session["CurrentSemesterID"]), out sid);
            }
            else
            {
                if (id == 0)
                {

                    int.TryParse(Convert.ToString(Session["CurrentSemesterID"]), out sid);
                }
                else
                {
                    sid = Convert.ToInt32(id);
                }
            }

            var list = new List<SemesterSubjectMV>();
            var subj = db.SubjectSemesterTables.Where(s => s.ProgrammeSemesterID == sid).ToList();
            foreach (var item in subj)
            {
                list.Add(new SemesterSubjectMV { SubjectSemesterID = item.SubjectSemesterID, Name = item.SubjectTable.Name });
            }
            return Json(new { data=list}, JsonRequestBehavior.AllowGet);
        }





    }
}