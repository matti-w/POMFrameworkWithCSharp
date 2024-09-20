using E2E.UI.Test.Helper.driver;
using E2E.UI.Test.Helper.reports;
using OpenQA.Selenium;

namespace E2E.UI.Test.Helper.alert
{
    public class AlertActions
    {
        private IAlert alert;
        public void SwithcToAlert()
        {
            try
            {
                alert = DriverFactory.GetInstance().GetDriver().SwitchTo().Alert();
                ExtentFactory.GetInstance().PassTest("Swicthed to Alert");
            }
            catch (NoAlertPresentException e)
            {
                ExtentFactory.GetInstance().FailTest("Exception occured while swicthing to alert.");
            }
            
        }

        public void AcceptAlert()
        {
            try
            {
                this.alert.Accept();
                ExtentFactory.GetInstance().PassTest("Clicked on OK button");
            }
            catch (Exception e)
            {
                ExtentFactory.GetInstance().FailTest("Exception occured while clicking On OK button.");
            }
            
        }

        public void CancelAlert()
        {
            try
            {
                this.alert.Dismiss();
                ExtentFactory.GetInstance().PassTest("Clicked on cancel button");
            }
            catch (Exception e)
            {
                ExtentFactory.GetInstance().FailTest("Exception occured while clicking On cancel button.");
            } 
        }
    }
}
