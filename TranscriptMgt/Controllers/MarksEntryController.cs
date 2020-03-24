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
        public ActionResult MarkSheet(int SessionID, int DepartmentID, int ProgrammeID, int CurrentSemesterID, int SelectSubjectID)
        {
            if (SessionID == 0 || DepartmentID == 0 || ProgrammeID == 0 || CurrentSemesterID == 0 || SelectSubjectID==0)
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
                var marks = db.MarkSheetTables.Where(s => s.StudentID == item.StudentID && s.ProgrammeSemesterID == item.ProgrammeSemesterID && s.SubjectSemesterID== SelectSubjectID).FirstOrDefault();
                if(marks != null)
                {
                    stu.ObtainMidTermMarks = marks.ObtainMidTermMarks;
                    stu.ObtainFinalTermMarks = marks.ObtainFinalTermMarks;
                }
                else
                {
                    stu.ObtainFinalTermMarks = 0;
                    stu.ObtainMidTermMarks = 0;

                }
                
                list.Add(stu);
            }
            Session["CurrentSemesterID"] = CurrentSemesterID;
            return View(list);
        }

        [HttpPost]
        public ActionResult MarkSheetSubmit(FormCollection collection)
        {
            try
            {
                List<int> studentids = new List<int>();
                string[] keys = collection.AllKeys;
                string ssubjectid = collection["SubjectID"];
                if (ssubjectid == "0")
                {
                    Session["Message"] = "Please select subject";
                    return RedirectToAction("MarkSheet");
                }
                int SubjectID = int.Parse(ssubjectid);
                int ProgrammeSemesterID = db.SubjectSemesterTables.Find(SubjectID).ProgrammeSemesterID;
                string[] studentidlist = collection.GetValues("item.StudentID");
                string[] midtermmarks = collection.GetValues("item.ObtainMidTermMarks");
                string[] finaltermmarks = collection.GetValues("item.ObtainFinalTermMarks");
                List<MarkSheetTable> markslist = new List<MarkSheetTable>();
                for (int i = 0; i < studentidlist.Length; i++)
                {
                    var stdmarks = new MarkSheetTable();
                    stdmarks.StudentID = Convert.ToInt32(studentidlist[i]);
                    stdmarks.ObtainMidTermMarks = Convert.ToInt32(midtermmarks[i]);
                    stdmarks.ObtainFinalTermMarks = Convert.ToInt32(finaltermmarks[i]);
                    stdmarks.SubjectSemesterID = SubjectID;
                    stdmarks.ProgrammeSemesterID = ProgrammeSemesterID;
                    markslist.Add(stdmarks);
                }
                foreach (MarkSheetTable item in markslist)
                {
                    var findsubjectmarks = db.MarkSheetTables.Where(m => m.StudentID == item.StudentID && m.SubjectSemesterID == item.SubjectSemesterID && m.ProgrammeSemesterID == item.ProgrammeSemesterID).FirstOrDefault();
                    if(findsubjectmarks != null)
                    {
                        findsubjectmarks.ObtainMidTermMarks = item.ObtainMidTermMarks;
                        findsubjectmarks.ObtainFinalTermMarks = item.ObtainFinalTermMarks;
                        db.Entry(findsubjectmarks).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    else
                    {
                        db.MarkSheetTables.Add(item);
                        db.SaveChanges();
                    }

                   
                }

                Session["Message"] = "Mark sheet submit successfully";
            }
            catch 
            {

                Session["Message"] = "Please try again some problem";
            }
            return RedirectToAction("MarkSheet");
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