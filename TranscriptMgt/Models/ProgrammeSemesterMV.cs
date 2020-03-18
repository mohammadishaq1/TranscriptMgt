using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TranscriptMgt.Models
{
    public class ProgrammeSemesterMV
    {
        public int ProgrammeSemesterID { get; set; }
        public string Description { get; set; }
    }
}