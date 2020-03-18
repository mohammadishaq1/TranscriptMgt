using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TranscriptMgt.Models
{
    public class StudentPromoteMV
    {
        public int StudentPromoteID { get; set; }
        public int StudentID { get; set; }
        public int ProgrammeSemesterID { get; set; }
        public bool IsActive { get; set; }
    }
}