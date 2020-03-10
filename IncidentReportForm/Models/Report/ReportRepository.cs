﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace IncidentReportForm.Models
{
    public class ReportRepository : IReportRepository
    {
        public ClaimsPrincipal User { get; set; }
        private readonly UserManager<IdentityUser> _userManager;
        SignInManager<IdentityUser> SignInManager;
        private readonly AppDbContext _appDbContext;
        
        public ReportRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public void CreateReport(Reports order)
        {

            //order.OrderPlaced = DateTime.Now;
            


            _appDbContext.Reports.Add(order);
            _appDbContext.SaveChanges();

        }
        public IEnumerable<Reports> Reports { get; set; }
      
        public IEnumerable<Reports> AllReports
        {
            get
            {
                return _appDbContext.Reports.Include(c => c.Principal); ;
            }
        }
        public Reports GetReportById(int reportId)
        {
            return _appDbContext.Reports.FirstOrDefault(r => r.ReportId == reportId);
        }
        public int GetPending()
        {
            int numPending = 0;
            foreach (Reports report in _appDbContext.Reports)
            {
                if (report.UserId == _userManager.GetUserId(User) && !report.Complete)
                {
                    numPending++;
                }
            }
            return numPending;
        }


    }
}