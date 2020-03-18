using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TranscriptMgt.Models
{
    public class SemesterSubjectMV
    {
        public int SubjectSemesterID { get; set; }
        public int ProgrammeSemesterID { get; set; }
        public int SubjectID { get; set; }
        public string Name { get; set; }
    }
}