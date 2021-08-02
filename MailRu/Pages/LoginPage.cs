using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MailRu.Pages
{
    /// <summary>
    /// A class that defines the login page entity
    /// </summary>
    class LoginPage : BasePage
    {
        private readonly By _usernameFieldLocator = By.XPath("//input[@name='username']");

        private readonly By _confirmButtonLocator = By.XPath("//button[@type='submit']");

        private readonly By _passwordFieldLocator = By.XPath("//input[@name='password']");

        private readonly string _driverTitle = "Авторизация";

        private const string _baseUrl = "https://account.mail.ru/login";


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
            Driver.FindElement(_confirmButtonLocator).Click();
            return new InboxPage(Driver);
        }
    }
}