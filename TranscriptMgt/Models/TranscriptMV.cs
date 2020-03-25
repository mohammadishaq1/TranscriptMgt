using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TranscriptMgt.Models
{
    public class TranscriptMV
    {
        public string Programe { get; set; }
        public StudentTranscriptMV Student { get; set; }
        public SemesterTranscriptMV Semesters { get; set; }
        public int TotalMarks { get; set; }
        public int ObtainMarks { get; set; }
        public float Percentage { get; set; }
        public float CGPA { get; set; }
    }
}