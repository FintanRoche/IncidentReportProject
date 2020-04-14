using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IncidentReportForm.Models
{
    public class Subject : IPerson
    {
        [Display(Name = "Subject Type: ")]
        public string SubjectType { get; set; }
        public  int SubjectId { get; set; }
        [Display(Name = "D.O.B: ")]
        public DateTime DOB { get; set; }
        [Display(Name = "Next of Kin: ")]
        public string NextOfKin { get; set; }

        
    }
}
