using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TSSReport.Data;
using TSSReport.Models;
using TSSReport.Utilities;

namespace TSSReport.Repository
{
    public class ReportRepository
    {
        public static List<PartyWiseClosingModel> GetPartyMasterReport(string dbName)
        {
            var partyMaster = new List<PartyWiseClosingModel>();
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["TranDBEntities"].ToString().Replace("XXXX", dbName);
                using (var dbContext = new TranDBContext(connectionString))
                {
                    var results = dbContext
                       .MultipleResults("[dbo].[Sp_PartywiseClosingBalance]")
                       .With<PartyWiseClosingModel>()
                       .Execute();
                    if (results != null && results.Count > 0)
                    {
                        partyMaster = ((List<PartyWiseClosingModel>)results[0]).ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                Common.LogError("Report", "GetPartyMasterReport", "GetPartyMasterReport", ex.Message.ToString(), "", "", "");
                return partyMaster;
            }
            return partyMaster;
        }

        public static List<BookingReportModel> GetBookingFormReport(string dbName, string FromDate, string ToDate, string LRNO)
        {
            var bookingReports = new List<BookingReportModel>();
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["TranDBEntities"].ToString().Replace("XXXX", dbName);
                var _FromDate = new SqlParameter { ParameterName = "FromDate", Value = FromDate };
                var _ToDate = new SqlParameter { ParameterName = "ToDate", Value = ToDate };
                var _LRNO = new SqlParameter { ParameterName = "LRNo", Value = LRNO };
                using (var dbContext = new TranDBContext(connectionString))
                {
                    var results = dbContext
                       .MultipleResults("[dbo].[PROC_BookingFormReportWeb]")
                       .With<BookingReportModel>()
                       .Execute(_FromDate, _ToDate, _LRNO);
                    if (results != null && results.Count > 0)
                    {
                        bookingReports = ((List<BookingReportModel>)results[0]).ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                Common.LogError("Report", "GetBookingFormReport", "GetBookingFormReport", ex.Message.ToString(), "", "", "");
                return bookingReports;
            }

            return bookingReports;
        }

        public static List<DeliveryChallanReportModel> GetDeliveryChallanReport(string dbName, string FromDate, string ToDate, string LRNO)
        {
            var deliveryChallanReports = new List<DeliveryChallanReportModel>();
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["TranDBEntities"].ToString().Replace("XXXX", dbName);
                var _FromDate = new SqlParameter { ParameterName = "FromDate", Value = FromDate };
                var _ToDate = new SqlParameter { ParameterName = "ToDate", Value = ToDate };
                var _LRNO = new SqlParameter { ParameterName = "LRNo", Value = LRNO };
                using (var dbContext = new TranDBContext(connectionString))
                {
                    var results = dbContext
                       .MultipleResults("[dbo].[PROC_DeliveryChallanDelhiWeb]")
                       .With<DeliveryChallanReportModel>()
                       .Execute(_FromDate, _ToDate, _LRNO);
                    if (results != null && results.Count > 0)
                    {
                        deliveryChallanReports = ((List<DeliveryChallanReportModel>)results[0]).ToList();

                    }
                }
            }
            catch (Exception ex)
            {
                Common.LogError("Report", "GetDeliveryChallanReport", "GetDeliveryChallanReport", ex.Message.ToString(), "", "", "");
                return deliveryChallanReports;
            }

            return deliveryChallanReports;
        }

        public static List<SalesInvoiceReportModel> GetSalesInvoiceReport(string dbName, string FromDate, string ToDate, string LRNO)
        {
            var salesInvoiceReports = new List<SalesInvoiceReportModel>();
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["TranDBEntities"].ToString().Replace("XXXX", dbName);

                var _FromDate = new SqlParameter { ParameterName = "FromDate", Value = FromDate };
                var _ToDate = new SqlParameter { ParameterName = "ToDate", Value = ToDate };
                var _LRNO = new SqlParameter { ParameterName = "LRNo", Value = LRNO };
                using (var dbContext = new TranDBContext(connectionString))
                {
                    var results = dbContext
                       .MultipleResults("[dbo].[PROC_SalesINvoiceWeb]")
                       .With<SalesInvoiceReportModel>()
                       .Execute(_FromDate, _ToDate, _LRNO);
                    if (results != null && results.Count > 0)
                    {
                        salesInvoiceReports = ((List<SalesInvoiceReportModel>)results[0]).ToList();

                    }
                }
            }
            catch (Exception ex)
            {
                Common.LogError("Report", "GetSalesInvoiceReport", "GetSalesInvoiceReport", ex.Message.ToString(), "", "", "");
                return salesInvoiceReports;
            }

            return salesInvoiceReports;
        }
    }
}