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
        public string StudentName { get; set; }
        public string Enroll_No { get; set; }
        public string Reg_No { get; set; }
        public int ProgrammeSemesterID { get; set; }
        public bool IsActive { get; set; }
    }
}