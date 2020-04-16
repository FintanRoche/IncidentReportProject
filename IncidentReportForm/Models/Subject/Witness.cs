using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IncidentReportForm.Models
{
    public class Witness: IPerson 
    { 
       public int WitnessId { get; set; }
        [Display(Name = "Phone: ")]
        public string Phone { get; set; } 
    }
}
