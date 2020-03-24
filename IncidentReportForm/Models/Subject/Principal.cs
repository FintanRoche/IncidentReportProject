using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IncidentReportForm.Models
{
    public class Principal : ISubject
    {
        public string SubjectType { get; set; }
        [Key]
        [Required]
        public string Pin { get; set; }
        //[Remote(action: "EmailValidator", controller: "Report")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string nextOfKin { get; set; }

        
    }
}
