using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using WebDriverManager.DriverConfigs.Impl;

namespace E2E.UI.Test.Helper.driver
{
    public class BrowserFactory
    {
        public static IWebDriver CreateBrowserInstance(string browserName)
        {
            IWebDriver driver = null;
            switch (browserName.ToLower())
            {
                case "firefox":
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver = new FirefoxDriver();
                    break;

                case "chrome":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new ChromeDriver();
                    break;

                case "edge":
                    new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                    driver = new EdgeDriver();
                    break;
            }
            return driver;
        }

        public static IWebDriver CreateRemoteBrowserInstance(string browserName)
        {
            // Define the remote server URL (Selenium Grid Hub URL)
            string gridUrl = "http://localhost:4444/wd/hub";
            IWebDriver driver = null;
            switch (browserName.ToLower())
            {
                case "firefox":
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver = new FirefoxDriver();
                    break;

                case "chrome":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    var options = new ChromeOptions();
                    // options.AddArgument("--headless");
                    driver = new RemoteWebDriver(new Uri(gridUrl), options.ToCapabilities()); ;
                    break;

                case "edge":
                    new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                    driver = new EdgeDriver();
                    break;
            }
            return driver;
        }
    }
}
