using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IncidentReportForm.Models
{
    public class Search
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Location { get; set; }
        public string Type { get; set; }
    }
}
