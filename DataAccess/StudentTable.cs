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
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web;

    public partial class StudentTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StudentTable()
        {
            this.MarkSheetTables = new HashSet<MarkSheetTable>();
        }
    
        public int StudentID { get; set; }
        [Required(ErrorMessage = "Required")]
       
        public int DepartmentID { get; set; }
        [Required(ErrorMessage = "Required")]
        public int ProgrammeID { get; set; }
        [Required(ErrorMessage = "Required")]
        public int SessionID { get; set; }
        [Required(ErrorMessage = "Required")]
        [Display(Name = "Full Name:")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Reg_No { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Enroll_No { get; set; }
        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Date)]
        public System.DateTime Dob { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Father_Name { get; set; }
        public string Photo { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> Data_of_Addmission { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Religion { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Address { get; set; }
        public string Description { get; set; }
        [NotMapped]
        public HttpPostedFileBase LogoFile { get; set; }
        public virtual DepartmentTable DepartmentTable { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MarkSheetTable> MarkSheetTables { get; set; }
        public virtual ProgrammeTable ProgrammeTable { get; set; }
        public virtual SessionTable SessionTable { get; set; }
    }
}
