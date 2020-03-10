using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IncidentReportForm.Models;
using IncidentReportForm.Models.Report;
//using IncidentReportForm.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MimeKit;

namespace IncidentReportForm.Controllers
{
    [Authorize]
    public class ReportController : Controller

    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<ReportController> _logger;

        private readonly IReportRepository _reportRepository;
        public ReportController(IReportRepository reportRepository, UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            _reportRepository = reportRepository;
        }
        public IActionResult DisplayUser()
        {
            var displayViewModel = new DisplayViewModel
            {
                User = User,
                UserManager = _userManager,

                Reports = _reportRepository.AllReports
            };


            return View(displayViewModel);
        }

        public IActionResult Create()
        {



            return View();
        }



            public IActionResult Display()
        {
            var displayViewModel = new DisplayViewModel
            {
                Reports = _reportRepository.AllReports
            };


            return View(displayViewModel);

        }

        public IActionResult Search()
        {


            return View();
        }

        [HttpPost]
        public IActionResult SearchResults(Reports report)
        {
            if (!String.IsNullOrEmpty(report.PRN_Medication))
            {
                var displayViewModel = new DisplayViewModel
                {
                    Reports = _reportRepository.AllReports,
                    search = report.PRN_Medication,
                    firstName = report.Principal.FirstName
                };
                return View(displayViewModel);
            }

            return View("Search");
        }


        [HttpPost]
        public IActionResult Create(Reports report)
        {
            _reportRepository.CreateReport(report);
            return View(report);
        }

        public IActionResult Details(int reportid)
        {
            var report = _reportRepository.GetReportById(reportid);
            if (report == null)
            {
                return NotFound();
            }

            return View(report);
        }
        //private IdentityUser GetCurrentUser() => _userManager.GetUserAsync(HttpContext.User);





        [HttpPost]
        public IActionResult FormPage2(Reports report)
        {

            return View(report);
        }
        //[HttpPost]
        //public IActionResult Submit(Reports report)
        //{
        //    _reportRepository.CreateReport(report);
        //    return View(report);
        //}


        [HttpPost]
        public IActionResult Submit(Reports report)
        {
            report.UserId = _userManager.GetUserId(User);
            _reportRepository.CreateReport(report);
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("TeastA", report.Email));
                message.To.Add(new MailboxAddress("TestB", report.Email));
                message.Subject = "Incident Report";
                message.Body = new TextPart("plain")
                {
                    Text = Email.getEmail(report)
                };

                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {

                    client.Connect("smtp.gmail.com", 587, false);

                    //SMTP server authentication if needed
                    client.Authenticate("fintanroche1@gmail.com", "@Time123");

                    client.Send(message);

                    client.Disconnect(true);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "No Error occured");
            }

            return View();
        }
    }
}