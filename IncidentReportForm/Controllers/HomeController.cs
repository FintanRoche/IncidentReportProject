using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using IncidentReportForm.Models;

using System.IO;
using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;

namespace IncidentReportForm.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _hostingEnviroment;


        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment hostingEnviroment)
        {
            _hostingEnviroment = hostingEnviroment;
       
            _logger = logger;
        }
        public IActionResult Test()
        {
            return View();
        }

       public IActionResult Index()
        {
            HtmlToPdfConverter converter = new HtmlToPdfConverter();
            WebKitConverterSettings settings = new WebKitConverterSettings();
            settings.WebKitPath = Path.Combine(_hostingEnviroment.ContentRootPath, "QtBinariesWindows");
            converter.ConverterSettings = settings;

            PdfDocument document = converter.Convert("https://localhost:44381/Home/"+"Test");
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

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public FileStreamResult getEmail()
        {
            HtmlToPdfConverter converter = new HtmlToPdfConverter();
            WebKitConverterSettings settings = new WebKitConverterSettings();
            settings.WebKitPath = Path.Combine(_hostingEnviroment.ContentRootPath, "QtBinariesWindows");
            converter.ConverterSettings = settings;

            PdfDocument document = converter.Convert("https://localhost:44381/Home/" + "Test");
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
    }
}