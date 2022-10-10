using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Models
{
    public class User
    {
        public int Id { get; set; }
        [DisplayName("User ID")]
        [Required]
        [StringLength(30, MinimumLength =5)]
        public string admin_id { get; set; }
        [Required]
        [DisplayName("Password")]
        [StringLength(30, MinimumLength =5)]
        
        public string Ad_Password { get; set; }
        [Required]
        [DisplayName("First Name")]
        [StringLength(50, MinimumLength =1)]
        public string First_Name { get; set; }
        [DisplayName("Last Name")]
        [StringLength(50, MinimumLength =1)]
        [Required]
        public string Last_Name { get; set; }
    }
}
