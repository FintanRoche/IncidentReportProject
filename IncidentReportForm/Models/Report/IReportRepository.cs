using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IncidentReportForm.Models
{
    public interface IReportRepository
    {
        IEnumerable<Reports> AllReports { get; }

        void CreateReport(Reports report);
        public void UpdateReport(LineManager report);
        Reports GetReportById(int reportId);
        public int GetPending(string _userManager);
        public List<Reports> Search(Search search);
        public FileStreamResult Download(Reports report);
    }
}
