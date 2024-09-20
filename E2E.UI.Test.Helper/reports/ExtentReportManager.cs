using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;

namespace E2E.UI.Test.Helper.reports
{
    public class ExtentReportManager
    {
        public static ExtentReports SetUpExtentReport()
        {
            string workingDirectory = Environment.CurrentDirectory; 
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string reportPath = projectDirectory + "\\index.html";
            ExtentSparkReporter reporter = new ExtentSparkReporter(reportPath);
            ExtentReports extent = new ExtentReports();
            extent.AttachReporter(reporter);
            return extent;

        }
    }
}
