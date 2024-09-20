using E2E.UI.Test.Helper.alert;
using E2E.UI.Test.Helper.driver;
using E2E.UI.Test.Helper.javascript;
using E2E.UI.Test.Helper.Logger;
using E2E.UI.Test.Helper.reports;
using E2E.UI.Test.Helper.waits;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace E2E.UI.Test.Helper.testbase
{
    public class BasePage
    {
        protected AlertActions alertActions;
        protected JavaScriptActions javaScriptActions;
        protected ExplicitWaitActions explicitWaitActions;

        public BasePage()
        {
            this.alertActions = new AlertActions();
            this.javaScriptActions = new JavaScriptActions();
            this.explicitWaitActions = new ExplicitWaitActions();
        }

        public void Click(By locator, string elementName)
        {
            var button = GetElement(locator);
            this.explicitWaitActions.WaitForElementToBeClickable(button, elementName);
            button.Click();
            Log.Info(elementName + " is clicked.");
            ExtentFactory.GetInstance().PassTest(elementName + " is clicked.");
        }

        public void Sendkeys(By locator, string elementName, string value)
        {
            this.explicitWaitActions.WaitForElementToBePresent(locator, elementName);
            var element = GetElement(locator);
            element.Clear();
            element.SendKeys(value);
            Log.Info(value + " is entered in " + elementName);
            ExtentFactory.GetInstance().PassTest(value + " is entered in " + elementName);
        }

        public IWebElement GetElement(By locator)
        {
            return DriverFactory.GetInstance().GetDriver().FindElement(locator);
        }

        public List<IWebElement> GetElements(By locator)
        {
            return DriverFactory.GetInstance().GetDriver().FindElements(locator).ToList();
        }

        public string GetText(By locator)
        {
            return GetElement(locator).Text;
        }

        public bool IsElementDisplayed(By locator, int expectedElementCount)
        {
            var count = GetElements(locator).Count();
            if (count == expectedElementCount)
            {
                return true;
            }
            return false;
        }

        public bool IsElementDisplayed(By locator)
        {
            var count = GetElements(locator).Count();
            if (count == 1)
            {
                return true;
            }
            return false;
        }

        public bool IsElementSelected(By locator, string elementName)
        {
            this.explicitWaitActions.WaitForElementToBePresent(locator, elementName);
            return GetElement(locator).Selected;
        }

        public void SelectCheckBox(By locator, string elementName)
        {
            if (this.IsElementSelected(locator, elementName) == false)
            {
                this.Click(locator, elementName);
            }
            else
            {
                ExtentFactory.GetInstance().FailTest(elementName + " is already selected");
            }
        }

        public void SelectByIndex(By locator, int index)
        {
            SelectElement select = new SelectElement(GetElement(locator));
            select.SelectByIndex(index);
        }

        public void SelectByVisbleText(By locator, string visibleText)
        {
            SelectElement select = new SelectElement(GetElement(locator));
            select.SelectByText(visibleText);
        }

        public void doSelectByValue(By locator, string value)
        {
            SelectElement select = new SelectElement(GetElement(locator));
            select.SelectByValue(value);
        }

        public int GetDropDownOptionsCount(By locator)
        {
            SelectElement select = new SelectElement(GetElement(locator));
            return select.Options.Count;

        }

        public List<string> GetDropDownOptionsTextList(By locator)
        {
            SelectElement select = new SelectElement(GetElement(locator));

            List<IWebElement> optionsList = select.Options.ToList();
            List<string> optionsTextList = new List<string>();

            foreach (IWebElement e in optionsList)
            {
                string text = e.Text;
                optionsTextList.Add(text);
            }

            return optionsTextList;
        }

        public void HandleParentSubMenu(By parentLocator, By childLocator, string elementName)
        {
            Actions act = new Actions(DriverFactory.GetInstance().GetDriver());
            act.MoveToElement(GetElement(parentLocator)).Perform();

		    Click(childLocator, elementName);
        }


        public void SwitchToChildWindow()
        {
            string parentWindowHandle = DriverFactory.GetInstance().GetDriver().CurrentWindowHandle;
            List<string> windowHandles = DriverFactory.GetInstance().GetDriver().WindowHandles.ToList();

            foreach (string windowHandle in windowHandles)
            {
                if(windowHandle != parentWindowHandle)
                {
                    DriverFactory.GetInstance().GetDriver().SwitchTo().Window(windowHandle);
                    break;
                }
            }
        }
    }
}
