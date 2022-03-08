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

    public partial class USER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USER()
        {
            this.ORDERS = new HashSet<ORDER>();
        }
    
        public int userId { get; set; }

        [Required(ErrorMessage ="This field is required")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string userEmail { get; set; }

        
        
        
        
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Password")]
        public string userPassword { get; set; }


        [DataType(DataType.Password)]
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Confirm Password")]
        [NotMapped]
        [Compare("userPassword", ErrorMessage ="Confirm Password doesn't match. Enter again!")]
        public string confirmPassword { get; set; }



        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Full Name")]
        public string userFullName { get; set; }

        
        
        
        
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Address")]
        public string userAddresss { get; set; }





        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Phone")]
        public string userPhone { get; set; }
    
        
        
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDER> ORDERS { get; set; }
    }
}
