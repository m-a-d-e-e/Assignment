//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EF_DataFirst_TrainingDB_App
{
    using System;
    using System.Collections.Generic;
    
    public partial class EMP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EMP()
        {
            this.EMP1 = new HashSet<EMP>();
        }
    
        public int EMPNO { get; set; }
        public string ENAME { get; set; }
        public string JOB { get; set; }
        public Nullable<int> MGR { get; set; }
        public Nullable<System.DateTime> HIREDATE { get; set; }
        public Nullable<decimal> SAL { get; set; }
        public Nullable<decimal> COMM { get; set; }
        public Nullable<int> DEPTNO { get; set; }
    
        public virtual DEPT DEPT { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMP> EMP1 { get; set; }
        public virtual EMP EMP2 { get; set; }
    }
}