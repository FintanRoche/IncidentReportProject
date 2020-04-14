using IncidentReportForm.CustomValidation;
using IncidentReportForm.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IncidentReportForm.Models
{
    public class LineManager: IPerson
    {
        [Key]
        public int LineManagerId { get; set;}
        [Required(ErrorMessage = "Enter an email address.")]
        [Display(Name = "Email :")]
        [EmailVAlidation(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }
        //public int ReportId { get; set; }

    }
}
