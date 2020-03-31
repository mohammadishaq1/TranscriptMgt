using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TranscriptMgt.Models
{
    public class SemesterTranscriptMV
    {
        public string SemesterTitle { get; set; }
        public List<SemesterSubjectTranscriptMV> Subjects { get; set; }
        public double GPA { get; set; }
    }
}