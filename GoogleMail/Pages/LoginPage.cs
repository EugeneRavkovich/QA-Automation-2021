using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace GoogleMail.Pages
{
    /// <summary>
    /// A class that defines the login page entity
    /// </summary>
    public class LoginPage: BasePage
    {
        private readonly By _usernameFieldLocator = By.XPath("//input[@type='email']");

        private readonly By _confirmButtonLocator = By.XPath("//span[text()='Далее']");

        private readonly By _passwordFieldLocator = By.XPath("//input[@type='password']");

        private readonly string _driverTitle = "Gmail";

        private readonly By _incorrectUsernameMessageLocator = By.XPath("//div[text()[contains(., 'Не удалось')]]");

        private readonly By _emptyUsernameMessageLocator = By.XPath("//div[text()[contains(., 'Введите адрес')]]");

        private readonly By _incorrectPasswordMessageLocator = By.XPath("//span[contains(text(), 'Неверный')]");

        private readonly By _emptyPasswordMessageLocator = By.XPath("//span[text()[contains(., 'Введите пароль')]]");


        /// <summary>
        /// Constructor for initializing the class fields
        /// </summary>
        /// <param name="driver">The current state of the Selenium driver</param>
        public LoginPage(IWebDriver driver) : base(driver)
        {
            Wait.Until(ExpectedConditions.TitleContains(_driverTitle));
        }


        /// <summary>
        /// Method for entering the username for logging
        /// </summary>
        /// <param name="username"></param>
        /// <returns>Current page</returns>
        public LoginPage EnterUsername(string username)
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(_usernameFieldLocator));
            Driver.FindElement(_usernameFieldLocator).SendKeys(username);
            return this;
        }


        /// <summary>
        /// Method for confirming the entered username
        /// </summary>
        /// <returns>Current page</returns>
        public LoginPage ConfirmUsername()
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(_confirmButtonLocator));
            Driver.FindElement(_confirmButtonLocator).Click();
            return this;
        }


        /// <summary>
        /// Method for entering the password for logging
        /// </summary>
        /// <param name="password"></param>
        /// <returns>Current page</returns>
        public LoginPage EnterPassword(string password)
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(_passwordFieldLocator));
            Driver.FindElement(_passwordFieldLocator).SendKeys(password);
            return this;
        }


        /// <summary>
        /// Method for confirming the entered password
        /// </summary>
        /// <returns>The page to which it transfers after pressing the confirm button</returns>
        public InboxPage ConfirmPassword()
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(_confirmButtonLocator));
            Driver.FindElement(_confirmButtonLocator).Click();
            return new InboxPage(Driver);
        }


        /// <summary>
        /// Method that is waiting for a message about an incorrect entered username
        /// </summary>
        /// <returns>Is message shown or not</returns>
        public bool IsIncorrectUsernameMessageShown()
        {
            Wait.Until(ExpectedConditions.ElementExists(_incorrectUsernameMessageLocator));
            var incorrectUsernameMessage = Driver.FindElement(_incorrectUsernameMessageLocator);
            return incorrectUsernameMessage != null;
        }


        /// <summary>
        /// Method that is waiting for a message about an empty entered username
        /// </summary>
        /// <returns>Is message shown or not</returns>
        public bool IsEmptyUsernameMessageShown()
        {
            Wait.Until(ExpectedConditions.ElementExists(_emptyUsernameMessageLocator));
            var emptyUsernameMessage = Driver.FindElement(_emptyUsernameMessageLocator);
            return emptyUsernameMessage != null;
        }


        /// <summary>
        /// Method that is waiting for a message about an incorrect entered password
        /// </summary>
        /// <returns>Is message shown or not</returns>
        public bool IsIncorrectPasswordMessageShown()
        {
            Wait.Until(ExpectedConditions.ElementExists(_incorrectPasswordMessageLocator));
            var incorrectPasswordMessage = Driver.FindElement(_incorrectPasswordMessageLocator);
            return incorrectPasswordMessage != null;
        }


        /// <summary>
        /// Method that is waiting for a message about an empty entered password
        /// </summary>
        /// <returns>Is message shown or not</returns>
        public bool IsEmptyPasswordMessageShown()
        {
            Wait.Until(ExpectedConditions.ElementExists(_emptyPasswordMessageLocator));
            var emptyPasswordMessage = Driver.FindElement(_emptyPasswordMessageLocator);
            return emptyPasswordMessage != null;
        }
    }
}