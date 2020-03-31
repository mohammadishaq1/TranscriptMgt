using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TranscriptMgt.Models;

namespace TranscriptMgt.Controllers
{
    public class TranscriptsController : Controller
    {
        private TranscriptDbEntities db = new TranscriptDbEntities();
        // GET: Transcripts
        
        public ActionResult GetAllStudent()
        {
            return View(db.StudentTables.ToList());
        }
        public ActionResult GetTranscript(string regno)
        {
            TranscriptMV transcript = new TranscriptMV();

            
            int TotalSemesterMarks = 0;
            int TotalSemesterObtainMarks = 0;

            double TotalSubjectGradePoints = 0;
            double TotalSubjectsCrHrs = 0;

            var findstudent = db.StudentTables.Where(s => s.Reg_No == regno.Trim()).FirstOrDefault();
            if (findstudent == null)
            {
                Session["Message"] = "Not found";
                return View(transcript);
            }

            var student = new StudentTranscriptMV();
            student.Name = findstudent.Name;
            student.Photo = findstudent.Photo;
            student.RegNo = findstudent.Reg_No;
            student.Session = findstudent.SessionTable.Name;
            student.EnrollNo = findstudent.Enroll_No;
            student.FatherName = findstudent.Father_Name;
            transcript.Student = student;
            transcript.Programe = findstudent.ProgrammeTable.Name;

            var findmarksdetails = db.MarkSheetTables.Where(m => m.StudentID == findstudent.StudentID);

            List<SemesterTranscriptMV> semestersList = new List<SemesterTranscriptMV>();
            SemesterTranscriptMV semesters = new SemesterTranscriptMV();
            List<SemesterSubjectTranscriptMV> subjects = new List<SemesterSubjectTranscriptMV>();

            int checkprogramesemesterid = 0;

            foreach (MarkSheetTable marks in findmarksdetails)
            {
                var findsemester = db.ProgrammeSemestersTables.Find(marks.ProgrammeSemesterID);
                if (checkprogramesemesterid == 0)
                {
                    checkprogramesemesterid = marks.ProgrammeSemesterID;
                    semesters = null;
                  
                    semesters = new SemesterTranscriptMV();
                    subjects = null;
                    subjects = new List<SemesterSubjectTranscriptMV>();
                    semesters.SemesterTitle = findsemester.Description;
                }
                
                if (checkprogramesemesterid != marks.ProgrammeSemesterID)
                {
                    semesters.Subjects = subjects;
                    double totalcrhrs = 0;
                    double totalgradepoint = 0;
                    foreach (var item in semesters.Subjects)
                    {
                        totalcrhrs = totalcrhrs + item.CrHrs;
                        totalgradepoint = totalgradepoint + item.GradePoint;
                    }
                    TotalSubjectGradePoints = TotalSubjectGradePoints + totalgradepoint;
                    TotalSubjectsCrHrs = TotalSubjectsCrHrs + totalcrhrs;
                    semesters.GPA = (totalgradepoint / totalcrhrs);
                    semestersList.Add(semesters);

                    semesters = null;
                    semesters = new SemesterTranscriptMV();
                    subjects = null;
                    subjects = new List<SemesterSubjectTranscriptMV>();
                    semesters.SemesterTitle = findsemester.Description;
                    
                }

          


                var subject = new SemesterSubjectTranscriptMV();
                var findsubject = db.SubjectSemesterTables.Find(marks.SubjectSemesterID);
                int totalmarks = findsubject.SubjectTable.MidTermTotalMarks + findsubject.SubjectTable.FinalTermTotalMarks;
                int obtainmarks = (marks.ObtainMidTermMarks + marks.ObtainFinalTermMarks);
                subject.CourseTitle = findsubject.SubjectTable.Name;
                subject.SubjectCode = findsubject.Name;
                double crhrs = findsubject.SubjectTable.CrHrs;
                subject.ObtainedMarks = obtainmarks;
                subject.TotalMarks = totalmarks;
                var value = GetValue(obtainmarks);
                var GP = value * crhrs;
                subject.GradePoint = GP;
                subject.Value = value;
                subject.CrHrs = crhrs;
                subject.Grade = GetGrade(obtainmarks);
                TotalSemesterMarks = TotalSemesterMarks + totalmarks;
                TotalSemesterObtainMarks = TotalSemesterObtainMarks + obtainmarks;
                subjects.Add(subject);
                checkprogramesemesterid = marks.ProgrammeSemesterID;
            }

            semesters.Subjects = subjects;
            double totalcrhrss = 0;
            double totalgradepoints = 0;
            foreach (var item in semesters.Subjects)
            {
                totalcrhrss = totalcrhrss + item.CrHrs;
                totalgradepoints = totalgradepoints + item.GradePoint;
            }
            TotalSubjectGradePoints = TotalSubjectGradePoints + totalgradepoints;
            TotalSubjectsCrHrs = TotalSubjectsCrHrs + totalcrhrss;
            semesters.GPA = (totalgradepoints / totalcrhrss);
        
            semestersList.Add(semesters);



            transcript.Semesters = semestersList;
            transcript.TotalMarks = TotalSemesterMarks;
            transcript.ObtainMarks = TotalSemesterObtainMarks;
            double percentage = (TotalSemesterObtainMarks * 100 / TotalSemesterMarks);
            transcript.Percentage = percentage;
            double CGPA = TotalSubjectGradePoints / TotalSubjectsCrHrs;
            transcript.CrHrs = TotalSubjectsCrHrs;
            transcript.CGPA = CGPA;
            return View(transcript);
        }

        public string GetGrade(int obtainmarks)
        {
            if (obtainmarks >= 60 && obtainmarks < 65)
            {
                return "C";
            }
            else if (obtainmarks >= 65 && obtainmarks < 70)
            {
                return "C+";
            }
            else if (obtainmarks >= 70 && obtainmarks < 75)
            {
                return "B";
            }
            else if (obtainmarks >= 75 && obtainmarks < 80)
            {
                return "B+";
            }
            else if (obtainmarks >= 80 && obtainmarks < 90)
            {
                return "A";
            }
            else if (obtainmarks >= 90 && obtainmarks <= 100)
            {
                return "A+";
            }
            else
            {
                return "No Grade";
            }
        }
        public double GetValue(int obtainmarks)
        {
            double gp = 0;
            switch (obtainmarks)
            {
                case 60:
                    gp = 2.0;
                    break;
                case 61:
                    gp = 2.1;
                    break;
                case 62:
                    gp = 2.2;
                    break;
                case 63:
                    gp = 2.3;
                    break;
                case 64:
                    gp = 2.4;
                    break;
                case 65:
                    gp = 2.5;
                    break;
                case 66:
                    gp = 2.6;
                    break;
                case 67:
                    gp = 2.7;
                    break;
                case 68:
                    gp = 2.8;
                    break;
                case 69:
                    gp = 2.9;
                    break;
                case 70:
                    gp = 3.0;
                    break;
                case 71:
                    gp = 3.1;
                    break;
                case 72:
                    gp = 3.2;
                    break;
                case 73:
                    gp = 3.3;
                    break;
                case 74:
                    gp = 3.4;
                    break;
                case 75:
                    gp = 3.5;
                    break;
                case 76:
                    gp = 3.6;
                    break;
                case 77:
                    gp = 3.7;
                    break;
                case 78:
                    gp = 3.8;
                    break;
                case 79:
                    gp = 3.9;
                    break;
                case 80:
                    gp = 4.0;
                    break;
                default:
                    gp = 0;
                    break;
            }
            if (obtainmarks > 80)
            {
                gp = 4.0;
            }
            return gp;

        }
    }
}