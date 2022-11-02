//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CAP_Backend_Source.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Program
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Program()
        {
            this.ContentPrograms = new HashSet<ContentProgram>();
            this.Tests = new HashSet<Test>();
        }
    
        public int ProgramId { get; set; }
        public int AccountIdCreator { get; set; }
        public int FacultyId { get; set; }
        public int CategoryId { get; set; }
        public string ProgramName { get; set; }
        public string Image { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public bool IsPublish { get; set; }
        public Nullable<int> Coin { get; set; }
    
        public virtual Account Account { get; set; }
        public virtual Category Category { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ContentProgram> ContentPrograms { get; set; }
        public virtual Faculty Faculty { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Test> Tests { get; set; }
    }
}
