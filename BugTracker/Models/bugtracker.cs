using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Models
{
    public class bugtracker
    {
        public int Id { get; set; }
 
        public Status Status { get; set; }
        [Required]
        [StringLength(255)]
        public string Title { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Required]
        [StringLength(30)]
        [DisplayName("Reporter")]
        public string ReportedBy { get; set; } 
        [Required]
        [StringLength(30)]
        [DisplayName("Assigned To")]
        public string AssignedTo { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        [DisplayName("Open On")]
        public DateTime CreationDate { get; set; } = System.DateTime.Now;


    }
}
