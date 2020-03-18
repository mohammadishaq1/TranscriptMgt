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

    public partial class ProgrammeSemestersTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProgrammeSemestersTable()
        {
            this.MarkSheetTables = new HashSet<MarkSheetTable>();
            this.SubjectSemesterTables = new HashSet<SubjectSemesterTable>();
            this.StudentPromoteTables = new HashSet<StudentPromoteTable>();
        }
    
        public int ProgrammeSemesterID { get; set; }
        [Required(ErrorMessage = "Required")]
        public int ProgrammeID { get; set; }
        [Required(ErrorMessage = "Required")]
        public int SemesterID { get; set; }
        [Display(Name ="Program Semester Title")]
        [Required(ErrorMessage = "Required")]
        public string Description { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MarkSheetTable> MarkSheetTables { get; set; }
        public virtual ProgrammeTable ProgrammeTable { get; set; }
        public virtual SemesterTable SemesterTable { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SubjectSemesterTable> SubjectSemesterTables { get; set; }
        public virtual ICollection<StudentPromoteTable> StudentPromoteTables { get; set; }
    }
}
