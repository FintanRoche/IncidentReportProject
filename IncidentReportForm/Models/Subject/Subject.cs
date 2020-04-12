using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IncidentReportForm.Models
{
    public class Subject : ISubject
    {
        public string SubjectType { get; set; }
        public  int SubjectId { get; set; }
       
        public DateTime DOB { get; set; }
        public string NextOfKin { get; set; }

        
    }
}
