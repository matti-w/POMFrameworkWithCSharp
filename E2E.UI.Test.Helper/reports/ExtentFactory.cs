using AventStack.ExtentReports;
using AventStack.ExtentReports.MarkupUtils;
using E2E.UI.Test.Helper.driver;
using OpenQA.Selenium;

namespace E2E.UI.Test.Helper.reports
{
    public class ExtentFactory
    {
        ThreadLocal<ExtentTest> extent = new ThreadLocal<ExtentTest>();

        private ExtentFactory()
        {

        }

        private static ExtentFactory instance = new ExtentFactory();

        public static ExtentFactory GetInstance()
        {
            return instance;
        }

        public void SetExtent(ExtentTest obj)
        {
            extent.Value = obj;

        }

        public ExtentTest GetExtentTest()
        {
            return extent.Value;
        }

        public void RemoveTest()
        {
            
        }

        public void ClickPass(string btnName)
        {

            GetInstance().GetExtentTest().Pass(btnName + " button is clicked.");

        }

        public void ClickFail(string btnName)
        {
            GetInstance().GetExtentTest().Fail("Error occured while clicking on " + btnName);
        }

        public void SendKeysPass(string value, string elementName)
        {
            GetInstance().GetExtentTest().Pass(value + " is enetered in " + elementName);
        }

        public void SendKeysFail(string value, string elementName)
        {

            GetInstance().GetExtentTest()
                    .Fail("Error occured while entering value " + value + " in text box " + elementName);

        }

        public void PassTest(string message)
        {

            GetInstance().GetExtentTest().Log(Status.Pass, MarkupHelper.CreateLabel(message, ExtentColor.Green));

        }

        public void FailTest(string message)
        {

            GetInstance().GetExtentTest().Fail(message,
                    MediaEntityBuilder.CreateScreenCaptureFromBase64String(CaptureScreenshot()).Build());

        }

        public string CaptureScreenshot()
        {
            ITakesScreenshot ts = (ITakesScreenshot)DriverFactory.GetInstance().GetDriver();
            return ts.GetScreenshot().AsBase64EncodedString;

        }
    }
}
