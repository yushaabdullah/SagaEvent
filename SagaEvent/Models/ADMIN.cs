//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SagaEvent.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public partial class ADMIN
    {
        public int adminID { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string adminEmail { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Password")]
        public string adminPassword { get; set; }
    }
}
