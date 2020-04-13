using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IncidentReportForm.Models
{
    public class Witness: ISubject 
    { 
       public int WitnessId { get; set; } 
       public string Phone { get; set; } 
    }
}
