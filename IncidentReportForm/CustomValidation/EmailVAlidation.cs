using IncidentReportForm.Areas.Identity.Pages.Account;
using IncidentReportForm.Controllers;
using IncidentReportForm.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace IncidentReportForm.CustomValidation
{
    public class EmailVAlidation : ValidationAttribute
    {
        public static UserManager<IdentityUser> userManager { set; get; }
        public override bool IsValid(object value)
        {
            //var rolesForUser = userManager.GetUsersInRoleAsync("Manager");

            foreach (IdentityUser user in userManager.Users)
            {
                
                String email = Convert.ToString(value);

                if (email == user.Email)
                {
                    return true;
                }
            }
            return false;    
        }
    }
}
