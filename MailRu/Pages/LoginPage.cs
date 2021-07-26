using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace MailRu.Pages
{
    class LoginPage: BasePage
    {
        private readonly By _usernameFieldLocator = By.XPath("//input[@name='username']");

        private readonly By _confirmButtonLocator = By.XPath("//button[@type='submit']");

        private readonly By _passwordFieldLocator = By.XPath("//input[@name='password']");

        private readonly string _driverTitle = "Авторизация";

        private const string _baseUrl = "https://account.mail.ru/login";

        public LoginPage(IWebDriver driver) : base(driver)
        {
            Wait.Until(ExpectedConditions.TitleContains(_driverTitle));
        }

        public LoginPage OpenPage()
        {
            Driver.Navigate().GoToUrl(_baseUrl);
            return this;
        }

        public LoginPage EnterUsername(string username)
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(_usernameFieldLocator));
            Driver.FindElement(_usernameFieldLocator).SendKeys(username);
            return this;
        }

        public LoginPage ConfirmUsername()
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(_confirmButtonLocator));
            Driver.FindElement(_confirmButtonLocator).Click();
            return this;
        }


        public LoginPage EnterPassword(string password)
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(_passwordFieldLocator));
            Driver.FindElement(_passwordFieldLocator).SendKeys(password);
            return this;
        }

        public InboxPage ConfirmPassword()
        {
            Driver.FindElement(_confirmButtonLocator).Click();
            return new InboxPage(Driver);
        }
    }
}
