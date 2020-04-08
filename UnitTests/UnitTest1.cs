using IncidentReportForm.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        LineManager lineManager = new LineManager();
        Reports report = new Reports();
        static AppDbContext appDbContext = new AppDbContext();
       
        ReportRepository reportRepository = new ReportRepository( appDbContext);

         [TestMethod]
        public void Create()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;
            using(var context = new AppDbContext(options))
            {
                var service = new ReportRepository(context);
                service.CreateReport(report);
                context.SaveChanges();
            }
            using(var context = new AppDbContext(options))
            {
                Assert.AreEqual(1, context.Reports.Count());
                Assert.AreEqual(report.ReportId, context.Reports.First().ReportId);
            }
        }
        public void Update()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;

        }
    }
}