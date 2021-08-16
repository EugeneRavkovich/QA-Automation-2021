using OpenQA.Selenium;
using MailFramework.Models;
using MailFramework.Wrappers;
using NLog;

namespace MailFramework.MailServices.MailRu.Pages
{
    /// <summary>
    /// A class that defines the login page entity
    /// </summary>
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


        /// <summary>
        /// Constructor for initializing the class fields
        /// </summary>
        /// <param name="driver">The current state of the Selenium driver</param>
        public LoginPage(IWebDriver driver) : base(driver)
        {
            Wait.Until(ExpectedConditionsWrapper.TitleContains(_driverTitle));
            _logger.Info("The login page is opened");
        }


        /// <summary>
        /// Method for entering the username for logging
        /// </summary>
        /// <param name="username"></param>
        /// <returns>Current page</returns>
        public LoginPage EnterUsername(string username)
        {
            UsernameField.SendKeys(username);
            return this;
        }


        /// <summary>
        /// Method for confirming the entered username
        /// </summary>
        /// <returns>Current page</returns>
        public LoginPage ConfirmUsername()
        {
            ConfirmButton.Click();
            return this;
        }


        /// <summary>
        /// Method for entering the password for logging
        /// </summary>
        /// <param name="password"></param>
        /// <returns>Current page</returns>
        public LoginPage EnterPassword(string password)
        {
            PasswordField.SendKeys(password);
            return this;
        }

        /// <summary>
        /// Method for confirming the entered password
        /// </summary>
        /// <returns>The page to which it transfers after pressing the confirm button</returns>
        public InboxPage ConfirmPassword()
        {
            ConfirmButton.Click();
            return new InboxPage(Driver);
        }
    }
}
