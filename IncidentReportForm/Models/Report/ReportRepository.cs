﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using MimeKit;

namespace IncidentReportForm.Models
{
    public class ReportRepository : IReportRepository
    {
        public ClaimsPrincipal User { get; set; }

        private readonly AppDbContext _appDbContext;
        private readonly IWebHostEnvironment _hostingEnviroment;
        

        public ReportRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public ReportRepository(AppDbContext appDbContext, IWebHostEnvironment hostEnvironment)
        {
            _appDbContext = appDbContext;
            _hostingEnviroment = hostEnvironment;
            
        }



        public void CreateReport(Reports report)
        {
            

            _appDbContext.Reports.Add(report);
            _appDbContext.SaveChanges();

        }
        public void RemoveReport(Reports report)
        {
            _appDbContext.Reports.Remove(report);
            _appDbContext.SaveChanges();
        }
        public void UpdateReport(Reports report)
        {
            //Reports newReport = _appDbContext.Reports.FirstOrDefault(d => d.ReportId == report.ReportId);
            //newReport.LineManager = report;
            report.Complete = true;
            _appDbContext.Update(report);
            _appDbContext.SaveChanges();
        }

        public IEnumerable<Reports> AllReports
        {
            get
            {
                return _appDbContext.Reports.Include(c => c.Subject).Include(w => w.Witness).Include(l => l.LineManager); ;
            }
        }
        public Reports GetReportById(int reportId)
        {
            Reports report = _appDbContext.Reports.Include(p => p.Subject).Include(c => c.LineManager).Include(w => w.Witness).FirstOrDefault(r => r.ReportId == reportId);
            return report;
        }
        public int GetPending(string _userManager)
        {
            int numPending = 0;
            foreach (Reports report in _appDbContext.Reports)
            {
                if (report.UserId == _userManager && !report.Complete)
                {
                    numPending++;
                }
            }
            return numPending;
        }
        public List<Reports> Search(Search search)
        {
            DateTime NullTime = new DateTime(0001, 1, 1, 0, 0, 0, 0);
            List<Reports> searchResults = new List<Reports>();

            foreach (var line in AllReports)
            {
                if (line.Subject.FirstName == search.FirstName || search.FirstName == null)
                {
                    if (line.Subject.LastName == search.LastName || search.LastName == null)
                    {

                        if (line.Date <= search.EndTime && line.Date >= search.StartTime || search.EndTime.ToString("MM/dd/yyyy") == NullTime.ToString("MM/dd/yyyy"))
                        {
                            if (line.IncidentType == search.Type || search.Type == null)
                            {
                                if (line.IncidentLocation == search.Location || search.Location == null)
                                {
                                    searchResults.Add(line);
                                }

                            }
                        }
                    }
                }
            }
        
            return searchResults;
        }

        public FileStreamResult Download(Reports report)
        {
            HtmlToPdfConverter converter = new HtmlToPdfConverter();
            WebKitConverterSettings settings = new WebKitConverterSettings();
            settings.WebKitPath = Path.Combine(_hostingEnviroment.ContentRootPath, "QtBinariesWindows");
            converter.ConverterSettings = settings;
            String Id = (report.ReportId).ToString();
            PdfDocument document = converter.Convert("https://localhost:44381/Report/Email?reportId=" + Id);
            //PdfDocument document = converter.Convert("https://i.stack.imgur.com/xhzgN.png");
            MemoryStream ms = new MemoryStream();
            document.Save(ms);
            document.Close(true);
            ms.Position = 0;
            FileStreamResult fileStreamResult = new FileStreamResult(ms, "application/pdf")
            {
                FileDownloadName = "Report.pdf"
            };
            return fileStreamResult;
        }
        public void Email(Reports report)
        {
            HtmlToPdfConverter converter = new HtmlToPdfConverter();
            WebKitConverterSettings settings = new WebKitConverterSettings();
            settings.WebKitPath = Path.Combine(_hostingEnviroment.ContentRootPath, "QtBinariesWindows");
            converter.ConverterSettings = settings;
            String Id = (report.ReportId).ToString();
            PdfDocument document = converter.Convert("https://localhost:44381/Report/Email?reportId=" + Id);
            MemoryStream ms = new MemoryStream();

            document.Save(ms);
            document.Close(true);
            ms.Position = 0;

                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("TeastA", report.LineManager.Email));
                message.To.Add(new MailboxAddress("TestB", report.LineManager.Email));
                message.Subject = "Incident Report";
                var builder = new BodyBuilder();
                builder.TextBody = "A incident report has been submitted" ;
                ContentType ct = new ContentType("application", "pdf");
                builder.Attachments.Add("Incident_Report.pdf", ms, ct);

                message.Body = builder.ToMessageBody();

                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {

                    client.Connect("smtp.gmail.com", 587, false);

                    //SMTP server authentication if needed
                    client.Authenticate("*****@gmail.com", "*******");

                    client.Send(message);

                    client.Disconnect(true);
                }

            }
            
        }
    }

