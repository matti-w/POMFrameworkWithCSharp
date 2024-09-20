using E2E.UI.Test.Helper.reports;
using OpenQA.Selenium;

namespace E2E.UI.Test.Helper.driver
{
    public class DriverFactory
    {
        private ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();

        private static DriverFactory instance = new DriverFactory();

        public static DriverFactory GetInstance()
        {
            return instance;
        }

        public void SetDriver(IWebDriver driverObj)
        {
            driver.Value = driverObj;
        }

        public IWebDriver GetDriver()
        {
            return driver.Value;
        }

        // Dispose the WebDriver and clear the ThreadLocal storage
        public void DisposeDriver()
        {
            if (driver.Value != null)
            {
                try
                {
                    driver.Value.Quit();
                }
                catch (Exception ex)
                {
                    ExtentFactory.GetInstance().FailTest("Error quitting driver: {ex.Message}");
                }
                finally
                {
                    // Ensure the WebDriver instance is set to null
                    driver.Value = null;
                }
            }
        }
    }
}
