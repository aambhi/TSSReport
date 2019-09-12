using System;
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
        public ActionResult Index(string DBName = null,string CompanyName = null)
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
            var fromDate = DateTime.Now.AddDays(-7).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            var toDate = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            ViewBag.FromDate = fromDate;
            ViewBag.ToDate = toDate;
            string dbname = ((LoginResultModel)Session["UserDetails"]).DBName;
            var result = ReportRepository.GetBookingFormReport(dbname, fromDate, toDate, "");
            return View(result);
        }
        [HttpPost]
        public ActionResult BookingFormReport(string FromDate, string ToDate, string LRNo)
        {
            ViewBag.FromDate = FromDate;
            ViewBag.ToDate = ToDate;
            string dbname = ((LoginResultModel)Session["UserDetails"]).DBName;
            var result = ReportRepository.GetBookingFormReport(dbname, FromDate, ToDate, LRNo);
            return View(result);
        }

        public ActionResult DeliveryChallanReport()
        {
            var fromDate = DateTime.Now.AddDays(-7).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            var toDate = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            ViewBag.FromDate = fromDate;
            ViewBag.ToDate = toDate;
            string dbname = ((LoginResultModel)Session["UserDetails"]).DBName;
            var result = ReportRepository.GetDeliveryChallanReport(dbname, fromDate, toDate, "");
            return View(result);
        }
        [HttpPost]
        public ActionResult DeliveryChallanReport(string FromDate, string ToDate, string LRNo)
        {
            ViewBag.FromDate = FromDate;
            ViewBag.ToDate = ToDate;
            string dbname = ((LoginResultModel)Session["UserDetails"]).DBName;
            var result = ReportRepository.GetDeliveryChallanReport(dbname, FromDate, ToDate, LRNo);
            return View(result);
        }

        public ActionResult SalesInvoiceReport()
        {
            var fromDate = DateTime.Now.AddDays(-7).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            var toDate = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            ViewBag.FromDate = fromDate;
            ViewBag.ToDate = toDate;
            string dbname = ((LoginResultModel)Session["UserDetails"]).DBName;
            var result = ReportRepository.GetSalesInvoiceReport(dbname, fromDate, toDate, "");
            return View(result);
        }
        [HttpPost]
        public ActionResult SalesInvoiceReport(string FromDate, string ToDate, string LRNo)
        {
            ViewBag.FromDate = FromDate;
            ViewBag.ToDate = ToDate;
            string dbname = ((LoginResultModel)Session["UserDetails"]).DBName;
            var result = ReportRepository.GetSalesInvoiceReport(dbname, FromDate, ToDate, LRNo);
            return View(result);
        }
    }
}