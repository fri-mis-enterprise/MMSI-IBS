namespace IBS.Models.ViewModels
{
    public class DispatchReportViewModel
    {
        public string ReportType { get; set; }

        public DateOnly DateFrom { get; set; }

        public DateOnly DateTo { get; set; }
    }
}
