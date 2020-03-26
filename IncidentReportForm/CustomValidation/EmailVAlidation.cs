using IncidentReportForm.Areas.Identity.Pages.Account;

using IncidentReportForm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace IncidentReportForm.CustomValidation
{
    public class EmailVAlidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            String email = Convert.ToString(value);
            //var report = (Reports)validationContext.ObjectInstance;
            //if (email == "fintanroche1@gmail.com")
            //    {
               
            //        return true;
            //}
            return true;
        }
    }
}
