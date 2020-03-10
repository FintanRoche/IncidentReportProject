using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IncidentReportForm.Models.Report
{
    public class Email
    {
        public static String getEmail(Reports report)
        {
            string email = ("Incident Type: " + report.IncidentType +
                "\nPRN: " + report.PRNBool +
                "\nRRN Medication: " + report.PRN_Medication +
                "\nSubject Type {3}" + report.Principal.SubjectType);
            





            return email;

        }
    }
}
