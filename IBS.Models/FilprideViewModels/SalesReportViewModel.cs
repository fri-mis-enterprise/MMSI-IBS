using IBS.Models.AccountsReceivable;
using IBS.Models.Integrated;

namespace IBS.Models.ViewModels
{
    public class SalesReportViewModel
    {
        public SalesInvoice? SalesInvoice { get; set; }
        public DeliveryReceipt DeliveryReceipt { get; set; }

        public string SalesInvoiceNo => SalesInvoice?.SalesInvoiceNo ?? " ";
    }
}
