﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IncidentReportForm.Models
{
    public class Secondary : ISubject
    {
        public string SubjectType { get; set; }
        [Key]
        [Required]
        public string Pin { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
