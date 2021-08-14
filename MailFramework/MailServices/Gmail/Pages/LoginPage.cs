using OpenQA.Selenium;
using MailFramework.Models;
using NLog;
using MailFramework.Wrappers;

namespace MailFramework.MailServices.Gmail.Pages
{
    public class LoginPage: BasePage
    {
        private IWebElement UsernameField =>
            Wait.Until(ExpectedConditionsWrapper.ElementIsVisible(
                By.XPath("//input[@type='email']")));

        private IWebElement ConfirmButton =>
            Wait.Until(ExpectedConditionsWrapper.ElementIsVisible(
                By.XPath("//span[text()='Далее']")));

        private IWebElement PasswordField =>
            Wait.Until(ExpectedConditionsWrapper.ElementIsVisible(
                By.XPath("//input[@type='password']")));

        private IWebElement IncorrectUsernameMessage =>
            Wait.Until(ExpectedConditionsWrapper.ElementIsVisible(
                By.XPath("//div[text()[contains(., 'Не удалось')]]")));

        private IWebElement EmptyUsernameMessage =>
            Wait.Until(ExpectedConditionsWrapper.ElementIsVisible(
                By.XPath("//div[text()[contains(., 'Введите адрес')]]")));

        private IWebElement IncorrectPasswordMessage =>
            Wait.Until(ExpectedConditionsWrapper.ElementIsVisible(
                By.XPath("//span[contains(text(), 'Неверный')]")));

        private IWebElement EmptyPasswordMessage =>
            Wait.Until(ExpectedConditionsWrapper.ElementIsVisible(
                By.XPath("//span[text()[contains(., 'Введите пароль')]]")));

        private readonly string _driverTitle = "Gmail";

        private readonly Logger _logger = LogManager.GetCurrentClassLogger();


        public LoginPage(IWebDriver driver) : base(driver)
        {
            Wait.Until(ExpectedConditionsWrapper.TitleContains(_driverTitle));
            _logger.Info("The login page is loaded");
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


        public bool IsIncorrectUsernameMessageShown()
        {
            return IncorrectUsernameMessage != null;
        }


        public bool IsEmptyUsernameMessageShown()
        {
            return EmptyUsernameMessage != null;
        }


        public bool IsIncorrectPasswordMessageShown()
        {
            return IncorrectPasswordMessage != null;
        }


        public bool IsEmptyPasswordMessageShown()
        {
            return EmptyPasswordMessage != null;
        }
    }
}
