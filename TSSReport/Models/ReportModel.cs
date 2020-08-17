using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TSSReport.Models
{
    public class DeliveryChallanReportModel
    {
        public string DocumentNo { get; set; }
        public string ChallanNo { get; set; }
        public string ChallanDate { get; set; }
        public string IssueFrom { get; set; }
        public string FromSource { get; set; }
        public string ToDestination { get; set; }
        public string TransportName { get; set; }
        public string DriverName { get; set; }
        public string LorryNo { get; set; }
        public string ConsolidatedNo { get; set; }
        public string LRNo { get; set; }
        public string LRDate { get; set; }
        public int NoOfPkgs { get; set; }
        public string WeightinKgs { get; set; }
        public string Remarks { get; set; }
        public string ArrivalDate { get; set; }
    }

    public class BookingReportModel
    {
        public string DocumentNo { get; set; }
        public string Lrno { get; set; }
        public string Lrdate { get; set; }
        public string Consignor { get; set; }
        public string Consignee { get; set; }
        public string FromCity { get; set; }
        public string ToCity { get; set; }
        public string ManualBill { get; set; }
        public string InvoiceNo { get; set; }
        public decimal ValeOfGoods { get; set; }
        public string EWBNo { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string DocumentType { get; set; }
        public int Packages { get; set; }
        public decimal ToPayPaid { get; set; }
        public decimal WeightActual { get; set; }
        public decimal QtyCharged { get; set; }
        public decimal Rate { get; set; }
        public decimal GrossAmount { get; set; }
        public string PrivateMarks { get; set; }
    }

    public class SalesInvoiceReportModel
    {
        public string DocumentNo { get; set; }
        public string DocumentDate { get; set; }
        public string CustomerName { get; set; }
        public string ChallanNo { get; set; }
        public string PaymentStatus { get; set; }
        public string ConsignmentNo { get; set; }
        public string Description { get; set; }
        public int Noofpkgs { get; set; }
        public decimal Rate { get; set; }
        public decimal GrossAmount { get; set; }
        public decimal NetAmount { get; set; }
        public string Remark { get; set; }
        public string FileNo { get; set; }
        public decimal WeightinKgs { get; set; }
    }

    public class PartyWiseClosingModel
    {
        public string PartyName { get; set; }
        public string Grp_Name { get; set; }
        public string Address { get; set; }
        public decimal TotalOutstanding { get; set; }
    }
}