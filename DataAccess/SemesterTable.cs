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

    public partial class SemesterTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SemesterTable()
        {
            this.ProgrammeSemestersTables = new HashSet<ProgrammeSemestersTable>();
        }
    
        public int SemesterID { get; set; }
        [Required(ErrorMessage = "Required")]
        public int SemesterTypeID { get; set; }
        [Required(ErrorMessage = "Required")]
        [Display(Name ="Semester Title:")]
        public string Name { get; set; }
        public string Description { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProgrammeSemestersTable> ProgrammeSemestersTables { get; set; }
        public virtual SemesterTypeTable SemesterTypeTable { get; set; }
    }
}
