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
    public class LineManager: ISubject
    {
        [Key]
        public int LineManagerId { get; set;}
        [Required(ErrorMessage = "Please choose admission date.")]
        [Display(Name = "Email :")]
        [EmailVAlidation(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }
        //public int ReportId { get; set; }

    }
}
