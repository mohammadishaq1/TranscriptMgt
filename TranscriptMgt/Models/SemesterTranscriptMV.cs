using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TranscriptMgt.Models
{
    public class SemesterTranscriptMV
    {
        public string SemesterTitle { get; set; }
        public SemesterSubjectTranscriptMV Students { get; set; }
        public float GPA { get; set; }
    }
}