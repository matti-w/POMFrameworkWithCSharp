using E2E.UI.Test.Helper.testbase;
using E2E.UI.Test.pages;

namespace E2E.UI.Test.tests
{

    public class LoginPageTest : BaseTest
    {
        [Test]
        public void LoginWithValidUserNameAndValidPassword()
        {
            LoginPage loginPage = new LoginPage();
            loginPage.LoginToApplication("Admin",
                "admin123");

            Thread.Sleep(2000);
        }

        [Test]
        public void LoginWithInValidUserNameAndValidPassword()
        {
            LoginPage loginPage = new LoginPage();
            loginPage.LoginToApplication("Admin",
                "admin");
            Thread.Sleep(2000);
            Assert.IsTrue(false);


        }
    }
}
