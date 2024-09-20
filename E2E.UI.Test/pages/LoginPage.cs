using E2E.UI.Test.Helper.testbase;
using OpenQA.Selenium;

namespace E2E.UI.Test.pages
{
    public class LoginPage : BasePage
    {
        private By userNameTextBox = By.Name("username");
        private By passwordTExtBox = By.Name("password");
        private By loginBtn = By.XPath("//button[@type='submit']");

        public void LoginToApplication(string userNameValue, string passwordValue)
        {
            Sendkeys(userNameTextBox, "Username text box", userNameValue);
            Sendkeys(passwordTExtBox, "Password text box", passwordValue);
            Click(loginBtn, "Login button");

	    }
    }
}
