using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TranscriptMgt.Models
{
    public class SemesterSubjectTranscriptMV
    {
        public string SubjectCode { get; set; }
        public string CourseTitle { get; set; }
        public int TotalMarks { get; set; }
        public int ObtainedMarks { get; set; }
        public string Grade { get; set; }
        public double Value { get; set; }
        public double CrHrs { get; set; }
        public double GradePoint { get; set; }

    }
}