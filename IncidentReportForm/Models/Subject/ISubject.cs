using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IncidentReportForm.Models
{
    public abstract class ISubject
    {
        public String FirstName { get; set; }
        public string LastName { set; get; }

    }
}
