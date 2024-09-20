using E2E.UI.Test.Helper.driver;
using E2E.UI.Test.Helper.reports;
using OpenQA.Selenium;

namespace E2E.UI.Test.Helper.javascript
{
    public class JavaScriptActions
    {
        public void Click(IWebElement element)
        {
            try
            {
                var js = (IJavaScriptExecutor)DriverFactory.GetInstance().GetDriver();
                js.ExecuteScript("arguments[0].click()", element);
                ExtentFactory.GetInstance().PassTest("Element is clicked using Javascript");
            }
            catch (Exception e)
            {
                ExtentFactory.GetInstance().FailTest("Exception occured while clicking on element using JS");
            }

        }

        public void SendKeys(IWebElement element, string value)
        {
            try
            {
                var js = (IJavaScriptExecutor)DriverFactory.GetInstance().GetDriver();
                js.ExecuteScript("arguments[0].value=" + "'" + value + "'", element);
                ExtentFactory.GetInstance().PassTest(value + " is entered");
            }
            catch (Exception e)
            {
                ExtentFactory.GetInstance().FailTest("Exception occured while entering value using JS");
            }

        }

        public void ScrollPageToViewElement(IWebElement element)
        {
            try
            {
                var js = (IJavaScriptExecutor)DriverFactory.GetInstance().GetDriver();
                js.ExecuteScript("arguments[0].scrollIntoView(true)", element);
                ExtentFactory.GetInstance().PassTest("Element is visible on Screen");
            }
            catch (Exception e)
            {
                ExtentFactory.GetInstance().FailTest("Exception occured while scrolling the page ");
            }
        }

        public void ScrollTillEndOfPage()
        {
            try
            {
                var js = (IJavaScriptExecutor)DriverFactory.GetInstance().GetDriver();
                js.ExecuteScript("window.scrollTo(0 , document.body.scrollHeight)");
                ExtentFactory.GetInstance().PassTest("Page is scrolled till end");
            }
            catch (Exception e)
            {
                ExtentFactory.GetInstance().FailTest("Exception occured while scrolling the page till end ");
            }

        }
    }
}
