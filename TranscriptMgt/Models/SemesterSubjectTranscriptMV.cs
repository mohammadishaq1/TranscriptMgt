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
        public int Grade { get; set; }
        public float Value { get; set; }
        public float CrHrs { get; set; }
        public float GradePoint { get; set; }

    }
}