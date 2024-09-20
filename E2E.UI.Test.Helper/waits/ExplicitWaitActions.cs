using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using E2E.UI.Test.Helper.driver;
using E2E.UI.Test.Helper.constants;
using E2E.UI.Test.Helper.reports;

namespace E2E.UI.Test.Helper.waits
{
    public class ExplicitWaitActions
    {
        public void WaitForElementToBePresent(By locator, string elementName)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(DriverFactory.GetInstance().GetDriver(),
                                        TimeSpan.FromSeconds(Constants.EXPLICIT_WAIT_TIME));
                wait.Until(ExpectedConditions.ElementIsVisible(locator));
            }
            catch (Exception e)
            {
                ExtentFactory.GetInstance().ClickFail("Exception occured while waiting for the eleement to be visible");
            }


        }

        public void WaitForElementToBeClickable(IWebElement element, string elementName)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(DriverFactory.GetInstance().GetDriver(),
                            TimeSpan.FromSeconds(Constants.EXPLICIT_WAIT_TIME));
                wait.Until(ExpectedConditions.ElementToBeClickable(element));
            }
            catch (Exception)
            {
                ExtentFactory.GetInstance().ClickFail("Exception occured while waiting for the element to be clickable");
            }


        }


    }
}
