//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EventReminderService.Areas.Admin.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblCity
    {
        public int CityId { get; set; }
        public int StateId { get; set; }
        public int CountryId { get; set; }
        public string CityName { get; set; }
        public bool IsActive { get; set; }
    
        public virtual tblCountry tblCountry { get; set; }
        public virtual tblState tblState { get; set; }
    }
}
