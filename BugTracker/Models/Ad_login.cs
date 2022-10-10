using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Models
{
    public class Ad_login
    {
        
        [Required]
        [DisplayName("User ID")]
        public string Admin_id { get; set; }

        [Required]
        [DisplayName("Password")]
        public string Ad_Password { get; set; }
    }
}
