using IncidentReportForm.CustomValidation;
using IncidentReportForm.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IncidentReportForm.Models
{
    public class Reports
    {
        [Key]
        public int ReportId { get; set; }
        [Display(Name = "*Incident Type:")]
        [Required(ErrorMessage = "Please choose an Icident type.")]
        public string IncidentType { get; set; }
        public Subject Subject { get; set; }
        [Display(Name = "Description:")]
        public string IncidentDescription { get; set; }
        [Display(Name = "*Location:")]
        [Required(ErrorMessage = "Please enter Incident Loction")]
        public string IncidentLocation { get; set; }
        public Witness Witness { get; set; }
        [Display(Name = "*Medical Intervention:")]
        public string MedicalIntervention { get; set; }
        public string Serverity { get; set; }
        public string UserId { get; set; }
        public bool Complete { get; set; }
        public LineManager LineManager { get; set; }
        [Display(Name="*Date :")]
        [DateValidation(ErrorMessage="Please enter valid date")]
        public DateTime Date { get; set; }
        [Display(Name = "*Time :")]
        [Required(ErrorMessage = "Please enter time")]
        public DateTime Time { get; set; }
        [Display(Name ="Next of Kin Notified: ")]
        public string Notified { get; set; }
        [Display(Name = "Responses given: ")]
        public string Responses { get; set; }
        [Display(Name = "Comment: ")]
        public string Comment { get; set; }
    }
}
