using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IncidentReportForm.Models
{
    public class Options
    {
        
        public static List<string> SubjectType = new List<string>() { "Service User", "Staff Member", "Member of Public", "other" };
        public static List<string> Boolean = new List<string>() { "yes", "no" };



    }
}
