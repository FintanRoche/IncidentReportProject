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
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //using (var context = new BloggingContext())
            //{
            //    var blogs = context.Blogs.ToList();
            //}
            var report = (Reports)validationContext.ObjectInstance;
            
            bool correct = false;
           // foreach (String email in RegisterModel.ManagerEmails)
           // {
                if (report.Email == "fintanroche1@gmail.com")
                {
                    correct = true;
                }
            //

            return (correct == true) ? ValidationResult.Success : new ValidationResult("asfljh");
        }
    }
}
