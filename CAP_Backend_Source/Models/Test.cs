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
    
    public partial class Test
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Test()
        {
            this.EssayQuestions = new HashSet<EssayQuestion>();
            this.MultipleChoiceQuestions = new HashSet<MultipleChoiceQuestion>();
        }
    
        public int TestId { get; set; }
        public int ProgramId { get; set; }
        public string TestTitle { get; set; }
        public int TypeId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EssayQuestion> EssayQuestions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MultipleChoiceQuestion> MultipleChoiceQuestions { get; set; }
        public virtual Program Program { get; set; }
        public virtual Type Type { get; set; }
    }
}
