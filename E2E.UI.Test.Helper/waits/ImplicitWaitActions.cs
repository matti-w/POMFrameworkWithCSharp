using E2E.UI.Test.Helper.constants;
using E2E.UI.Test.Helper.driver;

namespace E2E.UI.Test.Helper.waits
{
    public class ImplicitWaitActions
    {
        public void SetImplicitWait()
        {
            DriverFactory.GetInstance().GetDriver()
                .Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Constants.IMPLICIT_WAIT_TIME);

        }
    }
}
