//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class MarkSheetTable
    {
        public int MarkID { get; set; }
        [Required(ErrorMessage = "Required")]
        public int StudentID { get; set; }
        [Required(ErrorMessage = "Required")]
        public int ProgrammeSemesterID { get; set; }
        [Required(ErrorMessage = "Required")]
        public int SubjectSemesterID { get; set; }
        [Required(ErrorMessage = "Required")]
        public int ObtainMidTermMarks { get; set; }
        [Required(ErrorMessage = "Required")]
        public int ObtainFinalTermMarks { get; set; }
    
        public virtual ProgrammeSemestersTable ProgrammeSemestersTable { get; set; }
        public virtual StudentTable StudentTable { get; set; }
    }
}
