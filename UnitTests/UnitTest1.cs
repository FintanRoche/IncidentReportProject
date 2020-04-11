using IncidentReportForm.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests
{
    
    [TestClass]
    public class UnitTest1
    {
        LineManager lineManager = new LineManager();

        Reports report = new Reports()
        {
            UserId = "1"
        };
        Reports report2 = new Reports()
        {
            Principal = new Principal
            {
                FirstName = "Report 2",
                LastName = "Blogs"
            },
            UserId = "1"
        };
        Reports report3 = new Reports()
        {
            Principal = new Principal()
            {
                FirstName = "Report 3",
                LastName = "Blogs",
            },
            UserId = "2"
        };



        [TestMethod]
        public void Create()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "Tempory DataBase")
                .Options;
                AppDbContext context = new AppDbContext(options);
            
                var service = new ReportRepository(context);
                service.CreateReport(report);
                context.SaveChanges();
           
                Assert.AreEqual(1, context.Reports.Count());
                Assert.AreEqual(report.ReportId, context.Reports.First().ReportId);
            
        }
        [TestMethod]
        public void Remove()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "Remove")
                .Options;
                AppDbContext context = new AppDbContext(options);
            
                var service = new ReportRepository(context);
                service.CreateReport(report);
                service.CreateReport(report2);
                context.SaveChanges();
                Assert.AreEqual(2, context.Reports.Count());
                service.RemoveReport(report);
                Assert.AreEqual(1, context.Reports.Count());
                Assert.AreEqual("Report 2", context.Reports.First().Principal.FirstName);


        }
        [TestMethod]
        public void Update()
        {

            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "Update")
                .Options;
                AppDbContext context = new AppDbContext(options);
                var service = new ReportRepository(context);
                service.CreateReport(report2);
                report2.Principal.FirstName = "ReportB";
                service.UpdateReport(report2);
                
                Assert.AreEqual("ReportB", context.Reports.First().Principal.FirstName);
            Assert.AreEqual(true , context.Reports.First().Complete);

            
        }
        [TestMethod]
        public void Search()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "Search")
                .Options;
                AppDbContext context = new AppDbContext(options);
                var service = new ReportRepository(context);
                service.CreateReport(report2);
                service.CreateReport(report3);
                context.SaveChanges();

                Search search1 = new Search() { FirstName = "Report 2" };
                Search search2 = new Search() { LastName = "Blogs" };
                Search search3 = new Search() { FirstName = "Mary" };
                List<Reports> Result1 = service.Search(search1);
                List<Reports> Result2 = service.Search(search2);
                List<Reports> Result3 = service.Search(search3);

                Assert.AreEqual(1, Result1.Count());
                Assert.AreEqual("Report 2", Result1.First().Principal.FirstName);

                Assert.AreEqual(2, Result2.Count());

                Assert.AreEqual(0, Result3.Count());

            
        }
        [TestMethod]
        public void GetPending()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
               .UseInMemoryDatabase(databaseName: "GetPending")
               .Options;
                AppDbContext context = new AppDbContext(options);
            
                var service = new ReportRepository(context);
                service.CreateReport(report);
                service.CreateReport(report2);
                service.CreateReport(report3);
                context.SaveChanges();
                Assert.AreEqual(2, service.GetPending("1"));
                Assert.AreEqual(1, service.GetPending("2"));
                Assert.AreEqual(0, service.GetPending("3"));

            

        }
        [TestMethod]
        public void GetReportByID()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
              .UseInMemoryDatabase(databaseName: "Database")
              .Options;

                AppDbContext context = new AppDbContext(options);
                var service = new ReportRepository(context);
                service.CreateReport(report);
                service.CreateReport(report2);
                service.CreateReport(report3);
                context.SaveChanges();
                Reports Result1 = service.GetReportById(report.ReportId);
                Reports Result2 = service.GetReportById(report2.ReportId);
                Reports Result3 = service.GetReportById(report3.ReportId);

                Assert.AreEqual(report, Result1);
                Assert.AreNotEqual(report2, Result1);
                Assert.AreEqual(report3, Result3);
            
        }
        [TestMethod]
        public void Download()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "Download")
                .Options;

            using var context = new AppDbContext(options);
            Reports report4 = new Reports()
            {
                ReportId = 109
            };
            var _hostingEnviroment = new Mock<IWebHostEnvironment>();
         
            _hostingEnviroment
                .Setup(m => m.EnvironmentName)
                .Returns("Hosting:UnitTestEnvironment");
            _hostingEnviroment.Setup(p => p.ContentRootPath).Returns("C:\\Users\\finta\\source\\repos\\IncidentReportForm\\IncidentReportForm");

            var service = new ReportRepository(context, _hostingEnviroment.Object);
            var testType = service.Download(report4);

            Assert.IsInstanceOfType(testType, typeof(FileStreamResult));
        }
    }

}