using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IncidentReportForm.Models
{
    public abstract class IPerson
    {
        [Display(Name = "First Name: ")]
        public String FirstName { get; set; }
        [Display(Name = "Last Name: ")]
        public string LastName { set; get; }

    }
}
