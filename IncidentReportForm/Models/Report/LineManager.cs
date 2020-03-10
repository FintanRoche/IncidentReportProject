using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IncidentReportForm.Models.Report
{
    public class LineManager
    {
        [Key]
        public int LineManagerId { get; set;}
        public string Notified { get; set; }
        public string Responses { get; set; }
        public string Comment { get; set; }
        public string Debriefing { get; set; }
        public bool PRMP { get; set; }
        public bool Abuse { get; set; }
        public string Email { get; set; }

    }
}
