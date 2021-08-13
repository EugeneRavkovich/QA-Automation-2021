using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NLog;

namespace MailFramework.MailServices.MailRu.Pages
{
    public class LoginPage: BasePage
    {
        private readonly By _usernameFieldLocator = By.XPath("//input[@name='username']");

        private readonly By _confirmButtonLocator = By.XPath("//button[@type='submit']");

        private readonly By _passwordFieldLocator = By.XPath("//input[@name='password']");

        private readonly string _driverTitle = "Авторизация";

        private readonly Logger _logger = LogManager.GetCurrentClassLogger();


        public LoginPage(IWebDriver driver) : base(driver)
        {
            Wait.Until(ExpectedConditions.TitleContains(_driverTitle));
            _logger.Info("The login page is opened");
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
