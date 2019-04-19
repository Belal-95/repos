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
    
    public partial class tblUserAccountDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblUserAccountDetail()
        {
            this.tblUserCvDetails = new HashSet<tblUserCvDetail>();
            this.tblUserPersonalDetails = new HashSet<tblUserPersonalDetail>();
        }
    
        public int UserId { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public Nullable<System.DateTime> DateOfRegistration { get; set; }
        public Nullable<System.DateTime> LastAccessDateTime { get; set; }
        public Nullable<bool> IsApproved { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblUserCvDetail> tblUserCvDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblUserPersonalDetail> tblUserPersonalDetails { get; set; }
    }
}
