using AventStack.ExtentReports;
using E2E.UI.Test.Helper.constants;
using E2E.UI.Test.Helper.driver;
using E2E.UI.Test.Helper.reports;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

namespace E2E.UI.Test.Helper.testbase
{
    public class BaseTest
    {
        private ExtentReports extentReports;

        private ExtentTest extentTest;

        [OneTimeSetUp]
        public void TestStart()
        {
            extentReports = ExtentReportManager.SetUpExtentReport();
        }

        [OneTimeTearDown]
        public void TestFinish()
        {
            extentReports.Flush();
        }

        [SetUp]
        public void SetUP()
        {
            extentTest = extentReports.CreateTest(TestContext.CurrentContext.Test.Name);
            ExtentFactory.GetInstance().SetExtent(extentTest);
            ExtentFactory.GetInstance().GetExtentTest();

            IWebDriver driver = BrowserFactory.CreateRemoteBrowserInstance("Chrome");
            DriverFactory.GetInstance().SetDriver(driver);
            DriverFactory.GetInstance().GetDriver().Manage().Cookies.DeleteAllCookies();
            DriverFactory.GetInstance().GetDriver().Manage().Window.Maximize();
            DriverFactory.GetInstance().GetDriver().Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(Constants.PageLoadTimeOut);
            DriverFactory.GetInstance().GetDriver()
                        .Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Constants.IMPLICIT_WAIT_TIME);
            DriverFactory.GetInstance().GetDriver().Url = "https://opensource-demo.orangehrmlive.com/web/index.php/auth/login";
            // DriverFactory.GetInstance().GetDriver().Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");

        }

        [TearDown]
        public void TearDown()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = TestContext.CurrentContext.Result.StackTrace;
            var testName = TestContext.CurrentContext.Test.Name;
            switch (status)
            {
                case TestStatus.Failed:
                    ExtentFactory.GetInstance().GetExtentTest().Fail("Exception details: " + stackTrace);
                    break;
                case TestStatus.Passed:
                    ExtentFactory.GetInstance().PassTest(testName);
                    break;
                case TestStatus.Skipped:
                    ExtentFactory.GetInstance().GetExtentTest().Log(Status.Skip, $"{testName} is skipped");
                    break;
            }

            DriverFactory.GetInstance().DisposeDriver();
        }
    }
}
