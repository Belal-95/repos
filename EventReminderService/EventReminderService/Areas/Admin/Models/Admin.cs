using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace EventReminderService.Areas.Admin.Models
{
    public class Admin
    {
        [Required(ErrorMessage = "The Old Password field is required.")]
        [Display(Name = "Old Password")]

        public string OldPassword { get; set; }

        [Required(ErrorMessage = "The New Password field is required.")]
        [Display(Name = "New Password")]

        public string NewPassword { get; set; }


        [Required(ErrorMessage = "The Confirm Password field is required.")]
        [Display(Name = "Confirm Password")]
        [Compare("NewPassword", ErrorMessage = "Confirm Password Must be same as New Password .")]
        public string ConfirmPassword { get; set; }

    }
}