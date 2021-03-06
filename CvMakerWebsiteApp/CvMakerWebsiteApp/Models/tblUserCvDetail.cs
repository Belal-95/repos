//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CvMakerWebsiteApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblUserCvDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblUserCvDetail()
        {
            this.tblCvBasicInformations = new HashSet<tblCvBasicInformation>();
            this.tblEducationDetails = new HashSet<tblEducationDetail>();
            this.tblObjectives = new HashSet<tblObjective>();
            this.tblQualifications = new HashSet<tblQualification>();
            this.tblWorkExperienceDetails = new HashSet<tblWorkExperienceDetail>();
            this.tblInterestDetails = new HashSet<tblInterestDetail>();
            this.tblReferencesDetails = new HashSet<tblReferencesDetail>();
        }
    
        public int CvId { get; set; }
        public int UserId { get; set; }
        public string CvName { get; set; }
        public string Language { get; set; }
        public Nullable<System.DateTime> LastModificationDateTime { get; set; }
        public string Industry { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblCvBasicInformation> tblCvBasicInformations { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblEducationDetail> tblEducationDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblObjective> tblObjectives { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblQualification> tblQualifications { get; set; }
        public virtual tblUserAccountDetail tblUserAccountDetail { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblWorkExperienceDetail> tblWorkExperienceDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblInterestDetail> tblInterestDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblReferencesDetail> tblReferencesDetails { get; set; }
    }
}
