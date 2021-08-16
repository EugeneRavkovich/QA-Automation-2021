using OpenQA.Selenium;
using MailFramework.Models;
using NLog;
using MailFramework.Wrappers;

namespace MailFramework.MailServices.Gmail.Pages
{
    /// <summary>
    /// A class that defines the login page entity
    /// </summary>
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


        /// <summary>
        /// Constructor for initializing the class fields
        /// </summary>
        /// <param name="driver">The current state of the Selenium driver</param>
        public LoginPage(IWebDriver driver) : base(driver)
        {
            Wait.Until(ExpectedConditionsWrapper.TitleContains(_driverTitle));
            _logger.Info("The login page is loaded");
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


        /// <summary>
        /// Method that is waiting for a message about an incorrect entered username
        /// </summary>
        /// <returns>Is message shown or not</returns>
        public bool IsIncorrectUsernameMessageShown()
        {
            return IncorrectUsernameMessage != null;
        }


        /// <summary>
        /// Method that is waiting for a message about an empty entered username
        /// </summary>
        /// <returns>Is message shown or not</returns>
        public bool IsEmptyUsernameMessageShown()
        {
            return EmptyUsernameMessage != null;
        }


        /// <summary>
        /// Method that is waiting for a message about an incorrect entered password
        /// </summary>
        /// <returns>Is message shown or not</returns>
        public bool IsIncorrectPasswordMessageShown()
        {
            return IncorrectPasswordMessage != null;
        }


        /// <summary>
        /// Method that is waiting for a message about an empty entered password
        /// </summary>
        /// <returns>Is message shown or not</returns>
        public bool IsEmptyPasswordMessageShown()
        {
            return EmptyPasswordMessage != null;
        }
    }
}
