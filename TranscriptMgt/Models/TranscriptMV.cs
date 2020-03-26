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
        public List<SemesterTranscriptMV> Semesters { get; set; }
        public int TotalMarks { get; set; }
        public int ObtainMarks { get; set; }
        public double Percentage { get; set; }
        public double CrHrs { get; set; }
        public double CGPA { get; set; }
    }
}