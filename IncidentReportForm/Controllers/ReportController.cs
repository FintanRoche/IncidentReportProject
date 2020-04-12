using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using IncidentReportForm.CustomValidation;
using IncidentReportForm.Models;
using IncidentReportForm.Models;
//using IncidentReportForm.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MimeKit;
using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;

namespace IncidentReportForm.Controllers
{
    
    public class ReportController : Controller

    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<ReportController> _logger;
        private readonly IWebHostEnvironment _hostingEnviroment;

        private readonly IReportRepository _reportRepository;
        public ReportController(IReportRepository reportRepository,
        UserManager<IdentityUser> userManager, IWebHostEnvironment hostingEnviroment)
        {
            _userManager = userManager;
            _reportRepository = reportRepository;
            _hostingEnviroment = hostingEnviroment;
            EmailVAlidation.userManager = userManager;
        }
        [Authorize]
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


        [Authorize]
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
        [Authorize]
        public IActionResult Search()
        {


            return View();
        }
        [Authorize]
        [HttpPost]
        public IActionResult SearchResults(Search report)
        {
            if (report!=null)
            {
                List<Reports> searchResults = _reportRepository.Search(report);
                return View(searchResults);
            }

            return View("Search");
        }

        [Authorize]
        public IActionResult LineManager(int reportid)
        {
            Reports report = _reportRepository.GetReportById(reportid);
            if (report == null)
            {
                return NotFound();
            }

            return View(report);
        }

        [Authorize]
        public IActionResult Line(Reports report)
        {
            _reportRepository.UpdateReport(report);
            return RedirectToAction("DisplayUser");
        }
       
        [HttpPost]
        public IActionResult FormPage2(Reports report)
        {

            return View(report);
        }

        public IActionResult Submit()
        {
            return View();
        }

        public IActionResult FinalReport(int reportid)
        {
            Reports report = _reportRepository.GetReportById(reportid);
            var displayVeiwModel = new DisplayViewModel {
                    Report = report,
                    Principal = report.Subject
            };
            if (report == null)
            {
                return NotFound();
            }

            return View(report);
        }
        public IActionResult Email(int reportid)
        {
            Reports report = _reportRepository.GetReportById(reportid);
            var displayVeiwModel = new DisplayViewModel
            {
                Report = report,
                Principal = report.Subject
            };
            if (report == null)
            {
                return NotFound();
            }

            return View(report);
        }
        public IActionResult Print(int reportid)
        {
            Reports report = _reportRepository.GetReportById(reportid);
            var displayVeiwModel = new DisplayViewModel
            {
                Report = report,
                Principal = report.Subject
            };
            if (report == null)
            {
                return NotFound();
            }

            return View(report);
        }
        public IActionResult Download(Reports report)
        {
            FileStreamResult fileStreamResult =_reportRepository.Download(report);


            return fileStreamResult;

        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Submit(Reports report)
        {

            //var errors = ModelState.Values.SelectMany(v => v.Errors);
            //if (!ModelState.IsValid)
            //{
            //    return View("Create");
            //}
            //else
            //{
                report.UserId = _userManager.GetUserId(User);
                _reportRepository.CreateReport(report);


                HtmlToPdfConverter converter = new HtmlToPdfConverter();
                WebKitConverterSettings settings = new WebKitConverterSettings();
                settings.WebKitPath = Path.Combine(_hostingEnviroment.ContentRootPath, "QtBinariesWindows");
                converter.ConverterSettings = settings;
                String Id = (report.ReportId).ToString();
                PdfDocument document = converter.Convert("https://localhost:44381/Report/Email?reportId="+Id);
                MemoryStream ms = new MemoryStream();
                
                document.Save(ms);
                document.Close(true);
                ms.Position = 0;
               
                try
                {
                    var message = new MimeMessage();
                    message.From.Add(new MailboxAddress("TeastA", report.LineManager.Email));
                    message.To.Add(new MailboxAddress("TestB", report.LineManager.Email));
                    message.Subject = "Incident Report";
                    var builder = new BodyBuilder();
                    builder.TextBody = "Test12";
                    ContentType ct = new ContentType("application", "pdf");
                    builder.Attachments.Add("Incident_Report.pdf", ms,ct);

                    message.Body = builder.ToMessageBody();

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
                    return StatusCode(500, "Email Address was invailid");
                }

                return View();
            //}
        }

    }


}
