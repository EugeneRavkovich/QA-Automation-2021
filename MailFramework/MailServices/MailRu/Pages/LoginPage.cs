using OpenQA.Selenium;
using MailFramework.Models;
using MailFramework.Wrappers;
using NLog;

namespace MailFramework.MailServices.MailRu.Pages
{
    public class LoginPage: BasePage
    {
        private IWebElement UsernameField =>
            Wait.Until(ExpectedConditionsWrapper.ElementIsVisible(
                By.XPath("//input[@name='username']")));

        private IWebElement ConfirmButton =>
            Wait.Until(ExpectedConditionsWrapper.ElementIsVisible(
                By.XPath("//button[@type='submit']")));

        private IWebElement PasswordField =>
            Wait.Until(ExpectedConditionsWrapper.ElementIsVisible(
                By.XPath("//input[@name='password']")));

        private readonly string _driverTitle = "Авторизация";

        private readonly Logger _logger = LogManager.GetCurrentClassLogger();


        public LoginPage(IWebDriver driver) : base(driver)
        {
            Wait.Until(ExpectedConditionsWrapper.TitleContains(_driverTitle));
            _logger.Info("The login page is opened");
        }


        public LoginPage EnterUsername(string username)
        {
            UsernameField.SendKeys(username);
            return this;
        }


        public LoginPage ConfirmUsername()
        {
            ConfirmButton.Click();
            return this;
        }


        public LoginPage EnterPassword(string password)
        {
            PasswordField.SendKeys(password);
            return this;
        }


        public InboxPage ConfirmPassword()
        {
            ConfirmButton.Click();
            return new InboxPage(Driver);
        }
    }
}
