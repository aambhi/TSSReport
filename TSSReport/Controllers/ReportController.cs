using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web.Mvc;
using TSSReport.App_Start;
using TSSReport.Models;
using TSSReport.Repository;
using TSSReport.Utilities;

namespace TSSReport.Controllers
{
    [ErrorFilter]
    [Authenticate]
    public class ReportController : Controller
    {
        public ActionResult Index(string DBName = null, string CompanyName = null)
        {
            if (!string.IsNullOrEmpty(DBName))
            {
                ((LoginResultModel)Session["UserDetails"]).DBName = DBName;
                ((LoginResultModel)Session["UserDetails"]).CompanyName = CompanyName;
                return RedirectToAction("Index");
            }
            return View();
        }
        // GET: Report
        public ActionResult PartyMasterReport(string DBName = null)
        {
            string dbname = ((LoginResultModel)Session["UserDetails"]).DBName;
            var result = ReportRepository.GetPartyMasterReport(dbname);
            return View(result);
        }

        public ActionResult BookingFormReport()
        {
            return View(new List<BookingReportModel>());
        }
        [HttpPost]
        public ActionResult BookingFormReport(string LRNo)
        {
            string dbname = ((LoginResultModel)Session["UserDetails"]).DBName;
            var result = ReportRepository.GetBookingFormReport(dbname, LRNo);
            return View(result);
        }

        public ActionResult DeliveryChallanReport()
        {
            return View(new List<DeliveryChallanReportModel>());
        }
        [HttpPost]
        public ActionResult DeliveryChallanReport(string LRNo)
        {
            string dbname = ((LoginResultModel)Session["UserDetails"]).DBName;
            var result = ReportRepository.GetDeliveryChallanReport(dbname, LRNo);
            return View(result);
        }

        public ActionResult SalesInvoiceReport()
        {
            return View(new List<SalesInvoiceReportModel>());
        }
        [HttpPost]
        public ActionResult SalesInvoiceReport(string LRNo)
        {
            string dbname = ((LoginResultModel)Session["UserDetails"]).DBName;
            var result = ReportRepository.GetSalesInvoiceReport(dbname, LRNo);
            return View(result);
        }
    }
}