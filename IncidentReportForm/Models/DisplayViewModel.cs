using IncidentReportForm.Models;
using Microsoft.AspNetCore.Identity;
//using IncidentReportForm.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IncidentReportForm.Models
{
    public class DisplayViewModel
    {

        public UserManager<IdentityUser> UserManager;
        //public ReportRepository reportRepository { get; set; }
        public ClaimsPrincipal User { get; set; }
        public IEnumerable<Reports> Reports { get; set; }
      
       
        public readonly DateTime NullTime = new DateTime(0001, 1, 1, 0, 0, 0, 0);
        public Reports Report { get; set; }
        public Subject Principal { get; set; }
        public LineManager LineManager { get; set; }
        
    }
}
